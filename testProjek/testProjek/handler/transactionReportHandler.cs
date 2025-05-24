using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProjek.Dataset;
using testProjek.Repository;

namespace testProjek.handler
{
    public class transactionReportHandler
    {
        transactionReportRepo repo = new transactionReportRepo();
        public DataSet1 getData()
        {
            return repo.getData();
        }
    }
}