﻿using BLL;
using DAL;
using Entidades;
using ProyectoFinal_WalderReyes;
using ProyectoFinal_WalderReyes.UI.Reporte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Consulta
{
    public partial class cUsuario : Form
    {
        private List<Usuarios> ListarUsuarios = new List<Usuarios>();
        List<Usuarios> lista = new List<Usuarios>();
        public cUsuario()
        {
            InitializeComponent();
        }

        private void DgvConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Expression<Func<Usuarios, bool>> filtro = x => true;

            switch (cbFiltro.SelectedIndex)
            {
                case 0://ID
                    filtro = x => true;
                    break;
                case 1://Usuario
                    
                  
                    break;
                case 2://Nombre
                    filtro = x => x.Nombres.Contains(txtCriterio.Text)
                    &&
                    (x.FehaIngreso >= DesdedateTimePicker.Value && x.FehaIngreso <= dateTimePicker2.Value);
                    break;
                case 3://Email
                    filtro = x => x.Email.Contains(txtCriterio.Text)
                    &&
                    (x.FehaIngreso >= DesdedateTimePicker.Value && x.FehaIngreso <= dateTimePicker2.Value);
                    break;
                case 4://Nombre
                    int nivel = Convert.ToInt32(txtCriterio.Text);
                    filtro = x => x.NivelUsuario == nivel
                    &&
                    (x.FehaIngreso >= DesdedateTimePicker.Value && x.FehaIngreso <= dateTimePicker2.Value);
                    break;
                case 5://Email
                    filtro = x => x.Usuario.Contains(txtCriterio.Text)
                    &&
                    (x.FehaIngreso >= DesdedateTimePicker.Value && x.FehaIngreso <= dateTimePicker2.Value);
                    break;


            }

            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>(new Contexto());
            ListarUsuarios = repositorio.GetList(filtro);
            dgvConsulta.DataSource = ListarUsuarios;

        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            if (ListarUsuarios.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir");
                return;
            }
            
                UsuarioReportyView r = new UsuarioReportyView(ListarUsuarios);
                r.ShowDialog();
            
            
           /*if(ListarUsuarios.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir");
                return;
            }
            else
            {
                ReporteUsuario r = new ReporteUsuario(ListarUsuarios);
                r.ShowDialog();
            }*/
            
        }

        private void CbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
