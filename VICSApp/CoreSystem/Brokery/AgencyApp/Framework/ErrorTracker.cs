using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Brokery.Framework
{
   public class ErrorTracker
   {
      private HashSet<Control> mErrors = new HashSet<Control>();
      private readonly ErrorProvider mProvider;
      private readonly Action onError;

      public ErrorTracker(ErrorProvider provider, Action onErrorSet)
      {
         mProvider = provider;
         onError = onErrorSet;
      }

      public void Clear(Control ctl)
      {
         SetError(ctl, string.Empty);
      }

      public void SetError(Control ctl, string text)
      {
         if (string.IsNullOrEmpty(text)) mErrors.Remove(ctl);
         else if (!mErrors.Contains(ctl)) mErrors.Add(ctl);
         mProvider.SetError(ctl, text);

         if (onError != null)
            onError();
      }

      public int Count { get { return mErrors.Count; } }
   }
}
