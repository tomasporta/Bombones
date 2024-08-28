using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using Bombones.Windows.Helpers;

namespace Bombones.Windows.Formularios
{
    public partial class frmProveedores : Form
    {

        private readonly IServiciosProveedores? _servicio;
        private List<ProveedorListDto> lista = null!;
        private readonly IServiceProvider? _serviceProvider;
        private int paginaActual = 1;
        private int registrosPorPagina = 10; 

        public int? totalRecords { get; private set; }

        private int totalPaginas;

        public int? currentPage { get; private set; }
        public decimal pageSize { get; private set; }
        public int totalPages { get; private set; }
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            string criterioBusqueda = txtBusqueda.Text.ToLower().Trim();

            var ProveedoresFiltrados = lista
                .Where(b => b.NombreProveedor.ToLower().Contains(criterioBusqueda) ||
                            b.NombreProveedor.ToLower().StartsWith(criterioBusqueda))
                .ToList();

            MostrarDatosFiltradosEnGrilla(ProveedoresFiltrados);
        }
        private void CalcularTotalPaginas()
        {
            totalPaginas = (int)Math.Ceiling((double)lista.Count / registrosPorPagina);
        }

        private void MostrarPagina(int numeroPagina)
        {
            paginaActual = numeroPagina;
            var bombonesFiltrados = lista
                .Skip((paginaActual - 1) * registrosPorPagina)
                .Take(registrosPorPagina)
                .ToList();

            MostrarDatosFiltradosEnGrilla(bombonesFiltrados);
            ActualizarControlesPaginacion();
        }

        private void ActualizarControlesPaginacion()
        {
            cboPaginas.Text = $"Página {paginaActual} de {totalPaginas}";
            btnAnterior.Enabled = paginaActual > 1;
            btnSiguiente.Enabled = paginaActual < totalPaginas;
        }

        private void MostrarDatosFiltradosEnGrilla(object ProveedoresFiltrados)
        {
            GridHelper.LimpiarGrilla(dgvDatos); // Limpia la grilla antes de mostrar los datos filtrados
            foreach (var Proveedores in lista)
            {
                var r = GridHelper.ConstruirFila(dgvDatos); // Inicializa r con el resultado de ConstruirFila
                GridHelper.SetearFila(r, Proveedores);
                GridHelper.AgregarFila(r, dgvDatos);
            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            MostrarPagina(1);
            txtBusqueda.Clear();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            MostrarPagina(1);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                MostrarPagina(paginaActual - 1);
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                MostrarPagina(paginaActual + 1);
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            MostrarPagina(totalPaginas);
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmProveedoresAE frm = new frmProveedoresAE(_serviceProvider);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            try
            {
                Proveedor? proveedor = frm.GetProveedor();
                if (proveedor is null) return;
                if (!Servicios!.Existe(proveedor))
                {
                    _servicio.Guardar(proveedor);


                    totalRecords = _servicio?.GetCantidad() ?? 0;
                    totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
                    currentPage = _servicio?.GetPaginaPorRegistro(Proveedor.NombreProveedor, pageSize) ?? 0;
                    LoadData();

                    MessageBox.Show("Registro agregado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro existente\nAlta denegada",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            }
        }

        private void LoadData()
        {
            try
            {
                lista = _servicio!.GetLista(currentPage, pageSize);
                MostrarDatosEnGrilla(lista);
                if (cboPaginas.Items.Count != totalPages)
                {
                    CombosHelper.CargarComboPaginas(ref cboPaginas, totalPages);
                }
                txtCantidadPaginas.Text = totalPages.ToString();
                cboPaginas.SelectedIndexChanged -= cboPaginas_SelectedIndexChanged;
                cboPaginas.SelectedIndex = (int)(currentPage == 1 ? 0 : currentPage - 1);
                cboPaginas.SelectedIndexChanged += cboPaginas_SelectedIndexChanged;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cboPaginas_SelectedIndexChanged(object? sender, EventArgs e)
        {
            currentPage = int.Parse(cboPaginas.Text);
            LoadData();
        }

        private void MostrarDatosEnGrilla(List<ProveedorListDto> lista)
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            if (lista is not null)
            {
                foreach (var c in lista)
                {
                    var r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, c);
                    GridHelper.AgregarFila(r, dgvDatos);
                }

            }
        }
    }
}
