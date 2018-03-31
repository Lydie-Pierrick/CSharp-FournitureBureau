using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Data.SQLite;
using Mercure.Controller;
using System.Data.SqlClient;

namespace Mercure.DAO
{
    class DaoFurniture
    {
        private List<String> ListNameTables;
        private static int CountInsertRowArticle = 0;
        private static int CountInsertRowBrand = 0;
        private static int CountInsertRowFamily = 0;
        private static int CountInsertRowSubFamily = 0;

        private static int LastRefBrand = 0;
        private static int LastRefFamily = 0;
        private static int LastRefSubFamily= 0;

        private static SQLiteConnection M_dbConnection;

        public DaoFurniture()
        {
            M_dbConnection = SingletonBD.GetInstance.GetDB();
            ListNameTables = GetAllNameTables();
        }

        // --- Create or modify section

        /*
         *  Create or modify a brand
         *  @return article reference
         */
        public string CreateOrModifyArticle(Article Article)
        {
            SQLiteCommand QueryGetQuantiteArticle = new SQLiteCommand();
            QueryGetQuantiteArticle.Connection = M_dbConnection;

            // Get article if it exists
            int QuantiteArticle = 0;
            QueryGetQuantiteArticle.CommandText = "SELECT Quantite FROM Articles WHERE RefArticle = @RefArticle;";
            QueryGetQuantiteArticle.Parameters.AddWithValue("@RefArticle", Article.GetSetRefArticle);
            SQLiteDataReader GetQuantiteArticleReader = QueryGetQuantiteArticle.ExecuteReader();

            if (GetQuantiteArticleReader.HasRows)
            {
                GetQuantiteArticleReader.Read();
                QuantiteArticle = GetQuantiteArticleReader.GetInt32(0);
            }
            else
            {
                // Get article if it exists
                int IdArticle;

                SQLiteCommand QueryGetArticle = new SQLiteCommand();
                QueryGetArticle.Connection = M_dbConnection;

                QueryGetArticle.CommandText = "SELECT RefArticle FROM Articles WHERE RefArticle = @RefArticle AND Description = @RefDescription AND RefSousFamille = @RefSousFamille AND RefMarque = @RefMarque AND PrixHT = @RefPrixHT AND Quantite = @RefQuantite";
                QueryGetArticle.Parameters.AddWithValue("@RefArticle", Article.GetSetRefArticle);
                QueryGetArticle.Parameters.AddWithValue("@RefDescription", Article.GetSetDescription);
                QueryGetArticle.Parameters.AddWithValue("@RefSousFamille", Article.GetSetSubFamily);
                QueryGetArticle.Parameters.AddWithValue("@RefMarque", Article.GetSetBrand);
                QueryGetArticle.Parameters.AddWithValue("@RefPrixHT", Article.GetSetPriceHT);
                QueryGetArticle.Parameters.AddWithValue("@RefQuantite", QuantiteArticle + 1);
                SQLiteDataReader GetArticleReader = QueryGetArticle.ExecuteReader();

                // Create if it does not exist
                if (!GetArticleReader.HasRows)
                {
                    int idSubFamily = GetOrCreateSubFamily(Article.GetSetSubFamily, Article.GetSetFamily);
                    int idBrand = GetOrCreateBrand(Article.GetSetBrand);

                    // Insert new brand
                    SQLiteCommand QueryInsertBrand = new SQLiteCommand();
                    QueryInsertBrand.Connection = M_dbConnection;

                    QueryInsertBrand.CommandText = "INSERT INTO Articles (RefArticle, Description, RefSousFamille, RefMarque, PrixHT, Quantite) VALUES (@RefArticle, @RefDescription, @RefRefSousFamille, @RefMarque, @RefPrixHT, @RefQuantite);";
                    QueryInsertBrand.Parameters.AddWithValue("@RefArticle", Article.GetSetRefArticle);
                    QueryInsertBrand.Parameters.AddWithValue("@RefDescription", Article.GetSetDescription);
                    QueryInsertBrand.Parameters.AddWithValue("@RefRefSousFamille", idSubFamily);
                    QueryInsertBrand.Parameters.AddWithValue("@RefMarque", idBrand);
                    QueryInsertBrand.Parameters.AddWithValue("@RefPrixHT", Article.GetSetPriceHT);
                    QueryInsertBrand.Parameters.AddWithValue("@RefQuantite", Article.GetSetQuantity);

                    CountInsertRowArticle += QueryInsertBrand.ExecuteNonQuery();

                    return Article.GetSetRefArticle;
                }
                else
                {
                    GetArticleReader.Read();
                    IdArticle = GetArticleReader.GetInt32(0);
                }
            }

            return Article.GetSetRefArticle;
        }

        /*
         *  Get or create a brand
         *
         *  @return id of brand
         */
        private int GetOrCreateBrand(string Brand)
        {
            // Get brand if it exists
            int IdBrand = 0;

            SQLiteCommand QueryGetBrand = new SQLiteCommand();
            QueryGetBrand.CommandText = "SELECT RefMarque FROM Marques WHERE Nom = @Nom;";
            QueryGetBrand.Connection = M_dbConnection;
            QueryGetBrand.Parameters.AddWithValue("@Nom", Brand);

            SQLiteDataReader GetBrandReader = QueryGetBrand.ExecuteReader();

            // Create if it does not exist
            if (!GetBrandReader.HasRows)
            {
                // Get last id for autoincrement
                int LastId = 0;

                SQLiteCommand QueryLastInsertId = new SQLiteCommand();
                QueryLastInsertId.Connection = M_dbConnection;

                QueryLastInsertId.CommandText = "SELECT * FROM Marques;";
                SQLiteDataReader LastInsertReader = QueryLastInsertId.ExecuteReader();

                if (!LastInsertReader.HasRows)
                {
                    LastRefBrand = 0;
                }

                // Insert new brand

                using (var QueryInsertBrand = new SQLiteCommand())
                {
                    QueryInsertBrand.Connection = M_dbConnection;

                    QueryInsertBrand.CommandText = "INSERT INTO Marques (RefMarque, Nom) VALUES (@RefMarque, @RefNom);";
                    QueryInsertBrand.Parameters.AddWithValue("@RefMarque", LastRefBrand + 1);
                    QueryInsertBrand.Parameters.AddWithValue("@RefNom", Brand);
                    CountInsertRowBrand += QueryInsertBrand.ExecuteNonQuery();

                    LastRefBrand++;
                }

                return LastId + 1;
            }
            else
            {
                GetBrandReader.Read();
                IdBrand = GetBrandReader.GetInt32(0);
            }

            return IdBrand;
        }

        /*
         *  Get or create a family
         *
         *  @return id of family
         */
        private int GetOrCreateFamily(string FamilyName)
        {
            SQLiteCommand QueryGetFamily = new SQLiteCommand();
            QueryGetFamily.Connection = M_dbConnection;

            // Get family if it exists
            int IdFamily = 0;
            QueryGetFamily.CommandText = "SELECT * FROM Familles WHERE Nom = @Nom;";
            QueryGetFamily.Parameters.AddWithValue("@Nom", FamilyName);
            SQLiteDataReader GetFamilyReader = QueryGetFamily.ExecuteReader();

            // Create if it does not exist
            if (!GetFamilyReader.HasRows)
            {
                SQLiteCommand QueryLastInsertId = new SQLiteCommand();
                QueryLastInsertId.Connection = M_dbConnection;

                // Get last id for autoincrement
                QueryLastInsertId.CommandText = "SELECT * FROM Familles;";
                SQLiteDataReader LastInsertReader = QueryLastInsertId.ExecuteReader();

                if (!LastInsertReader.HasRows)
                {
                    LastRefFamily = 0;
                }

                SQLiteCommand QueryCreateModify = new SQLiteCommand();
                QueryCreateModify.Connection = M_dbConnection;

                // Insert new family
                QueryCreateModify.CommandText = "INSERT INTO Familles (RefFamille, Nom) VALUES (@RefFamille, @RefNom);";
                QueryCreateModify.Parameters.AddWithValue("@RefFamille", LastRefFamily + 1);
                QueryCreateModify.Parameters.AddWithValue("@RefNom", FamilyName);
                CountInsertRowFamily += QueryCreateModify.ExecuteNonQuery();

                LastRefFamily++;

                return LastRefFamily;
            }
            else
            {
                GetFamilyReader.Read();
                IdFamily = GetFamilyReader.GetInt32(0);
            }

            return IdFamily;
        }

        /*
         *  Get or create a sub family
         *
         *  @return id of sub family
         */
        private int GetOrCreateSubFamily(string SubFamilyName, string FamilyName)
        {
            int IdSubFamily = 0;

            SQLiteCommand QueryGetSubFamily = new SQLiteCommand();
            QueryGetSubFamily.Connection = M_dbConnection;

            // Get sub family if it exists
            QueryGetSubFamily.CommandText = "SELECT RefSousFamille FROM SousFamilles WHERE Nom = @Nom;";
            QueryGetSubFamily.Parameters.AddWithValue("@Nom", SubFamilyName);
            SQLiteDataReader GetSubFamilyReader = QueryGetSubFamily.ExecuteReader();

            // Create if it does not exist
            if (!GetSubFamilyReader.HasRows)
            {
                // Get last id for autoincrement
                int LastId = 0;

                SQLiteCommand QueryLastInsertId = new SQLiteCommand();
                QueryLastInsertId.Connection = M_dbConnection;

                QueryLastInsertId.CommandText = "SELECT * FROM SousFamilles;";
                SQLiteDataReader LastInsertReader = QueryLastInsertId.ExecuteReader();

                if (!LastInsertReader.HasRows)
                {
                    LastRefSubFamily = 0;
                }

                // Get Family for this SubFamily
                int IdFamily = GetOrCreateFamily(FamilyName);

                SQLiteCommand QueryCreateModify  = new SQLiteCommand();
                QueryCreateModify.Connection = M_dbConnection;

                // Insert new sub family
                QueryCreateModify.CommandText = "INSERT INTO SousFamilles (RefSousFamille, RefFamille, Nom) VALUES (@RefSousFamille, @RefFamille, @RefNom);";
                QueryCreateModify.Parameters.AddWithValue("@RefSousFamille", LastRefSubFamily + 1);
                QueryCreateModify.Parameters.AddWithValue("@RefFamille", IdFamily);
                QueryCreateModify.Parameters.AddWithValue("@RefNom", SubFamilyName);
                CountInsertRowSubFamily += QueryCreateModify.ExecuteNonQuery();

                LastRefSubFamily++;

                return LastId + 1;
            }
            else
            {
                GetSubFamilyReader.Read();
                IdSubFamily = GetSubFamilyReader.GetInt32(0);
            }


            return IdSubFamily;
        }

        // Delete

        /*
         * Delete All entries of tables
         */
        public bool DeleteAllEntriesTables()
        {
            int countResetTable = 0;

            foreach (String tableName in ListNameTables)
            {
                SQLiteCommand Delete = new SQLiteCommand();
                Delete.Connection = M_dbConnection;
                Delete.CommandText = "DELETE FROM " + tableName + ";";
                Delete.ExecuteNonQuery();

                countResetTable++;
            }

            if (countResetTable == ListNameTables.Count)
            {
                return true;
            }

            return false;
        }

        // ---

        private List<String> GetAllNameTables()
        {
            List<string> List = new List<string>();

            SQLiteCommand NameTableCommand = new SQLiteCommand();
            NameTableCommand.Connection = M_dbConnection;

            NameTableCommand.CommandText = "SELECT name FROM sqlite_master WHERE type='table';";
            SQLiteDataReader NameTableReader = NameTableCommand.ExecuteReader();

            if (NameTableReader.HasRows)
            {
                try
                {
                    while (NameTableReader.Read())
                    {
                        List.Add(NameTableReader.GetString(0));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error during delete row database ! " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return List;
        }

        public List<Article> GetAllArticles()
        {
            List<Article> ListArticles = new List<Article>();

            SQLiteCommand QueryGetAllArticles = new SQLiteCommand();
            QueryGetAllArticles.CommandText = "SELECT * FROM Articles;";
            QueryGetAllArticles.Connection = SingletonBD.GetInstance.GetDB();
            SQLiteDataReader ArticlesReader = QueryGetAllArticles.ExecuteReader();

            while (ArticlesReader.Read())
            {
                string RefArticle = ArticlesReader.GetString(0);
                string Description = ArticlesReader.GetString(1);
                int RefSubFamily =  ArticlesReader.GetInt32(2);
                int RefBrand = ArticlesReader.GetInt32(3);
                float PriceHT = ArticlesReader.GetFloat(4);
                int Quantity =  ArticlesReader.GetInt32(5);

                // Get the name of this SubFamily
                SQLiteCommand QueryGetSubFamily = new SQLiteCommand();
                QueryGetSubFamily.CommandText = "SELECT Nom FROM SousFamilles WHERE RefSousFamille = @RefSousFamille;";
                QueryGetSubFamily.Parameters.AddWithValue("@RefSousFamille", RefSubFamily);
                QueryGetSubFamily.Connection = SingletonBD.GetInstance.GetDB();
                SQLiteDataReader SubFamilyReader = QueryGetSubFamily.ExecuteReader();
                string SubFamily = null;
                if (SubFamilyReader.Read())
                {
                    SubFamily = SubFamilyReader.GetString(0);
                }

                // Get the name of this SubFamily
                SQLiteCommand QueryGetBrand = new SQLiteCommand();
                QueryGetBrand.CommandText = "SELECT Nom FROM Marques WHERE RefMarque= @RefMarque;";
                QueryGetBrand.Parameters.AddWithValue("@RefMarque", RefBrand);
                QueryGetBrand.Connection = SingletonBD.GetInstance.GetDB();
                SQLiteDataReader BrandReader = QueryGetBrand.ExecuteReader();

                string Brand = null;
                if (BrandReader.Read())
                {
                    Brand = BrandReader.GetString(0);
                }

                // Create a new object Article
                Article Article = new Article(RefArticle, Description, SubFamily, Brand, PriceHT, Quantity);

                // Add this article into the list
                ListArticles.Add(Article);
            }

            return ListArticles;
        }
    }


}
