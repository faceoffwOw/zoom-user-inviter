namespace zoom
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_create = new System.Windows.Forms.Button();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_surname = new System.Windows.Forms.TextBox();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.textBox_departament = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.textBox_personnel_number = new System.Windows.Forms.TextBox();
            this.textBox_network_name = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.upload_photo_manually = new System.Windows.Forms.CheckBox();
            this.check_email = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_create
            // 
            this.button_create.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_create.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(160)))), ((int)(((byte)(248)))));
            this.button_create.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(196)))), ((int)(((byte)(242)))));
            this.button_create.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(215)))), ((int)(((byte)(254)))));
            this.button_create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_create.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_create.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(160)))), ((int)(((byte)(248)))));
            this.button_create.Image = ((System.Drawing.Image)(resources.GetObject("button_create.Image")));
            this.button_create.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_create.Location = new System.Drawing.Point(186, 282);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(198, 55);
            this.button_create.TabIndex = 8;
            this.button_create.Text = "Добавить\r\nпользователя";
            this.button_create.UseVisualStyleBackColor = false;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(78, 193);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.PlaceholderText = "Имя";
            this.textBox_name.Size = new System.Drawing.Size(306, 23);
            this.textBox_name.TabIndex = 5;
            // 
            // textBox_surname
            // 
            this.textBox_surname.Location = new System.Drawing.Point(78, 164);
            this.textBox_surname.Name = "textBox_surname";
            this.textBox_surname.PlaceholderText = "Фамилия";
            this.textBox_surname.Size = new System.Drawing.Size(306, 23);
            this.textBox_surname.TabIndex = 4;
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(78, 135);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.PlaceholderText = "Почта";
            this.textBox_email.Size = new System.Drawing.Size(306, 23);
            this.textBox_email.TabIndex = 3;
            // 
            // textBox_departament
            // 
            this.textBox_departament.Location = new System.Drawing.Point(78, 223);
            this.textBox_departament.Name = "textBox_departament";
            this.textBox_departament.PlaceholderText = "Отдел";
            this.textBox_departament.Size = new System.Drawing.Size(306, 23);
            this.textBox_departament.TabIndex = 6;
            // 
            // button_search
            // 
            this.button_search.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_search.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(160)))), ((int)(((byte)(248)))));
            this.button_search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(196)))), ((int)(((byte)(242)))));
            this.button_search.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(215)))), ((int)(((byte)(254)))));
            this.button_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_search.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(160)))), ((int)(((byte)(248)))));
            this.button_search.Image = ((System.Drawing.Image)(resources.GetObject("button_search.Image")));
            this.button_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_search.Location = new System.Drawing.Point(186, 74);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(198, 55);
            this.button_search.TabIndex = 2;
            this.button_search.Text = "Поиск";
            this.button_search.UseCompatibleTextRendering = true;
            this.button_search.UseVisualStyleBackColor = false;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // textBox_personnel_number
            // 
            this.textBox_personnel_number.Location = new System.Drawing.Point(78, 253);
            this.textBox_personnel_number.Name = "textBox_personnel_number";
            this.textBox_personnel_number.PlaceholderText = "Таб. номер";
            this.textBox_personnel_number.Size = new System.Drawing.Size(306, 23);
            this.textBox_personnel_number.TabIndex = 7;
            // 
            // textBox_network_name
            // 
            this.textBox_network_name.Location = new System.Drawing.Point(78, 45);
            this.textBox_network_name.Name = "textBox_network_name";
            this.textBox_network_name.PlaceholderText = "Сетевое имя";
            this.textBox_network_name.Size = new System.Drawing.Size(306, 23);
            this.textBox_network_name.TabIndex = 1;
            this.textBox_network_name.TextChanged += new System.EventHandler(this.textBox_network_name_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(444, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(231, 231);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // upload_photo_manually
            // 
            this.upload_photo_manually.AutoSize = true;
            this.upload_photo_manually.Location = new System.Drawing.Point(456, 301);
            this.upload_photo_manually.Name = "upload_photo_manually";
            this.upload_photo_manually.Size = new System.Drawing.Size(205, 19);
            this.upload_photo_manually.TabIndex = 9;
            this.upload_photo_manually.Text = "Добавить фотографию вручную";
            this.upload_photo_manually.UseVisualStyleBackColor = true;
            // 
            // check_email
            // 
            this.check_email.Location = new System.Drawing.Point(78, 289);
            this.check_email.Name = "check_email";
            this.check_email.Size = new System.Drawing.Size(104, 42);
            this.check_email.TabIndex = 10;
            this.check_email.Text = "Нет внешней почты";
            this.check_email.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.check_email);
            this.Controls.Add(this.upload_photo_manually);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_network_name);
            this.Controls.Add(this.textBox_personnel_number);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.textBox_departament);
            this.Controls.Add(this.textBox_email);
            this.Controls.Add(this.textBox_surname);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.button_create);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zoom IT";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_surname;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.TextBox textBox_departament;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.TextBox textBox_personnel_number;
        private System.Windows.Forms.TextBox textBox_network_name;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox upload_photo_manually;
        private System.Windows.Forms.CheckBox check_email;
    }
}

