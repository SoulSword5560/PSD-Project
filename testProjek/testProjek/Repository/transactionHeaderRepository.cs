using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProjek.Model;

namespace testProjek.Repository
{
    public class transactionHeaderRepository
    {
        databaseEntities1 db = databaseSingleton.getInstance();
        public List<TransactionHeader> getTransactionHeader()
        {
            return db.TransactionHeaders.ToList();
        }
        
        public TransactionHeader getTransactionHeaderById(int id)
        {
            return db.TransactionHeaders.Find(id);
        }

        public void createTransaction(TransactionHeader transactionHeader)
        {
            db.TransactionHeaders.Add(transactionHeader);
            db.SaveChanges();
        }
        public void updateTransactionHeader(TransactionHeader transactionHeader)
        {
            TransactionHeader old = db.TransactionHeaders.Find(transactionHeader.TransactionID);
            old.Status = transactionHeader.Status;
            db.SaveChanges();
        }
    }
}