using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RWAProject.WebFormsClient {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e) {
            var person = DAL.DatabaseFacade.Repository.Login(txtEmail.Text, txtPassword.Text);

            if (person == null)
                error.ErrorText = "Person doesn't exist";
        }
    }
}