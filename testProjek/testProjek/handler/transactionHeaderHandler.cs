using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProjek.Model;
using testProjek.Repository;

namespace testProjek.handler
{
    public class transactionHeaderHandler
    {
        transactionHeaderRepository transactionHeaderRepository = new transactionHeaderRepository();
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
    }
}