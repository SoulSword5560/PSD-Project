using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testProjek.Controller;
using testProjek.Report;
using testProjek.Repository;

namespace testProjek.View
{
    public partial class transactionReport : System.Web.UI.Page
    {
        transactionReportController controller = new transactionReportController();
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReport1 report = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report;
            report.SetDataSource(controller.getData());
        }

    }
}