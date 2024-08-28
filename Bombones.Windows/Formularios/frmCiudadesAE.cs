using Bombones.Entidades.Entidades;
using Bombones.Windows.Helpers;

namespace Bombones.Windows.Formularios
{
    public partial class frmProveedoresAE : Form
    {
        private readonly IServiceProvider? _servicios;
        private Pais? paisSeleccionado;
        private ProvinciaEstado? provinciaEstado;
        private Ciudad? ciudad;
        public frmProveedoresAE(IServiceProvider? servicios)
        {
            InitializeComponent();
            _servicios = servicios;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper
                .CargarComboPaises(ref cboProveedor, _servicios);
            if (ciudad is not null)
            {
                txtProovedor.Text = ciudad.NombreCiudad;
                cboProveedor.SelectedValue = ciudad.PaisId;
                cboProvinciasEstados.SelectedValue = ciudad.ProvinciaEstadoId;
            }

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (ciudad is null)
                {
                    ciudad = new Ciudad();
                }
                ciudad.NombreCiudad = txtProovedor.Text;
                ciudad.Pais = paisSeleccionado;
                ciudad.ProvinciaEstado=provinciaEstado;
                ciudad.PaisId = paisSeleccionado?.PaisId??0;
                ciudad.ProvinciaEstadoId = provinciaEstado?.ProvinciaEstadoId ?? 0;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtProovedor.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtProovedor, "proveedor es requerido");
            }
            if (cboProveedor.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(cboProveedor, "Debe seleccionar proveedor");
            }
            if (cboProvinciasEstados.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboProvinciasEstados, "Debe seleccionar una prov/estado");
            }
            return valido;
        }

        private void cboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            paisSeleccionado = cboProveedor.SelectedIndex > 0 ?
                (Pais?)cboProveedor.SelectedItem : null;
            if (paisSeleccionado is not null)
            {
                CombosHelper.CargarComboProvinciaEstado(ref cboProvinciasEstados, paisSeleccionado, _servicios);
            }
            else
            {
                cboProvinciasEstados.DataSource = null;
            }
        }

        private void cboProvinciasEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            provinciaEstado = cboProvinciasEstados.SelectedIndex > 0 ?
                (ProvinciaEstado?)cboProvinciasEstados.SelectedItem : null;
        }

        public Proveedor? GetProveedor()
        {
            return Proveedor;
        }

        public void SetCiudad(Ciudad ciudad)
        {
            this.ciudad = ciudad;
        }

    }
}
