using Firebase.Database;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSGarden_DownloadFirebase.ConexionBaseDatos.Repository
{
    public interface IFirebaseRepository
    {
        Task<IReadOnlyCollection<FirebaseObject<Garden>>> GetGardens();
        Task<IReadOnlyCollection<FirebaseObject<sensorData>>> GetCampos(string jardinSeleccionado);
        Task<IReadOnlyCollection<FirebaseObject<Data>>> GetData(string jardinSeleccionado, string campoSeleccionado);
    }
}
