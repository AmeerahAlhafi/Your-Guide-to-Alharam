using alharamApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace alharamApp.myData
{
    //here all the operatios with database
    public class alharamDAO
    {
        private string ConnectionString = @"Data Source=DESKTOP-ETF55SF\SQLEXP2017;Initial Catalog=alharamDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //fetch all

        public List<facilitie> fetchAllBarbershops()
        {
            List<facilitie> barbershopsList = new List<facilitie>();

            //daelling with data base "using the key word using will make the conections end at the closing paranthases 
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                String sql = "select * from barbershop";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        facilitie barbershop = new facilitie();

                        barbershop.id = reader.GetInt32(0);
                        barbershop.name = reader.GetString(1);
                        barbershop.location = reader.GetString(2);
                        barbershop.image = reader.GetString(3);

                        barbershopsList.Add(barbershop);
                    }

                }

            }

            return barbershopsList;
        }


        public List<facilitie> fetchAllHotels()
        {
            List<facilitie> hotelsList = new List<facilitie>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                String sql = "select * from hotel";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        facilitie hotel = new facilitie();

                        hotel.id = reader.GetInt32(0);
                        hotel.name = reader.GetString(1);
                        hotel.location = reader.GetString(2);
                        hotel.image = reader.GetString(3);

                        hotelsList.Add(hotel);
                    }

                }

            }

            return hotelsList;
        }

        public List<facilitie> fetchAllRestaurants()
        {
            List<facilitie> restaurantList = new List<facilitie>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                String sql = "select * from restaurant";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        facilitie restaurant = new facilitie();

                        restaurant.id = reader.GetInt32(0);
                        restaurant.name = reader.GetString(1);
                        restaurant.location = reader.GetString(2);
                        restaurant.image = reader.GetString(3);

                        restaurantList.Add(restaurant);
                    }

                }

            }

            return restaurantList;
        }

        //fetch depend on user search 

        public List<facilitie> searchBarbershops(string name)
        {

            List<facilitie> returnList = new List<facilitie>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                String sql = "select * from barbershop where barbershopName Like @name";

                SqlCommand command = new SqlCommand(sql, connection);

                //associate @name with parameter 

                command.Parameters.Add("@name", System.Data.SqlDbType.VarChar, 100).Value = "%" + name + "%";
                //the last name here have to match the exact pramerter name

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        facilitie barbershop = new facilitie();

                        barbershop.id = reader.GetInt32(0);
                        barbershop.name = reader.GetString(1);
                        barbershop.location = reader.GetString(2);
                        barbershop.image = reader.GetString(3);

                        returnList.Add(barbershop);

                    }

                }
            }
            return returnList;
        }


        public List<facilitie> searchHotels(string name)
        {

            List<facilitie> returnList = new List<facilitie>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                String sql = "select * from hotel where hotelName Like @name";

                SqlCommand command = new SqlCommand(sql, connection);

                //associate @name with parameter 

                command.Parameters.Add("@name", System.Data.SqlDbType.VarChar, 100).Value = "%" + name + "%";
                //the last name here have to match the exact pramerter name

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        facilitie hotel = new facilitie();

                        hotel.id = reader.GetInt32(0);
                        hotel.name = reader.GetString(1);
                        hotel.location = reader.GetString(2);
                        hotel.image = reader.GetString(3);

                        returnList.Add(hotel);

                    }

                }
            }
            return returnList;
        }



        public List<facilitie> searchRestaurants(string name)
        {

            List<facilitie> returnList = new List<facilitie>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                String sql = "select * from restaurant where restaurantName Like @name";

                SqlCommand command = new SqlCommand(sql, connection);

                //associate @name with parameter 

                command.Parameters.Add("@name", System.Data.SqlDbType.VarChar, 100).Value = "%" + name + "%";
                //the last name here have to match the exact pramerter name

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        facilitie restaurant = new facilitie();

                        restaurant.id = reader.GetInt32(0);
                        restaurant.name = reader.GetString(1);
                        restaurant.location = reader.GetString(2);
                        restaurant.image = reader.GetString(3);

                        returnList.Add(restaurant);

                    }

                }
            }
            return returnList;
        }



    }//end of class
}//end of name space