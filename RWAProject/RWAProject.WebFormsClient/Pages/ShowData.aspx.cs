using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

using RWAProject.DAL;

using static Resources.AppResources;

namespace RWAProject.WebFormsClient
{
    public partial class ShowData : CustomPage
    {
        private List<User> users;

        #region Methods

        protected void Page_Load(object sender, EventArgs e) {
            CheckPermissions(false);

            if (!IsPostBack) {
                users = Utils.GetUsers();
                BindUsers();

                var deletedUser = this.Session<User>(deletedUserKey, true);

                if (deletedUser != null)
                    Toast(ToastType.Warning, ResourceManager.GetString("UserDeletedSuccessfully"), $"{deletedUser}");
            }

            (Master as Main).SetNavigationButtonActive(3);
        }

        #region Grid Events

        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e) {
            var controls = Utils.GetSpecificControls<DropDownList>(e.Row);

            if (controls.Count == 0 || grid.EditIndex == e.Row.RowIndex)
                return;

            var ddl = controls[0];

            ddl.Items.Add(new ListItem { Text = ((User)e.Row.DataItem).RoleName });
        }

        //Edit mode
        protected void grid_RowEditing(object sender, GridViewEditEventArgs e) {
            grid.EditIndex = e.NewEditIndex;
            BindUsers();

            var row = grid.Rows[e.NewEditIndex];

            var textBoxes = Utils.GetSpecificControls<TextBox>(row);
            foreach (TextBox txt in textBoxes)
                txt.CssClass = "form-control";

            var ddl = Utils.GetSpecificControls<DropDownList>(row)[0];

            ddl.SelectedValue = users[e.NewEditIndex].RoleID.ToString();
        }

        //Cancel the update
        protected void grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            grid.EditIndex = -1;
            BindUsers();
        }

        //Update the edited data
        protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            var row = grid.Rows[e.RowIndex];

            var txtName = row.Cells[0].Controls[0] as TextBox;
            var txtSurname = row.Cells[1].Controls[0] as TextBox;
            var txtTelephone = row.Cells[3].Controls[0] as TextBox;
            var ddlRoles = row.Cells[4].Controls[1] as DropDownList;

            var repeater = row.Cells[2].Controls[1];
            var emailTextBoxes = Utils.GetSpecificControls<TextBox>(repeater);

            var user = users[e.RowIndex];
            var emails = new List<PersonEmail>();

            for (int i = 0; i < emailTextBoxes.Count; i++) {
                var txtEmail = emailTextBoxes[i];

                emails.Add(new PersonEmail {
                    ID = user.Emails.ElementAt(i).ID,
                    Email = txtEmail.Text,
                    PersonID = user.ID
                });
            }

            var role = roles.Get<Role>(ddlRoles.SelectedIndex);

            var newUser = new User {
                ID = user.ID,
                Name = txtName.Text,
                Surname = txtSurname.Text,
                CityID = user.CityID,
                RoleID = role.ID,
                Password = user.Password,
                Telephone = txtTelephone.Text,
                Emails = new HashSet<PersonEmail>(emails)
            };

            if (RepositoryFacade.Repository.UpdateUser(newUser))
                users[e.RowIndex] = newUser;

            grid.EditIndex = -1;
            BindUsers();
        }

        #endregion

        //Repeater Edit button click
        protected void repeater_ItemCommand(object source, RepeaterCommandEventArgs e) {
            var index = e.Item.ItemIndex.ToBase64();

            this.GoTo($"~/Pages/{nameof(EditData)}.aspx?{editUserKey}={index}");
        }

        private void BindUsers() {
            grid.DataSource = users;
            grid.DataBind();

            repeater.DataSource = users;
            repeater.DataBind();
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