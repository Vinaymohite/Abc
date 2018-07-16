namespace Pet_Shop_Management
{
    partial class USER_LOGIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USER_LOGIN));
            this.Label4 = new System.Windows.Forms.Label();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtpsw = new System.Windows.Forms.TextBox();
            this.txtus = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Algerian", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(668, 137);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(228, 41);
            this.Label4.TabIndex = 17;
            this.Label4.Text = "USER LOGIN";
            // 
            // Button3
            // 
            this.Button3.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button3.Location = new System.Drawing.Point(805, 371);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(111, 51);
            this.Button3.TabIndex = 16;
            this.Button3.Text = "CANCEL";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Location = new System.Drawing.Point(670, 371);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(111, 51);
            this.Button1.TabIndex = 14;
            this.Button1.Text = "LOGIN";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Castellar", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(633, 308);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(131, 23);
            this.Label2.TabIndex = 13;
            this.Label2.Text = "Password";
            // 
            // txtpsw
            // 
            this.txtpsw.Location = new System.Drawing.Point(774, 308);
            this.txtpsw.Name = "txtpsw";
            this.txtpsw.PasswordChar = '*';
            this.txtpsw.Size = new System.Drawing.Size(122, 20);
            this.txtpsw.TabIndex = 12;
            // 
            // txtus
            // 
            this.txtus.BackColor = System.Drawing.Color.White;
            this.txtus.Location = new System.Drawing.Point(774, 257);
            this.txtus.Name = "txtus";
            this.txtus.Size = new System.Drawing.Size(122, 20);
            this.txtus.TabIndex = 11;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Castellar", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(619, 253);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(140, 23);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "User Name";
            // 
            // USER_LOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(963, 476);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtpsw);
            this.Controls.Add(this.txtus);
            this.Controls.Add(this.Label1);
            this.Name = "USER_LOGIN";
            this.Text = "LOGIN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.USER_LOGIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtpsw;
        internal System.Windows.Forms.TextBox txtus;
        internal System.Windows.Forms.Label Label1;
    }
}

