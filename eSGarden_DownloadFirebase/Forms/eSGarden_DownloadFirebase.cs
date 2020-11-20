using ConexionBaseDatos;
using eSGarden_DownloadFirebase.Utils;
using Firebase.Database;
using Firebase.Database.Query;
using Models;
using System;
using System.Windows.Forms;
using Utils;

namespace eSGarden_DownloadFirebase
{
    public partial class eSGarden_DownloadFirebase : Form
    {
        public FirebaseClient firebase { get; set; }
        public eSGarden_DownloadFirebase()
        {
            InitializeComponent();
            firebase = FireBaseClient.GetFireBaseClient(Constantes.URL_TFM, Constantes.APP_SECRET_TFM);
        }

        private async void Huertos_Load(object sender, EventArgs e)
        {
            listBoxGardens.Items.Clear();
            var jardines = await firebase
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
            var jardinSeleccionado = listBoxGardens.SelectedItem.ToString();
            var campos = await firebase
                   .Child("Gardens")
                   .Child(jardinSeleccionado)
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
            var jardinSeleccionado = listBoxGardens.SelectedItem.ToString();
            var campoSeleccionado = listBoxCampos.SelectedItem.ToString();
            var data = await firebase
               .Child("Gardens")
               .Child(jardinSeleccionado)
               .Child("sensorData")
               .Child(campoSeleccionado)
               .Child("Data")
               .OrderByKey()
               .OnceAsync<Data>();
            
            string urlExcel = "c:\\temp\\Data_Test.xlsx";

            GeneracionExcel.GenerarExcel(urlExcel, data);

        }
    }
}
