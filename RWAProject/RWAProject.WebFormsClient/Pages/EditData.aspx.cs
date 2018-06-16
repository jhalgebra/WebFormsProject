using System;
using System.Collections.Generic;

using RWAProject.DAL;

using static Resources.AppResources;

namespace RWAProject.WebFormsClient
{
    public partial class EditData : CustomPage
    {
        private List<User> users;

        #region Methods

        protected void Page_Load(object sender, EventArgs e) {
            CheckPermissions(true);

            if (!IsPostBack) {
                users = Utils.GetUsers();

                var deletedUser = this.Session<User>(deletedUserKey, true);

                if (deletedUser != null)
                    Toast(ToastType.Warning, ResourceManager.GetString("UserDeletedSuccessfully"), $"{deletedUser}");
            }

            var editUserIndex = this.Query<string>(editUserKey).FromBase64();

            if (editUserIndex.HasValue) {
                if (!IsPostBack)
                    users = new List<User> { users[editUserIndex.Value] };

                AddControl("User", users[0], true);
            } else
                foreach (var user in users)
                    AddControl($"User{user.ID}", user, false);

            (Master as Main).SetNavigationButtonActive(2);
        }

        protected void btnConfirm_Click(object sender, EventArgs e) {
            var user = this.Session<User>(userDeleteKey, true);

            if (user != null && RepositoryFacade.Repository.RemoveUser(user)) {
                this.Session(deletedUserKey, user);

                var editUserIndex = this.Query<string>(editUserKey).FromBase64();

                if (editUserIndex == null)
                    this.Refresh();
                else
                    this.GoToPage(nameof(ShowData));
            }
        }

        private void AddControl(string validationGroup, User user, bool centered) {
            var control = LoadControl("~/Controls/EditUser.ascx") as Controls.EditUser;

            control.ValidationGroup = validationGroup;
            control.User = user;
            control.Centered = centered;

            placeholder.Controls.Add(control);
        }

        #region ViewState

        protected override object SaveViewState() => new object[]
        {
            base.SaveViewState(),
            users
        };

        protected override void LoadViewState(object savedState) {
            var state = (object[])savedState;

            if (state[0] != null)
                base.LoadViewState(state[0]);
            if (state[1] != null)
                users = (List<User>)state[1];
        }

        #endregion 

        #endregion
    }
}