using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;
using Models;
using SqlKata.Compilers;
using SqlKata;

namespace Services
{
    public class Repository
    {
        private readonly IDbConnection dbConnection;
        private readonly Compiler compiler;

        public Repository(string connection)
        {
            dbConnection = new SqliteConnection(connection);
            compiler = new SqliteCompiler();
        }

        public async Task<List<Habitacion>> ObtenerHabitaciones()
        {
            var consulta = compiler.Compile(new Query("habitaciones"));
            return (await dbConnection.QueryAsync<Habitacion>(consulta.Sql, consulta.NamedBindings)).ToList();
        }   

        public async Task<Habitacion?> ObtenerHabitacionPorId(int id_hab)
        {
            var consulta = compiler.Compile(new Query("habitaciones").Where("id_hab", id_hab));
            return await dbConnection.QueryFirstOrDefaultAsync<Habitacion>(consulta.Sql, consulta.NamedBindings);
        }   
    }
}