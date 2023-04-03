using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.Common.Std;
using CS.UI.Common.Extensions;
using CS.UI.Common.Interfaces;

namespace CS.UI.Common.ViewBase
{
    public class ModelEventArg<T> : ExecutedEventArg
        where T : DataContract, new()
    {
        public ModelEventArg(T model, ExecuteType executeType, bool isCompleted = true) 
            : base(isCompleted)
        {
            Model = model;
            ExecuteType = executeType;
        }
        public T Model { get; }
        public ExecuteType ExecuteType { get; }
    }

    public abstract class EditViewModel<T> : ViewModelBase, IViewModel
        where T : DataContract, new()
    {
        protected event EventHandler<ModelEventArg<T>> ModelChangedEventHandler;

        protected EditViewModel(T model, ExecuteType viewType = ExecuteType.Edit)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
            ViewType = viewType;
            EnablePropertyChange = true;

            CreateCommand = new RelayCommand(CreateExecute, CanCreate);
            SaveCommand = new RelayCommand(async () => await SaveExecute(), CanSave);
            DeleteCommand = new RelayCommand(async () => await DeleteExecute(), CanDelete);

            AddOnPropertyChangeListener(() => ViewType, () => UpdateViewTitle());
            ModelChangedEventHandler = OnUpdated;
        }

        /// <summary>
        /// Model has been update to database or deleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnUpdated(object sender, ModelEventArg<T> e) { }

        private void UpdateViewTitle()
        {
            var currentNav = Shell.NavigationItems.LastOrDefault();
            if (currentNav != null)
            {
                currentNav.Title = Title;
                currentNav.Description = SubTitle;
            }
        }

        private async Task SaveExecute()
        {
            if (ViewType == ExecuteType.Edit && !CanOverride())
            {
                ShowMessage(Translate("ViewModel_RestrictedRight_SaveFailed"));
                return;
            }

            if (ViewType == ExecuteType.New && !Shell.User.HasRight(AccessRight, AccessType.Add))
            {
                ShowMessage(Translate("ViewModel_RestrictedRight_SaveFailed"));
                return;
            }

            ErrorMessage = null;
            var result = await Save();
            if (result.IsSuccess)
            {
                ShowMessage(Translate("ViewModel_SaveSuccessfully"));

                ModelChangedEventHandler?.Invoke(this, new ModelEventArg<T>(result.Value, ViewType));
                Model = result.Value.Clone<T>();
                ViewType = ExecuteType.Edit;
            }
            else
            {
                ShowMessage(Translate("ViewModel_SaveFailed"), NotificationType.Error);

                if (result.ErrorMessages != null)
                    ErrorMessage = string.Join(Environment.NewLine, result.ErrorMessages);
            }
        }

        protected abstract AccessRight AccessRight { get; }

        private async Task DeleteExecute()
        {
            if (!Shell.User.HasRight(AccessRight, AccessType.Delete))
            {
                ShowMessage(Translate("ViewModel_RestrictedRight_DeleteFailed"));
                return;
            }

            ErrorMessage = null;
            var state = await Delete();
            if (state.Type == StateType.Cancel)
                return;

            if (state.Result)
            {
                ShowMessage(Translate("ViewModel_DeleteSuccessfully"));
                ModelChangedEventHandler?.Invoke(this, new ModelEventArg<T>(Model, ExecuteType.Delete));
                CreateExecute();
            }
            else
                ShowMessage(Translate("ViewModel_DeleteFailed"), NotificationType.Error);
        }

        private void CreateExecute()
        {
            ErrorMessage = null;
            Model = new T();
            ViewType = ExecuteType.New;
            OnBinding();
            ModelChangedEventHandler?.Invoke(this, new ModelEventArg<T>(Model, ExecuteType.New, false));
        } 

        public ExecuteType ViewType
        {
            get => Get<ExecuteType>();
            set => Set(value);
        }

        public bool IsViewOnly => ViewType == ExecuteType.View ||
                                  (!CurrentPrincipal.Instance.IsInRole(UserRoleType.Admin) &&
                                   Shell.User.HasOnly(AccessRight, AccessType.View));
        private T model;

        public T Model
        {
            get => model;
            set
            {
                model?.Dispose();
                model = value;
                if (model != null)
                {
                    model.EnablePropertyChange = true;
                    NotifyPropertyChanged();
                }
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CreateCommand { get; }
        public ICommand DeleteCommand { get; }
        protected abstract Task<RequestResult<T>> Save();
        protected abstract Task<State<bool>> Delete();

        protected virtual bool CanSave()
        {
            if (Shell.IsBusy)
                return false;

            return Model != null && Model.IsValid && !Shell.IsBusy && CanOverride();
        }

        protected virtual bool CanOverride() => Shell.User.HasRight(AccessRight, AccessType.Add);

        protected virtual bool CanDelete()
        {
            if (Shell.IsBusy)
                return false;

            return Model != null && ViewType == ExecuteType.Edit && Shell.User.HasRight(AccessRight, AccessType.Delete);
        }

        protected virtual bool CanCreate()
        {
            if (Shell.IsBusy || ViewType == ExecuteType.New)
                return false;

            return Shell.User.HasRight(AccessRight, AccessType.Add);
        }
    }
}