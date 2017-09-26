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
        bool isTested, isFirstRun , isTestMode, isProcStarted, isServiceStarted, isHourChanged, isManualDelete;
        bool checkUpdates;
        DateTime startTime, stopTime;
        Timer service;
        int checkCount, stopActionIndex;
        string programFiles32, programFiles64;

        public Otoin() {
            RetrieveSettings();
            InitializeComponent();

            this.Icon = Properties.Resources.icon;
            notifyIcon.Icon = Properties.Resources.icon;

            programFiles64 = Environment.ExpandEnvironmentVariables("%ProgramW6432%");
            programFiles32 = Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%");

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
                    EnableButton(testButton);
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
            service.Tick += new EventHandler(Check); //Her 30 saniyede bir Check() çalışsın
            service.Interval = 5000; // 30 saniyede bir kontrol etsin

            processes = new List<Process>();
            isManualDelete = true;
            isTestMode = false;

            if (checkUpdates) {
                // kullanıcı daha önceden "Asla" butonuna basmadı. Asenkron güncelleme kontrolü yapacağız
                CheckUpdate();
            }
            
        }

        private void filePromptButton_Click(object sender, EventArgs e) {
            programPrompt.Filter = "Program (*.exe)|*.exe";
            programPrompt.ShowDialog();
        }

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
                EnableButton(testButton);
                SaveSettings();
            } else {
                Log("Herhangi bir program bulunamadı. Manuel ekleyiniz.", "error", false);
            }
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e) {
            if (!programPrompt.CheckFileExists) {
                Log("Program seçilirken bir hata oluştu :(", "error", true);
                return;
            }
            programPaths.Add(programPrompt.FileName);
            programsList.Rows.Add(programPrompt.SafeFileName, programPrompt.FileName);

            isTested = false;
            Log("Program başarılı bir şekilde seçildi!", "success", false);
            EnableButton(actionButton); //kapalı olan butonları aktifleştirelim
            EnableButton(testButton);
            SaveSettings();
        }
        
        private void programsList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e) {
            if (isManualDelete) {
                //bu kısım kullanıcı el ile bir program sildiğide çalışır, program içi silmelerde çalışmaz
                programPaths.RemoveAt(e.RowIndex); // satır sıralaması listeyle aynı (umarım)
                isManualDelete = true; //eski haline çevirelim
            }
            if(programPaths.Count == 0) {
                DisableButton(actionButton);
                DisableButton(testButton);
            }

            SaveSettings();
        }

        private void testButton_Click(object sender, EventArgs e) {
            var confirmResult = MessageBox.Show("Seçtiğiniz programlar bir dakika sonra açılacak ve bir dakika açık kalacak. " +
                        "Daha sonra seçtiğiniz kapanış eylemi gerçekleştirilecek. "+
                        "Kaydetmediğiniz çalışmalarınız varsa lütfen kaydedin. " +
                        "\nOnaylıyor musunuz?",
                        "Onayla",
                        MessageBoxButtons.OKCancel);
            if (confirmResult == DialogResult.OK) {
                if (isServiceStarted)
                    StopService();

                SaveSettings();
                TestService();
            }
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

            if (isTested) {
                StartService();
            }
            else {
                var confirmResult = MessageBox.Show("Programı henüz test etmediniz. " +
                     "Programın çalıştığını doğrulamanız için test etmenizi öneririm :)" +
                     "\nServis yine de başlatılsın mı?",
                     "Programı test etmediniz",
                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes) {
                    StartService();
                }
            }
        }

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

        private void RetrieveSettings() {
            programPaths = new List<string>();
            isTested = Properties.Settings.Default.isTested;
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
                //selectedProgramPath = Properties.Settings.Default.targetAppLocs;
            }
        }

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

            Properties.Settings.Default.isTested = isTested;
            Properties.Settings.Default.isFirstRun = isFirstRun;
            Properties.Settings.Default.startTime = startTime;
            Properties.Settings.Default.stopTime = stopTime;
            Properties.Settings.Default.stopAction = stopActionIndex;
            Properties.Settings.Default.updateCheck = checkUpdates;
            Properties.Settings.Default.Save();
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

        private void stopAction_SelectedIndexChanged(object sender, EventArgs e) {
            stopActionIndex = stopAction.SelectedIndex;
        }

        private void helpPrograms_Click(object sender, EventArgs e) {
            if (help == null) {
                help = new HelpForm();
                help.Show();
            }
            help.SelectTab(1);
            help.Show();
            help.Focus();
        }

        private void StartService() {
            service.Start();
            checkCount = 0;
            isServiceStarted = true;
            actionButton.Text = "Durdur";
            actionButton.BackColor = Color.FromArgb(255, 168, 35, 35);
            EnableButton(hideButton);
            Log("Servis başarılı bir şekilde başlatıldı.", "success", true);
        }

        private void StopService() {
            service.Stop();
            isServiceStarted = false;
            actionButton.Text = "Başlat!";
            actionButton.BackColor = Color.FromArgb(255, 35, 91, 168);
            DisableButton(hideButton);
            Log("Servis başarılı bir şekilde durduruldu.", "success", true);
        }

        private void TestService() {
            isTestMode = true;
            
            DisableButton(testButton);
            DisableButton(actionButton);

            startTime = DateTime.Now.AddMinutes(1); // başlangıcı 1 dakika sonraya ayarlayalım
            stopTime = DateTime.Now.AddMinutes(2); // bitişi 2 dakika sonraya
            isHourChanged = true;

            checkCount = 0;
            isServiceStarted = true;
            service.Interval = 5000; //işe yarar bir şey yapıyormuş gibi kontrol hızını arttıralım
            service.Start(); // kontrolü baslatalım başlatalım
            Log("Test başarılı bir şekilde başlatıldı.", "success", true);
        }

        private bool ValidateTimeInputs() {
            if (!isHourChanged)
                return true;

            char[] start = startTB.Text.ToCharArray();
            char[] stop = stopTB.Text.ToCharArray();
            if (start.Length != 5 || stop.Length != 5) {
                Log("Saat formatı ss:dd şeklinde olmalı. (Örn 02:10)", "error", false);
                return false;
            }
            for (int i = 0; i < start.Length; i++) {
                if ((!Char.IsNumber(start[i]) || !Char.IsNumber(stop[i])) && i != 2) {
                    Log("Saat formatı ss:dd şeklinde olmalı. (Örn 02:10)", "error", false);
                    return false;
                }
            }
            if (start[2] != ':' || stop[2] != ':') {
                Log("Saat formatı 02:10 gibi olmalı.", "error", false);
                return false;
            }
            string[] temp_start = startTB.Text.Split(':');
            if (int.Parse(temp_start[0]) >= 24 || int.Parse(temp_start[1]) >= 60) {
                Log("O saatde bilgisayar zaten kapalı olur...", "error", false);
                return false;
            }
            string[] temp_stop = stopTB.Text.Split(':');
            if (int.Parse(temp_stop[0]) >= 24 || int.Parse(temp_stop[1]) >= 60) {
                Log("O saatde bilgisayar zaten kapalı olur...", "error", false);
                return false;
            }
            startTime = new DateTime(1970, 1, 1, int.Parse(temp_start[0]), int.Parse(temp_start[1]), 0);
            stopTime = new DateTime(1970, 1, 1, int.Parse(temp_stop[0]), int.Parse(temp_stop[1]), 0);

            isHourChanged = false; // değişim onaylandı, bir sonraki değişimi yakalamak için eski haline döndürelim
            return true;
        }

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

        private void EnableButton(Button targetButton) {
            targetButton.Enabled = true;
            targetButton.BackColor = Color.FromArgb(255, 35, 91, 168);
        }

        private void DisableButton(Button targetButton) {
            targetButton.Enabled = false;
            targetButton.BackColor = Color.FromArgb(255, 60, 60, 60);
        }

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
                        
                        if (isTestMode) {
                            isTested = true;
                            Properties.Settings.Default.isTested = true;
                            Properties.Settings.Default.Save();
                            ValidateTimeInputs();
                            EnableButton(testButton);
                            EnableButton(actionButton);
                        }

                        //kapanış saati geldiğinde ne yapacağımıza bakalım
                        if (stopActionIndex == 1) {
                            //bilgisayarı uyut (sleep/suspend)
                            System.Windows.Forms.Application.SetSuspendState(PowerState.Suspend, true, true);
                        } else if (stopActionIndex == 2) {
                            //bilgisayarı hazırda beklet (hibernate)
                            System.Windows.Forms.Application.SetSuspendState(PowerState.Hibernate, true, true);
                        } else if (stopActionIndex == 3) {
                            //bilgisayarı kapat
                            var shutDown = new ProcessStartInfo("shutdown", "/s /t 0"); // "shutdown", "/s /f /t 0" -> zorla kapatma
                            shutDown.CreateNoWindow = true;
                            shutDown.UseShellExecute = false;
                            Process.Start(shutDown);
                        } else if(stopActionIndex ==4) {
                            //bilgisayarı kapatmaya zorla
                            var shutDown = new ProcessStartInfo("shutdown", "/s /f /t 0");
                            shutDown.CreateNoWindow = true;
                            shutDown.UseShellExecute = false;
                            Process.Start(shutDown);
                        }
                        //selectedIndex == 0 ise hiçbir şey yapmayacağız
                        
                    }
                    catch (Exception ex) {
                        Log(ex.Message, "error", true);
                    }
                   
                }
                else {
                    Log(checkCount + ". kontrol yapıldı", "info", false);
                }

                // TODO: check network activity here!!!

            }
        }

        private async void CheckUpdate() {
            await Task.Delay(3000);

            if (!CheckInternetConnection()) {
                Log("İnternet bağlantınız olmadığından güncelleme kontrol edilemedi :(", "error", true);
                return;
            }
            var github = new GitHubClient(new ProductHeaderValue("Otoin"));
            var releases = github.Repository.Release.GetAll("BekirUzun", "Otoin");
            var latestRelease = releases.Result[0];
            int latestVersion = Int16.Parse(latestRelease.TagName.Remove(4, 1).Remove(2, 1).Remove(0, 1));
            var v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            int currentVersion = v.Major * 100 + v.Minor * 10 + v.Build;

            if (latestVersion > currentVersion) {
                shadow.Image = Properties.Resources.blur;
                shadow.BackColor = Color.Transparent;
                shadow.Visible = true;

                UpdateForm update = new UpdateForm(shadow);
                update.Show();
                update.Focus();
            }
        }

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
    }
}
