using CS.Common.Contract.VsdModels;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Domain.Data.Entities;
using System.Linq;

namespace CS.VSD.Service
{
    public class FileActDataService : CommonServiceBase<long, FileActModel, FileAct>
    {
        public FileActDataService(IDataFactory dataFactory, ICacheService cacheService) : base(dataFactory, cacheService)
        {
        }

        protected override bool ValidateInsert(FileActModel model)
        {
            var exitedFileActData = Query.Queryable().Any(b => b.ReportCode.Equals(model.ReportCode) && b.LogicalName == model.LogicalName);
            return !exitedFileActData;
        }

        protected override bool ValidateUpdate(FileActModel model)
        {
            return true;
        }

        protected override bool ValidateDelete(FileAct deletedEntity)
        {
            return true;
        }

        protected override bool UseCache => true;
    }
}