using System;
using System.Data.SqlClient;
using System.Linq;

namespace ConsoleApp2
{
    internal class Program
    {

        static void Main(string[] args)
        {


            Console.WriteLine("Enter your username:");
            string UserName = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string UserPassword = Console.ReadLine();
            //UserValidate(UserName, UserPassword);
            PerformSQL(UserName,UserPassword);
            Console.ReadKey();
        }

        //public static void UserValidate(string x, string y)
        //{



        //    if (!x.Contains<char>('\'') || !y.Contains<char>('\''))
        //    {
        //        PerformSQL(x, y);

        //       //Console.WriteLine($"The user input does not contain sql special characters.");

        //    }

        //    else
        //    {
        //        Console.WriteLine("Your credentials contained invalid input. Please try again.");
        //    }


        //}

        //public static void Check(string x) 
        //{
        //    x.IndexOf('\'');

        //    if() 
            
        //    {
            
        //    }

        //}
        // ####################### sql injection works ############################################################
        //public static void PerformSQL(string x, string y)
        //{
        //    string connectionString = "Server=DESKTOP-QI20K42\\SQLEXPRESS;Database=Cyber;Trusted_Connection=True;TrustServerCertificate=True";

        //    string sqlQuery = $"SELECT * FROM Employees WHERE FirstName='{x}' AND PassWord='{y}'";


        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
        //        {
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    Console.WriteLine($"First name:{reader["FirstName"]} Last name :{reader["LastName"]} and to contact them Email: {reader["Email"]}");
        //                }
        //                Console.ReadKey();
        //            }
        //        }

        //    }
        //}
        public static void PerformSQL(string x, string y)
        {
            string connectionString = "Server=DESKTOP-QI20K42\\SQLEXPRESS;Database=Cyber;Trusted_Connection=True;TrustServerCertificate=True";
            string storedProcedure = "User_Login";


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue($"@Username", x);
                    cmd.Parameters.AddWithValue($"@Password", y);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"First name:{reader["FirstName"]} Last name :{reader["LastName"]} and to contact them Email: {reader["Email"]}");
                        }
                        Console.ReadKey();
                    }
                }

            }
        }
    }

}
