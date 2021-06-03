using ConexionBaseDatos;
using eSGarden_DownloadFirebase.ConexionBaseDatos.Repository;
using Firebase.Database;
using Firebase.Database.Query;
using Models;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Utils;

namespace eSGarden_DownloadFirebase.Repository
{
    public class FirebaseRepository : IFirebaseRepository
    {

        public FirebaseClient Firebase { get; set; }

        public FirebaseRepository()
        {
            Firebase = FireBaseClient.GetFireBaseClient(
                 ConfigurationManager.AppSettings.Get(Constantes.KEY_URL),
                 ConfigurationManager.AppSettings.Get(Constantes.KEY_SECRET)
             );
        }

        public Task<IReadOnlyCollection<FirebaseObject<Garden>>> GetGardens()
        {
            return Firebase.Child("Gardens")
                           .OrderByKey()
                           .OnceAsync<Garden>();
        }

        public Task<IReadOnlyCollection<FirebaseObject<sensorData>>> GetCampos(string jardinSeleccionado)
        {
            return Firebase.Child("Gardens")
                           .Child(jardinSeleccionado)
                           .Child("sensorData")
                           .OrderByKey()
                           .OnceAsync<sensorData>();
        }

        public Task<IReadOnlyCollection<FirebaseObject<Data>>> GetData(string jardinSeleccionado, string campoSeleccionado)
        {
            return Firebase
                  .Child("Gardens")
                  .Child(jardinSeleccionado)
                  .Child("sensorData")
                  .Child(campoSeleccionado)
                  .Child("Data")
                  .OrderByKey()
                  .OnceAsync<Data>();
        }
    }
}
