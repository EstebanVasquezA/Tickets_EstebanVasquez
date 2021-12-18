using System;
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
    public partial class FrmUsuarioGestion : Form
    {
        private Logica.Models.Usuario MiUsuarioLocal { get; set; }

        private DataTable ListaUsuarios { get; set; }
       
        public FrmUsuarioGestion()
        {
            InitializeComponent();

            MiUsuarioLocal = new Logica.Models.Usuario();

            ListaUsuarios = new DataTable();
           
        }

        private void FrmUsuarioGestion_Load(object sender, EventArgs e)
        {
            CargarComboRoles();

            LlenarListaUsuarios(CboxVerActivos.Checked);

            LimpiarFormulario();
        }

        private void LlenarListaUsuarios(bool VerActivos, string FiltroBusqueda = "")
        {
            string Filtro = "";

            if (!string.IsNullOrEmpty(FiltroBusqueda) &&
                FiltroBusqueda != "Buscar..." )
            {
                Filtro = FiltroBusqueda;
            }
                        
            ListaUsuarios = MiUsuarioLocal.Listar(VerActivos, Filtro);

            DgvListaUsuarios.DataSource = ListaUsuarios;

            DgvListaUsuarios.ClearSelection();

        }

        private void CargarComboRoles()
        {
            DataTable DatosDeRoles = new DataTable();

            DatosDeRoles = MiUsuarioLocal.MiRol.Listar();

            CbRol.ValueMember = "ID";
            CbRol.DisplayMember = "Descript";

            CbRol.DataSource = DatosDeRoles;

            CbRol.SelectedIndex = -1;                
        }

        private bool ValidarDatosRequeridos(bool ValidarPassword = true)
        {
            bool R = false;

            if (!string.IsNullOrEmpty(MiUsuarioLocal.Nombre) &&
                !string.IsNullOrEmpty(MiUsuarioLocal.Cedula) &&
                !string.IsNullOrEmpty(MiUsuarioLocal.Email) &&
                MiUsuarioLocal.MiRol.IDUsuarioRol > 0
                )
            {
                if (ValidarPassword && !string.IsNullOrEmpty(MiUsuarioLocal.Contrasennia))
                {
                    R = true;
                }
                else
                {
                    R = true;
                }                 
            }
            else
            {
                if (string.IsNullOrEmpty(MiUsuarioLocal.Nombre))
                {
                    MessageBox.Show("Debe digitar el Nombre", "Error de validación", MessageBoxButtons.OK);
                    TxtNombre.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(MiUsuarioLocal.Cedula))
                {
                    MessageBox.Show("Debe digitar la cédula", "Error de validación", MessageBoxButtons.OK);
                    TxtCedula.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(MiUsuarioLocal.Email))
                {
                    MessageBox.Show("Debe digitar el Email", "Error de validación", MessageBoxButtons.OK);
                    TxtEmail.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(MiUsuarioLocal.Contrasennia))
                {
                    MessageBox.Show("Debe digitar la Contraseña", "Error de validación", MessageBoxButtons.OK);
                    TxtContrasennia.Focus();
                    return false;
                }

                if (MiUsuarioLocal.MiRol.IDUsuarioRol <= 0)
                {
                    MessageBox.Show("Debe seleccionar un Rol", "Error de validación", MessageBoxButtons.OK);
                    CbRol.Focus();  
                   
                    return false;
                }

            }
        
            return R;
        }


        private void LimpiarFormulario(bool LimpiarBusqueda = true)
        {
            TxtIDUsuario.Clear();
            TxtNombre.Clear();
            TxtCedula.Clear();
            TxtTelefono.Clear();
            TxtEmail.Clear();
            TxtContrasennia.Clear();
            CbRol.SelectedIndex = -1;

            if (LimpiarBusqueda)
            {
                TxtBuscar.Text = "Buscar...";
            }
            MiUsuarioLocal = new Logica.Models.Usuario();

            ActivarAgregar();

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosRequeridos())
			{ 
			    bool OkCedula = MiUsuarioLocal.ConsultarPorCedula(MiUsuarioLocal.Cedula);

			    bool OkEmail = MiUsuarioLocal.ConsultarPorEmail();

                if (!OkCedula && !OkEmail)
                {
                    string Mensaje = string.Format("¿Desea Continuar y Agregar al Usuario {0}?", MiUsuarioLocal.Nombre);

                    DialogResult Continuar = MessageBox.Show(Mensaje, "???", MessageBoxButtons.YesNo);

                    if (Continuar == DialogResult.Yes)
                    {
                        if (MiUsuarioLocal.Agregar())
                        {
                            MessageBox.Show("Usuario Agregado Correctamente", ":)", MessageBoxButtons.OK);
                            LimpiarFormulario();
                            LlenarListaUsuarios(CboxVerActivos.Checked);
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error y no se ha guardado el usuario", ":(", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    if (OkCedula)
                    {
                        MessageBox.Show("Ya existe un usuario con la cédula digitada", "Error de Validación", MessageBoxButtons.OK);
                    }

                    if (OkEmail)
                    {
                        MessageBox.Show("Ya existe un usuario con el Email digitado", "Error de Validación", MessageBoxButtons.OK);
                    }

                }
			}
        }

        private void TxtNombre_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtNombre.Text.Trim()))
            {
                MiUsuarioLocal.Nombre = TxtNombre.Text.Trim();
            }
            else
            {
                MiUsuarioLocal.Nombre = "";
            }
        }

        private void TxtCedula_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtCedula.Text.Trim()))
            {
                MiUsuarioLocal.Cedula = TxtCedula.Text.Trim();
            }
            else
            {
                MiUsuarioLocal.Cedula = "";
            }
        }

        private void TxtTelefono_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtTelefono.Text.Trim()))
            {
                MiUsuarioLocal.Telefono = TxtTelefono.Text.Trim();
            }
            else
            {
                MiUsuarioLocal.Telefono = "";
            }
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtEmail.Text.Trim()))
            {
                if (Commons.ObjetosGlobales.ValidarEmail(TxtEmail.Text.Trim()))
                {
                    MiUsuarioLocal.Email = TxtEmail.Text.Trim();
                }
                else
                {
                    MessageBox.Show("El formato del correo no es correcto!!", "Error de validación", MessageBoxButtons.OK);
                    TxtEmail.Focus();
                    TxtEmail.SelectAll();
                }
            }
            else
            {
                MiUsuarioLocal.Email = "";
            }
        }

        private void TxtContrasennia_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtContrasennia.Text.Trim()))
            {
                MiUsuarioLocal.Contrasennia = TxtContrasennia.Text.Trim();
            }
            else
            {
                MiUsuarioLocal.Contrasennia = "";
            }
        }

        private void CbRol_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbRol.SelectedIndex >= 0)
            {
                MiUsuarioLocal.MiRol.IDUsuarioRol = Convert.ToInt32(CbRol.SelectedValue);
            }
            else
            {
                MiUsuarioLocal.MiRol.IDUsuarioRol = 0;
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            LlenarListaUsuarios(CboxVerActivos.Checked);
        }
               

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosRequeridos(false))
            {
                Logica.Models.Usuario ObjUsuario = MiUsuarioLocal.ConsultarPorID(MiUsuarioLocal.IDUsuario);

                if (ObjUsuario.IDUsuario > 0)
                {
                    string Mensaje = string.Format("¿Desea Continuar con la Modificación del Usuario {0}?", MiUsuarioLocal.Nombre);

                    DialogResult Continuar = MessageBox.Show(Mensaje, "???", MessageBoxButtons.YesNo);

                    if (Continuar == DialogResult.Yes)
                    {
                        if (MiUsuarioLocal.Editar())
                        {
                            MessageBox.Show("El Usuario se ha actualizado correctamente!", ":)", MessageBoxButtons.OK);

                            LimpiarFormulario();

                            LlenarListaUsuarios(CboxVerActivos.Checked);

                            Logica.Bitacora.GuardarAccionEnBitacora(ObjUsuario.IDUsuario, "Edición del usuario "
                            + ObjUsuario.Nombre);
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error y no se actualizó el usuario!", ":(", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Logica.Models.Usuario ObjUsuarioTemporal = MiUsuarioLocal.ConsultarPorID(MiUsuarioLocal.IDUsuario);

            if (ObjUsuarioTemporal.IDUsuario > 0)
            {
                string Mensaje = "";

                if (CboxVerActivos.Checked)
                {
                    Mensaje = string.Format("¿Desea Continuar con la Desactivación del Usuario {0}?", MiUsuarioLocal.Nombre);
                }
                else
                {
                    Mensaje = string.Format("¿Desea Continuar con la Activación del Usuario {0}?", MiUsuarioLocal.Nombre);
                }               

                DialogResult Continuar = MessageBox.Show(Mensaje, "???", MessageBoxButtons.YesNo);

                if (Continuar == DialogResult.Yes)
                {
                    if (CboxVerActivos.Checked)
                    {
                        if (MiUsuarioLocal.Eliminar())
                        {
                            MessageBox.Show("El Usuario se ha Desactivado correctamente!", ":)", MessageBoxButtons.OK);

                            Logica.Bitacora.GuardarAccionEnBitacora(MiUsuarioLocal.IDUsuario, "Desactivación del usuario "
                            + MiUsuarioLocal.Nombre);
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error y no se desactivó el usuario!", ":(", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        if (MiUsuarioLocal.Activar())
                        {
                            MessageBox.Show("El Usuario se ha Activado correctamente!", ":)", MessageBoxButtons.OK);

                            Logica.Bitacora.GuardarAccionEnBitacora(MiUsuarioLocal.IDUsuario, "Activación del usuario "
                            + MiUsuarioLocal.Nombre);
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error y no se desactivó el usuario!", ":(", MessageBoxButtons.OK);
                        }
                    }

                    LimpiarFormulario();

                    LlenarListaUsuarios(CboxVerActivos.Checked);

                }                             
            }
        }

        private void DgvListaUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvListaUsuarios.SelectedRows.Count == 1)
            {
                LimpiarFormulario(false);

                DataGridViewRow MiFila = DgvListaUsuarios.SelectedRows[0];

                int CodigoUsuario = Convert.ToInt32(MiFila.Cells["CIDUsuario"].Value);

                MiUsuarioLocal = MiUsuarioLocal.ConsultarPorID(CodigoUsuario);

                TxtIDUsuario.Text = MiUsuarioLocal.IDUsuario.ToString();
                TxtNombre.Text = MiUsuarioLocal.Nombre;
                TxtCedula.Text = MiUsuarioLocal.Cedula;
                TxtTelefono.Text = MiUsuarioLocal.Telefono;
                TxtEmail.Text = MiUsuarioLocal.Email;
                CbRol.SelectedValue = MiUsuarioLocal.MiRol.IDUsuarioRol;

                ActivarEditaryEliminar();
            }
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
           e.Handled = Commons.ObjetosGlobales.CaracteresTexto(e, true);
        }

        private void TxtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
           e.Handled = Commons.ObjetosGlobales.CaracteresNumeros(e);
        }

        private void TxtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Commons.ObjetosGlobales.CaracteresTexto(e, false, true);
        }

        private void ActivarAgregar()
        {
            BtnAgregar.Enabled = true;
            BtnEditar.Enabled = false;
            BtnEliminar.Enabled = false;
            LblPassRequerido.Visible = true;
        }

        private void ActivarEditaryEliminar()
        {
            BtnAgregar.Enabled = false;
            BtnEditar.Enabled = true;
            BtnEliminar.Enabled = true;
            LblPassRequerido.Visible = false;
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        { 
            if (!string.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >= 2)
            {
                LlenarListaUsuarios(CboxVerActivos.Checked, TxtBuscar.Text.Trim());
            }
            else
            {
                LlenarListaUsuarios(CboxVerActivos.Checked);
            }
        }

        private void CboxVerActivos_Click(object sender, EventArgs e)
        {
            LlenarListaUsuarios(CboxVerActivos.Checked);

            if (CboxVerActivos.Checked)
            {
                BtnEliminar.Text = "Eliminar";
                BtnEliminar.BackColor = Color.Brown;
            }
            else
            {
                BtnEliminar.Text = "Activar";
                BtnEliminar.BackColor = Color.BlueViolet;
            }
        }
    }
}
