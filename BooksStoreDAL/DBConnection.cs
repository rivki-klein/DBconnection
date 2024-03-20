using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BooksStoreDAL
{
    public class DBConnection
    {
        public List<BookDetails> GetAllBooks()
        {
            string conStr = 
                ConfigurationManager.ConnectionStrings["shop"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT * from Customer";

            SqlDataReader reader;

            List<BookDetails> listOfBooks = new List<BookDetails>();
            try
            {
                con.Open();

                reader = com.ExecuteReader();

                while( reader.Read())
                {
                    int id = int.Parse(reader["Id"].ToString());
                    string firstName = reader["FirstName"].ToString();
                    string lastName = reader["LastName"].ToString();
                    string city = reader["City"].ToString();
                    string country = reader["Country"].ToString();
                    string phone = reader["Phone"].ToString();
                    var newBook = new BookDetails(id, firstName, lastName, city, country, phone);
                    listOfBooks.Add(newBook);
                }
            }
            catch(Exception ex)
            {

            }
            return listOfBooks;

            
        }

        public bool Add(BookDetails b)
        {
            bool degel = false;
            string conStr =
               ConfigurationManager.ConnectionStrings["shop"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = string.Format("INSERT INTO Customer (Id, FirstName, LastName, City, Country, Phone) VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}'" b.Id, b.FirstName, b.LastName, b.City, b.Country, b.Phone);

            try
            {
                con.Open();
                int numberRows = com.ExecuteNonQuery();
                if (numberRows > 0) degel = true;
            }
            catch(Exception)
            {

            }
            finally
            {
                con.Close();
            }
            return degel;
        }
        //string filePath = Directory.GetCurrentDirectory() + @"\..\..\..\Src\BookList.txt";
        //public List<BookDetails> ReadAllBooks()
        //{
        //    var allLines = File.ReadAllLines(filePath);
        //    List<BookDetails> listOfBooks = new List<BookDetails>();
        //    foreach (var text in allLines)
        //    {
        //        string [] detailsAsString = text.Split(',');
        //        int id = int.Parse(detailsAsString[0]);
        //        string name = detailsAsString[1];
        //        int price = int.Parse(detailsAsString[2]);
        //        int numberOfPages = int.Parse(detailsAsString[3]);
        //        int minAge = int.Parse(detailsAsString[4]);
        //        int maxAge = int.Parse(detailsAsString[5]);
        //        bool isComics = bool.Parse(detailsAsString[6]);
        //        var newBook = new BookDetails(id, name, price, numberOfPages,
        //            minAge, maxAge, isComics);
        //        listOfBooks.Add(newBook);
        //    }
        //    return listOfBooks;
        //}
    }
}
