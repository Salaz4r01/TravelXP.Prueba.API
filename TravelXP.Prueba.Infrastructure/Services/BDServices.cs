using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using FluentAssertions.Common;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver.Core.Configuration;
using MySql.Data.MySqlClient;

namespace MySqlConnectionExample
{
    public class BDServices
    {
        private  MySqlConnection _dbConnection {  get; set; }
        private string? _connection { get; set; }


        public BDServices(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("DefaultConnection");
        }

        

        static void Main(string[] args)
        {
            // Configura los parámetros de conexión
            string server = "34.172.54.122"; // La dirección IP de tu instancia de Cloud SQL
            string database = "travelxp"; // El nombre de tu base de datos
            string uid = "Salazar"; // El nombre de usuario de tu instancia de Cloud SQL
            string password = "12345678"; // La contraseña de tu instancia de Cloud SQL
            string port = "3306"; // El puerto MySQL de tu instancia de Cloud SQL

            // Construye la cadena de conexión
            string connectionString = $"Server={server};Port={port};Database={database};Uid={uid};Pwd={password};";

            // Crea una conexión MySQL
            MySqlConnection connection = new(connectionString);

            try
            {
                // Abre la conexión
                connection.Open();

                // La conexión está abierta, puedes ejecutar consultas o realizar otras operaciones aquí

                Console.WriteLine("Conexión establecida correctamente.");

                // Cierra la conexión cuando hayas terminado de usarla
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al establecer la conexión: " + ex.Message);
            }
        }

        public async ValueTask<IEnumerable<T>> ExecuteStoredProcedureQueryAsync<T>(string storedProcedureName, DynamicParameters? parameters = null)
        {
            

            using (var connection = new MySqlConnection(_connection))
            {
                    await connection.OpenAsync();

                    return await connection.QueryAsync<T>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async ValueTask<T> ExecuteStoredProcedureQueryFirstOrDefault<T>(string storedProcedure, DynamicParameters parameters = null)
        {
            using (var connection = new MySqlConnection())
            {
                _dbConnection = connection;
                return await connection.QuerySingleOrDefaultAsync<T>(storedProcedure,
                                        parameters,
                                        commandType: CommandType.StoredProcedure);
            }
        }
    }
}

