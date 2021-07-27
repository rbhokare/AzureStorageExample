using System; // Namespace for Console output
using System.Threading.Tasks;
//using System.Configuration; // Namespace for ConfigurationManager
//using System.Threading.Tasks; // Namespace for Task
//using Azure.Storage.Queues; // Namespace for Queue storage types
//using Azure.Storage.Queues.Models; // Namespace for PeekedMessage
using Common;
using DTO;
using Entity;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
//using DTO;
//using Entity;
//using Newtonsoft.Json;

namespace OrderProcessor
{
    //using System;
    //using System.Threading.Tasks;
    //using Azure.Storage.Queues;
    //using Azure.Storage.Queues.Models;
    //using Common;
    //using DTO;
    //using Entity;
    //using Newtonsoft.Json;

    class Program
    {
        private static string agentAppID;
        static async Task Main(string[] args)
        {
            if (String.IsNullOrEmpty(Connections.AzzureStorageConnection))
            {
                Connections.AzzureStorageConnection = "UseDevelopmentStorage=true";
            }

            agentAppID = Guid.NewGuid().ToString();
            Console.WriteLine("Press Enter for Continue...");
            var ReadKey = Console.ReadKey();
            //var readobj = Convert.ToString(ReadKey.Key);
            for (int i = 0; i <= 1; i++)
            {
                if (Convert.ToString(ReadKey.Key) == "Enter")
                {
                    await check();
                    i = 0;
                }
                else
                {
                    i++;
                }
                Console.WriteLine("Please provide input!...");
                ReadKey = Console.ReadKey();
                //readobj = Convert.ToString(tst.Key);
            }


            //QueueClient orderQueue = new QueueClient(Connections.AzzureStorageConnection, AzureQueque.orders);
            ////QueueClient confirmationQueue = new QueueClient(Connections.AzzureStorageConnection, AzureQueque.confirmations);
            //AzureStorage azureStorage = new AzureStorage();

            //Console.WriteLine("Press Enter for Continue...");
            //Console.ReadLine();

            //var CheckQueue = await azureStorage.CheckQueueExist(orderQueue);
            //if (CheckQueue)
            //    Console.WriteLine("{0} queue is created...", orderQueue.Name);
            //else
            //    Console.WriteLine("{0} queue is already created...", orderQueue.Name);

            //if (await orderQueue.ExistsAsync())
            //{
            //    QueueMessage[] retrievedMessage = await orderQueue.ReceiveMessagesAsync(1);
            //    var MessageText = retrievedMessage[0].Body.ToString();
            //    OrderDTO order = JsonConvert.DeserializeObject<OrderDTO>(MessageText);

            //    //Sequences.AgentAppID = Sequences.AgentAppID + 1;

            //    OrderModel orderModel = new OrderModel();
            //    //orderModel.OrderId = order.OrderId;
            //    //orderModel.AgentAppID = Guid.NewGuid();
            //    //orderModel.MagicNumber = Sequences.AgentAppID;
            //    //orderModel.OrderDate = order.OrderDate;
            //    //orderModel.OrderText = order.OrderText;
            //    //orderModel.OrderStatus = "Processed";

            //    orderModel.PartitionKey = Convert.ToString(orderModel.AgentAppID);
            //    orderModel.RowKey = Convert.ToString(Sequences.AgentAppID);
            //    //orderModel.Timestamp = DateTime.Now;

            //    Console.WriteLine($"Received order OrderId: {order.OrderId}");
            //    Console.WriteLine($"order Text: {order.OrderText}");

            //    await orderQueue.DeleteMessageAsync(retrievedMessage[0].MessageId, retrievedMessage[0].PopReceipt);
            //}
            //else
            //{

            //}

            ////    //Get the message from the queue
            ////    QueueMessage[] messages = await orderQueue.ReceiveMessagesAsync();

            ////foreach (var msg in messages)
            ////{
            ////    //var RetrievedMessage = await azureStorage.RetrieveNextMessageAsync(orderQueue);

            ////    Console.WriteLine("Press Enter for Continue...");
            ////    Console.ReadLine();

            ////    //var result = JsonConvert.DeserializeObject<T>(json);
            ////    //OrderDTO order = (OrderDTO)RetrievedMessage;
            ////    OrderDTO order = JsonConvert.DeserializeObject<OrderDTO>(msg.MessageText);

            ////    Sequences.AgentAppID = Sequences.AgentAppID + 1;

            ////    OrderModel orderModel = new OrderModel();
            ////    orderModel.OrderId = order.OrderId;
            ////    orderModel.AgentAppID = Guid.NewGuid();
            ////    orderModel.MagicNumber = Sequences.AgentAppID;
            ////    orderModel.OrderDate = order.OrderDate;
            ////    orderModel.OrderText = order.OrderText;
            ////    orderModel.OrderStatus = "Processed";

            ////    orderModel.PartitionKey = Convert.ToString(orderModel.AgentAppID);
            ////    orderModel.RowKey = Convert.ToString(Sequences.AgentAppID);
            ////    orderModel.Timestamp = DateTime.Now;

            ////    Console.WriteLine($"Received order OrderId: {order.OrderId}");
            ////    Console.WriteLine($"order Text: {order.OrderText}");

            ////    var confirmOrderMassage = JsonConvert.SerializeObject(orderModel);
            ////    //var result= await azureStorage.CreateTableAsync("confirmation");

            ////    // Retrieve storage account from connection-string.
            ////    CloudStorageAccount storageAccount =
            ////        CloudStorageAccount.Parse(Connections.AzzureStorageConnection);

            ////    // Create the table client.
            ////    CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            ////    // Create a cloud table object for the table.
            ////    CloudTable cloudTable = tableClient.GetTableReference("Confirmation");

            ////    // Create the table
            ////    await cloudTable.CreateIfNotExistsAsync();

            ////    #region new code
            ////    // Create the InsertOrReplace table operation
            ////    TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(orderModel);

            ////    // Execute the operation.
            ////    TableResult result = await cloudTable.ExecuteAsync(insertOrMergeOperation);
            ////    OrderModel insertedCustomer = result.Result as OrderModel;

            ////    if (result.Result != null)
            ////    {
            ////        Console.WriteLine("Request Charge of InsertOrMerge Operation: " + result.Result.ToString());
            ////    }
            ////    #endregion
            ////    //// Create an operation to add the new customer to the people table.
            ////    //TableOperation insertOrder = TableOperation.InsertOrReplace(orderModel);

            ////    //// Submit the operation to the table service.
            ////    //await cloudTable.ExecuteAsync(insertOrder);

            ////    Console.WriteLine($"I’m agent {0}, my magic number is:{1}", orderModel.AgentAppID, orderModel.MagicNumber);
            ////}

            Console.WriteLine("Press Enter for Exit...");
            Console.ReadLine();
        }

        public static async Task check()
        {
            for (int i = 0; i <= 1; i++)
            {
                if (await RetrieveMessage())
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
        }

        public static async Task<bool> RetrieveMessage()
        {
            bool result = true;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Connections.AzzureStorageConnection);
            CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue cloudQueue = cloudQueueClient.GetQueueReference("orders");
            CloudQueueMessage queueMessage = await cloudQueue.GetMessageAsync();
            Console.WriteLine();
            if (queueMessage == null)
            {
                Console.WriteLine("orders Queue is empty!...");
                result = false;
            }
            else
            {
                Console.WriteLine("Order Message: " + queueMessage.AsString);

                OrderDTO order = JsonConvert.DeserializeObject<OrderDTO>(queueMessage.AsString);

                Sequences.MagicNumber = Sequences.MagicNumber + 1;

                var magicNumber = Sequences.MagicNumber;

                OrderModel orderModel = new OrderModel(agentAppID, magicNumber.ToString());
                orderModel.OrderId = order.OrderId;
                //orderModel.AgentAppID = agentAppID;
                //orderModel.MagicNumber = magicNumber;
                orderModel.OrderDate = order.OrderDate;
                orderModel.OrderText = order.OrderText;
                orderModel.OrderStatus = "Processed";

                orderModel.PartitionKey = Convert.ToString(agentAppID);
                orderModel.RowKey = Convert.ToString(magicNumber);
                //orderModel.Timestamp = DateTime.Now;

                Console.WriteLine($"Received order OrderId: {order.OrderId}");
                Console.WriteLine($"order Text: {order.OrderText}");

                Console.WriteLine();
                Console.WriteLine("Order Supervisor Agent Application ID: " + Convert.ToString(agentAppID));

                Console.WriteLine();
                Console.WriteLine("Try to insert values into the table");
                AzureTableStorage azureTable = new AzureTableStorage(Connections.AzzureStorageConnection, AzureQueque.confirmation, "AgentAppID", "MagicNumber");
                await azureTable.InsertTableEntity(orderModel);
                Console.WriteLine("Record Inserted into the table");

                Console.WriteLine();
                Console.WriteLine("Retrieve values from table");
                var obj = await azureTable.ReadEntity(agentAppID, magicNumber.ToString());

                if (obj != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("The Agent Application ID Key is: " + obj.PartitionKey);
                    Console.WriteLine("The Magic Number is " + obj.RowKey);
                    Console.WriteLine("The Order ID is " + obj.OrderId);
                    Console.WriteLine("The OrderText is " + obj.OrderText);
                    Console.WriteLine("The Order Status is " + obj.OrderStatus);
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Order Not Found in confirmation Table!...");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                //CloudStorageAccount storageAcc = CloudStorageAccount.Parse(Connections.AzzureStorageConnection);
                //CloudTableClient tblclient = storageAcc.CreateCloudTableClient(new TableClientConfiguration());
                //CloudTable table = tblclient.GetTableReference(table1);

                //table.CreateIfNotExists();

                //InsertTableEntity(table).Wait();

                await cloudQueue.DeleteMessageAsync(queueMessage);
            }
            return result;
        }
    }
}
