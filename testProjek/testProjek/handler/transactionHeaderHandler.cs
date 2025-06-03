using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProjek.Factory;
using testProjek.Model;
using testProjek.Repository;

namespace testProjek.handler
{
    public class transactionHeaderHandler
    {
        transactionHeaderRepository transactionHeaderRepository = new transactionHeaderRepository();
        transactionFactory transactionFactory = new transactionFactory();
        public List<TransactionHeader> getTransactionHeader()
        {
            return transactionHeaderRepository.getTransactionHeader();
        }
        public TransactionHeader getTransactionHeaderById(int id)
        {
            return transactionHeaderRepository.getTransactionHeaderById(id);
        }
        public void updateTransactionHeader(TransactionHeader transactionHeader)
        {
            transactionHeaderRepository.updateTransactionHeader(transactionHeader);
        }

        public void createTransaction(int userId, DateTime date, List<TransactionDetail> td)
        {
            TransactionHeader th = transactionFactory.createNewTransaction(userId, date, "unhandled", td);
            transactionHeaderRepository.createTransaction(th);
        }
    }
}