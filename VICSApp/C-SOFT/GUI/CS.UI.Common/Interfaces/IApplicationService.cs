using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CS.Common.Contract;

namespace CS.UI.Common.Interfaces
{
    public interface IApplicationService
    {
        void Invoke<T>(Expression<Func<T, ActionResult>> actionSelector = null) where T : Controller;
        void Invoke<T>(Expression<Func<T, Task<ActionResult>>> actionSelector = null) where T : Controller;
        Task<TResult> Invoke<T, TResult>(Func<T, Task<Result<TResult>>> actionSelector) where T : Controller;

        void ShowNotification(NotificationType notificationType, params string[] notifications);
    }
}