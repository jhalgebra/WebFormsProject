using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web.UI;

using RWAProject.DAL;

namespace RWAProject.WebFormsClient
{
    public class CustomPage : Page
    {
        #region Data Persistence Keys

        protected const string bgColorKey = "BackgroundColor";
        protected const string languageKey = "Language";
        protected const string userKey = "User";
        protected const string addedUserKey = "UserAdd";
        protected const string editUserKey = "UserIndex";
        protected const string deletedUserKey = "UserThatWasDeleted";

        public const string userDeleteKey = "UserDelete";
        public const string useDBRepoKey = "DBRepo";

        #endregion

        #region Methods

        #region Toastr

        private const string toastScript = "toastr.{0}(\"{1}\", \"{2}\");";

        private readonly Dictionary<ToastType, string> toastTypes = new Dictionary<ToastType, string>
        {
            { ToastType.Error, "error" },
            { ToastType.Warning, "warning" },
            { ToastType.Success, "success" },
            { ToastType.Information, "info" }
        };

        public void Toast(ToastType type, string message, string title) {
            var script = string.Format(
                toastScript,
                toastTypes[type],
                message,
                title
            );

            this.Run(script, "toasterino");
        }

        #endregion

        #region Page Initialization

        protected override void InitializeCulture() {
            var languageCookie = this.Cookie<string>(languageKey, false);

            if (languageCookie == null)
                return;

            var cultureInfo = new CultureInfo(languageCookie);

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        protected override void OnInit(EventArgs e) {
            base.OnInit(e);

            (Master as Main).ChangeBackgroundColor(this.Cookie<string>(bgColorKey, false));
            RepositoryFacade.DatabaseRepository = this.Cookie<bool>(useDBRepoKey, false);
        }

        #endregion

        #region Helpers

        protected void CheckPermissions(bool redirectIfNotAdmin) {
            var loggedInUser = GetUser();

            if (loggedInUser == null) {
                this.GoToPage(nameof(Login));
                return;
            }

            if (redirectIfNotAdmin && !loggedInUser.Admin) {
                this.GoToPage(nameof(ShowData));
                return;
            }
        }

        public User GetUser() => this.Session<User>(userKey, false) ?? this.Cookie<User>(userKey, false);

        public void Logout() {
            this.Cookie(userKey, null);
            this.Session(userKey, null);
            this.GoToPage(nameof(Login));
        }

        public void ChangeRepository(bool toDBRepo) => this.Cookie(useDBRepoKey, toDBRepo.ToString());

        #endregion 

        #endregion
    }
}