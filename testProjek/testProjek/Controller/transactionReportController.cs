using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProjek.Dataset;
using testProjek.handler;

namespace testProjek.Controller
{
    public class transactionReportController
    {
        transactionReportHandler handler = new transactionReportHandler();
        public DataSet1 getData()
        {
            return handler.getData();
        }

        public List<object> getHistoryByUser(int userid)
        {
            return handler.getHistory(userid);
        }
    }
}