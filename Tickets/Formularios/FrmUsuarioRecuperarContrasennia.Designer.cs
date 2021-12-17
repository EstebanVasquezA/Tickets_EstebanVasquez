
namespace Tickets.Formularios
{
    partial class FrmUsuarioRecuperarContrasennia
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.BtnEnviarCodigo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCodigoEnviado = new System.Windows.Forms.TextBox();
            this.TxtPass1 = new System.Windows.Forms.TextBox();
            this.TxtPass2 = new System.Windows.Forms.TextBox();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOMBRE DE USUARIO / EMAIL";
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuario.Location = new System.Drawing.Point(12, 39);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(374, 30);
            this.TxtUsuario.TabIndex = 1;
            this.TxtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnEnviarCodigo
            // 
            this.BtnEnviarCodigo.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BtnEnviarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEnviarCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnviarCodigo.ForeColor = System.Drawing.Color.Navy;
            this.BtnEnviarCodigo.Location = new System.Drawing.Point(38, 71);
            this.BtnEnviarCodigo.Name = "BtnEnviarCodigo";
            this.BtnEnviarCodigo.Size = new System.Drawing.Size(323, 39);
            this.BtnEnviarCodigo.TabIndex = 2;
            this.BtnEnviarCodigo.Text = "Enviar Código de Recuperación";
            this.BtnEnviarCodigo.UseVisualStyleBackColor = false;
            this.BtnEnviarCodigo.Click += new System.EventHandler(this.BtnEnviarCodigo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Código de Verificación Enviado";
            // 
            // TxtCodigoEnviado
            // 
            this.TxtCodigoEnviado.BackColor = System.Drawing.Color.GreenYellow;
            this.TxtCodigoEnviado.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodigoEnviado.Location = new System.Drawing.Point(47, 178);
            this.TxtCodigoEnviado.MaxLength = 8;
            this.TxtCodigoEnviado.Name = "TxtCodigoEnviado";
            this.TxtCodigoEnviado.Size = new System.Drawing.Size(304, 41);
            this.TxtCodigoEnviado.TabIndex = 4;
            this.TxtCodigoEnviado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtPass1
            // 
            this.TxtPass1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPass1.Location = new System.Drawing.Point(47, 250);
            this.TxtPass1.Name = "TxtPass1";
            this.TxtPass1.Size = new System.Drawing.Size(304, 34);
            this.TxtPass1.TabIndex = 6;
            this.TxtPass1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtPass2
            // 
            this.TxtPass2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPass2.Location = new System.Drawing.Point(47, 316);
            this.TxtPass2.Name = "TxtPass2";
            this.TxtPass2.Size = new System.Drawing.Size(304, 30);
            this.TxtPass2.TabIndex = 8;
            this.TxtPass2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.BackColor = System.Drawing.Color.Green;
            this.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.ForeColor = System.Drawing.Color.White;
            this.BtnAceptar.Location = new System.Drawing.Point(47, 368);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(138, 40);
            this.BtnAceptar.TabIndex = 9;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = false;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.Firebrick;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.Location = new System.Drawing.Point(228, 368);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(123, 40);
            this.BtnCancelar.TabIndex = 10;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(95, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Digite Nueva Contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(116, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Repetir Contraseña";
            // 
            // FrmUsuarioRecuperarContrasennia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(398, 435);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.TxtPass2);
            this.Controls.Add(this.TxtPass1);
            this.Controls.Add(this.TxtCodigoEnviado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnEnviarCodigo);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUsuarioRecuperarContrasennia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmUsuarioRecuperarContrasennia";
            this.Load += new System.EventHandler(this.FrmUsuarioRecuperarContrasennia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnEnviarCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCodigoEnviado;
        private System.Windows.Forms.TextBox TxtPass1;
        private System.Windows.Forms.TextBox TxtPass2;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox TxtUsuario;
    }
}