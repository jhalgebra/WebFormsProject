using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

using RWAProject.DAL;

using static Resources.AppResources;

namespace RWAProject.WebFormsClient.Controls
{
    public partial class EditUser : UserControl
    {
        #region Constants

        private const string nonCenteredCssClass = "editUser col-sm-6 col-lg-4";
        private const string centeredCssClass = "editUser centered auto100"; 

        #endregion

        #region Control Properties

        private string validationGroup;

        public string ValidationGroup
        {
            get
            {
                return validationGroup;
            }
            set
            {
                validationGroup = value;

                btnEdit.ValidationGroup = value;
                validationSummary.ValidationGroup = value;

                var textBoxes = Utils.GetSpecificControls<TextBox>(inputFields);

                var validators = Utils.GetControls<IValidator>(inputFields);

                foreach (var textBox in textBoxes)
                    textBox.ValidationGroup = value;
                foreach (var validator in validators)
                    (validator as BaseValidator).ValidationGroup = value;
            }
        }

        private User user;

        public User User
        {
            get { return user; }
            set { user = value; UpdateFields(); }
        }

        private bool centered;

        public bool Centered
        {
            get { return centered; }
            set
            {
                centered = value;

                wrapper.Attributes["class"] = value
                    ? centeredCssClass
                    : nonCenteredCssClass;
            }
        }


        #endregion

        #region Methods

        #region Helpers

        private void UpdateFields() {
            txtName.Text = user.Name;
            txtSurname.Text = user.Surname;

            ddlEmails.DataSource = user.Emails;
            ddlEmails.DataBind();

            txtEmail.Text = user.Emails.ToList()[ddlEmails.SelectedIndex].Email;

            txtTelephone.Text = user.Telephone;
            txtPassword.Text = user.Password;

            ddlCities.SelectedIndex = cities.IndexOf<City>(item => item.ID == user.CityID);
            ddlRoles.SelectedIndex = roles.IndexOf<Role>(item => item.ID == user.RoleID);
        }

        private bool UpdateUser() {
            if (RepositoryFacade.Repository.UpdateUser(user)) {
                UpdateFields();
                return true;
            }

            return false;
        }

        #endregion

        #region Control Events

        protected void btnDelete_Click(object sender, EventArgs e) {
            Page.Session(CustomPage.userDeleteKey, user);
            this.Run("$('#modal').modal('show')", "show");
        }

        protected void btnEdit_Click(object sender, EventArgs e) {
            user.Name = txtName.Text;
            user.Surname = txtSurname.Text;
            user.Emails = (HashSet<PersonEmail>)ddlEmails.DataSource;
            user.Telephone = txtTelephone.Text;
            user.Password = txtPassword.Text;

            var role = roles.Get<Role>(ddlRoles.SelectedIndex);
            user.RoleID = role.ID;

            var city = cities.Get<City>(ddlCities.SelectedIndex);
            user.CityID = city.ID;

            if (UpdateUser())
                this.Page().Toast(ToastType.Success, ResourceManager.GetString("UserUpdatedSuccessfully"), $"{user}");
        }

        protected void btnEditEmail_Click(object sender, EventArgs e) {
            Page.Validate(validationGroup);
            if (!Page.IsValid)
                return;

            var emails = (ddlEmails.DataSource as HashSet<PersonEmail>).ToList();

            var email = emails[ddlEmails.SelectedIndex];

            emails[ddlEmails.SelectedIndex] = new PersonEmail {
                Email = txtEmail.Text,
                PersonID = email.PersonID,
                ID = email.ID
            };

            user.Emails = new HashSet<PersonEmail>(emails);

            if (UpdateUser())
                this.Page().Toast(ToastType.Information, ResourceManager.GetString("UserEmailUpdatedSuccessfully"), $"{user}");
        }

        protected void ddlEmails_SelectedIndexChanged(object sender, EventArgs e) {
            txtEmail.Text = user.Emails.ToList()[ddlEmails.SelectedIndex].Email;
        }

        #endregion

        #endregion
    }
}
