using System;

namespace TicketMaster
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ViewStateUserKey = User.Identity.Name;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}