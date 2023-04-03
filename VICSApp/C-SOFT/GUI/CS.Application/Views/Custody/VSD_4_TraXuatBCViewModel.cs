using CS.Application.Controllers;
using CS.Application.Framework;
using CS.Application.Views.Custody.Base;
using CS.UI.Common;
using CS.UI.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;
using CS.Common.Std.Extensions;

namespace CS.Application.Views.Custody
{
    public class VSD_4_TraXuatBCViewModel : RequestPublishViewModel
    {
        public VSD_4_TraXuatBCViewModel(CustodyRequestModel model) : base(model)
        {
            AddOnPropertyChangeListener(() => ReportSelected, () => OnReportSelectedChanged());
            FilterStockCommand = new AutoCompleteTextBox.FilterCommand(async f => await FilterStock(f));
        }

        private void OnReportSelectedChanged()
        {
            if (ReportSelected == null)
                return;

            UpdateParamTempateTypes();
            Model.AddOnPropertyChangeListener(() => ReportSelected.ReportCode, () => UpdateParamTempateTypes());
        }

        private async Task<IEnumerable> FilterStock(string filter)
        {
            if (string.IsNullOrEmpty(filter))
                return null;

            return await Invoke<AssetController, IList<AssetModel>>(c => c.FilterAsset(filter));
        }

        public AssetModel Stock { get => Get<AssetModel>(); set => Set(value); }
        public ICommand FilterStockCommand { get; }
        public DataTemplate ReportDataTemplate { get; set; }
        private Type GetTypeReportModel(string reportName)
        {
            var assembly = typeof(DataContract).Assembly;
            var className = $".{reportName}PramaterModel";
            return assembly.GetTypes().FirstOrDefault(x => x.FullName.EndsWith(className, StringComparison.OrdinalIgnoreCase));
        }
        private void UpdateParamTempateTypes()
        {
            ErrorMessage = null;

            var code = this.ReportSelected.ReportCode;
            if (Model.ContentModel != null && !string.IsNullOrEmpty(Model.ContentClrType) && Model.ContentClrType.Contains(code))
                return;

            #region Set Tyep of report paramater 

            var type = GetTypeReportModel(code);
            if (type == null)
            {
                ErrorMessage = string.Format(Translate("Report_PramaterModel_NotFound"), code);
                return;
            }
            Model.ContentModel = Activator.CreateInstance(type);
            Model.ContentClrType = type.FullName;

            #endregion

        }
        public override string Title => Translate("CustodyViewModel_VSD_4_TraXuatBC_Dialog_Title");

        public override Task LoadData()
        {
            if (string.IsNullOrEmpty(Model.Content))
            {
                Model.ContentModel = new DE084PramaterModel();
                ReportSelected = VsdReportList.Current.Items.SingleOrDefault(x => x.ReportCode.Equals("DE084"));
            }
            else
            {
                var contentType = Model.GetType().Assembly.GetType(Model.ContentClrType); 
                Model.ContentModel = Model.Content.Base64ProtoBufDeserialize(contentType);
                ReportSelected = VsdReportList.Current.Items.SingleOrDefault(
                    x => Model.ContentClrType.Contains(x.ReportCode));

            }
            return Task.CompletedTask;
        }

        public override bool ContentModelValid => Model.ContentModel is ValidableModel model && model.IsValid;
        public EnumCollection<BoardType> BoardTypes { get; } = new EnumCollection<BoardType>(BoardType.Hnx, BoardType.Hose, BoardType.Upcom, BoardType.Dccny);
        public IList<VsdReportModel> ListReportModels { get; } = VsdReportList.Current.Items;
        public VsdReportModel ReportSelected { get => Get<VsdReportModel>(); set => Set(value); }
        protected override AccessRight AccessRight => AccessRight.TraXuatBc;
    }
}