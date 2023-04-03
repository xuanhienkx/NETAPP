using System.Threading.Tasks;

namespace SMS.Data.Services.EF.Repositories.SmsRepositories
{
    public interface IHistoryRepository
    {
        int BackupToHistory();
        bool IsNeedBackup { get; }
    }
}