using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilyonerOyunu
{
    public class KullaniciKod
    {
       
            SqlConnection _connection = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=Milyoner;integrated security=true");
            private void ConnectionControl()
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
            }
            public List<Kullanici> GetAll()
            {
                ConnectionControl();
                SqlCommand command = new SqlCommand("Select * from Kullanici", _connection);

                SqlDataReader reader = command.ExecuteReader();
                List<Kullanici> kullanicilar = new List<Kullanici>();
                while (reader.Read())
                {
                Kullanici kullanici = new Kullanici
                {
                    KullaniciId = Convert.ToInt32(reader["KullaniciId"]),
                    KullaniciAd = reader["KullaniciAd"].ToString(),
                    KullaniciSoyad = reader["KullaniciSoyad"].ToString(),
                    KullaniciPuan = Convert.ToInt32(reader["KullaniciPuan"]),
                    KazanilanPara = Convert.ToInt32(reader["KazanilanPara"])

                };
                kullanicilar.Add(kullanici);
                }
                reader.Close();
                _connection.Close();
                return kullanicilar;
            }

        public List<Kullanici> Search(string key)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Kullanici where KullaniciAd like '%" + key + "%'", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Kullanici> kullanicilar = new List<Kullanici>();
            while (reader.Read())
            {
                Kullanici kullanici = new Kullanici
                {
                    KullaniciId = Convert.ToInt32(reader["KullaniciId"]),
                    KullaniciAd = reader["KullaniciAd"].ToString(),
                    KullaniciSoyad = reader["KullaniciSoyad"].ToString(),
                    KullaniciPuan = Convert.ToInt32(reader["KullaniciPuan"]),
                    KazanilanPara = Convert.ToInt32(reader["KazanilanPara"])

                };
                kullanicilar.Add(kullanici);
            }
            reader.Close();
            _connection.Close();
            return kullanicilar;
        }
        public void Add(Kullanici kullanici)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("insert into Kullanici values(@KullaniciAd,@KullaniciSoyad,@KullaniciPuan,@KazanilanPara)", _connection);
            command.Parameters.AddWithValue("@KullaniciAd", kullanici.KullaniciAd);
            command.Parameters.AddWithValue("@KullaniciSoyad", kullanici.KullaniciSoyad);
            command.Parameters.AddWithValue("@KullaniciPuan", kullanici.KullaniciPuan);
            command.Parameters.AddWithValue("@KazanilanPara", kullanici.KazanilanPara);
            command.ExecuteNonQuery();

            _connection.Close();

        }
    }
}
