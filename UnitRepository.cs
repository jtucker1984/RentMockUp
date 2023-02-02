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

        public apartment AssignCategory()
        {
            var categoryList = GetCategories();
            var apartment = new apartment();
            apartment.Categories = categoryList;

            return apartment;
        }

        public void DeleteApartment(apartment apartment)
        {
            _conn.Execute("DELETE FROM apartment WHERE id =@id;",
                new {id = apartment.id});
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

        public IEnumerable<Category>GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM apartment;");
        }

       

        public void InsertApartment(apartment apartmentToInsert)
        {
            _conn.Execute("INSERT INTO apartment(ID,NAME,UNIT,PAYMENT) VALUES(@id,@name,@unit,@payment);",
                  new {id = apartmentToInsert.id, name = apartmentToInsert.name, unit = apartmentToInsert.unit, payment =apartmentToInsert.payment});
        }

        public void UpdateApartment(apartment apartment)
        {
          _conn.Execute("UPDATE apartment SET Name = @name,Unit = @unit, Payment= @payment WHERE ID =@id",
              new {name = apartment.name, unit = apartment.unit, payment = apartment.payment, id = apartment.id});
        }
    }
}

