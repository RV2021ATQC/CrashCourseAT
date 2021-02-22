using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestProject
{
	class Connection
	{
		private string datasource;
		private string username;
		private string password;
		private string database;
		 public Connection(string datasource, string username, string password, string database)
		{
			this.datasource = datasource;
			this.username = username;
			this.password = password;
			this.database = database;
		}
		public static string connectionToDataBase(string datasource, string username, string password, string database)
		{
			string connection = ("datasource=" + datasource + "; port=3306; username=" + username + "; password=" + password + "; database=" + database + ";");
			return connection;
		}
	}
	
}
