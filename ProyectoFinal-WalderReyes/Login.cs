using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
	public partial class Login : Form
	{
		public Login()
		{
			InitializeComponent();
		}

		private void txtUse_Enter(object sender, EventArgs e)
		{
			if (txtUse.Text == "USUARIO: ")
			{
				txtUse.Text = "";
				txtUse.ForeColor = Color.LightGray;

			}
		}

		private void txtUse_Leave(object sender, EventArgs e)
		{
			if (txtUse.Text == "")
			{
				txtUse.Text = "USUARIO: ";
				txtUse.ForeColor = Color.DimGray;
			}
		}

		private void txtPassword_Enter(object sender, EventArgs e)
		{
			if (txtPassword.Text == "CONTRASEÑA: ")
			{
				txtPassword.Text = "";
				txtPassword.ForeColor = Color.LightGray;
				txtPassword.UseSystemPasswordChar = true;
			}
		}

		private void txtPassword_Leave(object sender, EventArgs e)
		{
			if (txtPassword.Text == "")
			{
				txtPassword.Text = "CONTRASEÑA: ";
				txtPassword.ForeColor = Color.DimGray;
				txtPassword.UseSystemPasswordChar = false;

			}
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{

		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{

		}

		private void btnAcceder_Click(object sender, EventArgs e)
		{
		
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void txtUse_TextChanged(object sender, EventArgs e)
		{
			
		}

		private void btnMinimizar_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void Login_Load(object sender, EventArgs e)
		{

		}

		private void Login_Leave(object sender, EventArgs e)
		{

		}
	}
}
