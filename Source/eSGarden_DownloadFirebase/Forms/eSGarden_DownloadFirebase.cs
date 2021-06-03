using ConexionBaseDatos;
using eSGarden_DownloadFirebase.Utils;
using Firebase.Database;
using Firebase.Database.Query;
using Models;
using System;
using System.Configuration;
using System.Windows.Forms;
using Utils;
using System.Linq;
using eSGarden_DownloadFirebase.ConexionBaseDatos.Repository;
using eSGarden_DownloadFirebase.Repository;

namespace eSGarden_DownloadFirebase
{
    public partial class eSGarden_DownloadFirebase : Form
    {

        public string JardinSeleccionado { get; set; }
        public string CampoSeleccionado { get; set; }
        public FirebaseClient Firebase { get; set; }
        public IFirebaseRepository FirebaseRepository { get; set; }
        public eSGarden_DownloadFirebase()
        {
            InitializeComponent();
            FirebaseRepository = new FirebaseRepository();
            LB_Vegetable.Text = "";
            LB_Name.Text = "";
            label1.Text = "";
            label2.Text = "";
        }

        private async void Huertos_Load(object sender, EventArgs e)
        {
            listBoxGardens.Items.Clear();

            var jardines = await FirebaseRepository.GetGardens();

            foreach (var jardin in jardines)
            {
                listBoxGardens.Items.Add(jardin.Key);
            }
        }

        private async void listBoxGardens_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxCampos.Items.Clear();
            JardinSeleccionado = listBoxGardens.SelectedItem.ToString();

            var campos = await FirebaseRepository.GetCampos(JardinSeleccionado);

            foreach (var campo in campos)
            {
                listBoxCampos.Items.Add(campo.Key);
            }
        }

        private async void btnDescargarCSV_Click(object sender, EventArgs e)
        {
            if (JardinSeleccionado != null && CampoSeleccionado != null)
            {

                var data = await FirebaseRepository.GetData(JardinSeleccionado, CampoSeleccionado);

               

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivo Excel files (*.xlsx)|*.xlsx";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    GeneracionExcel.GenerarExcel(saveFileDialog.FileName, data);
                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show("Please, select garden and plot", "Selection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void listBoxCampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CampoSeleccionado = listBoxCampos.SelectedItem.ToString();
            var data = await FirebaseRepository.GetCampos(JardinSeleccionado);

            if (CampoSeleccionado.ToLower().Contains("plot"))
            {
                var seleccionado = data.Where(w => w.Key == CampoSeleccionado).FirstOrDefault();
                label1.Text = "Name: ";
                label2.Text = "Vegetable: ";
                LB_Name.Text = seleccionado.Object.Name;
                LB_Vegetable.Text = seleccionado.Object.Vegetable;
            }
            else
            {
                LB_Name.Text = "";
                LB_Vegetable.Text = "";
                label1.Text = "";
                label2.Text = "";
            }
        }
    }
}
