using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProjek.Dataset;
using testProjek.Model;

namespace testProjek.Repository
{
    public class transactionReportRepo
    {
        databaseEntities1 db = databaseSingleton.getInstance();

        public DataSet1 getData()
        {
            DataSet1 ds = new DataSet1();
            var header = ds.TransactionHeader;
            var detail = ds.TransactionDetail;
            db.TransactionHeaders.Where(db => db.Status == "handled").ToList().ForEach(db =>
            {
               var headerRow = header.NewRow();
                headerRow[0] = db.TransactionID;
                headerRow[1] = db.TransactionDate;
                headerRow[2] = db.CustomerID;
                headerRow[3] = db.Status;
                header.Rows.Add(headerRow);
            });

            db.TransactionDetails.Where(db => db.TransactionHeader.Status == "handled").ToList().ForEach(db =>
            {
                var detailRow = detail.NewRow();
                detailRow[0] = db.TransactionID;
                detailRow[1] = db.CardID;
                detailRow[2] = db.Quantity;
                detailRow[3] = db.Card.CardPrice;
                detailRow[4] = db.Quantity * db.Card.CardPrice;
                detail.Rows.Add(detailRow);
            });
            return ds;
        }

        public List<Object> getHistoryByUser(int userid)
        {
            var history = db.TransactionHeaders.Where(th => th.CustomerID  == userid).
                SelectMany(th => th.TransactionDetails.Select(td => new
                {
                    th.TransactionID,
                    th.TransactionDate,
                    th.Status,                                            
                    td.CardID,
                    td.Card.CardName,
                    td.Card.CardPrice,
                    td.Quantity,
                    Subtotal = td.Quantity * td.Card.CardPrice
                    
                })).ToList<object>();
            return history;
        }
    }
}