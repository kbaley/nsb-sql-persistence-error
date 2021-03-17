using System;
using System.Threading.Tasks;
using NServiceBus;
using Npgsql;
using NpgsqlTypes;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main()
        {
            var config = new EndpointConfiguration("Moo");
            config.EnableInstallers();
            var persistence = config.UsePersistence<SqlPersistence>();
            var dialect = persistence.SqlDialect<SqlDialect.PostgreSql>();
            dialect.JsonBParameterModifier(
                modifier: parameter => {
                    var npgsqlParameter = (NpgsqlParameter)parameter;
                    npgsqlParameter.NpgsqlDbType = NpgsqlDbType.Jsonb;
                }
            );
            var connection = $"Server=127.0.0.1;Database=sagaerror;UserId=kylebaley;";
            persistence.ConnectionBuilder(
                connectionBuilder: () => {
                    return new NpgsqlConnection(connection);
                }
            );
            var transport = config.UseTransport<LearningTransport>();
            transport.StorageDirectory(".");

            var endpoint = await Endpoint.Start(config).ConfigureAwait(false);

            var message = new GenericMessage {
                MyId = 123,
                Name = "My Message",
                // Setting this to any value other than zero works
                MyValue = 0,
            };
            await endpoint.SendLocal(message).ConfigureAwait(false);

            Console.WriteLine("GenericMessage sent");
            Console.ReadLine();

            var another = new AnotherMessage {
                MyId = 123
            };
            await endpoint.SendLocal(another).ConfigureAwait(false);

            Console.WriteLine("AnotherMessage sent");
            Console.ReadLine();

        }
    }
}
