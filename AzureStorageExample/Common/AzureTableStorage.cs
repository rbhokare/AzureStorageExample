using Entity;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class AzureTableStorage
    {

        //CloudStorageAccount storageAcc ;
        //CloudTableClient tblclient ;
        //CloudTable table;


        public AzureTableStorage(string ConnectionString, string TableName, string partitionKey, string rowKey)
        {
            //storageAcc = CloudStorageAccount.Parse(ConnectionString);
            //tblclient = storageAcc.CreateCloudTableClient(new TableClientConfiguration());
            //table = tblclient.GetTableReference(TableName);
        }
        public async Task InsertTableEntity(OrderModel orderModel)
        {
            try
            {
                CloudStorageAccount storageAcc = CloudStorageAccount.Parse(Connections.AzzureStorageConnection);
                CloudTableClient tblclient = storageAcc.CreateCloudTableClient(new TableClientConfiguration());
                CloudTable table = tblclient.GetTableReference(AzureQueque.confirmation);

                table.CreateIfNotExists();


                OrderModel entity = new OrderModel(orderModel.PartitionKey, orderModel.RowKey);
                entity.OrderId = orderModel.OrderId;
                entity.OrderText = orderModel.OrderText;
                entity.OrderDate = orderModel.OrderDate;
                entity.OrderStatus = orderModel.OrderStatus;
                TableOperation insertOperation = TableOperation.InsertOrMerge(entity);
                TableResult result = await table.ExecuteAsync(insertOperation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrderModel> ReadEntity(string p_PartitionKey, string p_RowKey)
        {
            OrderModel obj = null;
            try
            {
                CloudStorageAccount storageAcc = CloudStorageAccount.Parse(Connections.AzzureStorageConnection);
                CloudTableClient tblclient = storageAcc.CreateCloudTableClient(new TableClientConfiguration());
                CloudTable table = tblclient.GetTableReference(AzureQueque.confirmation);

                TableOperation readOperation = TableOperation.Retrieve<OrderModel>(p_PartitionKey, p_RowKey);
                TableResult result = await table.ExecuteAsync(readOperation);

                obj = result.Result as OrderModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return obj;
        }

    }
}
