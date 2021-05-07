using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreDynamoDB.Models
{
    [DynamoDBTable("coches")]
    public class Coche
    {
        [DynamoDBHashKey]
        [DynamoDBProperty("idcoche")]
        public int IdCoche { get; set; }

        [DynamoDBProperty("marca")]
        public String Marca { get; set; }

        [DynamoDBProperty("modelo")]
        public String Modelo { get; set; }

        [DynamoDBProperty("vmax")]
        public int VMax { get; set; }

    }
}
