﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProjek.handler;
using testProjek.Model;

namespace testProjek.Controller
{
    public class transactionHeaderController
    {
        transactionHeaderHandler transactionHeaderHandler = new transactionHeaderHandler();
        public List<TransactionHeader> getTransactionHeader()
        {
            return transactionHeaderHandler.getTransactionHeader();
        }
        public void addNewTransaction(int userId, DateTime date, List<TransactionDetail> details)
        {
            transactionHeaderHandler.createTransaction(userId, date, details);
        }
        public TransactionHeader getTransactionHeaderById(int id)
        {
            return transactionHeaderHandler.getTransactionHeaderById(id);
        }
        public void updateTransactionHeader(TransactionHeader transactionHeader)
        {
            transactionHeaderHandler.updateTransactionHeader(transactionHeader);
        }
    }
}