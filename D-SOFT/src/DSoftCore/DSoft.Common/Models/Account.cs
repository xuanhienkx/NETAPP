using DSoft.Common.Shared;
using DSoft.Common.Shared.Base;

namespace DSoft.Common.Models
{

    public class Account : AccountInfo
    {
        public Account()
        {

        }

        public Account(string userName)
            : this()
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("message", nameof(userName));
            }

            UserName = userName;
            DisplayName = $"{userName}";
            CreatedDate = new Occurrence();
            Language = ProviderConstants.DefaultCulture;
            // Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
        }

        public Occurrence CreatedDate { get; protected set; }
    }
}