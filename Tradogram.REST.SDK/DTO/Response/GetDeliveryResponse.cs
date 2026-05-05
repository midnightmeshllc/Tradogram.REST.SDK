using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class GetDeliveryResponse
    {
        public List<Delivery> Deliveries { get; set; } = new List<Delivery>();
    }

    public class Delivery
    {
        public string DeliveryCode { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string ModifiedDate { get; set; } = string.Empty;
        public string POCode { get; set; } = string.Empty;
        public string POName { get; set; } = string.Empty;
        public string PONumber { get; set; } = string.Empty;
        public string POStatus { get; set; } = string.Empty;
        public string BuyerBranchName { get; set; } = string.Empty;
        public string SupplierName { get; set; } = string.Empty;
        public string SupplierAccount { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string DeliveredVia { get; set; } = string.Empty;
        public string BillNumber { get; set; } = string.Empty;
        public string InvoiceNumber { get; set; } = string.Empty;
        public string ShippedDate { get; set; } = string.Empty;
        public string ArrivalDate { get; set; } = string.Empty;
        public string ReceiveDate { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public bool IsBooked { get; set; } = false;
        public bool Isedited { get; set; } = false;
        public string BookedDate { get; set; } = string.Empty;
        public string BookedUserName { get; set; } = string.Empty;
        public string EditedDate { get; set; } = string.Empty;
        public string EditedUserName { get; set; } = string.Empty;
        public List<DeliveryItem> DeliveryItems { get; set; } = new List<DeliveryItem>();
        public List<CustomField> CustomFields { get; set; } = new List<CustomField>();
        public bool HasAttachments { get; set; } = false;
    }

    public class DeliveryItem
    {
        public int DeliveryItemIndex { get; set; }
        public string DeliveryItemCode { get; set; } = string.Empty;
        public string LineItemCode { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string ItemNumber { get; set; } = string.Empty;
        public string QtyShipped { get; set; } = string.Empty;
        public string QtyReceived { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string QtyOrdered { get; set; } = string.Empty;
        public string UOM { get; set; } = string.Empty;
        public string DepartmentNumber { get; set; } = string.Empty;
        public List<CustomField> CustomFields { get; set; } = new List<CustomField>();
    }
}
