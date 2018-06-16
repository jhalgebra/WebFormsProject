using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

using RWAProject.DAL;

using static Resources.AppResources;

namespace RWAProject.WebFormsClient.Pages {
    public partial class AddData : CustomPage {
        #region Fields

        private const int maxEmails = 3;
        private int numEmails;

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e) {
            CheckPermissions(true);

            if (!IsPostBack) {
                numEmails = 1;

                var addedUser = this.Session<User>(addedUserKey, true);

                if (addedUser != null)
                    Toast(ToastType.Success, ResourceManager.GetString("UserAddedSuccessfully"), $"{addedUser}");
            }

            for (int i = 1; i <= numEmails; i++) {
                AddEmailTextBox(i);
            }

            (Master as Main).SetNavigationButtonActive(1);
        }

        protected void btnAdd_Click(object sender, EventArgs e) {
            var emailTextBoxes = Utils.GetSpecificControls<TextBox>(phEmails);

            var user = new User {
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Emails = new HashSet<PersonEmail>(emailTextBoxes.Select(txtEmail => new PersonEmail { Email = txtEmail.Text })),
                Password = txtPassword.Text,
                Telephone = txtTelephone.Text,
                CityID = int.Parse(ddlCities.SelectedValue),
                RoleID = int.Parse(ddlRoles.SelectedValue)
            };

            if (RepositoryFacade.Repository.AddUser(user)) {
                this.Session(addedUserKey, user);
                this.Refresh();
            }
        }

        private void AddEmailTextBox(int ordinalNumber) {
            if (numEmails > maxEmails) {
                numEmails = maxEmails;
                return;
            }

            var txtEmailID = $"txtEmail{ordinalNumber}";

            //< asp:RegularExpressionValidator ErrorMessage = "Wrong email format" ControlToValidate = "txtEmail" runat = "server"
            //    ValidationExpression = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display = "None" />
            var regexValidator = new RegularExpressionValidator {
                ErrorMessage = ResourceManager.GetString("EmailFormatError"),// "Wrong email format",
                ControlToValidate = txtEmailID,
                ValidationExpression = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
                Display = ValidatorDisplay.None
            };

            //< asp:RequiredFieldValidator ID = "EmailValidator" ControlToValidate = "txtEmail" runat = "server"
            //    Text = "*" CssClass = "error" ErrorMessage = "Email is required" />
            var requiredValidator = new RequiredFieldValidator {
                ErrorMessage = ResourceManager.GetString("EmailEmptyError"),
                ControlToValidate = txtEmailID,
                Text = "*",
                CssClass = "error floatingValidator"
            };

            //< asp:TextBox runat = "server" CssClass = "form-control" ID = "txtEmail" />
            var txtEmail = new TextBox {
                ID = txtEmailID,
                CssClass = "form-control"
            };

            phEmails.Controls.Add(txtEmail);
            phEmails.Controls.Add(requiredValidator);
            phEmails.Controls.Add(regexValidator);

            //lblEmail.AssociatedControlID = txtEmailID;

            if (numEmails >= maxEmails)
                btnAddEmail.Visible = false;
        }

        #region ViewState

        protected void btnAddEmail_Click(object sender, EventArgs e) {
            AddEmailTextBox(++numEmails);
        }

        protected override object SaveViewState() => new object[] {
            base.SaveViewState(),
            numEmails
        };

        protected override void LoadViewState(object savedState) {
            var data = savedState as object[];

            if (data[0] != null)
                base.LoadViewState(data[0]);
            if (data[1] != null)
                numEmails = (int)data[1];
        }

        #endregion 

        #endregion
    }
}