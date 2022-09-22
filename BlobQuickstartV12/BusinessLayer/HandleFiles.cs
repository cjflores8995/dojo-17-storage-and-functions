using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobQuickstartV12.BusinessLayer
{
    public class HandleFiles: IHandleFiles
    {
        private readonly string LocalPath;

        /// <summary>
        /// Constructor Method
        /// </summary>
        public HandleFiles()
        {
            LocalPath = Path.GetFullPath(@"..\..\..\files\upload\");
        }

        /// <summary>
        /// Crea un archivo de texto con informacion aleatorea y lo copia en "files/upload"
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public  (string, string) CreateTxtFile(string fileName = null)
        {
            this.CreateUploadDirectory();

            if(fileName == null)
            {
                fileName = string.Format($"quickstart{Guid.NewGuid().ToString()}.txt");
            }

            // creacion del archivo local
            string localFilePath = Path.Combine(LocalPath, fileName);

            string message = string.Format($"Hola mundo{Environment.NewLine}Como estan, este el codigo: {Guid.NewGuid()}");

            // Escribir en el archivo de texto
            File.WriteAllText(localFilePath, message);

            return  (fileName, localFilePath);
        }

        /// <summary>
        /// Obtiene el listado de archivos de "files/upload" ademas de su ruta principal
        /// </summary>
        /// <returns></returns>
        public (string, List<string>) ListAllFiles()
        {
            List<string> fileNames = new();
            string[] fileEntries = Directory.GetFiles(LocalPath);

            // Obtener un listado de los archivos de un directorio
            foreach (string fileName in fileEntries)
            {
                
                fileNames.Add(Path.GetFileName(fileName));
            }

            return (LocalPath, fileNames);
        }

        /// <summary>
        /// Crea el directorio upload
        /// </summary>
        public void CreateUploadDirectory()
        {
            if (!Directory.Exists(LocalPath))
            {
                Directory.CreateDirectory(LocalPath);
            }
        }
    }
}
