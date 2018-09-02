namespace Otoin {
    partial class Otoin {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Otoin));
            this.skin = new FlatUI.FormSkin();
            this.tabControl = new FlatUI.FlatTabControl();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.noNetToggle = new FlatUI.FlatToggle();
            this.sleepDisabled = new FlatUI.FlatLabel();
            this.stopAction = new FlatUI.FlatComboBox();
            this.flatLabel9 = new FlatUI.FlatLabel();
            this.flatLabel8 = new FlatUI.FlatLabel();
            this.modeSleep = new FlatUI.FlatRadioButton();
            this.modeNormal = new FlatUI.FlatRadioButton();
            this.flatLabel7 = new FlatUI.FlatLabel();
            this.actionButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.startTB = new System.Windows.Forms.TextBox();
            this.sleepButton = new System.Windows.Forms.Button();
            this.helpSettings = new System.Windows.Forms.Button();
            this.noNetBG = new System.Windows.Forms.Panel();
            this.noNetTimeTB = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.stopTB = new System.Windows.Forms.TextBox();
            this.hideButton = new System.Windows.Forms.Button();
            this.startLabel = new FlatUI.FlatLabel();
            this.noNetLabel = new FlatUI.FlatLabel();
            this.stopLabel = new FlatUI.FlatLabel();
            this.programsTab = new System.Windows.Forms.TabPage();
            this.helpPrograms = new System.Windows.Forms.Button();
            this.findProgramsBtn = new System.Windows.Forms.Button();
            this.filePromptButton = new System.Windows.Forms.Button();
            this.programsList = new System.Windows.Forms.DataGridView();
            this.programNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programPathCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightClickMenu = new FlatUI.FlatContextMenuStrip();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutTab = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.aboutProjectLink = new System.Windows.Forms.RichTextBox();
            this.flatLabel6 = new FlatUI.FlatLabel();
            this.aboutVersion = new FlatUI.FlatLabel();
            this.flatLabel4 = new FlatUI.FlatLabel();
            this.flatLabel2 = new FlatUI.FlatLabel();
            this.flatLabel3 = new FlatUI.FlatLabel();
            this.aboutBold3 = new FlatUI.FlatLabel();
            this.aboutBold5 = new FlatUI.FlatLabel();
            this.flatLabel5 = new FlatUI.FlatLabel();
            this.aboutBold6 = new FlatUI.FlatLabel();
            this.flatLabel1 = new FlatUI.FlatLabel();
            this.aboutBold7 = new FlatUI.FlatLabel();
            this.aboutBold4 = new FlatUI.FlatLabel();
            this.aboutBold2 = new FlatUI.FlatLabel();
            this.aboutBold1 = new FlatUI.FlatLabel();
            this.aboutText = new System.Windows.Forms.Label();
            this.bgTop = new System.Windows.Forms.Panel();
            this.minimizeBtn = new FlatUI.FlatMini();
            this.message = new FlatUI.FlatAlertBox();
            this.closeBtn = new FlatUI.FlatClose();
            this.panel3 = new System.Windows.Forms.Panel();
            this.blur = new System.Windows.Forms.PictureBox();
            this.programPrompt = new System.Windows.Forms.OpenFileDialog();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.skin.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.panel2.SuspendLayout();
            this.noNetBG.SuspendLayout();
            this.panel1.SuspendLayout();
            this.programsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.programsList)).BeginInit();
            this.rightClickMenu.SuspendLayout();
            this.aboutTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blur)).BeginInit();
            this.SuspendLayout();
            // 
            // skin
            // 
            this.skin.BackColor = System.Drawing.Color.White;
            this.skin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.skin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.skin.Controls.Add(this.tabControl);
            this.skin.Controls.Add(this.bgTop);
            this.skin.Controls.Add(this.minimizeBtn);
            this.skin.Controls.Add(this.message);
            this.skin.Controls.Add(this.closeBtn);
            this.skin.Controls.Add(this.panel3);
            this.skin.Controls.Add(this.blur);
            this.skin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skin.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(91)))), ((int)(((byte)(168)))));
            this.skin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.skin.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.skin.HeaderMaximize = false;
            this.skin.Location = new System.Drawing.Point(0, 0);
            this.skin.Margin = new System.Windows.Forms.Padding(4);
            this.skin.Name = "skin";
            this.skin.Size = new System.Drawing.Size(700, 462);
            this.skin.TabIndex = 0;
            this.skin.Text = "Otoin";
            this.skin.Resize += new System.EventHandler(this.skin_Resize);
            // 
            // tabControl
            // 
            this.tabControl.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(91)))), ((int)(((byte)(168)))));
            this.tabControl.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.tabControl.Controls.Add(this.settingsTab);
            this.tabControl.Controls.Add(this.programsTab);
            this.tabControl.Controls.Add(this.aboutTab);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.ItemSize = new System.Drawing.Size(167, 40);
            this.tabControl.Location = new System.Drawing.Point(11, 65);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(679, 322);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 14;
            // 
            // settingsTab
            // 
            this.settingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.settingsTab.Controls.Add(this.noNetToggle);
            this.settingsTab.Controls.Add(this.sleepDisabled);
            this.settingsTab.Controls.Add(this.stopAction);
            this.settingsTab.Controls.Add(this.flatLabel9);
            this.settingsTab.Controls.Add(this.flatLabel8);
            this.settingsTab.Controls.Add(this.modeSleep);
            this.settingsTab.Controls.Add(this.modeNormal);
            this.settingsTab.Controls.Add(this.flatLabel7);
            this.settingsTab.Controls.Add(this.actionButton);
            this.settingsTab.Controls.Add(this.panel2);
            this.settingsTab.Controls.Add(this.sleepButton);
            this.settingsTab.Controls.Add(this.helpSettings);
            this.settingsTab.Controls.Add(this.noNetBG);
            this.settingsTab.Controls.Add(this.panel1);
            this.settingsTab.Controls.Add(this.hideButton);
            this.settingsTab.Controls.Add(this.startLabel);
            this.settingsTab.Controls.Add(this.noNetLabel);
            this.settingsTab.Controls.Add(this.stopLabel);
            this.settingsTab.Location = new System.Drawing.Point(4, 44);
            this.settingsTab.Margin = new System.Windows.Forms.Padding(4);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Windows.Forms.Padding(4);
            this.settingsTab.Size = new System.Drawing.Size(671, 274);
            this.settingsTab.TabIndex = 0;
            this.settingsTab.Text = "Ayarlar";
            // 
            // noNetToggle
            // 
            this.noNetToggle.BackColor = System.Drawing.Color.Transparent;
            this.noNetToggle.Checked = false;
            this.noNetToggle.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.noNetToggle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.noNetToggle.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.noNetToggle.Location = new System.Drawing.Point(236, 169);
            this.noNetToggle.Margin = new System.Windows.Forms.Padding(4);
            this.noNetToggle.Name = "noNetToggle";
            this.noNetToggle.Options = FlatUI.FlatToggle._Options.Style1;
            this.noNetToggle.Size = new System.Drawing.Size(76, 33);
            this.noNetToggle.TabIndex = 20;
            this.noNetToggle.Text = "flatToggle1";
            this.noNetToggle.CheckedChanged += new FlatUI.FlatToggle.CheckedChangedEventHandler(this.noNetToggle_CheckedChanged);
            // 
            // sleepDisabled
            // 
            this.sleepDisabled.AutoSize = true;
            this.sleepDisabled.BackColor = System.Drawing.Color.Transparent;
            this.sleepDisabled.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sleepDisabled.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Underline);
            this.sleepDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(121)))), ((int)(((byte)(198)))));
            this.sleepDisabled.Location = new System.Drawing.Point(365, 20);
            this.sleepDisabled.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sleepDisabled.Name = "sleepDisabled";
            this.sleepDisabled.Size = new System.Drawing.Size(120, 19);
            this.sleepDisabled.TabIndex = 19;
            this.sleepDisabled.Text = "(Bu neden kapalı?)";
            this.sleepDisabled.Visible = false;
            this.sleepDisabled.Click += new System.EventHandler(this.sleepDisabled_Click);
            // 
            // stopAction
            // 
            this.stopAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.stopAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopAction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.stopAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stopAction.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.stopAction.ForeColor = System.Drawing.Color.White;
            this.stopAction.FormattingEnabled = true;
            this.stopAction.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.stopAction.ItemHeight = 18;
            this.stopAction.Items.AddRange(new object[] {
            "Hiçbir şey yapma",
            "Bilgisayarı uyku moduna al",
            "Bilgisayarı hazırda beklet",
            "Bilgisayarı kapat",
            "Bilgisayarı kapatmaya zorla"});
            this.stopAction.Location = new System.Drawing.Point(179, 123);
            this.stopAction.Margin = new System.Windows.Forms.Padding(4);
            this.stopAction.Name = "stopAction";
            this.stopAction.Size = new System.Drawing.Size(249, 24);
            this.stopAction.TabIndex = 18;
            this.stopAction.SelectedIndexChanged += new System.EventHandler(this.stopAction_SelectedIndexChanged);
            // 
            // flatLabel9
            // 
            this.flatLabel9.AutoSize = true;
            this.flatLabel9.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatLabel9.ForeColor = System.Drawing.Color.White;
            this.flatLabel9.Location = new System.Drawing.Point(36, 175);
            this.flatLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.flatLabel9.Name = "flatLabel9";
            this.flatLabel9.Size = new System.Drawing.Size(186, 23);
            this.flatLabel9.TabIndex = 17;
            this.flatLabel9.Text = "İndirme bitince kapat : ";
            // 
            // flatLabel8
            // 
            this.flatLabel8.AutoSize = true;
            this.flatLabel8.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatLabel8.ForeColor = System.Drawing.Color.White;
            this.flatLabel8.Location = new System.Drawing.Point(36, 123);
            this.flatLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.flatLabel8.Name = "flatLabel8";
            this.flatLabel8.Size = new System.Drawing.Size(132, 23);
            this.flatLabel8.TabIndex = 17;
            this.flatLabel8.Text = "Kapanış Eylemi :";
            // 
            // modeSleep
            // 
            this.modeSleep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.modeSleep.Checked = false;
            this.modeSleep.Cursor = System.Windows.Forms.Cursors.Default;
            this.modeSleep.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.modeSleep.ForeColor = System.Drawing.Color.White;
            this.modeSleep.Location = new System.Drawing.Point(287, 15);
            this.modeSleep.Margin = new System.Windows.Forms.Padding(4);
            this.modeSleep.Name = "modeSleep";
            this.modeSleep.Options = FlatUI.FlatRadioButton._Options.Style1;
            this.modeSleep.Size = new System.Drawing.Size(87, 22);
            this.modeSleep.TabIndex = 16;
            this.modeSleep.Text = "Uyku";
            this.modeSleep.CheckedChanged += new FlatUI.FlatRadioButton.CheckedChangedEventHandler(this.modeSleep_CheckedChanged);
            // 
            // modeNormal
            // 
            this.modeNormal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.modeNormal.Checked = true;
            this.modeNormal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modeNormal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.modeNormal.Location = new System.Drawing.Point(173, 15);
            this.modeNormal.Margin = new System.Windows.Forms.Padding(4);
            this.modeNormal.Name = "modeNormal";
            this.modeNormal.Options = FlatUI.FlatRadioButton._Options.Style1;
            this.modeNormal.Size = new System.Drawing.Size(105, 22);
            this.modeNormal.TabIndex = 15;
            this.modeNormal.Text = "Normal";
            // 
            // flatLabel7
            // 
            this.flatLabel7.AutoSize = true;
            this.flatLabel7.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.flatLabel7.ForeColor = System.Drawing.Color.White;
            this.flatLabel7.Location = new System.Drawing.Point(32, 15);
            this.flatLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.flatLabel7.Name = "flatLabel7";
            this.flatLabel7.Size = new System.Drawing.Size(128, 23);
            this.flatLabel7.TabIndex = 14;
            this.flatLabel7.Text = "Çalışma Modu :";
            // 
            // actionButton
            // 
            this.actionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.actionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.actionButton.Enabled = false;
            this.actionButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.actionButton.FlatAppearance.BorderSize = 0;
            this.actionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.actionButton.ForeColor = System.Drawing.Color.White;
            this.actionButton.Location = new System.Drawing.Point(484, 217);
            this.actionButton.Margin = new System.Windows.Forms.Padding(4);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(141, 39);
            this.actionButton.TabIndex = 11;
            this.actionButton.Text = "Başlat!";
            this.actionButton.UseVisualStyleBackColor = false;
            this.actionButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.panel2.Controls.Add(this.startTB);
            this.panel2.ForeColor = System.Drawing.SystemColors.Window;
            this.panel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel2.Location = new System.Drawing.Point(179, 62);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(93, 37);
            this.panel2.TabIndex = 13;
            // 
            // startTB
            // 
            this.startTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.startTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startTB.ForeColor = System.Drawing.Color.Silver;
            this.startTB.Location = new System.Drawing.Point(15, 6);
            this.startTB.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.startTB.MaxLength = 5;
            this.startTB.Name = "startTB";
            this.startTB.Size = new System.Drawing.Size(61, 23);
            this.startTB.TabIndex = 12;
            this.startTB.Text = "00:00";
            this.startTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.startTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.timeTB_KeyPress);
            // 
            // sleepButton
            // 
            this.sleepButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.sleepButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sleepButton.Enabled = false;
            this.sleepButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.sleepButton.FlatAppearance.BorderSize = 0;
            this.sleepButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sleepButton.ForeColor = System.Drawing.Color.White;
            this.sleepButton.Location = new System.Drawing.Point(335, 217);
            this.sleepButton.Margin = new System.Windows.Forms.Padding(4);
            this.sleepButton.Name = "sleepButton";
            this.sleepButton.Size = new System.Drawing.Size(141, 39);
            this.sleepButton.TabIndex = 11;
            this.sleepButton.Text = "Uyut\r\n";
            this.sleepButton.UseVisualStyleBackColor = false;
            this.sleepButton.Click += new System.EventHandler(this.sleepButton_Click);
            // 
            // helpSettings
            // 
            this.helpSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.helpSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.helpSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.helpSettings.FlatAppearance.BorderSize = 0;
            this.helpSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpSettings.ForeColor = System.Drawing.Color.White;
            this.helpSettings.Location = new System.Drawing.Point(36, 217);
            this.helpSettings.Margin = new System.Windows.Forms.Padding(4);
            this.helpSettings.Name = "helpSettings";
            this.helpSettings.Size = new System.Drawing.Size(141, 39);
            this.helpSettings.TabIndex = 11;
            this.helpSettings.Text = "Yardım";
            this.helpSettings.UseVisualStyleBackColor = false;
            this.helpSettings.Click += new System.EventHandler(this.helpSettings_Click);
            // 
            // noNetBG
            // 
            this.noNetBG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.noNetBG.Controls.Add(this.noNetTimeTB);
            this.noNetBG.ForeColor = System.Drawing.SystemColors.Window;
            this.noNetBG.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.noNetBG.Location = new System.Drawing.Point(532, 169);
            this.noNetBG.Margin = new System.Windows.Forms.Padding(4);
            this.noNetBG.Name = "noNetBG";
            this.noNetBG.Size = new System.Drawing.Size(93, 37);
            this.noNetBG.TabIndex = 13;
            this.noNetBG.Visible = false;
            // 
            // noNetTimeTB
            // 
            this.noNetTimeTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.noNetTimeTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.noNetTimeTB.Enabled = false;
            this.noNetTimeTB.ForeColor = System.Drawing.Color.Silver;
            this.noNetTimeTB.Location = new System.Drawing.Point(17, 6);
            this.noNetTimeTB.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.noNetTimeTB.MaxLength = 5;
            this.noNetTimeTB.Name = "noNetTimeTB";
            this.noNetTimeTB.Size = new System.Drawing.Size(61, 23);
            this.noNetTimeTB.TabIndex = 12;
            this.noNetTimeTB.Text = "10";
            this.noNetTimeTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.noNetTimeTB.Visible = false;
            this.noNetTimeTB.TextChanged += new System.EventHandler(this.noNetTimeTB_TextChanged);
            this.noNetTimeTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.noNetTimeTB_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.panel1.Controls.Add(this.stopTB);
            this.panel1.ForeColor = System.Drawing.SystemColors.Window;
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel1.Location = new System.Drawing.Point(515, 62);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(93, 37);
            this.panel1.TabIndex = 13;
            // 
            // stopTB
            // 
            this.stopTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.stopTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stopTB.ForeColor = System.Drawing.Color.Silver;
            this.stopTB.Location = new System.Drawing.Point(17, 6);
            this.stopTB.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.stopTB.MaxLength = 5;
            this.stopTB.Name = "stopTB";
            this.stopTB.Size = new System.Drawing.Size(61, 23);
            this.stopTB.TabIndex = 12;
            this.stopTB.Text = "00:00";
            this.stopTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stopTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.timeTB_KeyPress);
            // 
            // hideButton
            // 
            this.hideButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.hideButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hideButton.Enabled = false;
            this.hideButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.hideButton.FlatAppearance.BorderSize = 0;
            this.hideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hideButton.ForeColor = System.Drawing.Color.White;
            this.hideButton.Location = new System.Drawing.Point(185, 217);
            this.hideButton.Margin = new System.Windows.Forms.Padding(4);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(141, 39);
            this.hideButton.TabIndex = 11;
            this.hideButton.Text = "Gizle";
            this.hideButton.UseVisualStyleBackColor = false;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.BackColor = System.Drawing.Color.Transparent;
            this.startLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.startLabel.ForeColor = System.Drawing.Color.White;
            this.startLabel.Location = new System.Drawing.Point(36, 68);
            this.startLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(99, 23);
            this.startLabel.TabIndex = 5;
            this.startLabel.Text = "Açılış Saati :";
            // 
            // noNetLabel
            // 
            this.noNetLabel.AutoSize = true;
            this.noNetLabel.BackColor = System.Drawing.Color.Transparent;
            this.noNetLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.noNetLabel.ForeColor = System.Drawing.Color.White;
            this.noNetLabel.Location = new System.Drawing.Point(383, 175);
            this.noNetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noNetLabel.Name = "noNetLabel";
            this.noNetLabel.Size = new System.Drawing.Size(129, 23);
            this.noNetLabel.TabIndex = 5;
            this.noNetLabel.Text = "... dakika bekle :";
            this.noNetLabel.Visible = false;
            // 
            // stopLabel
            // 
            this.stopLabel.AutoSize = true;
            this.stopLabel.BackColor = System.Drawing.Color.Transparent;
            this.stopLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.stopLabel.ForeColor = System.Drawing.Color.White;
            this.stopLabel.Location = new System.Drawing.Point(379, 68);
            this.stopLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stopLabel.Name = "stopLabel";
            this.stopLabel.Size = new System.Drawing.Size(120, 23);
            this.stopLabel.TabIndex = 5;
            this.stopLabel.Text = "Kapanış Saati :";
            // 
            // programsTab
            // 
            this.programsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.programsTab.Controls.Add(this.helpPrograms);
            this.programsTab.Controls.Add(this.findProgramsBtn);
            this.programsTab.Controls.Add(this.filePromptButton);
            this.programsTab.Controls.Add(this.programsList);
            this.programsTab.Location = new System.Drawing.Point(4, 44);
            this.programsTab.Margin = new System.Windows.Forms.Padding(4);
            this.programsTab.Name = "programsTab";
            this.programsTab.Padding = new System.Windows.Forms.Padding(4);
            this.programsTab.Size = new System.Drawing.Size(671, 274);
            this.programsTab.TabIndex = 1;
            this.programsTab.Text = "Açılacak Programlar";
            // 
            // helpPrograms
            // 
            this.helpPrograms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.helpPrograms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.helpPrograms.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.helpPrograms.FlatAppearance.BorderSize = 0;
            this.helpPrograms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpPrograms.ForeColor = System.Drawing.Color.White;
            this.helpPrograms.Location = new System.Drawing.Point(36, 217);
            this.helpPrograms.Margin = new System.Windows.Forms.Padding(4);
            this.helpPrograms.Name = "helpPrograms";
            this.helpPrograms.Size = new System.Drawing.Size(168, 39);
            this.helpPrograms.TabIndex = 13;
            this.helpPrograms.Text = "Yardım";
            this.helpPrograms.UseVisualStyleBackColor = false;
            this.helpPrograms.Click += new System.EventHandler(this.helpPrograms_Click);
            // 
            // findProgramsBtn
            // 
            this.findProgramsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(91)))), ((int)(((byte)(168)))));
            this.findProgramsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.findProgramsBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(91)))), ((int)(((byte)(168)))));
            this.findProgramsBtn.FlatAppearance.BorderSize = 0;
            this.findProgramsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findProgramsBtn.ForeColor = System.Drawing.Color.White;
            this.findProgramsBtn.Location = new System.Drawing.Point(247, 217);
            this.findProgramsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.findProgramsBtn.Name = "findProgramsBtn";
            this.findProgramsBtn.Size = new System.Drawing.Size(168, 39);
            this.findProgramsBtn.TabIndex = 11;
            this.findProgramsBtn.Text = "Otomatik Bul";
            this.findProgramsBtn.UseVisualStyleBackColor = false;
            this.findProgramsBtn.Click += new System.EventHandler(this.findProgramsBtn_Click);
            // 
            // filePromptButton
            // 
            this.filePromptButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(91)))), ((int)(((byte)(168)))));
            this.filePromptButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filePromptButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.filePromptButton.FlatAppearance.BorderSize = 0;
            this.filePromptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filePromptButton.ForeColor = System.Drawing.Color.White;
            this.filePromptButton.Location = new System.Drawing.Point(459, 217);
            this.filePromptButton.Margin = new System.Windows.Forms.Padding(4);
            this.filePromptButton.Name = "filePromptButton";
            this.filePromptButton.Size = new System.Drawing.Size(168, 39);
            this.filePromptButton.TabIndex = 11;
            this.filePromptButton.Text = "Program Ekle";
            this.filePromptButton.UseVisualStyleBackColor = false;
            this.filePromptButton.Click += new System.EventHandler(this.filePromptButton_Click);
            // 
            // programsList
            // 
            this.programsList.AllowUserToAddRows = false;
            this.programsList.AllowUserToResizeColumns = false;
            this.programsList.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(91)))), ((int)(((byte)(168)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.programsList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.programsList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.programsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.programsList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(91)))), ((int)(((byte)(168)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.programsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.programsList.ColumnHeadersHeight = 30;
            this.programsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.programNameCol,
            this.programPathCol});
            this.programsList.ContextMenuStrip = this.rightClickMenu;
            this.programsList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.programsList.EnableHeadersVisualStyles = false;
            this.programsList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.programsList.Location = new System.Drawing.Point(-56, 0);
            this.programsList.Margin = new System.Windows.Forms.Padding(4);
            this.programsList.Name = "programsList";
            this.programsList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(91)))), ((int)(((byte)(168)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.programsList.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.programsList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(91)))), ((int)(((byte)(168)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.programsList.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.programsList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.programsList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.programsList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(91)))), ((int)(((byte)(168)))));
            this.programsList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.programsList.RowTemplate.Height = 28;
            this.programsList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.programsList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.programsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.programsList.ShowCellErrors = false;
            this.programsList.ShowCellToolTips = false;
            this.programsList.ShowEditingIcon = false;
            this.programsList.ShowRowErrors = false;
            this.programsList.Size = new System.Drawing.Size(727, 209);
            this.programsList.TabIndex = 12;
            this.programsList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.programsList_CellMouseDown);
            this.programsList.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.programsList_RowsRemoved);
            // 
            // programNameCol
            // 
            this.programNameCol.HeaderText = "Program Adı";
            this.programNameCol.MaxInputLength = 100;
            this.programNameCol.Name = "programNameCol";
            this.programNameCol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.programNameCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.programNameCol.Width = 150;
            // 
            // programPathCol
            // 
            this.programPathCol.HeaderText = "Program Dosya Konumu";
            this.programPathCol.MaxInputLength = 1000;
            this.programPathCol.Name = "programPathCol";
            this.programPathCol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.programPathCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.programPathCol.Width = 353;
            // 
            // rightClickMenu
            // 
            this.rightClickMenu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rightClickMenu.ForeColor = System.Drawing.Color.White;
            this.rightClickMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.rightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.silToolStripMenuItem});
            this.rightClickMenu.Name = "rightClickMenu";
            this.rightClickMenu.ShowImageMargin = false;
            this.rightClickMenu.Size = new System.Drawing.Size(73, 32);
            this.rightClickMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.rightClickMenu_ItemClicked);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(72, 28);
            this.silToolStripMenuItem.Text = "Sil";
            // 
            // aboutTab
            // 
            this.aboutTab.AutoScroll = true;
            this.aboutTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.aboutTab.Controls.Add(this.richTextBox2);
            this.aboutTab.Controls.Add(this.richTextBox1);
            this.aboutTab.Controls.Add(this.aboutProjectLink);
            this.aboutTab.Controls.Add(this.flatLabel6);
            this.aboutTab.Controls.Add(this.aboutVersion);
            this.aboutTab.Controls.Add(this.flatLabel4);
            this.aboutTab.Controls.Add(this.flatLabel2);
            this.aboutTab.Controls.Add(this.flatLabel3);
            this.aboutTab.Controls.Add(this.aboutBold3);
            this.aboutTab.Controls.Add(this.aboutBold5);
            this.aboutTab.Controls.Add(this.flatLabel5);
            this.aboutTab.Controls.Add(this.aboutBold6);
            this.aboutTab.Controls.Add(this.flatLabel1);
            this.aboutTab.Controls.Add(this.aboutBold7);
            this.aboutTab.Controls.Add(this.aboutBold4);
            this.aboutTab.Controls.Add(this.aboutBold2);
            this.aboutTab.Controls.Add(this.aboutBold1);
            this.aboutTab.Controls.Add(this.aboutText);
            this.aboutTab.Location = new System.Drawing.Point(4, 44);
            this.aboutTab.Margin = new System.Windows.Forms.Padding(4);
            this.aboutTab.Name = "aboutTab";
            this.aboutTab.Padding = new System.Windows.Forms.Padding(4);
            this.aboutTab.Size = new System.Drawing.Size(671, 274);
            this.aboutTab.TabIndex = 2;
            this.aboutTab.Text = "Hakkında";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.richTextBox2.ForeColor = System.Drawing.Color.White;
            this.richTextBox2.Location = new System.Drawing.Point(225, 535);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox2.Multiline = false;
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(376, 26);
            this.richTextBox2.TabIndex = 18;
            this.richTextBox2.Text = "https://github.com/octokit/octokit.net";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(225, 513);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Multiline = false;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(376, 26);
            this.richTextBox1.TabIndex = 18;
            this.richTextBox1.Text = "https://github.com/saneki-discontinued/FlatUI";
            // 
            // aboutProjectLink
            // 
            this.aboutProjectLink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.aboutProjectLink.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.aboutProjectLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aboutProjectLink.ForeColor = System.Drawing.Color.White;
            this.aboutProjectLink.Location = new System.Drawing.Point(153, 374);
            this.aboutProjectLink.Margin = new System.Windows.Forms.Padding(4);
            this.aboutProjectLink.Multiline = false;
            this.aboutProjectLink.Name = "aboutProjectLink";
            this.aboutProjectLink.Size = new System.Drawing.Size(315, 26);
            this.aboutProjectLink.TabIndex = 18;
            this.aboutProjectLink.Text = "https://github.com/BekirUzun/Otoin";
            // 
            // flatLabel6
            // 
            this.flatLabel6.AutoSize = true;
            this.flatLabel6.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.flatLabel6.ForeColor = System.Drawing.Color.White;
            this.flatLabel6.Location = new System.Drawing.Point(163, 537);
            this.flatLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.flatLabel6.Name = "flatLabel6";
            this.flatLabel6.Size = new System.Drawing.Size(39, 23);
            this.flatLabel6.TabIndex = 17;
            this.flatLabel6.Text = "MIT";
            // 
            // aboutVersion
            // 
            this.aboutVersion.AutoSize = true;
            this.aboutVersion.BackColor = System.Drawing.Color.Transparent;
            this.aboutVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aboutVersion.ForeColor = System.Drawing.Color.White;
            this.aboutVersion.Location = new System.Drawing.Point(363, 414);
            this.aboutVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aboutVersion.Name = "aboutVersion";
            this.aboutVersion.Size = new System.Drawing.Size(45, 23);
            this.aboutVersion.TabIndex = 17;
            this.aboutVersion.Text = "1.0.0";
            // 
            // flatLabel4
            // 
            this.flatLabel4.AutoSize = true;
            this.flatLabel4.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.flatLabel4.ForeColor = System.Drawing.Color.White;
            this.flatLabel4.Location = new System.Drawing.Point(163, 514);
            this.flatLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.flatLabel4.Name = "flatLabel4";
            this.flatLabel4.Size = new System.Drawing.Size(39, 23);
            this.flatLabel4.TabIndex = 17;
            this.flatLabel4.Text = "MIT";
            // 
            // flatLabel2
            // 
            this.flatLabel2.AutoSize = true;
            this.flatLabel2.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.flatLabel2.ForeColor = System.Drawing.Color.White;
            this.flatLabel2.Location = new System.Drawing.Point(163, 491);
            this.flatLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.flatLabel2.Name = "flatLabel2";
            this.flatLabel2.Size = new System.Drawing.Size(56, 23);
            this.flatLabel2.TabIndex = 17;
            this.flatLabel2.Text = "GPL-3";
            // 
            // flatLabel3
            // 
            this.flatLabel3.AutoSize = true;
            this.flatLabel3.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.flatLabel3.ForeColor = System.Drawing.Color.White;
            this.flatLabel3.Location = new System.Drawing.Point(127, 414);
            this.flatLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.flatLabel3.Name = "flatLabel3";
            this.flatLabel3.Size = new System.Drawing.Size(92, 23);
            this.flatLabel3.TabIndex = 17;
            this.flatLabel3.Text = "Bekir Uzun";
            // 
            // aboutBold3
            // 
            this.aboutBold3.AutoSize = true;
            this.aboutBold3.BackColor = System.Drawing.Color.Transparent;
            this.aboutBold3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aboutBold3.ForeColor = System.Drawing.Color.White;
            this.aboutBold3.Location = new System.Drawing.Point(25, 375);
            this.aboutBold3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aboutBold3.Name = "aboutBold3";
            this.aboutBold3.Size = new System.Drawing.Size(117, 23);
            this.aboutBold3.TabIndex = 1;
            this.aboutBold3.Text = "Proje Sayfası:";
            this.aboutBold3.UseWaitCursor = true;
            // 
            // aboutBold5
            // 
            this.aboutBold5.AutoSize = true;
            this.aboutBold5.BackColor = System.Drawing.Color.Transparent;
            this.aboutBold5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aboutBold5.ForeColor = System.Drawing.Color.White;
            this.aboutBold5.Location = new System.Drawing.Point(265, 414);
            this.aboutBold5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aboutBold5.Name = "aboutBold5";
            this.aboutBold5.Size = new System.Drawing.Size(87, 23);
            this.aboutBold5.TabIndex = 1;
            this.aboutBold5.Text = "Versiyon: ";
            // 
            // flatLabel5
            // 
            this.flatLabel5.AutoSize = true;
            this.flatLabel5.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.flatLabel5.ForeColor = System.Drawing.Color.White;
            this.flatLabel5.Location = new System.Drawing.Point(25, 537);
            this.flatLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.flatLabel5.Name = "flatLabel5";
            this.flatLabel5.Size = new System.Drawing.Size(108, 23);
            this.flatLabel5.TabIndex = 1;
            this.flatLabel5.Text = "octokit.net :";
            // 
            // aboutBold6
            // 
            this.aboutBold6.AutoSize = true;
            this.aboutBold6.BackColor = System.Drawing.Color.Transparent;
            this.aboutBold6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aboutBold6.ForeColor = System.Drawing.Color.White;
            this.aboutBold6.Location = new System.Drawing.Point(8, 450);
            this.aboutBold6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aboutBold6.Name = "aboutBold6";
            this.aboutBold6.Size = new System.Drawing.Size(94, 28);
            this.aboutBold6.TabIndex = 1;
            this.aboutBold6.Text = "Lisanslar";
            // 
            // flatLabel1
            // 
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.flatLabel1.ForeColor = System.Drawing.Color.White;
            this.flatLabel1.Location = new System.Drawing.Point(25, 514);
            this.flatLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(67, 23);
            this.flatLabel1.TabIndex = 1;
            this.flatLabel1.Text = "FlatUI :";
            // 
            // aboutBold7
            // 
            this.aboutBold7.AutoSize = true;
            this.aboutBold7.BackColor = System.Drawing.Color.Transparent;
            this.aboutBold7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aboutBold7.ForeColor = System.Drawing.Color.White;
            this.aboutBold7.Location = new System.Drawing.Point(25, 491);
            this.aboutBold7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aboutBold7.Name = "aboutBold7";
            this.aboutBold7.Size = new System.Drawing.Size(122, 23);
            this.aboutBold7.TabIndex = 1;
            this.aboutBold7.Text = "Otoin Lisansı :";
            // 
            // aboutBold4
            // 
            this.aboutBold4.AutoSize = true;
            this.aboutBold4.BackColor = System.Drawing.Color.Transparent;
            this.aboutBold4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aboutBold4.ForeColor = System.Drawing.Color.White;
            this.aboutBold4.Location = new System.Drawing.Point(25, 414);
            this.aboutBold4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aboutBold4.Name = "aboutBold4";
            this.aboutBold4.Size = new System.Drawing.Size(90, 23);
            this.aboutBold4.TabIndex = 1;
            this.aboutBold4.Text = "Geliştirici:";
            // 
            // aboutBold2
            // 
            this.aboutBold2.AutoSize = true;
            this.aboutBold2.BackColor = System.Drawing.Color.Transparent;
            this.aboutBold2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aboutBold2.ForeColor = System.Drawing.Color.White;
            this.aboutBold2.Location = new System.Drawing.Point(8, 174);
            this.aboutBold2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aboutBold2.Name = "aboutBold2";
            this.aboutBold2.Size = new System.Drawing.Size(146, 25);
            this.aboutBold2.TabIndex = 1;
            this.aboutBold2.Text = "Nasıl kullanılır?";
            // 
            // aboutBold1
            // 
            this.aboutBold1.BackColor = System.Drawing.Color.Transparent;
            this.aboutBold1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aboutBold1.ForeColor = System.Drawing.Color.White;
            this.aboutBold1.Location = new System.Drawing.Point(8, 7);
            this.aboutBold1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aboutBold1.Name = "aboutBold1";
            this.aboutBold1.Size = new System.Drawing.Size(153, 25);
            this.aboutBold1.TabIndex = 1;
            this.aboutBold1.Text = "Otoin nedir?";
            // 
            // aboutText
            // 
            this.aboutText.BackColor = System.Drawing.Color.Transparent;
            this.aboutText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutText.ForeColor = System.Drawing.Color.White;
            this.aboutText.Location = new System.Drawing.Point(24, 37);
            this.aboutText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aboutText.Name = "aboutText";
            this.aboutText.Size = new System.Drawing.Size(579, 537);
            this.aboutText.TabIndex = 16;
            this.aboutText.Text = resources.GetString("aboutText.Text");
            // 
            // bgTop
            // 
            this.bgTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.bgTop.ForeColor = System.Drawing.Color.White;
            this.bgTop.Location = new System.Drawing.Point(16, 114);
            this.bgTop.Margin = new System.Windows.Forms.Padding(4);
            this.bgTop.Name = "bgTop";
            this.bgTop.Size = new System.Drawing.Size(668, 5);
            this.bgTop.TabIndex = 17;
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeBtn.BackColor = System.Drawing.Color.White;
            this.minimizeBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.minimizeBtn.Font = new System.Drawing.Font("Marlett", 12F);
            this.minimizeBtn.Location = new System.Drawing.Point(628, 15);
            this.minimizeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(18, 18);
            this.minimizeBtn.TabIndex = 15;
            this.minimizeBtn.Text = "flatMini1";
            this.minimizeBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // message
            // 
            this.message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.message.Cursor = System.Windows.Forms.Cursors.Hand;
            this.message.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.message.kind = FlatUI.FlatAlertBox._Kind.Success;
            this.message.Location = new System.Drawing.Point(16, 395);
            this.message.Margin = new System.Windows.Forms.Padding(4);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(668, 42);
            this.message.TabIndex = 9;
            this.message.Text = "Bilgilendirme...";
            this.message.Visible = false;
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.BackColor = System.Drawing.Color.White;
            this.closeBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.closeBtn.Font = new System.Drawing.Font("Marlett", 10F);
            this.closeBtn.Location = new System.Drawing.Point(660, 15);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(18, 18);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = "kapat";
            this.closeBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.closeBtn.Click += new System.EventHandler(this.close_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(0, 62);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(700, 400);
            this.panel3.TabIndex = 16;
            // 
            // blur
            // 
            this.blur.BackColor = System.Drawing.Color.Transparent;
            this.blur.InitialImage = global::Otoin.Properties.Resources.shadow;
            this.blur.Location = new System.Drawing.Point(0, 0);
            this.blur.Margin = new System.Windows.Forms.Padding(4);
            this.blur.Name = "blur";
            this.blur.Size = new System.Drawing.Size(700, 462);
            this.blur.TabIndex = 18;
            this.blur.TabStop = false;
            this.blur.Visible = false;
            // 
            // programPrompt
            // 
            this.programPrompt.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "Otoin";
            this.notifyIcon.BalloonTipTitle = "Otoin";
            this.notifyIcon.Icon = global::Otoin.Properties.Resources.icon;
            this.notifyIcon.Text = "Otoin";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // Otoin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(700, 462);
            this.Controls.Add(this.skin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::Otoin.Properties.Resources.icon;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Otoin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Otoin";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.skin.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.settingsTab.ResumeLayout(false);
            this.settingsTab.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.noNetBG.ResumeLayout(false);
            this.noNetBG.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.programsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.programsList)).EndInit();
            this.rightClickMenu.ResumeLayout(false);
            this.aboutTab.ResumeLayout(false);
            this.aboutTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blur)).EndInit();
            this.ResumeLayout(false);

        }

        private void ProgramsList_RowsRemoved(object sender, System.Windows.Forms.DataGridViewRowsRemovedEventArgs e) {
            throw new System.NotImplementedException();
        }

        #endregion

        private FlatUI.FormSkin skin;
        private FlatUI.FlatClose closeBtn;
        private FlatUI.FlatLabel stopLabel;
        private FlatUI.FlatLabel startLabel;
        private FlatUI.FlatAlertBox message;
        private System.Windows.Forms.Button actionButton;
        private System.Windows.Forms.OpenFileDialog programPrompt;
        private System.Windows.Forms.Button hideButton;
        private System.Windows.Forms.Button filePromptButton;
        private System.Windows.Forms.TextBox stopTB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox startTB;
        private FlatUI.FlatTabControl tabControl;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.TabPage programsTab;
        private System.Windows.Forms.DataGridView programsList;
        private FlatUI.FlatMini minimizeBtn;
        private System.Windows.Forms.TabPage aboutTab;
        private FlatUI.FlatLabel aboutBold2;
        private FlatUI.FlatLabel aboutBold1;
        private System.Windows.Forms.Label aboutText;
        private System.Windows.Forms.RichTextBox aboutProjectLink;
        private FlatUI.FlatLabel flatLabel3;
        private FlatUI.FlatLabel aboutBold3;
        private FlatUI.FlatLabel aboutBold4;
        private FlatUI.FlatLabel aboutVersion;
        private FlatUI.FlatLabel aboutBold5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private FlatUI.FlatLabel flatLabel4;
        private FlatUI.FlatLabel flatLabel2;
        private FlatUI.FlatLabel aboutBold6;
        private FlatUI.FlatLabel flatLabel1;
        private FlatUI.FlatLabel aboutBold7;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private FlatUI.FlatLabel flatLabel6;
        private FlatUI.FlatLabel flatLabel5;
        private FlatUI.FlatRadioButton modeSleep;
        private FlatUI.FlatRadioButton modeNormal;
        private FlatUI.FlatLabel flatLabel7;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel bgTop;
        private System.Windows.Forms.DataGridViewTextBoxColumn programNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn programPathCol;
        private System.Windows.Forms.Button findProgramsBtn;
        private System.Windows.Forms.Button helpSettings;
        private System.Windows.Forms.Button helpPrograms;
        private FlatUI.FlatComboBox stopAction;
        private FlatUI.FlatLabel flatLabel8;
        private System.Windows.Forms.PictureBox blur;
        private FlatUI.FlatContextMenuStrip rightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.Button sleepButton;
        private FlatUI.FlatLabel sleepDisabled;
        private FlatUI.FlatToggle noNetToggle;
        private FlatUI.FlatLabel flatLabel9;
        private System.Windows.Forms.Panel noNetBG;
        private System.Windows.Forms.TextBox noNetTimeTB;
        private FlatUI.FlatLabel noNetLabel;
    }
}

