using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using Octokit;

namespace Otoin {
    public partial class Otoin : Form {

        HelpForm help;
        List<string> programPaths;
        List<Process> processes;
        List<PerformanceCounter> networksPC;
        bool isFirstRun, isProcStarted, isServiceStarted;
        bool isHourChanged, isManualDelete, sleepMode, taskEnabled, wakeLockEnabled, rtcWakeEnabled;
        bool logicalChange, checkUpdates;
        DateTime startTime, stopTime;
        Timer service;
        int checkCount, totalUsage, noNetActivityCount, stopActionIndex;
        string programFiles32, programFiles64;
        PerformanceCounter received;

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
            } else {
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
            } else {
                isManualDelete = true; //eski haline çevirelim
            }

            if(programPaths.Count == 0) {
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
            if (help == null) {
                help = new HelpForm();
                help.Show();
            }
            help.SelectTab(0);
            help.Show();
            help.Focus();
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
            if (help == null) {
                //daha önceden yardım formunu oluşturmamışız
                help = new HelpForm();
                help.Show();
            }
            help.SelectTab(1);
            help.Show();
            help.Focus();
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
                string logLine = "[" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "][" + kind + "]" + message + "\n\r";
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
            if (!isFirstRun) {
                if(Properties.Settings.Default.targetAppLocs.Length > 0) {
                    string[] tempPaths = Properties.Settings.Default.targetAppLocs.Split(';');
                    foreach(string tempPath in tempPaths) {
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
                    } else {
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
            } else {
                Properties.Settings.Default.targetAppLocs = "";
            }
            ValidateTimeInputs();

            Properties.Settings.Default.isFirstRun = isFirstRun;
            Properties.Settings.Default.startTime = startTime;
            Properties.Settings.Default.stopTime = stopTime;
            Properties.Settings.Default.stopAction = stopActionIndex;
            Properties.Settings.Default.updateCheck = checkUpdates;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Saat kontrolü servisini başlatır. İsim yanıltmasın herhangi bir gerçek servis kullanmaz.
        /// 'Başlat' butonu ile çağırılır.
        /// </summary>
        private void StartService() {
            service.Start();
            checkCount = 0;
            isServiceStarted = true;
            actionButton.Text = "Durdur";
            actionButton.BackColor = Color.FromArgb(255, 168, 35, 35);
            EnableButton(hideButton);
            Log("Servis başarılı bir şekilde başlatıldı.", "success", true);
        }

        private void rightClickMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            if(e.ClickedItem.Text == "Sil") {
                var rowsToDelete = programsList.SelectedRows;
                foreach( DataGridViewRow row in rowsToDelete) {
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


        /// <summary>
        /// Saat kontrolü servisini durdurur.
        /// </summary>
        private void StopService() {
            service.Stop();
            isServiceStarted = false;
            actionButton.Text = "Başlat!";
            actionButton.BackColor = Color.FromArgb(255, 35, 91, 168);
            DisableButton(hideButton);
            float usageDisplay;
            string usageUnit;
            if (totalUsage > 1024 && totalUsage < 1024*1024) {
                //toplam indirmeyi mb cinsinden göstereceğiz
                usageDisplay = (float)totalUsage / 1024;
                usageUnit = " MB";
            }
            else if (totalUsage > 1024*1024) {
                //toplam indirmeyi gb cinsinden göstereceğiz
                usageDisplay = ((float)totalUsage / 1024 ) / 1024;
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
            if (int.Parse(temp_start[0]) >= 24 || int.Parse(temp_start[1]) >= 60) {
                //saat 23'den dakika 59'dan büyük olamaz
                Log("O saatde indirmeler zaten açık olur...", "error", false);
                return false;
            }
            string[] temp_stop = stopTB.Text.Split(':');
            if (int.Parse(temp_stop[0]) >= 24 || int.Parse(temp_stop[1]) >= 60) {
                //saat 23'den dakika 59'dan büyük olamaz
                Log("O saatde bilgisayar zaten kapalı olur...", "error", false);
                return false;
            }
            startTime = new DateTime(1970, 1, 1, int.Parse(temp_start[0]), int.Parse(temp_start[1]), 0);
            stopTime = new DateTime(1970, 1, 1, int.Parse(temp_stop[0]), int.Parse(temp_stop[1]), 0);

            isHourChanged = false; // değişim onaylandı, bir sonraki değişimi yakalamak için eski haline döndürelim
            return true;
        }

        /// <summary>
        /// Kullanıcın girdiği program dosya konumlarını doğrular
        /// </summary>
        /// <returns>Dosya konumları geçerli ise true döner</returns>
        private bool ValidateProgramPaths() {
            bool valid = true;
            for(int i = 0; i < programPaths.Count; i++) {
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
                        for(int i = 0; i < programPaths.Count; i++) {
                            processes.Add(Process.Start(programPaths[i]));
                        }

                        Log(checkCount + ". kontrolde " + processes.Count + " program başlatıldı!", "success", true);
                        isProcStarted = true;
                        checkCount = 0;
                    } catch (Exception ex) {
                        Log(ex.Message, "error", true);
                    }
                }
                else {
                    Log(checkCount + ". kontrol yapıldı", "info", false);
                }
            }
            else {
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
                    Log(checkCount + ". kontrol yapıldı", "info", false);
                }

                int speedKbPs = GetNetworkUsage() / 1024;
                totalUsage += speedKbPs * service.Interval / 1000;

                if (speedKbPs < 50) {
                    noNetActivityCount++;
                    Log("İndirme yapılmadı.", "error", true);
                    if (noNetActivityCount * service.Interval / 1000 > 600) {
                        //bu kısıma her service.Interval milisaniyede bir geliyoruz.
                        //service.Interval / 1000 bunu saniyeye çevirir, onu noNetActivityCount ile
                        //çarpmak kaç saniyedir indirme yapılmadığını verir

                        //10 dakikadır herhangi bir indirme yapılmadı, muhtemelen her şey tamamlandı.
                        Log("10 dakikadır herhangi bir indirme yapılmadı. Kapanış eylemi uygulanıyor.", "error", true);
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
            await Task.Delay(1000);

            if (!CheckInternetConnection()) {
                Log("İnternet bağlantınız olmadığından güncelleme kontrol edilemedi :(", "error", true);
                return;
            }
            var github = new GitHubClient(new ProductHeaderValue("Otoin"));
            var releases = await github.Repository.Release.GetAll("BekirUzun", "Otoin");
            var latestRelease = releases[0];
            int latestVersion = Int16.Parse(latestRelease.TagName.Remove(4, 1).Remove(2, 1).Remove(0, 1));
            var v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            int currentVersion = v.Major * 100 + v.Minor * 10 + v.Build;

            if (latestVersion > currentVersion) {
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
                var shutDown = new ProcessStartInfo("shutdown", "/s /t 0"); // "shutdown", "/s /f /t 0" -> zorla kapatma
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

    }
}
