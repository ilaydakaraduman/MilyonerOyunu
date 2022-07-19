using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilyonerOyunu.SorularGenel
{
     public class SorularKod
    {
        SqlConnection _connection = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=Milyoner;integrated security=true");
        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        public List<CikanSoru> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Sorular", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<CikanSoru> sorular = new List<CikanSoru>();
            while (reader.Read())
            {
                CikanSoru soru = new CikanSoru
                {
                    SoruId = Convert.ToInt32(reader["SoruId"]),
                    SoruNumarasi = Convert.ToInt32(reader["SoruNumarasi"]),
                    Soru = reader["Soru"].ToString(),
                    CevapA = reader["CevapA"].ToString(),
                    CevapB = reader["CevapB"].ToString(),
                    CevapC = reader["CevapC"].ToString(),
                    CevapD = reader["CevapD"].ToString(),
                    SoruPuani = Convert.ToInt32(reader["SoruPuani"]),
                    DogruCevap = reader["DogruCevap"].ToString()

                };
                sorular.Add(soru);
            }
            reader.Close();
            _connection.Close();
            return sorular;
        }

    }
}
