namespace Otoin {
    partial class UpdateForm {
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
            this.bgBack = new System.Windows.Forms.Panel();
            this.bgFront = new System.Windows.Forms.Panel();
            this.text = new FlatUI.FlatLabel();
            this.openButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.neverButton = new System.Windows.Forms.Button();
            this.skin = new FlatUI.FormSkin();
            this.bgBack.SuspendLayout();
            this.skin.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgBack
            // 
            this.bgBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.bgBack.Controls.Add(this.bgFront);
            this.bgBack.ForeColor = System.Drawing.Color.White;
            this.bgBack.Location = new System.Drawing.Point(0, 49);
            this.bgBack.Name = "bgBack";
            this.bgBack.Size = new System.Drawing.Size(462, 126);
            this.bgBack.TabIndex = 18;
            // 
            // bgFront
            // 
            this.bgFront.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.bgFront.ForeColor = System.Drawing.Color.White;
            this.bgFront.Location = new System.Drawing.Point(5, 5);
            this.bgFront.Name = "bgFront";
            this.bgFront.Size = new System.Drawing.Size(452, 116);
            this.bgFront.TabIndex = 19;
            // 
            // text
            // 
            this.text.BackColor = System.Drawing.Color.Transparent;
            this.text.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.text.ForeColor = System.Drawing.Color.White;
            this.text.Location = new System.Drawing.Point(12, 67);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(438, 41);
            this.text.TabIndex = 0;
            this.text.Text = "Programın eski bir sürümünü kullanıyorsunuz. Yeni sürümü indirmek için web sitesi" +
    " açılsın mı?";
            // 
            // openButton
            // 
            this.openButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.openButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.openButton.FlatAppearance.BorderSize = 0;
            this.openButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openButton.ForeColor = System.Drawing.Color.White;
            this.openButton.Location = new System.Drawing.Point(29, 129);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(100, 32);
            this.openButton.TabIndex = 12;
            this.openButton.Text = "Evet";
            this.openButton.UseVisualStyleBackColor = false;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // noButton
            // 
            this.noButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(91)))), ((int)(((byte)(168)))));
            this.noButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.noButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.noButton.FlatAppearance.BorderSize = 0;
            this.noButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noButton.ForeColor = System.Drawing.Color.White;
            this.noButton.Location = new System.Drawing.Point(179, 129);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(100, 32);
            this.noButton.TabIndex = 13;
            this.noButton.Text = "Hayır";
            this.noButton.UseVisualStyleBackColor = false;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // neverButton
            // 
            this.neverButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.neverButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.neverButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.neverButton.FlatAppearance.BorderSize = 0;
            this.neverButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.neverButton.ForeColor = System.Drawing.Color.White;
            this.neverButton.Location = new System.Drawing.Point(327, 129);
            this.neverButton.Name = "neverButton";
            this.neverButton.Size = new System.Drawing.Size(100, 32);
            this.neverButton.TabIndex = 14;
            this.neverButton.Text = "Asla";
            this.neverButton.UseVisualStyleBackColor = false;
            this.neverButton.Click += new System.EventHandler(this.neverButton_Click);
            // 
            // skin
            // 
            this.skin.BackColor = System.Drawing.Color.White;
            this.skin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.skin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.skin.Controls.Add(this.neverButton);
            this.skin.Controls.Add(this.noButton);
            this.skin.Controls.Add(this.openButton);
            this.skin.Controls.Add(this.text);
            this.skin.Controls.Add(this.bgBack);
            this.skin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skin.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.skin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.skin.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.skin.HeaderMaximize = false;
            this.skin.Location = new System.Drawing.Point(0, 0);
            this.skin.Name = "skin";
            this.skin.Size = new System.Drawing.Size(462, 175);
            this.skin.TabIndex = 0;
            this.skin.Text = "Mesaj";
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 175);
            this.Controls.Add(this.skin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomMessageBox";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.bgBack.ResumeLayout(false);
            this.skin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bgBack;
        private System.Windows.Forms.Panel bgFront;
        private FlatUI.FlatLabel text;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Button neverButton;
        private FlatUI.FormSkin skin;
    }
}