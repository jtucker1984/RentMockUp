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

        public void UpdateApartment(apartment apartment)
        {
          _conn.Execute("UPDATE apartment SET Name = @name,Unit = @unit, Payment= @payment WHERE ID =@id",
              new {name = apartment.name, unit = apartment.unit, payment = apartment.payment, id = apartment.id});
        }
    }
}

