using ClosedXML.Excel;
using Firebase.Database;
using Models;
using System.Collections.Generic;
using System.Windows.Forms;
using Utils;

namespace eSGarden_DownloadFirebase.Utils
{
    public class GeneracionExcel
    {
        public static void GenerarExcel(string urlExcel, IReadOnlyCollection<FirebaseObject<Data>> data)
        { 
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Data_Test_Worksheet");
            ws.Cell(1, 1).Value = "ID";
            ws.Cell(1, 2).Value = "ID Node";
            ws.Cell(1, 3).Value = "Insertado";
            ws.Cell(1, 4).Value = "Type";
            ws.Cell(1, 5).Value = "DATASLOT_0";
            ws.Range(1, 5, 1, 8).Row(1).Merge();
            ws.Cell(1, 9).Value = "Type";
            ws.Cell(1, 10).Value = "DATASLOT_1";
            ws.Range(1, 10, 1, 13).Row(1).Merge();
            ws.Cell(1, 14).Value = "Type";
            ws.Cell(1, 15).Value = "DATASLOT_2";
            ws.Range(1, 15, 1, 18).Row(1).Merge();
            ws.Cell(1, 19).Value = "Type";
            ws.Cell(1, 20).Value = "DATASLOT_3";
            ws.Range(1, 20, 1, 23).Row(1).Merge();

            int indice = 2;
            foreach (var d in data)
            {
                ws.Cell(indice, 1).Value = d.Key;
                ws.Cell(indice, 2).Value = d.Object.ID_Node;
                ws.Cell(indice, 3).Value = UnixDateTimeConverter.UnixTimeStampToDateTime(d.Object.timestamp, UnixDateTimeConverter.TypeConversion.Milliseconds);
                ws.Cell(indice, 4).Value = d.Object.DATASLOT_0.Type;
                var indiceDataslot_0 = 5;
                foreach (var v in d.Object.DATASLOT_0.Value)
                {
                    ws.Cell(indice, indiceDataslot_0).Value = v;
                    indiceDataslot_0++;
                    if (indiceDataslot_0 >= 8)
                        break;
                }

                ws.Cell(indice, 9).Value = d.Object.DATASLOT_1.Type;
                var indiceDataslot_1 = 10;
                foreach (var v in d.Object.DATASLOT_1.Value)
                {
                    ws.Cell(indice, indiceDataslot_1).Value = v;
                    indiceDataslot_1++;
                    if (indiceDataslot_1 >= 13)
                        break;

                }
                ws.Cell(indice, 14).Value = d.Object.DATASLOT_2.Type;
                var indiceDataslot_2 = 15;
                foreach (var v in d.Object.DATASLOT_2.Value)
                {
                    ws.Cell(indice, indiceDataslot_2).Value = v;
                    indiceDataslot_2++;
                    if (indiceDataslot_2 >= 18)
                        break;

                }
                ws.Cell(indice, 19).Value = d.Object.DATASLOT_3.Type;
                var indiceDataslot_3 = 20;
                foreach (var v in d.Object.DATASLOT_3.Value)
                {
                    ws.Cell(indice, indiceDataslot_3).Value = v;
                    indiceDataslot_3++;
                    if (indiceDataslot_3 >= 23)
                        break;

                }

                indice++;
            }

            ws.Columns().AdjustToContents();
            wb.SaveAs(urlExcel);

            MessageBox.Show($"Excel generado correctamente {urlExcel}");
        }
    }
}
