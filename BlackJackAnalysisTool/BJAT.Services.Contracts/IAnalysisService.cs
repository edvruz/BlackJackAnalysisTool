using System.IO;

namespace BJAT.Services.Contracts
{
    public interface IAnalysisService
    {
        bool ImportDataFromFile(string stream, string user);
    }
}