using System;
using System.Web;

namespace RWAProject.WebFormsClient {
    public partial class Error : CustomPage {
        public const string errorKey = "Error";

        protected void Page_Load(object sender, EventArgs e) {
            var error = Server.GetLastError();

            lblErrorMessageText.Text = "";
            lblStackTraceText.Text = "";

            while(error != null) {
                lblErrorMessageText.Text += $"<br/>{error.Message}";
                lblStackTraceText.Text = $"<br/>{error.StackTrace}";

                error = error.InnerException;
            }
        }
    }
}