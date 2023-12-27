using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TALON.Models;


namespace TALON.Controllers

{
    public class TALON : Controller
    {

        private readonly IConfiguration configuration;
        public TALON(IConfiguration config)
        {
            this.configuration = config;
        }



        public IActionResult Index()
        {
            string connectionString = configuration.GetConnectionString("Default");
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select ID,NAME,PHOTO,DETAILS from talon", conn);
            List<talon> talon = new List<talon>();

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                talon.Add(
                    new talon
                    {
                        ID = (int)dr["ID"],
                        NAME = (string)dr["Name"],
                        PHOTO = (string)dr["PHOTO"],
                        DETAILS = (string)dr["DETAILS"]

                    });

            }

            conn.Close();

            return View(talon);
        }
        public IActionResult Special_Page(int id)
        {

            string connectionString = configuration.GetConnectionString("Default");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sqlQuery = $"SELECT ID, NAME,PHOTO, DETAILS, SPECIAL,LORE,PERK_IMAGE1,PERK_IMAGE2,PERK_IMAGE3,PERK_DESCRIPTION1,PERK_DESCRIPTION2,PERK_DESCRIPTION3,PERK_NAME,PERK_NAME2,PERK_NAME3 FROM talon WHERE ID = {id}";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {

                            talon character = new talon
                            {
                                ID = reader.GetInt32(0),
                                NAME = reader.GetString(1),
                                PHOTO = reader.GetString(2),
                                DETAILS = reader.GetString(3),
                                SPECIAL = reader.GetString(4),
                                LORE = reader.GetString(5),
                                PERK_IMAGE1 = reader.GetString(6),
                                PERK_IMAGE2 = reader.GetString(7),
                                PERK_IMAGE3 = reader.GetString(8),
                                PERK_DESCRIPTION1 = reader.GetString(9),
                                PERK_DESCRIPTION2 = reader.GetString(10),
                                PERK_DESCRIPTION3 = reader.GetString(11),
                                PERK_NAME = reader.GetString(12),
                                PERK_NAME2 = reader.GetString(13),
                                PERK_NAME3 = reader.GetString(14),

                            };


                            return View(character);
                        }
                    }
                }
            }


            return View("CharacterNotFound");
        }

        public IActionResult PERKS(int id)
        {


            string connectionString = configuration.GetConnectionString("Default");
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select ID,NAME,PHOTO,DETAILS,PERK_IMAGE1,PERK_IMAGE2,PERK_IMAGE3,PERK_DESCRIPTION1,PERK_DESCRIPTION2,PERK_DESCRIPTION3,PERK_NAME,PERK_NAME2,PERK_NAME3 from talon", conn);
            List<talon> talon = new List<talon>();

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                talon.Add(
                    new talon
                    {
                        ID = (int)dr["ID"],
                        NAME = (string)dr["Name"],
                        PHOTO = (string)dr["PHOTO"],
                        DETAILS = (string)dr["DETAILS"],
                        PERK_IMAGE1 = (string)dr["PERK_IMAGE1"],
                        PERK_IMAGE2= (string)dr["PERK_IMAGE2"],
                        PERK_IMAGE3 = (string)dr["PERK_IMAGE3"],
                        PERK_DESCRIPTION1 = (string)dr["PERK_DESCRIPTION1"],
                        PERK_DESCRIPTION2 = (string)dr["PERK_DESCRIPTION2"],
                        PERK_DESCRIPTION3 = (string)dr["PERK_DESCRIPTION3"],  
                        PERK_NAME = (string)dr["PERK_Name"],
                        PERK_NAME2 = (string)dr["PERK_Name2"],
                        PERK_NAME3 = (string)dr["PERK_Name3"],
                        

                    });

            }

            conn.Close();

            return View(talon);









        }
    }
}

