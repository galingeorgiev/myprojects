/* Write a program that retrieves the images for 
 * all categories in the Northwind database and 
 * stores them as JPG files in the file system.
 * 
 * If you using express edition of sql server you 
 * must change connection string in settings file.
 */


namespace RetrievesImagesAndStoreThem
{
    using _05.RetrievesImagesAndStoreThem;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;

    class Program
    {
        public const string FileLocation = @"..\..\CreatedPictures\";

        static void Main()
        {
            SqlConnection dbCon = new SqlConnection(SettingsConnection.Default.DBConnectionString);
            List<byte[]> listOfPictures = new List<byte[]>();
            List<string> listOfCategoryNames = new List<string>();

            try
            {
                dbCon.Open();
                SqlCommand readImages = new SqlCommand("use NORTHWND select Picture, CategoryName from Categories", dbCon);
                SqlDataReader reader = readImages.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        byte[] image = (byte[])reader["Picture"];
                        string categoryName = (string)reader["CategoryName"];
                        if (categoryName.Contains('/'))
                        {
                            categoryName = categoryName.Replace('/', '-');
                        }
                        listOfPictures.Add(image);
                        listOfCategoryNames.Add(categoryName);
                    }
                }

                int offset = 78;
                for (int i = 0; i < listOfPictures.Count; i++)
                {
                    using (FileStream fs = new FileStream(FileLocation + listOfCategoryNames[i] + ".jpg", FileMode.Create))
                    {
                        fs.Write(listOfPictures[i], offset, listOfPictures[i].Length - offset);
                    }
                }

                Console.WriteLine("Images created in folder CreatedPictures");
            }
            catch (Exception ex)
            {
                throw new Exception("{0}", ex);
            }
            finally
            {
                dbCon.Close();
            }
        }
    }
}