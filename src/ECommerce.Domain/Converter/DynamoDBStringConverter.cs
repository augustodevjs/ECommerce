using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace ECommerce.Domain.Converter;

public class DynamoDBStringConverter<TEnum> : IPropertyConverter
{
    public object FromEntry(DynamoDBEntry entry)
    {
        return (TEnum)Enum.Parse(typeof(TEnum), entry.AsString());
    }

    public DynamoDBEntry ToEntry(object value)
    {
        return new Primitive(value.ToString());
    }
}
