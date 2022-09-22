using System.Collections.Generic;

namespace BlobQuickstartV12.BusinessLayer
{
    public interface IHandleFiles
    {

        (string, string) CreateTxtFile(string fileName = null);
        bool DeleteAllDataFiles();

        //bool DeleteSpecificFile(string fileName);

        (string, List<string>) ListAllFiles();
        void CreateDataDirectory();
    }
}
