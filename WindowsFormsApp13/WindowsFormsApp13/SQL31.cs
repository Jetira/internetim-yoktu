using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApp13
{
    class sqlbaglanitisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-H8NKVL1;Initial Catalog=master;Integrated Security=True");
            baglanti.Open();
            return baglanti;
         }
    }
}
