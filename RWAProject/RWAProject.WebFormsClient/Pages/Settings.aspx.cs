using System;
using System.Web.UI.WebControls;

namespace RWAProject.WebFormsClient {
    public partial class Settings : CustomPage {
        #region Methods

        protected void Page_Load(object sender, EventArgs e) {
            CheckPermissions(true);

            (Master as Main).SetNavigationButtonActive(4);
        }

        protected void ddlThemes_SelectedIndexChanged(object sender, EventArgs e)
            => SetCookie(bgColorKey, sender as DropDownList);

        protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
            => SetCookie(languageKey, sender as DropDownList);

        protected void ddlRepositories_SelectedIndexChanged(object sender, EventArgs e)
            => SetCookie(useDBRepoKey, sender as DropDownList);

        private void SetCookie(string cookieName, DropDownList ddl) {
            if (ddl.SelectedIndex == 0)
                return;

            this.Cookie(cookieName, ddl.SelectedValue);
            this.Refresh();
        } 

        #endregion
    }
}