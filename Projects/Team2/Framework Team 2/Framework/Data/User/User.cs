using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Framework.Data.User
{
	class User
	{
		public static Account GetUser()
		{
		    Account account = new Account("kover18595@geeky83.com", "hahaitwork");
			return account;
		}
	}
}
