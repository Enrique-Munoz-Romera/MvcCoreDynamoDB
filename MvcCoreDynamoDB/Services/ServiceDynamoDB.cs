using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using MvcCoreDynamoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreDynamoDB.Services
{
    public class ServiceDynamoDB
    {
        private DynamoDBContext context;

        public void ServiceAWSDynamoDb()
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            this.context = new DynamoDBContext(client);
        }

        public async Task CreateCoche(Coche car)
        {
            await this.context.SaveAsync<Coche>(car);
        }

        public async Task<List<Coche>> GetCoches()
        {
            var tabla = this.context.GetTargetTable<Coche>();
            var scanOptions = new ScanOperationConfig();
            //scanOptions.PaginationToken = "";
            var results = tabla.Scan(scanOptions);
            //Los datos que recuperamos son document y devuelve una coleccion
            List<Document> data = await results.GetNextSetAsync();
            //Debemos transformar dichos datos a su tippado
            //esto es automatico mediante un metodo
            IEnumerable<Coche> cars = this.context.FromDocuments<Coche>(data);
            return cars.ToList();
        }

        public async Task<Coche> FindCoche(int idcoche)
        {
            //si etamos buscando por patiition key(PK) HASKEY solamente debemos hacerlo con load
            //esto es equivalente a buscar con consulta
            return await this.context.LoadAsync<Coche>(idcoche);
        }

        public async Task DeleteCoche(int idCoche)
        {
            await this.context.DeleteAsync<Coche>(idCoche);
        }
    }
}
