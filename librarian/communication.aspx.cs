﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace library_ms.librarian
{
    public partial class communication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["librarian"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}