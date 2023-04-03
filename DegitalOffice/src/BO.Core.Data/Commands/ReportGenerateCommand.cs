using BO.Core.DataCommon.Shared;
using BO.Core.DataCommon.Shared.Base;

namespace BO.Core.DataCommon.Commands
{
    public class ReportGenerateCommand : BaseCommand<MediaResource>
    {
        public string ReportTemplateName { get; }
        public PlaceHolder PlaceHolder { get; }
        public string ReportId { get; }
        public string QrCodeData { get; }

        public ReportGenerateCommand(string reportTemplateName, PlaceHolder placeHolder, string reportId, string qrCodeData)
        {
            ReportTemplateName = reportTemplateName;
            PlaceHolder = placeHolder;
            ReportId = reportId;
            QrCodeData = qrCodeData;
        }
    }
}
