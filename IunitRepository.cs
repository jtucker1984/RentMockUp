using System;
using RentMockUp.Models;

namespace RentMockUp
{
	public interface IunitRepository
	{
		public IEnumerable<apartment> GetAllApartments();
		public apartment GetApartment(int id);
		public void UpdateApartment(apartment apartment);
		public void InsertApartment(apartment apartmentToInsert);
		public IEnumerable<Category> GetCategories();
		public apartment AssignCategory();
		public void DeleteApartment(apartment apartment);
	}
}

