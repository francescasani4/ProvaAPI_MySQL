using System;
namespace ProvaAPI_MySQL.Model.Request
{
	public class UserRequest
	{
        public int? IdUser { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? Name { get; set; }

        public string? SurName { get; set; }
    }
}

