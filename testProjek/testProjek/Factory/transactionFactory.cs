using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProjek.Model;

namespace testProjek.Factory
{
    public class transactionFactory
    {
        public TransactionHeader createNewTransaction(int userId, DateTime date, string status, List<TransactionDetail> detail)
        {
            TransactionHeader transactionHeader = new TransactionHeader();
            transactionHeader.CustomerID = userId;
            transactionHeader.TransactionDate = date;
            transactionHeader.Status = status;
            transactionHeader.TransactionDetails = detail;
            return transactionHeader;
        }
    }
}