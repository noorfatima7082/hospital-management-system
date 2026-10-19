namespace Hospital_Management_System
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            label1 = new Label();
            label2 = new Label();
            passwordtext = new TextBox();
            loginbutton = new Button();
            label3 = new Label();
            checkBox1 = new CheckBox();
            label4 = new Label();
            usernametext = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(253, 154);
            label1.Name = "label1";
            label1.Size = new Size(81, 21);
            label1.TabIndex = 2;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(253, 213);
            label2.Name = "label2";
            label2.Size = new Size(76, 21);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // passwordtext
            // 
            passwordtext.Anchor = AnchorStyles.None;
            passwordtext.Font = new Font("Segoe UI", 12F);
            passwordtext.Location = new Point(349, 210);
            passwordtext.Name = "passwordtext";
            passwordtext.PlaceholderText = "Enter Password";
            passwordtext.Size = new Size(186, 29);
            passwordtext.TabIndex = 1;
            passwordtext.UseSystemPasswordChar = true;
            // 
            // loginbutton
            // 
            loginbutton.Anchor = AnchorStyles.None;
            loginbutton.BackColor = SystemColors.Control;
            loginbutton.Font = new Font("Segoe UI", 11F);
            loginbutton.Location = new Point(248, 275);
            loginbutton.Name = "loginbutton";
            loginbutton.Size = new Size(287, 31);
            loginbutton.TabIndex = 4;
            loginbutton.Text = "Login";
            loginbutton.UseVisualStyleBackColor = false;
            loginbutton.Click += loginbutton_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(431, 244);
            label3.Name = "label3";
            label3.Size = new Size(92, 14);
            label3.TabIndex = 5;
            label3.Text = "Show Password";
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.None;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(410, 244);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 6;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Arial", 15F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(211, 25);
            label4.Name = "label4";
            label4.Size = new Size(383, 23);
            label4.TabIndex = 7;
            label4.Text = "Welcome to Hospital Management System";
            // 
            // usernametext
            // 
            usernametext.Font = new Font("Segoe UI", 12F);
            usernametext.Location = new Point(349, 151);
            usernametext.Name = "usernametext";
            usernametext.PlaceholderText = "Enter Username";
            usernametext.Size = new Size(186, 29);
            usernametext.TabIndex = 0;
            // 
            // Form2
            // 
            AccessibleRole = AccessibleRole.TitleBar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(usernametext);
            Controls.Add(label4);
            Controls.Add(checkBox1);
            Controls.Add(label3);
            Controls.Add(loginbutton);
            Controls.Add(passwordtext);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form2";
            Text = " ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox passwordtext;
        private Button loginbutton;
        private Label label3;
        private CheckBox checkBox1;
        private Label label4;
        private TextBox usernametext;
    }
}