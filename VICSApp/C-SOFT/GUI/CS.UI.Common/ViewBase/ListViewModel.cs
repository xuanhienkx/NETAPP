using CS.Common.Contract;
using CS.Common.Std.Extensions;
using CS.UI.Common.Extensions;
using CS.UI.Common.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CS.Common.Contract.Enums;

namespace CS.UI.Common.ViewBase
{
    public abstract class ListViewModel<TKey, T> : ViewModelBase
        where T : class, IResource<TKey>
    {
        protected ListViewModel()
        {
            ListModels = new ObservableCollection<T>();
            OpenEditDialogCommand = new RelayCommand<bool>(Open, CanOpen);
            DeleteCommand = new RelayCommand(async () => await DeleteExecute(), CanDelete);
            RefreshCommand = new RelayCommand(Refresh, () => !Shell.IsBusy);

            AddOnPropertyChangeListener(() => ListModels, () => OnListModelsChanged());
            AddOnPropertyChangeListener(() => SelectedModel, () => OnSelectedModelChanged());
        }

        private async Task DeleteExecute()
        {
            if (!Shell.User.HasRight(AccessRight, AccessType.Delete))
            {
                ShowMessage(Translate("ViewModel_RestrictedRight_DeleteFailed"));
                return;
            }

            var deletedId = SelectedModel.Id;
            var state = await Delete();
            if (state.Type == StateType.Cancel)
                return;

            if (state.Result)
            {
                ShowMessage(Translate("ViewModel_DeleteSuccessfully"));

                ListModels.RemoveWhen(x => x.Id.Equals(deletedId));
                NotifyPropertyChanged(() => ListModels);
            }
            else
                ShowMessage(Translate("ViewModel_DeleteFailed"), NotificationType.Error);
        }

        public virtual void OnSelectedModelChanged() { }

        protected virtual void OnListModelsChanged()
        {
            DispatcherHelper.SetProcessWorkingSize();
        }

        protected async void Refresh()
        {
            if (!Shell.User.HasRight(AccessRight, AccessType.View))
            {
                ShowMessage(Translate("ViewModel_RestrictedRight_ViewFailed"));
                return;
            }

            var list = await GetList();
            var hasSelectedItem = SelectedModel != null;
            var currentSelectedId = hasSelectedItem ? SelectedModel.Id : default(TKey);

            SelectedModel = null;

            ListModels.Update(list);
            if (hasSelectedItem && list != null)
                SelectedModel = list.FirstOrDefault(x => x.Id.Equals(currentSelectedId));
        }

        protected abstract Task<IList<T>> GetList();
        protected virtual bool CanDelete()
        {
            if (Shell.IsBusy)
                return false;

            return Shell.User.HasRight(AccessRight, AccessType.Delete) && 
                   SelectedModel != null &&
                   !SelectedModel.Id.Equals(default(TKey));
        }

        protected virtual bool CanOpen(bool isNew)
        {
            if (Shell.IsBusy)
                return false;

            if (isNew)
                return Shell.User.HasRight(AccessRight, AccessType.Add);

            return SelectedModel != null && !SelectedModel.Id.Equals(default(TKey));
        }

        protected abstract Task<State<bool>> Delete();
        protected abstract void Open(bool isNew);

        public ObservableCollection<T> ListModels { get; }

        public T SelectedModel
        {
            get => Get<T>();
            set => Set(value);
        }

        public ICommand RefreshCommand { get; }
        public ICommand OpenEditDialogCommand { get; }
        public ICommand DeleteCommand { get; }
        public override void OnBinding()
        {
            Refresh();
        }

        protected void Update(T model)
        {
            if (model == null)
                return;

            var idx = ListModels.IndexOf(x => x.Id.Equals(model.Id));
            if (idx > 0)
                ListModels[idx] = model;
        }

        protected abstract AccessRight AccessRight { get; }
    }
}