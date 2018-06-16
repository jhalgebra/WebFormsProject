using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;

using static Resources.AppResources;

namespace RWAProject.WebFormsClient {
    public partial class Main : MasterPage {
        #region Methods

        #region Initialization

        protected override void OnInit(EventArgs e) {
            base.OnInit(e);

            if (!IsPostBack) {
                if (Page.Cookie<bool>(CustomPage.useDBRepoKey, false))
                    lblRepositoryType.Text = ResourceManager.GetString("Database");
                else
                    lblRepositoryType.Text = ResourceManager.GetString("TextFile");
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            var user = (Page as CustomPage).GetUser();

            divButtons.Visible = user != null;
            btnUser.Text = $"{user?.Name} {user?.Surname}";

            if (!IsPostBack) {
                btnAddUser.Attributes["href"] = ResolveUrl("~/Pages/AddData.aspx");
                btnShowData.Attributes["href"] = ResolveUrl("~/Pages/ShowData.aspx");
                btnEditData.Attributes["href"] = ResolveUrl("~/Pages/EditData.aspx");
                btnSetup.Attributes["href"] = ResolveUrl("~/Pages/Settings.aspx");
            }
        }

        #endregion

        protected void btnLogout_Click(object sender, EventArgs e)
            => (Page as CustomPage).Logout();

        protected void btnUser_Click(object sender, EventArgs e) {

            var user = (Page as CustomPage).GetUser();

            var mail = user?.Emails?.FirstOrDefault()?.Email;

            if (mail != null)
                Response.Redirect($"mailto:{mail}");

        }

        #region Helpers

        public void SetNavigationButtonActive(int buttonOrdinalNumber) {
            var buttons = Utils.GetSpecificControls<HtmlAnchor>(navigation);

            for (int i = 0; i < buttons.Count; i++)
                buttons[i].Attributes["class"] = i + 1 == buttonOrdinalNumber
                    ? "btn btn-primary"
                    : "btn";
        }

        public void ChangeBackgroundColor(string color)
            => body.Attributes["style"] = $"background-color: {color};";

        #endregion 

        #endregion
    }
}