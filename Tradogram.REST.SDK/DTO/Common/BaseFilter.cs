using System.ComponentModel;

namespace Tradogram.REST.SDK.DTO.Common
{
    public class BaseFilter
    {
        public string? CreatedDateStart { get; set; }
        public string? CreatedDateEnd { get; set; }
        public string? ModifiedDateStart { get; set; }
        public string? ModifiedDateEnd { get; set; }
    }

    [Flags]
    public enum PurchaseOrderStatuses
    {
        Default = 0,
        [Description("Pending Approval")]
        PendingApproval = 1,
        [Description("Approval Rejected")]
        ApprovalRejected = 2,
        [Description("Pending Supplier")]
        PendingSupplier = 4,
        [Description("Declined by Supplier")]
        DeclinedBySupplier = 8,
        Issued = 16,
        [Description("In Delivery")]
        InDelivery = 32,
        [Description("Fully Received")]
        FullyReceived = 64,
        Closed = 128,
        Cancelled = 256,
        [Description("New Qoute")]
        NewQoute = 512,
        [Description("Declined Qoute")]
        DeclinedQoute = 1024,
        [Description("Waiting for Confirmation")]
        WaitingForConfirmation = 2048
    }
    public enum InvoiceStatuses
    {
        Default = 0,
        [Description("Pending Approval")]
        PendingApproval = 1,
        Declined = 2,
        [Description("Approved for Payment")]
        ApprovedForPayment = 4,
        Paid = 8,
        New = 16,
        [Description("Approval Rejected")]
        ApprovalRejected = 32
    }

    public enum DeliveryStatuses
    {
        Default = 0,
        [Description("In Delivery")]
        InDelivery = 1,
        [Description("Fully Received")]
        FullyReceived = 2,
        Closed = 4
    }

    public enum ExpenseStatuses
    {
        Default = 0,
        [Description("Pending Approval")]
        PendingApproval = 1,
        Approved = 2,
        Paid = 4
    }

    public enum FetchTypes
    {
        Flagged,
        Unflagged,
        Both
    }
}
