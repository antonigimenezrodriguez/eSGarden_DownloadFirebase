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

namespace eSGarden_DownloadFirebase
{
    public partial class eSGarden_DownloadFirebase : Form
    {
        public FirebaseClient Firebase { get; set; }
        public string JardinSeleccionado { get; set; }
        public string CampoSeleccionado { get; set; }
        public eSGarden_DownloadFirebase()
        {
            InitializeComponent();
            Firebase = FireBaseClient.GetFireBaseClient(
                 ConfigurationManager.AppSettings.Get(Constantes.KEY_URL),
                 ConfigurationManager.AppSettings.Get(Constantes.KEY_SECRET)
             );
            LB_Vegetable.Text = "";
            LB_Name.Text = "";
            label1.Text = "";
            label2.Text = "";
        }

        private async void Huertos_Load(object sender, EventArgs e)
        {
            listBoxGardens.Items.Clear();
            var jardines = await Firebase
                               .Child("Gardens")
                               //.Child("Garden 1")
                               //.Child("sensorData")
                               //.Child("General")
                               //.Child("Data")
                               .OrderByKey()
                               .OnceAsync<Garden>();

            foreach (var jardin in jardines)
            {
                listBoxGardens.Items.Add(jardin.Key);
            }
        }

        private async void listBoxGardens_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxCampos.Items.Clear();
            JardinSeleccionado = listBoxGardens.SelectedItem.ToString();
            var campos = await Firebase
                   .Child("Gardens")
                   .Child(JardinSeleccionado)
                   .Child("sensorData")
                   .OrderByKey()
                   .OnceAsync<sensorData>();
            foreach (var campo in campos)
            {
                listBoxCampos.Items.Add(campo.Key);
            }
        }

        private async void btnDescargarCSV_Click(object sender, EventArgs e)
        {
            if (JardinSeleccionado != null && CampoSeleccionado != null)
            {
                var data = await Firebase
                   .Child("Gardens")
                   .Child(JardinSeleccionado)
                   .Child("sensorData")
                   .Child(CampoSeleccionado)
                   .Child("Data")
                   .OrderByKey()
                   .OnceAsync<Data>();

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
            var data = await Firebase
               .Child("Gardens")
               .Child(JardinSeleccionado)
               .Child("sensorData")
               //.Child(CampoSeleccionado)
               .OrderByKey()
               .OnceAsync<sensorData>();

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
