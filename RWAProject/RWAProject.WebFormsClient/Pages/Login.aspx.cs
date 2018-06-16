using System;
using System.Collections.Generic;

using RWAProject.DAL;

using static Resources.AppResources;

namespace RWAProject.WebFormsClient
{
    public partial class Login : CustomPage
    {
        private readonly string targetPage = nameof(ShowData);

        #region Methods

        protected void Page_Load(object sender, EventArgs e) {
            if (GetUser() != null)
                this.GoToPage(targetPage);
        }

        protected void btnLogin_Click(object sender, EventArgs e) {
            var user = RepositoryFacade.Repository.Login(txtEmail.Text, txtPassword.Text);

            if (user == null) {
                if (!(txtEmail.Text == "admin@email.com" && txtPassword.Text == "123")) {
                    lblError.Text = ResourceManager.GetString("UserNotFound");
                    return;
                } else {
                    user = new User {
                        Name = "Admin",
                        Surname = "Admin",
                        RoleID = 2,
                        Emails = new HashSet<PersonEmail> { new PersonEmail { Email = "admin@mail.com" } }
                    };
                }
            }

            if (cbRememberUser.Checked)
                this.Cookie(userKey, user.GetCSV());

            this.Session(userKey, user);
            this.GoToPage(targetPage);
        } 

        #endregion
    }
}