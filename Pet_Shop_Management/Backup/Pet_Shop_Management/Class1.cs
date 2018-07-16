using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace Pet_Shop_Management
{
    class Class1
    {
        public SqlConnection cnn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=PETS;Integrated Security=True");

    }
}
