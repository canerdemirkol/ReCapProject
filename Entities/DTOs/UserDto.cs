using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
	public class UserDto : IDto
	{
		public int UserId { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
		public string MobilePhones { get; set; }
		public string Address { get; set; }
		public string Notes { get; set; }
		public int Gender { get; set; }
		public string Password { get; set; }
		public bool Status { get; set; }
	}
}
