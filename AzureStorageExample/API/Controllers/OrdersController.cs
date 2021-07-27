using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Common;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using Newtonsoft.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // POST api/<OrdersController> //receives the orders
        [HttpPost]
        public async Task<string> Post([FromBody] OrderDTO order)
        {
            string Result = string.Empty;

            if (ModelState.IsValid)
            {

                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Connections.AzzureStorageConnection);
                CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
                CloudQueue cloudQueue = cloudQueueClient.GetQueueReference("orders");
                if (!await cloudQueue.ExistsAsync())
                {
                    // Create the queue if it doesn't already exist
                    await cloudQueue.CreateIfNotExistsAsync();
                }

                Sequences.OrderID = Sequences.OrderID + 1;
                order.OrderId = Sequences.OrderID;
                //Random rnd = new Random();
                //order.OrderId = rnd.Next(1, 10);
                order.OrderStatus = "Pending";

                if (order != null)
                {
                    var orderMsgValue = JsonConvert.SerializeObject(order);
                    CloudQueueMessage queueMessage = new CloudQueueMessage(orderMsgValue);
                    await cloudQueue.AddMessageAsync(queueMessage);
                    Result = string.Format("Send order '{0}' with random number RandomNumber: {1}", order.OrderText, order.OrderId);
                }
                else
                {
                    Result = string.Format("Error: {0}", "This order is Not valid");
                }
            }
            else
            {
                //Validate model and return validation massages
                Result = string.Format("Error: {0}", "Validate model and return validation massages");
            }
            return Result;
        }
    }
}