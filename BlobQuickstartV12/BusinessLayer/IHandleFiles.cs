using System.Collections.Generic;

namespace BlobQuickstartV12.BusinessLayer
{
    public interface IHandleFiles
    {

        (string, string) CreateTxtFile(string fileName = null);

        (string, List<string>) ListAllFiles();
        void CreateUploadDirectory();
    }
}
