using Amazon.DynamoDBv2.DataModel;

namespace GloboClimaBlazor.Models
{
    [DynamoDBTable("paisesFavoritos")]
    public class PaisesModel
    {
            [DynamoDBHashKey]
            [DynamoDBProperty("pais_nome")]
            public string Nome { get; set; }
    }
}
