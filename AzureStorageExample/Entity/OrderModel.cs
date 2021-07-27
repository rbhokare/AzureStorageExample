using Microsoft.Azure.Cosmos.Table;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class OrderModel : TableEntity
    {
        public OrderModel()
        {

        }
        private void SetDefault()
        {
            //IsActive = true;
            //CreatedBy = 0;
            //DeletedBy = 0;
            //CreatedDate = DateTime.Now;
            //LastModifiedDate = DateTime.Now;
        }

        public OrderModel(string AgentAppID, string MagicNumber)
        {
            PartitionKey = AgentAppID;
            RowKey = MagicNumber;

            //this.AgentAppID = AgentAppID;
            //this.MagicNumber = Convert.ToInt32(MagicNumber);
            SetDefault();
        }


        //[Key]
        //[Required(ErrorMessage = "Agent App ID is Required")]
        //public string AgentAppID { get; set; }

        //[Required(ErrorMessage = "Magic Number is Required")]
        //public int MagicNumber { get; set; }

        [Required(ErrorMessage = "Order Id is Required")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Order Date is Required")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Order Text is Required")]
        public string OrderText { get; set; }

        [Required(ErrorMessage = "Order Status is Required")]
        public string OrderStatus { get; set; }


        //[Required(ErrorMessage = "Is Active is Required")]
        //public bool IsActive { get; set; }

        //[Required(ErrorMessage = "Created Date is Required")]
        //public DateTime CreatedDate { get; set; }

        //[Required(ErrorMessage = "Created Id is Required")]
        //public int CreatedBy { get; set; }

        //[Required(ErrorMessage = "Is Deleted is Required")]
        //public bool IsDeleted { get; set; }

        //[Required(ErrorMessage = "Deleted Date is Required")]
        //public DateTime DeletedDate { get; set; }

        //[Required(ErrorMessage = "Deleted Id is Required")]
        //public int DeletedBy { get; set; }

        //[Required(ErrorMessage = "Last Modified Date is Required")]
        //public DateTime LastModifiedDate { get; set; }
    }
}
