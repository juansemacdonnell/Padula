using SistemaKinesiologia.Clases;
using SistemaKinesiologia.Contexto;
using SistemaKinesiologia.Pantallas;
using SistemaKinesiologia.Servicios;
using System.Globalization;

namespace SistemaKinesiologia
{
    public partial class Inicio : Form
    {
        // Inicializamos el context DB
        private static ContextDB _contextoDB = new ContextDB();

        // Inicializamos los servicios opara pasarle al gestor
        private static EvaluacionService evaluacionService = new EvaluacionService(_contextoDB);
        private static KinesiologoService kinesiologoService = new KinesiologoService(_contextoDB);
        private static LesionService lesionService = new LesionService(_contextoDB);
        private static PacienteService pacienteService = new PacienteService(_contextoDB);
        private static PlanDeEntrenamientoService planDeEntrenamientoService = new PlanDeEntrenamientoService(_contextoDB);
        private static SesionService sesionService = new SesionService(_contextoDB);

        // Inicializamos el gestor del programa con todos los servicios para acceder a la BD
        Gestor gestor = new Gestor(evaluacionService, kinesiologoService, lesionService, pacienteService, planDeEntrenamientoService, sesionService);

        private System.Windows.Forms.Timer timer;
        public Inicio()
        {
            InitializeComponent();
            IniciarTemporizador();
            this.WindowState = FormWindowState.Maximized;

            // aca iria una consulta a la BD y que traiga todos los kine
            List<Kinesiologo> listaKines = gestor.kinesiologoService.GetKinesiologos();

            // Cargar cmb box
            foreach (Kinesiologo k in listaKines) { cmbBoxKine.Items.Add(k.GetNombre()); }
            cmbBoxKine.SelectedIndex = 0;

            gestor.SetKinesiologo(listaKines[0]);
            Kinesiologo kineActual = gestor.GetKinesiologoActual();

            // Setear campos de fecha y hora
            lblFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM", new CultureInfo("es-ES"));
            lblHora.Text = DateTime.Now.ToString("HH:mm");

            // Ubicar bien el lbl fecha
            int ubicacionX = (900 - lblFecha.Size.Width) / 2;
            lblFecha.Location = new Point(ubicacionX, 25);

            // ubicar bien lb hora
            int ubicacionXHora = (900 - lblHora.Size.Width) / 2;
            lblHora.Location = new Point(ubicacionXHora, 42);
        }
        private void IniciarTemporizador()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 55000; // 1000 ms = 1 segundo
            timer.Tick += new EventHandler(ActualizarFechaYHora);
            timer.Start();
        }
        private void ActualizarFechaYHora(object sender, EventArgs e)
        {
            // Setear campos de fecha y hora
            lblFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM", new CultureInfo("es-ES"));
            lblHora.Text = DateTime.Now.ToString("HH:mm");
        }
        private void btnRegistarPaciente_Click(object sender, EventArgs e)
        {
            RegistrarPaciente pantallaRP = new RegistrarPaciente(gestor);
            pantallaRP.Show();
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            BuscarPaciente pantallaBP = new BuscarPaciente(gestor);
            pantallaBP.Show();
        }

        private void btnUltimasSesiones_Click(object sender, EventArgs e)
        {
            VerUltimasSesiones pantallaUltimasSesiones = new VerUltimasSesiones(gestor);
            pantallaUltimasSesiones.Show();
        }

        private void btnCargarPlanGenerico_Click(object sender, EventArgs e)
        {
            PantallaPlanDeEntrenamiento pantallaPlanDeEntrenamiento = new PantallaPlanDeEntrenamiento(gestor, true);
            pantallaPlanDeEntrenamiento.Show();

        }
    }
}
