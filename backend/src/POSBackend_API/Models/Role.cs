using Amazon.DynamoDBv2.DataModel;

namespace POSBackend_API.Models
{
    //? TODO: Cambiar por el nombre de la tabla en aws dynamodb
    [DynamoDBTable("Roles")]
    public class Role
    {
        public string Role_name {get; set;} = "Cajero";
        public Guid IDRole {get; set;} = Guid.NewGuid();
        public string Description {get; set;} = string.Empty;
        
    }
}