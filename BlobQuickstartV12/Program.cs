using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BlobQuickstartV12.BusinessLayer;

namespace BlobQuickstartV12
{
    internal class Program
    {
        //static async Task Main(string[] args)
        static void Main(string[] args)
        {

            //IHandleFiles files = new HandleFiles();
            //string filePath = string.Empty;
            //IList<string> fileName = new List<string>();

            //(filePath, fileName) = files.ListAllFiles();

            //foreach(var file in fileName)
            //{
            //    Console.Write($"{Path.Combine(filePath, file)} - {file}{Environment.NewLine}");
            //}



            //--------------------------------------------------------------------------
            // Creacion de contenedor
            // Creacion de archivode texto
            // Subir archivo dentro del contenedor
            // Listar archivos alojados en el contenedor
            HandleFiles handleFiles = new HandleFiles();
            //Startup startup = new Startup();
            AzureStorageBlobs storage = new AzureStorageBlobs();

            //string connectionString = startup.AppSetttings.AzureStorageConnecionString;

            //// instancia para crear el contenedor
            //BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            //// nombre aleatoreo del contenedor
            //string containerName = string.Format($"blobquickstart{new Random().Next(0, 1000).ToString()}");
            Thread.Sleep(1000);

            // crea el contenedor de manera asincronica
            BlobContainerClient containerClient = storage.CreateContainerClient(); // await blobServiceClient.CreateBlobContainerAsync(containerName, publicAccessType: PublicAccessType.BlobContainer);
            Thread.Sleep(1000);
            // crea un archivo de texto
            //(fileName, localFilePath) = handleFiles.CreateTxtFile();

            //// Obtener una referencia para el blob
            //BlobClient blobClient = containerClient.GetBlobClient(fileName);

            //Console.WriteLine($"Subiendo al blob storage como blob\n\t{blobClient.Uri}");

            //// Subiendo al contenedor desde el archivo local
            //blobClient.Upload(localFilePath, true);
            //storage.UploadBlobToContainer(containerClient, fileName, localFilePath);

            storage.UploadAllBlobsToContainer(containerClient);
            Thread.Sleep(1000);

            storage.PrintListBlobsContainer(containerClient);
            Thread.Sleep(1000);

            storage.DownloadAllBlobsOfContainer(containerClient);

            Console.ReadLine();
        
        }

    }
}
