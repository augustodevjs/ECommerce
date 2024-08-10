using Amazon.DynamoDBv2.DataModel;

namespace ECommerce.Domain.Entities;

public class Invoice
{
    public string DocumentClient { get; set; }
    public string InvoiceId { get; set; }
    public decimal TaxableBase { get; set; }
    public decimal TaxRate { get; set; }
    public string Description { get; set; }
    public decimal TaxAmount
    {
        get
        {
            return TaxableBase * TaxRate / 100;
        }
        set
        {
            TaxAmount = value;
        }
    }
}
