using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobQuickstartV12.BusinessLayer
{
    public class AzureStorageBlobs
    {
        private readonly string ConnectionString = string.Empty;
        private readonly Startup Startup;
        private readonly string DownloadPath;

        public AzureStorageBlobs()
        {
            Startup = new Startup();
            ConnectionString = Startup.AppSetttings.AzureStorageConnecionString;
            DownloadPath = Path.GetFullPath(@"..\..\..\files\download\");
        }

        /// <summary>
        /// Crea un nuevo contenedor de blobs dentro de Azure
        /// </summary>
        /// <returns></returns>
        public BlobContainerClient CreateContainerClient(string containerName = null)
        {
            // nombre del contenedor
            if (containerName == null)
            {
                containerName = string.Format($"dojo-container-{DateTime.Now.ToLongTimeString().Replace(":", "-")}");
            }

            string connectionString = ConnectionString;


            // instancia para crear el contenedor
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            // crea el contenedor de manera asincronica
            BlobContainerClient containerClient = blobServiceClient.CreateBlobContainer(containerName, publicAccessType: PublicAccessType.BlobContainer);

            Console.WriteLine($"Contenedor: {containerName} creado correctamente.{Environment.NewLine}");

            return containerClient;
        }

        public void UploadBlobToContainer(BlobContainerClient containerClient, string fileName, string localFilePath)
        {
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            try
            {
                Console.WriteLine($"Subiendo al blob storage como blob\n\t{blobClient.Uri}");

                // Subiendo al contenedor desde el archivo local
                blobClient.Upload(localFilePath, true);

                Console.WriteLine($"blob subido correctamente\n\t{blobClient.Uri}");
            }
            catch
            {
                Console.WriteLine($"Error al subir el archivo\n\t{blobClient.Uri}");
            } 
        }

        /// <summary>
        /// Upload all files of "data" folder to Azure blob storage
        /// </summary>
        /// <param name="containerClient"></param>
        public void UploadAllBlobsToContainer(BlobContainerClient containerClient)
        {
            IHandleFiles files = new HandleFiles();
            string filePath = string.Empty;
            IList<string> fileNames = new List<string>();

            (filePath, fileNames) = files.ListAllFiles();

            foreach (var fileName in fileNames)
            {
                Console.WriteLine($"Subiendo blob {fileName}...");

                BlobClient blobClient = containerClient.GetBlobClient(fileName);
                blobClient.Upload(Path.Combine(filePath, fileName), true);

                Console.WriteLine($"\tBlob {blobClient.Uri.ToString().Substring(0, blobClient.Uri.ToString().Length-20)}... subido correctamente.");
            }

            Console.WriteLine(Environment.NewLine);
        }

        /// <summary>
        /// List all elements of a Container
        /// </summary>
        /// <param name="containerClient"></param>
        public void PrintListBlobsContainer(BlobContainerClient containerClient)
        {
            Console.WriteLine($"Listando archivos del contenedor: {containerClient.Name}");

            foreach (string blobItem in ListBlobsContainer(containerClient))
            {
                Console.WriteLine($"\t{blobItem}");
            }

            Console.WriteLine(Environment.NewLine);
        }

        private List<string> ListBlobsContainer(BlobContainerClient containerClient)
        {
            List<string> listBlobs = new List<string>();

            foreach (BlobItem blobItem in containerClient.GetBlobs())
            {
                listBlobs.Add(blobItem.Name);
            }

            return listBlobs;
        }

        /// <summary>
        /// Descarga los blobs de un contenedor específico
        /// </summary>
        /// <param name="containerClient"></param>
        public void DownloadAllBlobsOfContainer(BlobContainerClient containerClient)
        {
            foreach(var blobItem in containerClient.GetBlobs())
            {
                BlobClient blobClient = containerClient.GetBlobClient(blobItem.Name);

                blobClient.DownloadTo(Path.Combine(DownloadPath, blobItem.Name));

                Console.WriteLine($"Descarga correcta en: {Path.Combine(DownloadPath, blobItem.Name)}");
            }
        }
    }
}
