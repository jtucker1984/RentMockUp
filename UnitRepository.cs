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
            return _conn.Query<apartment>("SELECT * FROM APARTMENT;");
        }
    }
}

