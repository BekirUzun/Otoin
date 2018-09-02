using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Octokit;
using Microsoft.Win32.TaskScheduler;
using System.Runtime.InteropServices;
using System.Linq;

namespace Otoin {
    public partial class Otoin : Form {

        #region Fields
        List<string> programPaths;
        List<Process> processes;
        List<PerformanceCounter> networksPC;
        bool isFirstRun, isProcStarted, isServiceStarted, isHourChanged, isManualDelete;
        bool allowSleep, sleepMode, taskEnabled, wakeLockEnabled, rtcWakeEnabled;
        bool logicalChange, stopIfNoNet, checkUpdates;
        DateTime startTime, stopTime;
        Timer service;
        int checkCount, totalUsage, noNetActivityCount, stopActionIndex, noNetMaxMinute;
        string programFiles32, programFiles64;
        Guid scheme;
        #endregion

        #region Constants
        private static readonly Guid CONSOLELOCK = new Guid("0e796bdb-100d-47d6-a2d5-f7d2daa51f51");
        private static readonly Guid SUB_NONE = new Guid("fea3413e-7e05-4911-9a71-700331f1c294");
        private static readonly Guid RTCWAKE = new Guid("bd3b718a-0680-4d9d-8ab2-e1d2b4ac806d");
        private static readonly Guid SUB_SLEEP = new Guid("238C9FA8-0AAD-41ED-83F4-97BE242C8F20");
        #endregion

        #region Structs
        [StructLayout(LayoutKind.Sequential)]
        public class GuidClass {
            public Guid Value;
        }
        #endregion

        #region External functions
        [DllImport("powrprof.dll")]
        public static extern UInt32 PowerGetActiveScheme(
            IntPtr UserRootPowerKey,
            ref IntPtr ActivePolicyGuid
        );

        [DllImport("powrprof.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 PowerReadACValueIndex(
            IntPtr RootPowerKey,
            ref Guid SchemeGuid,
            ref Guid SubGroupOfPowerSettingsGuid,
            ref Guid PowerSettingGuid,
            ref UInt32 AcValueIndex
        );

        [DllImport("powrprof.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 PowerReadDCValueIndex(
            IntPtr RootPowerKey, ref Guid SchemeGuid,
            ref Guid SubGroupOfPowerSettingsGuid,
            ref Guid PowerSettingGuid,
            ref UInt32 AcValueIndex
        );
        /// <summary>
        /// [KULLANIMDAN KALDIRILDI]
        /// </summary>
        [DllImport("powrprof.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 PowerWriteACValueIndex(
            IntPtr RootPowerKey,
            ref Guid SchemeGuid,
            ref Guid SubGroupOfPowerSettingsGuid,
            ref Guid PowerSettingGuid,
            UInt32 AcValueIndex
        );

        /// <summary>
        /// [KULLANIMDAN KALDIRILDI]
        /// </summary>
        [DllImport("powrprof.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 PowerWriteDCValueIndex(
            IntPtr RootPowerKey,
            ref Guid SchemeGuid,
            ref Guid SubGroupOfPowerSettingsGuid,
            ref Guid PowerSettingGuid,
            UInt32 DcValueIndex
        );
        #endregion

        public Otoin() {
            RetrieveSettings(); //programı yeni başlatıyoruz, ayarları dosyadan alalım
            InitializeComponent();

            this.Icon = Properties.Resources.icon;
            notifyIcon.Icon = Properties.Resources.icon;
            aboutVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            programFiles64 = Environment.ExpandEnvironmentVariables("%ProgramW6432%");
            programFiles32 = Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%");

            networksPC = new List<PerformanceCounter>();
            PerformanceCounterCategory category = new PerformanceCounterCategory("Network Interface");
            string[] networkNames = category.GetInstanceNames();
            for (int i = 0; i < networkNames.Length; i++) {
                networksPC.Add(new PerformanceCounter("Network Interface", "Bytes Received/sec", networkNames[i]));
            }
            noNetActivityCount = 0;
            totalUsage = 0;

            if (programPaths.Count > 0) {
                bool valid = true;
                for (int i = 0; i < programPaths.Count; i++) {
                    if (!File.Exists(programPaths[i])) {
                        isManualDelete = false; //
                        programPaths.RemoveAt(i);
                        valid = false;
                    }
                }

                if (valid)
                    Log("Seçtiğiniz programların konumu başarılı bir şekilde doğrulandı :)", "success", false);
                else
                    Log("Seçtiğiniz programların konumu doğrularken bir hata oluştu :(", "error", true);

                // doğrulama yaparken programPaths.Count değişmiş olabilir
                if (valid || programPaths.Count > 0) {
                    foreach (string programPath in programPaths) {
                        programsList.Rows.Add(Path.GetFileName(programPath), programPath);
                    }
                    EnableButton(actionButton);
                }

            }
            else {
                Log("\"Açılacak Programlar\" sekmesinden en az bir program ekleyiniz.", "info", false);
            }

            if (isFirstRun) {
                findProgramsBtn_Click(new object(), new EventArgs());
                isFirstRun = false;
            }

            string temp_hour = (startTime.Hour < 10) ? "0" + startTime.Hour : "" + startTime.Hour;
            string temp_min = (startTime.Minute < 10) ? "0" + startTime.Minute : "" + startTime.Minute;
            startTB.Text = temp_hour + ":" + temp_min;

            temp_hour = (stopTime.Hour < 10) ? "0" + stopTime.Hour : "" + stopTime.Hour;
            temp_min = (stopTime.Minute < 10) ? "0" + stopTime.Minute : "" + stopTime.Minute;
            stopTB.Text = temp_hour + ":" + temp_min;

            stopAction.SelectedIndex = stopActionIndex;

            bool consoleLockAC = (GetACValue(scheme, SUB_NONE, CONSOLELOCK) == 1) ? true : false;
            bool consoleLockDC = (GetDCValue(scheme, SUB_NONE, CONSOLELOCK) == 1) ? true : false;
            bool rtcWakeAC = (GetACValue(scheme, SUB_SLEEP, RTCWAKE) == 1) ? true : false;
            bool rtcWakeDC = (GetDCValue(scheme, SUB_SLEEP, RTCWAKE) == 1) ? true : false;

            if (consoleLockAC || consoleLockDC || !rtcWakeAC) {
                allowSleep = false;
                modeSleep.Enabled = false;
                modeSleep.Font = new Font("Segoe UI", 10F, FontStyle.Strikeout);
                sleepDisabled.Visible = true;
            }
            else {
                allowSleep = true;
            }

            if (sleepMode && allowSleep) {
                logicalChange = true;
                modeSleep.Checked = true;
            }
            else {
                //uyandırma görevi Durdur butonuna basılınca siliniyor ama ne olur ne olmaz
                // kimsenin bilgisayarını gece gereksiz uyandırmadığımızdan emin olalım :)
                DeleteTask();
            }

            noNetToggle.Checked = stopIfNoNet;
            noNetTimeTB.Enabled = stopIfNoNet;
            noNetTimeTB.Visible = stopIfNoNet;
            noNetLabel.Visible = stopIfNoNet;
            noNetBG.Visible = stopIfNoNet;
            noNetTimeTB.Text = noNetMaxMinute.ToString();

            service = new Timer();
            service.Tick += new EventHandler(Check);
            service.Interval = 20000; // 20 saniyede bir kontrol etsin

            processes = new List<Process>();
            isManualDelete = true; // kullanıcının el ile sildiği programlar için

            if (checkUpdates) {
                // kullanıcı daha önceden "Asla" butonuna basmadı. Asenkron güncelleme kontrolü yapacağız
                CheckUpdate();
            }

        }

        /// <summary>
        /// Kullanıcı program seçmek istediğinde çağırılır. İstediği programı seçmesi için bir pencere açar
        /// </summary>
        private void filePromptButton_Click(object sender, EventArgs e) {
            // kullanıcı program seçmek istiyor.
            programPrompt.Filter = "Program (*.exe)|*.exe";
            programPrompt.ShowDialog();
        }

        /// <summary>
        /// Açılış ve kapanış saatlerinin kutularında bir tuşa basıldığında çağırılır. 
        /// Karakter doğrulaması için kullanılır.
        /// </summary>
        private void timeTB_KeyPress(object sender, KeyPressEventArgs e) {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9^:^\b]")) {
                Log("Geçersiz karakter :(", "error", false);
                e.Handled = true;
            }
            else if (message.Text == "Geçersiz karakter :(") {
                message.Visible = false;
                isHourChanged = true;
            }
            else {
                isHourChanged = true;
            }
        }

        private void findProgramsBtn_Click(object sender, EventArgs e) {
            string[] defaultProgramPaths = {
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\uTorrent\\uTorrent.exe",
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BitTorrent\\BitTorrent.exe",
                programFiles64 + "\\Vuze\\Azureus.exe",
                programFiles32 + "\\Vuze\\Azureus.exe",
                programFiles64 + "\\Transmission\\transmission-qt.exe",
                programFiles32 + "\\Transmission\\transmission-qt.exe",
                programFiles64 + "\\Deluge\\deluge.exe",
                programFiles32 + "\\Deluge\\deluge.exe",
                programFiles64 + "\\qBittorrent\\qbittorrent.exe",
                programFiles32 + "\\qBittorrent\\qbittorrent.exe",
                programFiles64 + "\\Steam\\Steam.exe",
                programFiles32 + "\\Steam\\Steam.exe",
            };
            int foundPrograms = 0;
            for (int i = 0; i < defaultProgramPaths.Length; i++) {
                if (File.Exists(defaultProgramPaths[i])) {
                    if (!programPaths.Contains(defaultProgramPaths[i])) {
                        foundPrograms++;
                        programPaths.Add(defaultProgramPaths[i]);
                        programsList.Rows.Add(Path.GetFileName(defaultProgramPaths[i]), defaultProgramPaths[i]);
                    }
                }
            }
            if (foundPrograms > 0) {
                Log(foundPrograms + " program bulundu.", "success", false);
                EnableButton(actionButton); //kapalı olan butonları aktifleştirelim
                SaveSettings();
            }
            else {
                Log("Herhangi bir program bulunamadı. Manuel ekleyiniz.", "error", false);
            }
        }

        /// <summary>
        /// Kullanıcı açılan pencereden program seçtikten sonra çalışır
        /// </summary>
        private void openFileDialog_FileOk(object sender, CancelEventArgs e) {
            if (!programPrompt.CheckFileExists) {
                // FileOk dan sonra bunu kontrol etmeye gerek olmayabilir ama işimizi garantiye alalım.
                Log("Program seçilirken bir hata oluştu :(", "error", true);
                return;
            }
            programPaths.Add(programPrompt.FileName);
            programsList.Rows.Add(programPrompt.SafeFileName, programPrompt.FileName);

            Log("Program başarılı bir şekilde seçildi!", "success", false);
            EnableButton(actionButton); //kapalı olan butonları aktifleştirelim
            SaveSettings();
        }

        /// <summary>
        /// Program listesinden bir satır silindiğinde çalışır
        /// </summary>
        private void programsList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e) {
            if (isManualDelete) {
                //bu kısım sadece kullanıcı el ile bir program sildiğide çalışır
                // program içi silmelerde çalışmaz
                programPaths.RemoveAt(e.RowIndex); // satır sıralaması listeyle aynı (umarım)
            }
            else {
                isManualDelete = true; //eski haline çevirelim
            }

            if (programPaths.Count == 0) {
                DisableButton(actionButton);
            }

            SaveSettings();
        }

        private void hideButton_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void startButton_Click(object sender, EventArgs e) {
            if (!ValidateTimeInputs())
                return;// geçersiz saat formatı, fonksiyonu bitirelim

            SaveSettings();

            if (isServiceStarted) {
                StopService();
                return;
            }
            StartService();
        }

        /// <summary>
        /// Program penceresi küçültüldüğünde çalışır. Programı görev çubuğu yerine
        /// sistem tepsisine küçültmek için kullanılır.
        /// </summary>
        private void skin_Resize(object sender, EventArgs e) {
            if (FormWindowState.Minimized == this.WindowState) {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState) {
                notifyIcon.Visible = false;
            }
        }

        private void notifyIcon_Click(object sender, EventArgs e) {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
        }

        private void close_Click(object sender, EventArgs e) {
            SaveSettings();
        }

        private void helpSettings_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/BekirUzun/Otoin/blob/master/HELP.md#ayarlar");
        }

        /// <summary>
        /// Kapatma eylemi değiştiğinde çağırılır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopAction_SelectedIndexChanged(object sender, EventArgs e) {
            stopActionIndex = stopAction.SelectedIndex;
        }

        private void helpPrograms_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/BekirUzun/Otoin/blob/master/HELP.md#a%C3%A7%C4%B1lacak-programlar");
        }

        /// <summary>
        /// Verilen mesajı kullanıcıya bildirim olarak gösterir. 'writeToFile' true ise dosyaya da kaydeder.
        /// </summary>
        /// <param name="message">Gösterilecek mesaj</param>
        /// <param name="b">Mesaj tipi ('error', 'success', 'info')</param>
        /// <param name="writeToFile">Mesajın dosyaya yazılık yazılmayacağını belirleyen boolean</param>
        private void Log(string message, string kind, bool writeToFile) {
            if (string.Equals(kind, "success", StringComparison.CurrentCultureIgnoreCase))
                this.message.kind = FlatUI.FlatAlertBox._Kind.Success;
            else if (string.Equals(kind, "error", StringComparison.CurrentCultureIgnoreCase))
                this.message.kind = FlatUI.FlatAlertBox._Kind.Error;
            else if (string.Equals(kind, "info", StringComparison.CurrentCultureIgnoreCase))
                this.message.kind = FlatUI.FlatAlertBox._Kind.Info;
            this.message.Text = message;
            this.message.Visible = true;

            if (writeToFile) {
                string logLine = "[" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "][" + kind + "]" + message + "\r\n";
                if (!File.Exists("events.log")) {
                    var f = File.Create("events.log");
                    f.Close();
                }
                File.AppendAllText("events.log", logLine);
            }
        }

        /// <summary>
        /// Uygulama içinde kullanılacak ayarları ayarlar dosyasında uygulamaya aktarır. 
        /// Uygulama başlatıldığında çalışır.
        /// </summary>
        private void RetrieveSettings() {
            programPaths = new List<string>();
            startTime = Properties.Settings.Default.startTime;
            stopTime = Properties.Settings.Default.stopTime;
            isFirstRun = Properties.Settings.Default.isFirstRun;
            stopActionIndex = Properties.Settings.Default.stopAction;
            checkUpdates = Properties.Settings.Default.updateCheck;
            sleepMode = Properties.Settings.Default.sleepMode;
            stopIfNoNet = Properties.Settings.Default.stopIfNoNet;
            noNetMaxMinute = Properties.Settings.Default.noNetMaxMinute;
            taskEnabled = Properties.Settings.Default.taskEnabled;
            scheme = GetActiveSchemeGuid();
            wakeLockEnabled = (GetACValue(scheme, SUB_NONE, CONSOLELOCK) == 1) ? true : false;
            rtcWakeEnabled = (GetACValue(scheme, SUB_SLEEP, RTCWAKE) == 1) ? true : false;
            if (!isFirstRun) {
                if (Properties.Settings.Default.targetAppLocs.Length > 0) {
                    string[] tempPaths = Properties.Settings.Default.targetAppLocs.Split(';');
                    foreach (string tempPath in tempPaths) {
                        programPaths.Add(tempPath);
                    }
                }
            }
        }

        /// <summary>
        /// Verilen mesajı kullanıcıya bildirim olarak gösterir. 'writeToFile' true ise dosyaya da kaydeder.
        /// </summary>
        private void SaveSettings() {
            if (programPaths.Count > 0) {
                bool valid = true;
                string programPathsString = "";
                for (int i = 0; i < programPaths.Count; i++) {
                    if (!File.Exists(programPaths[i])) {
                        isManualDelete = false; //
                        programPaths.RemoveAt(i);
                        programsList.Rows.RemoveAt(i--);
                        valid = false;
                    }
                    else {
                        if (programPathsString == "")
                            programPathsString = programPaths[i];
                        else
                            programPathsString += ";" + programPaths[i];
                    }
                }
                Properties.Settings.Default.targetAppLocs = programPathsString;

                if (!valid) {
                    Log("Seçtiğiniz programların konumu doğrularken bir hata oluştu. :(", "error", true);
                }
            }
            else {
                Properties.Settings.Default.targetAppLocs = "";
            }
            ValidateTimeInputs();

            Properties.Settings.Default.isFirstRun = isFirstRun;
            Properties.Settings.Default.startTime = startTime;
            Properties.Settings.Default.stopTime = stopTime;
            Properties.Settings.Default.stopAction = stopActionIndex;
            Properties.Settings.Default.updateCheck = checkUpdates;
            Properties.Settings.Default.sleepMode = sleepMode;
            Properties.Settings.Default.stopIfNoNet = stopIfNoNet;
            Properties.Settings.Default.noNetMaxMinute = noNetMaxMinute;
            Properties.Settings.Default.taskEnabled = taskEnabled;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Saat kontrolü servisini başlatır. İsim yanıltmasın herhangi bir gerçek servis kullanmaz.
        /// 'Başlat' butonu ile çağırılır.
        /// </summary>
        private void StartService() {
            SaveSettings();
            service.Start();
            checkCount = 0;
            isServiceStarted = true;
            actionButton.Text = "Durdur";
            actionButton.BackColor = Color.FromArgb(255, 168, 35, 35);
            EnableButton(hideButton);
            if (sleepMode) {
                EnableButton(sleepButton);
                CreateTask();
            }
            Log("Servis başarılı bir şekilde başlatıldı.", "success", true);

        }

        private void rightClickMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            if (e.ClickedItem.Text == "Sil") {
                var rowsToDelete = programsList.SelectedRows;
                foreach (DataGridViewRow row in rowsToDelete) {
                    programsList.Rows.Remove(row);
                }
            }
        }

        private void programsList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {

            MouseEventArgs click = (MouseEventArgs)e;
            if (click.Button == MouseButtons.Right) {
                if (!programsList.Rows[e.RowIndex].Selected) {
                    //sağ tıklanılan satır seçilmemişse sadece o satırı seçelim
                    foreach (DataGridViewRow row in programsList.SelectedRows) {
                        row.Selected = false;
                    }
                    programsList.Rows[e.RowIndex].Selected = true;
                }
                //sağ tıklanılan satır seçilmişse seçimleri değiştirmeyelim.
                // birden çok satır seçilip sağ tıklanırsa önceki seçimlerin
                // kaybolmaması için.
            }
        }

        private void sleepButton_Click(object sender, EventArgs e) {
            //bilgisayarı uyku moduna alalım
            System.Windows.Forms.Application.SetSuspendState(PowerState.Suspend, false, false);
        }

        /// <summary>
        /// Saat kontrolü servisini durdurur.
        /// </summary>
        private void StopService() {
            service.Stop();
            isServiceStarted = false;

            if (sleepMode) {
                DisableButton(sleepButton);
                DeleteTask();
            }

            actionButton.Text = "Başlat!";
            actionButton.BackColor = Color.FromArgb(255, 35, 91, 168);
            DisableButton(hideButton);
            float usageDisplay;
            string usageUnit;
            if (totalUsage > 1024 && totalUsage < 1024 * 1024) {
                //toplam indirmeyi mb cinsinden göstereceğiz
                usageDisplay = (float)totalUsage / 1024;
                usageUnit = " MB";
            }
            else if (totalUsage > 1024 * 1024) {
                //toplam indirmeyi gb cinsinden göstereceğiz
                usageDisplay = ((float)totalUsage / 1024) / 1024;
                usageUnit = " GB";
            }
            else {
                //toplamı kb cinsinden göstereceğiz.
                usageDisplay = totalUsage;
                usageUnit = " KB";
            }
            Log("Servis durduruldu. Yapılan toplam indirme " + usageDisplay.ToString("0.00") + usageUnit, "success", true);
        }

        /// <summary>
        /// Açılış ve kapanış saatlerinin formatını doğrular. Saatler ss:dd (hh:mm) formatında olmalıdır
        /// </summary>
        /// <returns>Saat formatı doğruysa true döner</returns>
        private bool ValidateTimeInputs() {
            if (!isHourChanged)
                return true; // saat değişmediyse kontrole gerek yok

            char[] start = startTB.Text.ToCharArray();
            char[] stop = stopTB.Text.ToCharArray();
            if (start.Length != 5 || stop.Length != 5) {
                //uzunluğu tam olarak 5 olmalı
                Log("Saat formatı ss:dd şeklinde olmalı. (Örn 02:10)", "error", false);
                return false;
            }
            for (int i = 0; i < start.Length; i++) {
                if ((!Char.IsNumber(start[i]) || !Char.IsNumber(stop[i])) && i != 2) {
                    // ortadaki ':' karakteri hariç diğerleri sayı olmalı
                    Log("Saat formatı ss:dd şeklinde olmalı. (Örn 02:10)", "error", false);
                    return false;
                }
            }
            if (start[2] != ':' || stop[2] != ':') {
                // ortada ':' karakteri olmalı
                Log("Saat formatı 02:10 gibi olmalı.", "error", false);
                return false;
            }
            string[] temp_start = startTB.Text.Split(':');
            int startHour = int.Parse(temp_start[0]);
            int startMinute = int.Parse(temp_start[1]);
            if (startHour >= 24 || startMinute >= 60) {
                //saat 23'den dakika 59'dan büyük olamaz
                Log("O saatde indirmeler zaten açık olur...", "error", false);
                return false;
            }
            string[] temp_stop = stopTB.Text.Split(':');
            int stopHour = int.Parse(temp_stop[0]);
            int stopMinute = int.Parse(temp_stop[1]);
            if (stopHour >= 24 || stopMinute >= 60) {
                //saat 23'den dakika 59'dan büyük olamaz
                Log("O saatde bilgisayar zaten kapalı olur...", "error", false);
                return false;
            }
            DateTime n = DateTime.Now;
            if(n.Hour > startHour || (n.Hour == startHour && n.Minute > startMinute) ) {
                //eğer şimdiki zaman açılış saatinden ilerideyse, günü yarına alalım
                n = n.AddDays(1);
            }
            startTime = new DateTime(n.Year, n.Month, n.Day, startHour, startMinute, 0);
            stopTime = new DateTime(1970, 1, 1, stopHour, stopMinute, 0);

            isHourChanged = false; // değişim onaylandı, bir sonraki değişimi yakalamak için eski haline döndürelim
            return true;
        }

        private void modeSleep_CheckedChanged(object sender) {
            FlatUI.FlatRadioButton sleep = (FlatUI.FlatRadioButton)sender;
            if (!logicalChange) {
                if (!allowSleep) {
                    logicalChange = true;
                    modeNormal.Checked = true;
                    return;
                }

                if (sleep.Checked) {
                    var confirmResult = MessageBox.Show("Uyku modunda; bilgisayarınız belirlediğiniz saatden 1 dakika"
                        + " önce uyku modundan uyandırılır, programlar belirlediğiniz saatde açılır."
                        + " Onaylıyor musunuz?",
                            "Bilgilendirme",
                            MessageBoxButtons.OKCancel);
                    if (confirmResult == DialogResult.OK) {
                        //SetRtcWakeSetting(true); //uykudan uyandırabilmeyi etkinleştirelim
                        //SetConsoleLockSetting(false);//uykudan uyunanınca şifre sormasın
                        sleepMode = true;
                    }
                    else {
                        logicalChange = true;
                        modeNormal.Checked = true;
                    }
                }
                //else {
                //    SetRtcWakeSetting(false); // uykudan uyandırabilmeyi eski haline çevirelim
                //    SetConsoleLockSetting(true);
                //}
            }
            else {
                logicalChange = false;
            }

            sleepMode = sleep.Checked;
        }

        /// <summary>
        /// Kullanıcın girdiği program dosya konumlarını doğrular
        /// </summary>
        /// <returns>Dosya konumları geçerli ise true döner</returns>
        private bool ValidateProgramPaths() {
            bool valid = true;
            for (int i = 0; i < programPaths.Count; i++) {
                if (!File.Exists(programPaths[i])) {
                    isManualDelete = false; //
                    programPaths.RemoveAt(i);
                    programsList.Rows.RemoveAt(i--);
                    valid = false;
                }
            }

            return valid;
        }

        /// <summary>
        /// Bir butonu aktişleştirir. Aktifleşen buton basılabilir hale gelir
        /// </summary>
        /// <param name="targetButton">Aktifleştirilecek buton</param>
        private void EnableButton(Button targetButton) {
            targetButton.Enabled = true;
            targetButton.BackColor = Color.FromArgb(255, 35, 91, 168);
        }

        /// <summary>
        /// Bir butonu deaktif konumuna getirir. Aktif olmayan buton ile etkileşim sağlanamaz.
        /// </summary>
        /// <param name="targetButton">Deaktifleştirilecek buton</param>
        private void DisableButton(Button targetButton) {
            targetButton.Enabled = false;
            targetButton.BackColor = Color.FromArgb(255, 60, 60, 60);
        }

        private void DisableUserInput() {
            //TODO: disable user input after starting service
        }

        private void sleepDisabled_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/BekirUzun/Otoin/blob/master/HELP.md#uyku-modu");
        }

        private void noNetTimeTB_TextChanged(object sender, EventArgs e) {
            if (noNetTimeTB.Text.Length > 0 && !int.TryParse(noNetTimeTB.Text, out noNetMaxMinute)) {
                Log(noNetTimeTB.Text + " geçerli bir sayı değil.", "error", true);
            }
        }

        private void noNetToggle_CheckedChanged(object sender) {
            noNetTimeTB.Enabled = noNetToggle.Checked;
            noNetTimeTB.Visible = noNetToggle.Checked;
            noNetLabel.Visible = noNetToggle.Checked;
            noNetBG.Visible = noNetToggle.Checked;
            stopIfNoNet = noNetToggle.Checked;
        }

        private void noNetTimeTB_KeyPress(object sender, KeyPressEventArgs e) {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9^\b]") || e.KeyChar == '^') {
                Log("Sadece sayı giriniz.", "error", false);
                e.Handled = true;
            }
            else if ( message.Text == "Sadece sayı giriniz.") {
                message.Visible = false;
            }
        }

        /// <summary>
        /// Girilen açılış ve kapanış saatlerini kontrol eder. Zamanı geldiğinde ilgili işlemleri uygular.
        /// 'service.Interval' saniyede bir çalışır.
        /// </summary>
        private void Check(object sender, EventArgs e) {
            //her service.Interval saniyede bir çalışacak fonksiyon
            checkCount++;
            if (!isProcStarted) {
                if (DateTime.Now.Hour == startTime.Hour && DateTime.Now.Minute == startTime.Minute) {
                    try {
                        isProcStarted = true;
                        for (int i = 0; i < programPaths.Count; i++) {
                            processes.Add(Process.Start(programPaths[i]));
                        }
                        Log(checkCount + ". kontrolde " + processes.Count + " program başlatıldı!", "success", true);
                        checkCount = 0;
                    }
                    catch (Exception ex) {
                        Log(ex.Message, "error", true);
                    }
                }
                else {
                    Log(checkCount + ". kontrol yapıldı", "info", false);
                }
            }
            else {
                int speedKbPs = GetNetworkUsage() / 1024;
                totalUsage += speedKbPs * service.Interval / 1000;

                if (DateTime.Now.Hour == stopTime.Hour && DateTime.Now.Minute == stopTime.Minute) {
                    try {
                        int i;
                        for (i = 0; i < processes.Count; i++) {
                            processes[i].Kill();
                        }
                        processes.Clear();
                        StopService();
                        Log(checkCount + ". kontrolde " + i + " program sonlandırıldı. Kapanış eylemi uygulanıyor...", "success", true);
                        isProcStarted = false;
                        DoStopAction();

                    }
                    catch (Exception ex) {
                        Log(ex.Message, "error", true);
                    }

                }
                else {
                    Log(checkCount + ". kontrol yapıldı. Hız: " + speedKbPs + " kbps, Toplam: " + totalUsage/1024 + " mb", "info", false);
                }

                if (speedKbPs < 50) {
                    noNetActivityCount++;
                    Log("İndirme yapılmadı.", "error", true);
                    if (stopIfNoNet && noNetActivityCount * service.Interval / 60000 >= noNetMaxMinute) {
                    //if (stopIfNoNet && noNetActivityCount * service.Interval / 1000 > noNetMaxMinute * 60) {
                        //bu kısıma her service.Interval milisaniyede bir geliyoruz.
                        //service.Interval / 1000 bunu saniyeye çevirir, onu noNetActivityCount ile
                        //çarpmak kaç saniyedir indirme yapılmadığını verir

                        //10 dakikadır herhangi bir indirme yapılmadı, muhtemelen her şey tamamlandı.
                        Log(noNetMaxMinute +" dakikadır herhangi bir indirme yapılmadı. Kapanış eylemi uygulanıyor.", "error", true);
                        for (int i = 0; i < processes.Count; i++)
                            processes[i].Kill();
                        
                        processes.Clear();
                        StopService();
                        DoStopAction();
                    }
                }
                else {
                    // ufak bir optimizasyon. Bazen torent geçici olarak yavaşlayabilir.
                    // Eğer tekrar indirme yaparsak sayacı azalmalıyız.Örneğin 1 saatde 3-4 defa
                    // yavaşlama olduğunu veya torrentin bir tanesinin bitip diğeri bağlanma aşamasında
                    // olduğunu varsayarsak sayaç birkaç saat içinde fazla ilerlediği için programı kapatabilir.
                    // Bu kontrol ile indirme yapılmayan dakikaların indirme yapılan dakikalardan büyük olduğu
                    // garantilenir. Örneğin son 12 dakikanın 11inde indirme yapılmıyor, 1inde yapılıyorsa
                    // muhtemelen indirmeler tamamlanmıştır. 
                    if (noNetActivityCount > 0)
                        noNetActivityCount--;
                    //Log("İndirme yapıldı. Sayaç = " + noNetActivityCount, "success", true);
                }
            }
        }

        /// <summary>
        /// Güncelleme var mı diye kontrol eder. Asenkrondur. Programın son sürüm olup olmadığını 
        /// Github'daki Release kısmındaki son sürümden kontrol eder.
        /// </summary>
        private async void CheckUpdate() {
            await System.Threading.Tasks.Task.Delay(1000);

            if (!CheckInternetConnection()) {
                Log("İnternet bağlantınız olmadığından güncelleme kontrol edilemedi :(", "error", true);
                return;
            }
            var github = new GitHubClient(new ProductHeaderValue("Otoin"));
            
            try
            {
                var releases = await github.Repository.Release.GetAll("BekirUzun", "Otoin");
                string tagName = releases[0].TagName;
                int latestVersion = Int16.Parse((string.Concat(tagName.Where(char.IsDigit))).Substring(0, 3));
                var v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                int currentVersion = v.Major * 100 + v.Minor * 10 + v.Build;
                if (latestVersion > currentVersion)
                {
                    blur.Image = Properties.Resources.blur;
                    blur.BackColor = Color.Transparent;
                    blur.BringToFront();
                    blur.Invalidate();
                    blur.Visible = true;

                    UpdateForm update = new UpdateForm(blur);
                    update.Show();
                    update.Focus();
                }
            }
            catch (Exception e)
            {
                Log("Güncelleme kontrol edilirken bir hata meydana geldi :(", "error", true);
                return;
            }
            
        }

        /// <summary>
        /// İnternet erişimini kontrol eder.
        /// </summary>
        /// <returns>İnternet erişimi var ise true döner</returns>
        private bool CheckInternetConnection() {
            try {
                using (var client = new System.Net.WebClient()) {
                    using (client.OpenRead("http://clients3.google.com/generate_204")) {
                        return true;
                    }
                }
            }
            catch {
                return false;
            }
        }

        /// <summary>
        /// Tüm ağlardaki toplam internet hızını kontrol eder
        /// </summary>
        /// <returns>İnternet hızını byte/saniye cinsinden döndürür</returns>
        private int GetNetworkUsage() {
            int usage = 0;
            for (int i = 0; i < networksPC.Count; i++) {
                usage += (int)networksPC[i].NextValue();
            }
            return usage;
        }

        /// <summary>
        /// Kapanış saati geldiğinde arayüzden seçilen eylemi uygular
        /// </summary>
        private void DoStopAction() {
            //kapanış saati geldiğinde ne yapacağımıza bakalım
            if (stopActionIndex == 1) {
                //bilgisayarı uyut (sleep/suspend)
                System.Windows.Forms.Application.SetSuspendState(PowerState.Suspend, true, true);
            }
            else if (stopActionIndex == 2) {
                //bilgisayarı hazırda beklet (hibernate)
                System.Windows.Forms.Application.SetSuspendState(PowerState.Hibernate, true, true);
            }
            else if (stopActionIndex == 3) {
                //bilgisayarı kapat
                var shutDown = new ProcessStartInfo("shutdown", "/s /t 0");
                shutDown.CreateNoWindow = true;
                shutDown.UseShellExecute = false;
                Process.Start(shutDown);
            }
            else if (stopActionIndex == 4) {
                //bilgisayarı kapatmaya zorla
                var shutDown = new ProcessStartInfo("shutdown", "/s /f /t 0");
                shutDown.CreateNoWindow = true;
                shutDown.UseShellExecute = false;
                Process.Start(shutDown);
            }
            //selectedIndex == 0 ise hiçbir şey yapmayacağız
        }

        /// <summary>
        /// Aktif güç planının GUID'ini bulur
        /// </summary>
        private Guid GetActiveSchemeGuid() {
            IntPtr activeSchemePtr = IntPtr.Zero;
            uint res = PowerGetActiveScheme(IntPtr.Zero, ref activeSchemePtr);
            GuidClass temp = new GuidClass();
            Marshal.PtrToStructure(activeSchemePtr, temp);
            Guid scheme = temp.Value;
            return scheme;
        }

        /// <summary>
        /// Bilgisayar fişe takılıyken GUID'i verilen ayarın değerini bulur
        /// </summary>
        private UInt32 GetACValue(Guid scheme, Guid subgroup, Guid setting) {
            UInt32 value = 0;
            PowerReadACValueIndex(IntPtr.Zero, ref scheme, ref subgroup, ref setting, ref value);
            return value;
        }

        /// <summary>
        /// Bilgisayar pildeyken GUID'i verilen ayarın değerini bulur
        /// </summary>
        private UInt32 GetDCValue(Guid scheme, Guid subgroup, Guid setting) {
            UInt32 value = 0;
            PowerReadDCValueIndex(IntPtr.Zero, ref scheme, ref subgroup, ref setting, ref value);
            return value;
        }

        /// <summary>
        /// [KULLANIMDAN KALDIRILDI] Bilgisayar fişe takılıyken GUID'i verilen ayarı değişirir
        /// </summary>
        private UInt32 SetACValue(Guid scheme, Guid subgroup, Guid setting, UInt32 value) {
            return PowerWriteACValueIndex(IntPtr.Zero, ref scheme, ref subgroup, ref setting, value);
        }

        /// <summary>
        /// [KULLANIMDAN KALDIRILDI] Bilgisayar pildeyken GUID'i verilen ayarın değerini değiştirir
        /// </summary>
        private UInt32 SetDCValue(Guid scheme, Guid subgroup, Guid setting, UInt32 value) {
            return PowerWriteDCValueIndex(IntPtr.Zero, ref scheme, ref subgroup, ref setting, value);
        }

        /// <summary>
        /// [KULLANIMDAN KALDIRILDI] Bilgisiyar uyandıktan sonra şifre istenmesi ayarını değiştirir
        /// </summary>
        /// <param name="enabled">Şifre ekranının gösterilip gösterilmeyeceğidir</param>
        private void SetConsoleLockSetting(bool enabled) {
            UInt32 value = (UInt32)((enabled) ? 1 : 0);
            SetACValue(scheme, SUB_NONE, CONSOLELOCK, value);
            SetDCValue(scheme, SUB_NONE, CONSOLELOCK, value);
            wakeLockEnabled = enabled;

        }

        /// <summary>
        /// [KULLANIMDAN KALDIRILDI] Bilgisayarın uykudan uyandırılabilme ayarını değiştirir
        /// </summary>
        /// <param name="enabled">Ayarın açık mı kapalımı olduğunu belirtir</param>
        private void SetRtcWakeSetting(bool enabled) {
            // 0:devre dışı 1: etkin, 2: sadece önemli olanlar
            // enabled == true ise AC ve DC için aktifleştirelim
            // false ise eski haline çevirelim
            UInt32 acValue = (UInt32)((enabled) ? 1 : 2);
            UInt32 dcValue = (UInt32)((enabled) ? 1 : 0);
            SetACValue(scheme, SUB_SLEEP, RTCWAKE, acValue);
            SetDCValue(scheme, SUB_SLEEP, RTCWAKE, dcValue);
        }

        /// <summary>
        /// Bilgisayarı uyandırmak için zamanlanmış görev oluşturur
        /// </summary>
        private void CreateTask() {
            using (TaskService ts = new TaskService()) {

                // yeni bir zamanlanmış görev oluşturalım
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Bilgisayarınızı belirlediğiniz saatde indirme yapması için uyandırır.";

                DateTime wakeTime = startTime.AddMinutes(-1);

                // Başlatma saatinde bir defa çalışacak bir tetikleyici ayarlayalım
                td.Triggers.Add(new TimeTrigger(wakeTime));
                //td.Triggers.Add(new DailyTrigger { DaysInterval = 1, StartBoundary = wakeTime });

                //diğer ayarları yapalım
                td.Settings.WakeToRun = true;
                if (ts.HighestSupportedVersion.Major >= 2) {
                    td.Settings.RunOnlyIfLoggedOn = false;
                    td.Principal.LogonType = TaskLogonType.None;
                }

                td.Settings.DisallowStartIfOnBatteries = false;
                td.Settings.StopIfGoingOnBatteries = false;
                td.Settings.Priority = ProcessPriorityClass.High; //UAC izni gerekiyor
                td.Principal.RunLevel = TaskRunLevel.Highest;
                //td.Settings.RunOnlyIfNetworkAvailable = true;

                // aslında hiçbir şey yapmayan bir işlem tanımlayalım
                td.Actions.Add(new ExecAction("ping", "-n 1 127.0.0.1 > nul", null));

                // Ana dizine görevimizi kaydedelim
                ts.RootFolder.RegisterTaskDefinition(@"Otoin Uyandırma", td);

                // Kaydettiğimiz görevi silelim
                //ts.RootFolder.DeleteTask("Otoin Uyandırma");
            }
        }

        /// <summary>
        /// Önceden oluşturulmuş görev varsa kaldırır
        /// </summary>
        private void DeleteTask() {
            using (TaskService ts = new TaskService()) {
                if (ts.RootFolder.Tasks.Exists("Otoin Uyandırma")) {
                    ts.RootFolder.DeleteTask("Otoin Uyandırma");
                }
            }
        }
    }
}
