using BackEndKalbeFarm.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndKalbeFarm.BusinessServices
{
    public class TestKalbeFarma : RepositoryTestKalbeFarma
    {
        string cnnString = "Server=NBID-0234;Initial Catalog=Db_Test_KalbeFarma;Persist Security Info=False;User ID=sa;Password=4ndr1y4nt0;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=3600;";

        public async Task<List<Transaction_Header>> GetAllTransaction()
        {
            List<Transaction_Header> ListData = new List<Transaction_Header>();
            try
            {
                SqlConnection cnn = new SqlConnection(cnnString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetTransactionHeader";
                //cmd.Parameters.Add(new SqlParameter("@CatalogId", CatalogId));
                cnn.Open();
                int i = 0;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Transaction_Header data = new Transaction_Header();
                        data.InvoiceNo = reader["InvoiceNo"].ToString();
                        data.Status = reader["Status"].ToString();
                        data.Language = reader["Language"].ToString();
                        data.Currency = reader["Currency"].ToString();
                        data.AddressFrom = reader["AddressFrom"].ToString();
                        data.AddressTo = reader["AddressTo"].ToString();
                        data.InvoiceDate = DateTime.Parse(reader["InvoiceDate"].ToString());
                        data.InvoiceDue = reader["invoiceDue"].ToString();
                        data.PurchaseOrderNo = reader["PurchaseOrderNo"].ToString();
                        ListData.Add(data);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return ListData;
        }
        public async Task<TransactionMain> GetTransaction(string Invoice) {

            TransactionMain Maindata = new TransactionMain();
            Transaction_Header Header = new Transaction_Header();
            List<Transaction_Detail> Detail = new List<Transaction_Detail>();

            try
            {
                SqlConnection cnn = new SqlConnection(cnnString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetTransactionDetail";
                cmd.Parameters.Add(new SqlParameter("@invoiceNo", Invoice));
                cnn.Open();
                int i = 0;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Transaction_Header dataheader = new Transaction_Header();
                        dataheader.InvoiceNo = reader["InvoiceNo"].ToString();
                        dataheader.Status = reader["Status"].ToString();
                        dataheader.Language = reader["Language"].ToString();
                        dataheader.Currency = reader["Currency"].ToString();
                        dataheader.AddressFrom = reader["AddressFrom"].ToString();
                        dataheader.AddressTo = reader["AddressTo"].ToString();
                        dataheader.InvoiceDate = DateTime.Parse(reader["InvoiceDate"].ToString());
                        dataheader.InvoiceDue = reader["invoiceDue"].ToString();
                        dataheader.PurchaseOrderNo = reader["PurchaseOrderNo"].ToString();

                        Header = dataheader;

                        Transaction_Detail dataDetail = new Transaction_Detail();
                        dataDetail.ItemName = reader["ItemName"].ToString();
                        dataDetail.qty = decimal.Parse(reader["qty"].ToString());
                        dataDetail.rate = decimal.Parse(reader["Rate"].ToString());
                        dataDetail.Amount = decimal.Parse(reader["Amount"].ToString());
                        dataDetail.TypeRate = reader["TypeRate"].ToString();
                        dataDetail.TypeDiscount = reader["TypeDiscount"].ToString();
                        dataDetail.DiscountValue = reader["DiscountValue"].ToString();
                        dataDetail.AmountDiscount = decimal.Parse(reader["AmountDiscount"].ToString());
                        Detail.Add(dataDetail);

                    }
                    Maindata.Tr_Header = Header;
                    Maindata.tr_Detail = Detail;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Maindata;
        
        }
        public async Task<string> InsertTransaction(TransactionMain insert)
        {
            string Result = "Success";
            try
            {
                SqlConnection cnn = new SqlConnection(cnnString);
                SqlDataReader rdr = null;
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "Sp_Insert_Transction_Header";
                cmd.Parameters.Add(new SqlParameter("@Status", insert.Tr_Header.Status));
                cmd.Parameters.Add(new SqlParameter("@InvoiceNo", insert.Tr_Header.InvoiceNo));
                cmd.Parameters.Add(new SqlParameter("@Language", insert.Tr_Header.Language));
                cmd.Parameters.Add(new SqlParameter("@Currency", insert.Tr_Header.Currency));
                cmd.Parameters.Add(new SqlParameter("@AddressFrom", insert.Tr_Header.AddressFrom));
                cmd.Parameters.Add(new SqlParameter("@AddressTo", insert.Tr_Header.AddressTo));
                cmd.Parameters.Add(new SqlParameter("@InvoiceDate", insert.Tr_Header.InvoiceDate));
                cmd.Parameters.Add(new SqlParameter("@InvoiceDue", insert.Tr_Header.InvoiceDue));
                cmd.Parameters.Add(new SqlParameter("@PurchaseOrderNo", insert.Tr_Header.PurchaseOrderNo));

                rdr = cmd.ExecuteReader();
                cnn.Close();
               for (int i =0; i< insert.tr_Detail.Count; i++)
                {
                    SqlDataReader rdrDetail = null;
                    cnn.Open();
                    SqlCommand cmddetail = new SqlCommand();
                    cmddetail.Connection = cnn;
                    cmddetail.CommandType = System.Data.CommandType.StoredProcedure;
                    cmddetail.CommandText = "Insert_Detail_Transaction";
                    cmddetail.Parameters.Add(new SqlParameter("@ItemName", insert.tr_Detail[i].ItemName));
                    cmddetail.Parameters.Add(new SqlParameter("@qty", insert.tr_Detail[i].qty));
                    cmddetail.Parameters.Add(new SqlParameter("@Rate", insert.tr_Detail[i].rate));
                    cmddetail.Parameters.Add(new SqlParameter("@Amount", insert.tr_Detail[i].Amount));
                    cmddetail.Parameters.Add(new SqlParameter("@TypeRate", insert.tr_Detail[i].TypeRate));
                    cmddetail.Parameters.Add(new SqlParameter("@TypeDiscount", insert.tr_Detail[i].TypeDiscount));
                    cmddetail.Parameters.Add(new SqlParameter("@valueDiscount", insert.tr_Detail[i].DiscountValue));
                    cmddetail.Parameters.Add(new SqlParameter("@AmountDiscount", insert.tr_Detail[i].AmountDiscount));
                    rdrDetail = cmddetail.ExecuteReader();
                }
                cnn.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
            return Result; 
        }

    }
}
