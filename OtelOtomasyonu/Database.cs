using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OtelOtomasyonu
{
    public class Database
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=HALIL;Initial Catalog=otel;Integrated Security=True;MultipleActiveResultSets=True");
    }
}
