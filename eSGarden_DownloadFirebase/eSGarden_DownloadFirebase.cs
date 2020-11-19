using ClosedXML.Excel;
using ConexionBaseDatos;
using Firebase.Database;
using Firebase.Database.Query;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //var firebase = FireBaseClient.GetFireBaseClient(Constantes.URL_TFM, Constantes.APP_SECRET_TFM);
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

            var asd = "asd";
            //ActualizarBDLocal actualizar = new ActualizarBDLocal();
            //bool resultado = actualizar.ActualizarBD();


            //if (resultado)
            //{
            //    string hola = "hola";
            //}
            //else
            //{
            //    string adios = "adios";
            //}
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
            string urlExcel = "c:\\temp\\Data_Test.xlsx";
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



            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Data_Test_Worksheet");
            ws.Cell(1, 1).Value = "ID";
            ws.Cell(1, 2).Value = "ID Node";
            ws.Cell(1, 3).Value = "Insertado";
            ws.Cell(1, 4).Value = "DATASLOT_0";
            ws.Range(1, 4, 1, 7).Row(1).Merge();
            ws.Cell(1, 8).Value = "Type";
            ws.Cell(1, 9).Value = "DATASLOT_1";
            ws.Range(1, 9, 1, 12).Row(1).Merge();
            ws.Cell(1, 13).Value = "Type";
            ws.Cell(1, 14).Value = "DATASLOT_2";
            ws.Range(1, 14, 1, 17).Row(1).Merge();
            ws.Cell(1, 18).Value = "Type";
            ws.Cell(1, 19).Value = "DATASLOT_3";
            ws.Range(1, 19, 1, 21).Row(1).Merge();
            ws.Cell(1, 22).Value = "Type";
            int indice = 2;
            foreach (var d in data)
            {
                ws.Cell(indice, 1).Value = d.Key;
                ws.Cell(indice, 2).Value = d.Object.ID_Node;
                ws.Cell(indice, 3).Value = UnixDateTimeConverter.UnixTimeStampToDateTime(d.Object.timestamp, UnixDateTimeConverter.TypeConversion.Milliseconds);
                var indiceDataslot_0 = 4;
                foreach (var v in d.Object.DATASLOT_0.Value)
                {
                    ws.Cell(indice, indiceDataslot_0).Value = v;
                    indiceDataslot_0++;
                    if (indiceDataslot_0 >= 7)
                        break;

                }
                ws.Cell(indice, 8).Value = d.Object.DATASLOT_0.Type;
                var indiceDataslot_1 = 9;
                foreach (var v in d.Object.DATASLOT_1.Value)
                {
                    ws.Cell(indice, indiceDataslot_1).Value = v;
                    indiceDataslot_1++;
                    if (indiceDataslot_1 >= 12)
                        break;

                }
                ws.Cell(indice, 13).Value = d.Object.DATASLOT_1.Type;
                var indiceDataslot_2 = 14;
                foreach (var v in d.Object.DATASLOT_2.Value)
                {
                    ws.Cell(indice, indiceDataslot_2).Value = v;
                    indiceDataslot_2++;
                    if (indiceDataslot_2 >= 17)
                        break;

                }
                ws.Cell(indice, 18).Value = d.Object.DATASLOT_2.Type;
                var indiceDataslot_3 = 19;
                foreach (var v in d.Object.DATASLOT_3.Value)
                {
                    ws.Cell(indice, indiceDataslot_3).Value = v;
                    indiceDataslot_3++;
                    if (indiceDataslot_3 >= 21)
                        break;

                }
                ws.Cell(indice, 22).Value = d.Object.DATASLOT_3.Type;
                indice++;
            }

            ws.Columns().AdjustToContents();
            wb.SaveAs(urlExcel);

            MessageBox.Show($"Excel generado correctamente {urlExcel}");

            var asd = "Asd";
        }
    }
}
