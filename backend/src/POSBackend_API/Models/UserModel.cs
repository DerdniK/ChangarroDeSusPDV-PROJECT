using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Identity;

namespace POSBackend_API.Models
{
    //? TODO: Cambiar por el nombre de la tabla en aws dynamodb
    [DynamoDBTable("Users")]
    public class User
    {
        [DynamoDBHashKey] //! Es la primary key de dynamo, es irrepetible, no se usa Id pq es mas tardado
        public string Username {get; set;} = string.Empty;

        [DynamoDBProperty]
        public static Guid UserId {get; set;} = Guid.NewGuid();

        [DynamoDBProperty]
        public string Password {get; set;} = string.Empty;

        [DynamoDBProperty]
        public static string First_name {get; set;} = string.Empty;

        [DynamoDBProperty]
        public static string Last_name{get; set;} = string.Empty;

        [DynamoDBProperty]
        public static string RoleID {get; set;} = string.Empty;

        [DynamoDBProperty]
        public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
        

    }
}