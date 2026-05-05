namespace Tradogram.REST.SDK.DTO.Request
{
    public class ApprovalMatrixRequest
    {
        /// <summary>
        /// Valid values are: purchase_order, invoice, requisition, or expense
        /// </summary>
        public required string TransactionType { get; set; } = string.Empty;

        /// <summary>
        /// Valid values are: POCode, InvoiceCode, RequisitionCode, or ExpenseCode
        /// </summary>
        public required string TransactionCode { get; set; } = string.Empty;
    }
}
