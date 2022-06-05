using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace lab1
{
   
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
  
    public class WebService1 : System.Web.Services.WebService
    {

       string cs = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"; 

        [WebMethod]
       public List<string> GetListOfClothes(string Id, string Name, string Amount, string Price, string Description)
        {
            List<string> cl = new List<string>();
           
            string selstr = "SELECT *";
            
            selstr += " FROM Shop";
            if (Id != "" || Name != "" || Amount != "" || Price != "" || Description != "")
            {
                selstr += " WHERE";
                int itt = 0;
                if (Id != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " Id=" + "'" + Id + "'";
                    itt = 1;
                }
               
                if (Name != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " Name=" + "'" + Name + "'";
                    itt = 1;

                }
                if (Amount != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " Amount=" + "'" + Amount + "'";
                    itt = 1;

                }
                if (Price != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " Price=" + "'" + Price + "'";
                    itt = 1;

                }
                if (Description != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " Description=" + "'" + Description + "'";
                    itt = 1;

                }
            }



            DataTable dd = new DataTable();


            using (SqlDataAdapter sda = new SqlDataAdapter(selstr, new SqlConnection(cs)))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                    foreach(DataRow dr in dt.Rows)
                       {
                           cl.Add(dr[0].ToString() + "        " + dr[1].ToString() + "        " + dr[2].ToString() + "        " + dr[3].ToString() + "        " + dr[4].ToString());
                       };

                    } 

                return cl;
            }

        [WebMethod]
        public int AddListOfClothes(string Id, string Name, string Amount, string Price, string Description)
        {
          
            string command = "INSERT INTO Shop SELECT '" + Convert.ToInt32(Id) + "','"
                + Name + "','" + Convert.ToInt32(Amount) + "'," + Convert.ToInt32(Price) + ", '"
                + Description + "' ";
            SqlConnection scon = new SqlConnection(cs);
            scon.Open();
            SqlCommand updcmd = new SqlCommand(command, scon);
            updcmd.ExecuteNonQuery();
            scon.Close();
            return 0;

        }



        [WebMethod]
        public int EditListOfClothes(string Id, string Name, string Amount, string Price, string Description)
        {
          
            string selstr = "UPDATE Shop ";

            if (Name != "" || Amount != "" || Price != "" || Description != "")
            {
                selstr += " Set";
                int itt = 0;
                if (Name != "")
                {
                    if (itt == 1) { selstr += " , "; };
                    selstr += " Name=" + "'" + Name + "'";
                    itt = 1;
                }


                if (Amount != "")
                {
                    if (itt == 1) { selstr += " , "; };
                    selstr += " Amount=" + "'" + Amount + "'";
                    itt = 1;

                }
                if (Price != "")
                {
                    if (itt == 1) { selstr += " , "; };
                    selstr += " Price=" + "'" + Price + "'";
                    itt = 1;

                }
                if (Description != "")
                {
                    if (itt == 1) { selstr += " , "; };
                    selstr += " Description=" + "'" + Description + "'";
                    itt = 1;

                }
            }
            selstr += " WHERE Id = '" + Id + "'";

            SqlConnection scon = new SqlConnection(cs);
            scon.Open();
            SqlCommand updcmd = new SqlCommand(selstr, scon);
            updcmd.ExecuteNonQuery();
            scon.Close();
            return 0;

        }



        [WebMethod]
        public int DeleteListOfClothes(string Id, string Name, string Amount, string Price, string Description)
        {
          

            string selstr = "Delete FROM Shop";
            if (Id != "" || Name != "" || Amount != "" || Price != "" || Description != "")
            {
                selstr += " WHERE";
                int itt = 0;
                if (Id != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " Id=" + "'" + Convert.ToInt32(Id) + "'";
                    itt = 1;
                }

                if (Name != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " Name=" + "'" + Name + "'";
                    itt = 1;

                }
                if (Amount != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " Amount =" + "'" + Convert.ToInt32(Amount) + "'";
                    itt = 1;

                }
                if (Price != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " Price=" + "'" + Convert.ToInt32(Price) + "'";
                    itt = 1;

                }
                if (Description != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " Description=" + "'" + Description + "'";
                    itt = 1;

                }
            }

            
            SqlConnection scon = new SqlConnection(cs);
            scon.Open();
            SqlCommand updcmd = new SqlCommand(selstr, scon);
            updcmd.ExecuteNonQuery();
            scon.Close();
            return 0;

        }

        }
    }

