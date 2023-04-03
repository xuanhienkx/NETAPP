using System;
using System.Threading;
using System.Windows;
using CS.UI.Common.Interfaces;

namespace CS.Application.Framework
{
    public interface IControllerContext
    {
        string Path { get; }
        string ControllerName { get; }
        IShell Shell { get; }
    }

    public class ControllerContext : IControllerContext
    {
        public ControllerContext(IShell shell)
        {
            Shell = shell ?? throw new ArgumentNullException(nameof(shell));
        }

        public string Path { get; set; }
        public string ControllerName { get; set; }
        public IShell Shell { get; }
    }
}
