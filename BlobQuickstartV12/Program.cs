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
        static void Main(string[] args)
        {
            HandleFiles handleFiles = new HandleFiles();
            AzureStorageBlobs storage = new AzureStorageBlobs();
            Thread.Sleep(1000);

            BlobContainerClient containerClient = storage.CreateContainerClient();
            Thread.Sleep(1000);

            storage.UploadAllBlobsToContainer(containerClient);
            Thread.Sleep(1000);

            storage.PrintListBlobsContainer(containerClient);
            Thread.Sleep(1000);

            storage.DownloadAllBlobsOfContainer(containerClient);

            Console.ReadLine();
        
        }

    }
}
