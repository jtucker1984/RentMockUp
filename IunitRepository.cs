using System;
using RentMockUp.Models;

namespace RentMockUp
{
	public interface IunitRepository
	{
		public IEnumerable<apartment> GetAllApartments();
		public apartment GetApartment(int id);
	}
}

