namespace Bombones.Windows.Formularios
{
    partial class frmProveedoresAE
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProveedoresAE));
            cboProveedor = new ComboBox();
            label2 = new Label();
            btnCancelar = new Button();
            btnOk = new Button();
            txtProovedor = new TextBox();
            label1 = new Label();
            cboProvinciasEstados = new ComboBox();
            label3 = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cboPaises
            // 
            cboProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProveedor.FormattingEnabled = true;
            cboProveedor.Location = new Point(179, 24);
            cboProveedor.Name = "cboPaises";
            cboProveedor.Size = new Size(315, 23);
            cboProveedor.TabIndex = 0;
            cboProveedor.SelectedIndexChanged += cboPaises_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(74, 27);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 19;
            label2.Text = "País:";
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.Cancelar;
            btnCancelar.Location = new Point(486, 157);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 54);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOk
            // 
            btnOk.Image = (Image)resources.GetObject("btnOk.Image");
            btnOk.Location = new Point(74, 157);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(289, 54);
            btnOk.TabIndex = 3;
            btnOk.Text = "Ok";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // txtCiudad
            // 
            txtProovedor.Location = new Point(179, 108);
            txtProovedor.MaxLength = 50;
            txtProovedor.Name = "txtCiudad";
            txtProovedor.Size = new Size(412, 23);
            txtProovedor.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 69);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 15;
            label1.Text = "Provincia/Estado:";
            // 
            // cboProvinciasEstados
            // 
            cboProvinciasEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProvinciasEstados.FormattingEnabled = true;
            cboProvinciasEstados.Location = new Point(179, 66);
            cboProvinciasEstados.Name = "cboProvinciasEstados";
            cboProvinciasEstados.Size = new Size(315, 23);
            cboProvinciasEstados.TabIndex = 1;
            cboProvinciasEstados.SelectedIndexChanged += cboProvinciasEstados_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(78, 111);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 21;
            label3.Text = "Ciudad:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmCiudadesAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 251);
            Controls.Add(label3);
            Controls.Add(cboProvinciasEstados);
            Controls.Add(cboProveedor);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(txtProovedor);
            Controls.Add(label1);
            Name = "frmCiudadesAE";
            Text = "frmCiudadesAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboProveedor;
        private Label label2;
        private Button btnCancelar;
        private Button btnOk;
        private TextBox txtProovedor;
        private Label label1;
        private ComboBox cboProvinciasEstados;
        private Label label3;
        private ErrorProvider errorProvider1;
    }
}