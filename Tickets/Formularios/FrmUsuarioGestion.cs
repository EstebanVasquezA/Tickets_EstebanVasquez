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
        //Este objeto será el que usa para asignar y obtener los valores que se 
        //mostrarán en el formulario (la parte gráfica) 
        //debería contener toda la funcionlidad que se requiere para cumplir los 
        //requerimiento Funcionales 
        private Logica.Models.Usuario MiUsuarioLocal { get; set; }

        private DataTable ListaUsuarios { get; set; }
        private DataTable ListaUsuariosConFiltro { get; set; }

        public FrmUsuarioGestion()
        {
            InitializeComponent();

            //Se instancia el objeto local
            //SDUsuarioRolListar Paso 1 y 1.1
            //SDUsuarioAgregar Paso 1.1 y 1.2
            MiUsuarioLocal = new Logica.Models.Usuario();

            ListaUsuarios = new DataTable();
            ListaUsuariosConFiltro = new DataTable();

        }

        private void FrmUsuarioGestion_Load(object sender, EventArgs e)
        {
            //Este código se desencadena al mostrar el form gráficamente en pantalla
            //primero vamos a llenar la info de los tipos de roles que existen en BD

            CargarComboRoles();

            //cargar la lista de usuarios
            LlenarListaUsuarios();

            LimpiarFormulario();
        }

        private void LlenarListaUsuarios()
        {
            ListaUsuarios = MiUsuarioLocal.Listar();

            DgvListaUsuarios.DataSource = ListaUsuarios;

            DgvListaUsuarios.ClearSelection();

        }

        private void CargarComboRoles()
        {
            DataTable DatosDeRoles = new DataTable();

            //SDUsuarioRolListar paso 2
            DatosDeRoles = MiUsuarioLocal.MiRol.Listar();

            CbRol.ValueMember = "ID";
            CbRol.DisplayMember = "Descrip";

            //paso 2.5
            CbRol.DataSource = DatosDeRoles;

            CbRol.SelectedIndex = -1;                
        }

        private bool ValidarDatosRequeridos()
            //esta función valida los datos requeridos según se diseño el modelo
            //lógico y físico de base de datos
        {
            bool R = false;

            if (!string.IsNullOrEmpty(MiUsuarioLocal.Nombre) &&
                !string.IsNullOrEmpty(MiUsuarioLocal.Cedula) &&
                !string.IsNullOrEmpty(MiUsuarioLocal.Email) &&
                !string.IsNullOrEmpty(MiUsuarioLocal.Contrasennia) &&
                MiUsuarioLocal.MiRol.IDUsuarioRol > 0
                )
            {
                //Si se cumplen los parámetros de validación se pasa el valor de R a true
                R = true;
            }
            else
            {
                //Trabajo en clase: 
                //retroalimentar al usuario para indicar qué campo hace falta digitar:

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


        private void LimpiarFormulario()
        {
            //se prodece a limpiar de datos los controles del form
            TxtIDUsuario.Clear();
            TxtNombre.Clear();
            TxtCedula.Clear();
            TxtTelefono.Clear();
            TxtEmail.Clear();
            TxtContrasennia.Clear();
            CbRol.SelectedIndex = -1;

            //al reinstanciar el objeto local se eliminan todos los datos de los atributos
            MiUsuarioLocal = new Logica.Models.Usuario();

            ActivarAgregar();

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            //La Asignación de valores a atributos se realiza en tiempo real, usaremos 
            //el evento Leave para almacenar el dato del atributo al objeto local 

            //es importante validar que los atributos tengan datos antes de proceder. 
          
			if (ValidarDatosRequeridos())
			{ 
			    //paso 1.3 y 1.3.6
			    bool OkCedula = MiUsuarioLocal.ConsultarPorCedula(MiUsuarioLocal.Cedula);

			    //paso 1.4 y 1.4.6
			    bool OkEmail = MiUsuarioLocal.ConsultarPorEmail();

			    //1.5 
			    if (!OkCedula && !OkEmail)
			    {
                    //si no existe la cedula y si no existe el email tengo permiso para continuar con agregar

                    string Mensaje = string.Format("¿Desea Continuar y Agregar al Usuario {0}?", MiUsuarioLocal.Nombre);

                    DialogResult Continuar = MessageBox.Show(Mensaje, "???", MessageBoxButtons.YesNo);

                    //si el id (o cualquier atrib obligatorio) tiene datos, se puede 
                    //asegurar que el usuario aún existe y proceder con el update 

                    if (Continuar == DialogResult.Yes)
                    {
                        //1.6
                        if (MiUsuarioLocal.Agregar())
                        {
                            MessageBox.Show("Usuario Agregado Correctamente", ":)", MessageBoxButtons.OK);

                            LimpiarFormulario();

                            LlenarListaUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error y no se ha guardado el usuario", ":(", MessageBoxButtons.OK);
                        }
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
        }
               

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            //según el diagrama de casos de uso expandido, se debe consultar por el 
            //ID antes de proceder con el proceso de actualización. 
            //esto debería estar exlpicado en el diagrama de secuencia correspondiente

            if (ValidarDatosRequeridos())
            {
                //si se cumplen los datos mínimos se procede 

                //uso un objeto temporal para no tocal el usuario local y poder evaluar
                //(si tiene datos en los atributos) que el usuario existe aún en BD
                Logica.Models.Usuario ObjUsuario = MiUsuarioLocal.ConsultarPorID(MiUsuarioLocal.IDUsuario);

                if (ObjUsuario.IDUsuario > 0)
                {
                    string Mensaje = string.Format("¿Desea Continuar con la Modificación del Usuario {0}?", MiUsuarioLocal.Nombre);

                    DialogResult Continuar = MessageBox.Show(Mensaje, "???", MessageBoxButtons.YesNo);

                    //si el id (o cualquier atrib obligatorio) tiene datos, se puede 
                    //asegurar que el usuario aún existe y proceder con el update 

                    if (Continuar == DialogResult.Yes)
                    {
                        if (MiUsuarioLocal.Editar())
                        {
                            //se muestra mensaje de éxito y se actualiza la lista 

                            MessageBox.Show("El Usuario se ha actualizado correctamente!", ":)", MessageBoxButtons.OK);

                            LimpiarFormulario();

                            LlenarListaUsuarios();
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
                string Mensaje = string.Format("¿Desea Continuar con la Desactivación del Usuario {0}?", MiUsuarioLocal.Nombre);

                DialogResult Continuar = MessageBox.Show(Mensaje, "???", MessageBoxButtons.YesNo);

                //si el id (o cualquier atrib obligatorio) tiene datos, se puede 
                //asegurar que el usuario aún existe y proceder con el update 

                if (Continuar == DialogResult.Yes)
                {
                    if (MiUsuarioLocal.Eliminar())
                    {
                        //se muestra mensaje de éxito y se actualiza la lista 
                        MessageBox.Show("El Usuario se ha Desactivado correctamente!", ":)", MessageBoxButtons.OK);

                        LimpiarFormulario();

                        LlenarListaUsuarios();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error y no se desactivó el usuario!", ":(", MessageBoxButtons.OK);
                    }
                }                             
            }
        }

        private void DgvListaUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvListaUsuarios.SelectedRows.Count == 1)
            {
                LimpiarFormulario();

                DataGridViewRow MiFila = DgvListaUsuarios.SelectedRows[0];

                int CodigoUsuario = Convert.ToInt32(MiFila.Cells["CIDUsuario"].Value);

                MiUsuarioLocal = MiUsuarioLocal.ConsultarPorID(CodigoUsuario);

                TxtIDUsuario.Text = MiUsuarioLocal.IDUsuario.ToString();
                TxtNombre.Text = MiUsuarioLocal.Nombre;
                TxtCedula.Text = MiUsuarioLocal.Cedula;
                TxtTelefono.Text = MiUsuarioLocal.Telefono;
                TxtEmail.Text = MiUsuarioLocal.Email;
                //TxtContrasennia.Text = MiUsuarioLocal.Contrasennia;
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
        }

        private void ActivarEditaryEliminar()
        {
            BtnAgregar.Enabled = false;
            BtnEditar.Enabled = true;
            BtnEliminar.Enabled = true;
        }

    }
}
