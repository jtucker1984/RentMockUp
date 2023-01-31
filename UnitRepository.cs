using System;
using System.Data;
using Dapper;
using RentMockUp.Models;

namespace RentMockUp
{
	public class UnitRepository:IunitRepository
	{
        private readonly IDbConnection _conn;
        public UnitRepository(IDbConnection conn)
		{
            _conn = conn;
		}

        public IEnumerable<apartment> GetAllApartments()
        {
            return _conn.Query<apartment>("SELECT * FROM apartment;");
        }

        public apartment GetApartment(int id)
        {
           return _conn.QuerySingle<apartment>("SELECT * FROM apartment WHERE ID = @id",
               new {id = id});
        }
    }
}

