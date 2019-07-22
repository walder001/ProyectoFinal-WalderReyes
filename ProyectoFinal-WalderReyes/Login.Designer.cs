namespace Proyecto
{
	partial class Login
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
			this.btnEntrer = new System.Windows.Forms.Button();
			this.labLogin = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUse = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.btnClose = new System.Windows.Forms.PictureBox();
			this.btnMinimizar = new System.Windows.Forms.PictureBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
			this.SuspendLayout();
			// 
			// btnEntrer
			// 
			this.btnEntrer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnEntrer.FlatAppearance.BorderSize = 0;
			this.btnEntrer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
			this.btnEntrer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btnEntrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEntrer.Font = new System.Drawing.Font("Museo Sans For Dell", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEntrer.ForeColor = System.Drawing.Color.DarkGray;
			this.btnEntrer.Location = new System.Drawing.Point(351, 211);
			this.btnEntrer.Name = "btnEntrer";
			this.btnEntrer.Size = new System.Drawing.Size(319, 40);
			this.btnEntrer.TabIndex = 3;
			this.btnEntrer.Text = "Acceder";
			this.btnEntrer.UseVisualStyleBackColor = false;
			this.btnEntrer.Click += new System.EventHandler(this.btnAcceder_Click);
			// 
			// labLogin
			// 
			this.labLogin.AutoSize = true;
			this.labLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labLogin.ForeColor = System.Drawing.Color.DarkGray;
			this.labLogin.Location = new System.Drawing.Point(474, 60);
			this.labLogin.Name = "labLogin";
			this.labLogin.Size = new System.Drawing.Size(59, 20);
			this.labLogin.TabIndex = 7;
			this.labLogin.Text = "LOGIN";
			// 
			// txtPassword
			// 
			this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
			this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtPassword.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPassword.ForeColor = System.Drawing.Color.DarkGray;
			this.txtPassword.Location = new System.Drawing.Point(351, 158);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(319, 16);
			this.txtPassword.TabIndex = 2;
			this.txtPassword.Text = "CONTRASEÑA: ";
			this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
			this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
			// 
			// txtUse
			// 
			this.txtUse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
			this.txtUse.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtUse.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUse.ForeColor = System.Drawing.Color.DarkGray;
			this.txtUse.Location = new System.Drawing.Point(351, 109);
			this.txtUse.Name = "txtUse";
			this.txtUse.Size = new System.Drawing.Size(319, 16);
			this.txtUse.TabIndex = 1;
			this.txtUse.Text = "USUARIO: ";
			this.txtUse.TextChanged += new System.EventHandler(this.txtUse_TextChanged);
			this.txtUse.Enter += new System.EventHandler(this.txtUse_Enter);
			this.txtUse.Leave += new System.EventHandler(this.txtUse_Leave);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
			this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.panel2.Controls.Add(this.pictureBox3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(250, 330);
			this.panel2.TabIndex = 5;
			// 
			// pictureBox3
			// 
			this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
			this.pictureBox3.Location = new System.Drawing.Point(12, 109);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(235, 142);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox3.TabIndex = 0;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
			// 
			// btnClose
			// 
			this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
			this.btnClose.Location = new System.Drawing.Point(700, 8);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(38, 37);
			this.btnClose.TabIndex = 9;
			this.btnClose.TabStop = false;
			this.btnClose.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// btnMinimizar
			// 
			this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
			this.btnMinimizar.Location = new System.Drawing.Point(656, 8);
			this.btnMinimizar.Name = "btnMinimizar";
			this.btnMinimizar.Size = new System.Drawing.Size(38, 37);
			this.btnMinimizar.TabIndex = 10;
			this.btnMinimizar.TabStop = false;
			this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.LinkColor = System.Drawing.Color.DarkGray;
			this.linkLabel1.Location = new System.Drawing.Point(457, 264);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(119, 13);
			this.linkLabel1.TabIndex = 0;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Olvidaste tu contraseña";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// Login
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
			this.ClientSize = new System.Drawing.Size(750, 330);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.btnMinimizar);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnEntrer);
			this.Controls.Add(this.labLogin);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUse);
			this.Controls.Add(this.panel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Login";
			this.Opacity = 0.9D;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "i";
			this.Load += new System.EventHandler(this.Login_Load);
			this.Leave += new System.EventHandler(this.Login_Leave);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnEntrer;
		private System.Windows.Forms.Label labLogin;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtUse;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.PictureBox btnClose;
		private System.Windows.Forms.PictureBox btnMinimizar;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.PictureBox pictureBox3;
	}
}

