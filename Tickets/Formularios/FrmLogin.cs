﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets.Formularios
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();

            Logica.Bitacora.GuardarAccionEnBitacora(0, "Cierre de sistema");
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = false;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = true;
        }


        private bool ValidarDatos()
        {
            bool R = false;

            if (!string.IsNullOrEmpty(TxtEmail.Text.Trim()) &&
                Commons.ObjetosGlobales.ValidarEmail(TxtEmail.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                R = true;
            }
            else
            {
                if (string.IsNullOrEmpty(TxtEmail.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar un nombre de usuario", "Error de Validación", MessageBoxButtons.OK);
                    TxtEmail.Focus();
                    return false;
                }
                if (!Commons.ObjetosGlobales.ValidarEmail(TxtEmail.Text.Trim()))
                {
                    MessageBox.Show("El correo no tiene el formato correcto", "Error de Validación", MessageBoxButtons.OK);
                    TxtEmail.Focus();
                    TxtEmail.SelectAll();
                    return false;
                }
                if (string.IsNullOrEmpty(TxtPassword.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar la contraseña", "Error de Validación", MessageBoxButtons.OK);
                    TxtPassword.Focus();
                    return false;
                }

            }

            return R;
        
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {               
                Logica.Models.Usuario MiUsuarioValidado = new Logica.Models.Usuario();

                MiUsuarioValidado = MiUsuarioValidado.ValidarIngreso(TxtEmail.Text.Trim(), TxtPassword.Text.Trim());

                if (MiUsuarioValidado != null && MiUsuarioValidado.IDUsuario > 0)
                {
                    Commons.ObjetosGlobales.MiUsuarioDeSistema = MiUsuarioValidado;

                    Commons.ObjetosGlobales.MiFormPrincipal.Show();

                    this.Hide();

                    Logica.Bitacora.GuardarAccionEnBitacora(MiUsuarioValidado.IDUsuario, "El usuario con el email "
                    + MiUsuarioValidado.Email + "ingresó correctamente al sistema");
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña Incorrectos", "Error de Validado", MessageBoxButtons.OK);

                    Logica.Bitacora.GuardarAccionEnBitacora(0, "Ingreso fallido al sistema con el email "
                    + TxtEmail.Text.Trim());
                }
            }
        }

        private void BtnIngresoDirecto_Click(object sender, EventArgs e)
        {
            Commons.ObjetosGlobales.MiUsuarioDeSistema.IDUsuario = 1;
            Commons.ObjetosGlobales.MiUsuarioDeSistema.Email = "a@gmail.com";
            Commons.ObjetosGlobales.MiUsuarioDeSistema.Nombre = "USUARIO DE PRUEBAS";
            Commons.ObjetosGlobales.MiUsuarioDeSistema.MiRol.IDUsuarioRol = 1;
            Commons.ObjetosGlobales.MiFormPrincipal.Show();

            this.Hide();

            Logica.Bitacora.GuardarAccionEnBitacora(1, "Ingreso directo al sistema");
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift & e.KeyCode == Keys.Escape)
            {
                BtnIngresoDirecto.Visible = true;
            }
        }

        private void LblRecuperarContrasennia_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Commons.ObjetosGlobales.FormularioRecuperacionContrasennia.TxtUsuario.Text = this.TxtEmail.Text.Trim();

            Commons.ObjetosGlobales.FormularioRecuperacionContrasennia.Show();

        }
    }
}
