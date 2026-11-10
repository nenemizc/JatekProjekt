using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace JatekProjekt
{
    public class AdatbazisKezelo
    {
        private readonly string connectionString;

        public AdatbazisKezelo()
        {
            this.connectionString = "Server=localhost;Database=jatekdb;Uid=root;Pwd=;";
        }

        public List<Karakter> AdatokBetoltese()
        {
            var karakterek = new List<Karakter>();
            string query = "SELECT * FROM karakterek;";

                using (var connection = new MySqlConnection(this.connectionString))
                {
                    connection.Open();

                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("Id");
                                string nev = reader.GetString("Nev");
                                string osztaly = reader.GetString("Osztaly");
                                int szint = reader.GetInt32("Szint");
                                int arany = reader.GetInt32("Arany");
                                string szerver = reader.GetString("Szerver");

                                Karakter karakter = new Karakter(id, nev, osztaly, szint, arany, szerver);

                                karakterek.Add(karakter);
                            }
                        }
                    }
                }

            return karakterek;
        }
    }
}