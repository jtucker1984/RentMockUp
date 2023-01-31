using System;
using RentMockUp.Models;

namespace RentMockUp
{
	public interface IunitRepository
	{
		public IEnumerable<apartment> GetAllApartments();
	}
}

