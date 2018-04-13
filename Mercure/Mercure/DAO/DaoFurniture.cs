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
using Mercure.Model;
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

        /// <summary>
        /// Create or modify article from the Dialog_SelectXML
        /// </summary>
        /// <param name="Article"> The Article object to add </param>
        public void CreateOrModifyArticleXML(Article Article)
        {
            try
            {
                int QuantiteArticle = 0;

                SQLiteCommand QueryGetQuantiteArticle = new SQLiteCommand();
                QueryGetQuantiteArticle.Connection = M_dbConnection;

                // Get article if it exists
                QueryGetQuantiteArticle.CommandText = "SELECT Quantite FROM Articles WHERE RefArticle = @RefArticle;";
                QueryGetQuantiteArticle.Parameters.AddWithValue("@RefArticle", Article.GetSetRefArticle);
                SQLiteDataReader GetQuantiteArticleReader = QueryGetQuantiteArticle.ExecuteReader();

                if (GetQuantiteArticleReader.HasRows)
                {
                    GetQuantiteArticleReader.Read();
                    QuantiteArticle = GetQuantiteArticleReader.GetInt32(0);

                    Article.GetSetQuantity = QuantiteArticle + 1;

                    ModifyArticle(Article);                   
                }
                else
                {
                    CreateArticle(Article);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Create or modify article from the Dialog_AddEditArticle
        /// </summary>
        /// <param name="Article"> The Article object to add </param>
        /// <param name="ActioNEdit"> The action wanted by the user, if true it's edit action</param>
        public void CreateOrModifyArticle(Article Article, bool ActionEdit)
        {
            try
            {
                int QuantiteArticle = 0;

                SQLiteCommand QueryGetQuantiteArticle = new SQLiteCommand();
                QueryGetQuantiteArticle.Connection = M_dbConnection;

                // Get article if it exists
                QueryGetQuantiteArticle.CommandText = "SELECT Quantite FROM Articles WHERE RefArticle = @RefArticle;";
                QueryGetQuantiteArticle.Parameters.AddWithValue("@RefArticle", Article.GetSetRefArticle);
                SQLiteDataReader GetQuantiteArticleReader = QueryGetQuantiteArticle.ExecuteReader();

                if (GetQuantiteArticleReader.HasRows)
                {
                    GetQuantiteArticleReader.Read();
                    QuantiteArticle = GetQuantiteArticleReader.GetInt32(0);

                    if (!ActionEdit)
                    {
                        Article.GetSetQuantity += QuantiteArticle;
                    }

                    ModifyArticleQuantity(Article);
                }
                else
                {
                    CreateArticle(Article);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void CreateArticle(Article Article)
        {
            // Create SubFamily or Brand if it does not exist
            int idSubFamily = GetOrCreateSubFamily(Article.GetSetSubFamily, Article.GetSetFamily);
            int idBrand = GetOrCreateBrand(Article.GetSetBrand);

            // Insert new brand
            SQLiteCommand QueryInsertArticle = new SQLiteCommand();
            QueryInsertArticle.Connection = M_dbConnection;

            QueryInsertArticle.CommandText = "INSERT INTO Articles (RefArticle, Description, RefSousFamille, RefMarque, PrixHT, Quantite) VALUES (@RefArticle, @RefDescription, @RefRefSousFamille, @RefMarque, @RefPrixHT, @RefQuantite);";
            QueryInsertArticle.Parameters.AddWithValue("@RefArticle", Article.GetSetRefArticle);
            QueryInsertArticle.Parameters.AddWithValue("@RefDescription", Article.GetSetDescription);
            QueryInsertArticle.Parameters.AddWithValue("@RefRefSousFamille", idSubFamily);
            QueryInsertArticle.Parameters.AddWithValue("@RefMarque", idBrand);
            QueryInsertArticle.Parameters.AddWithValue("@RefPrixHT", Article.GetSetPriceHT);
            QueryInsertArticle.Parameters.AddWithValue("@RefQuantite", 1);

            CountInsertRowArticle += QueryInsertArticle.ExecuteNonQuery();
        }

        private void ModifyArticle(Article Article)
        {
            // Create SubFamily or Brand if it does not exist
            int idSubFamily = GetOrCreateSubFamily(Article.GetSetSubFamily, Article.GetSetFamily);
            int idBrand = GetOrCreateBrand(Article.GetSetBrand);

            // Insert new brand
            SQLiteCommand QueryModifyArticle = new SQLiteCommand();
            QueryModifyArticle.Connection = M_dbConnection;

            QueryModifyArticle.CommandText = "UPDATE Articles SET Description = @RefDescription, RefSousFamille = @RefRefSousFamille, RefMarque = @RefMarque, PrixHT = @RefPrixHT, Quantite = @RefQuantite WHERE RefArticle = @RefArticle;";
            QueryModifyArticle.Parameters.AddWithValue("@RefArticle", Article.GetSetRefArticle);
            QueryModifyArticle.Parameters.AddWithValue("@RefDescription", Article.GetSetDescription);
            QueryModifyArticle.Parameters.AddWithValue("@RefRefSousFamille", idSubFamily);
            QueryModifyArticle.Parameters.AddWithValue("@RefMarque", idBrand);
            QueryModifyArticle.Parameters.AddWithValue("@RefPrixHT", Article.GetSetPriceHT);
            QueryModifyArticle.Parameters.AddWithValue("@RefQuantite", Article.GetSetQuantity);

            CountInsertRowArticle += QueryModifyArticle.ExecuteNonQuery();
        }

        private void ModifyArticleQuantity(Article Article)
        {
            // Create SubFamily or Brand if it does not exist
            int idSubFamily = GetOrCreateSubFamily(Article.GetSetSubFamily, Article.GetSetFamily);
            int idBrand = GetOrCreateBrand(Article.GetSetBrand);

            // Insert new brand
            SQLiteCommand QueryModifyArticle = new SQLiteCommand();
            QueryModifyArticle.Connection = M_dbConnection;

            QueryModifyArticle.CommandText = "UPDATE Articles SET Quantite = @RefQuantite WHERE RefArticle = @RefArticle;";
            QueryModifyArticle.Parameters.AddWithValue("@RefArticle", Article.GetSetRefArticle);
            QueryModifyArticle.Parameters.AddWithValue("@RefQuantite", Article.GetSetQuantity);

            CountInsertRowArticle += QueryModifyArticle.ExecuteNonQuery();
        }

        /*
         *  Get Brand id
         *
         *  @return id of brand or -1 if it does not exist
         */
        private int GetBrandId(string Brand)
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
                return -1;
            }

            GetBrandReader.Read();
            IdBrand = GetBrandReader.GetInt32(0);

            return IdBrand;
        }

        /*
         *  Get Brand name
         *
         *  @return name of brand or null if it does not exist
         */
        private string GetBrandName(int RefBrand)
        {
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

            return Brand;
        }

        /*
         *  Get or create a brand
         *
         *  @return id of brand
         */
        private int GetOrCreateBrand(string BrandName)
        {
            // Check family syntax
            Brand Brand;
            Brand = ControllerFurniture.CheckBrandSyntax(BrandName);

            // Create if it does not exist
            if (Brand == null)
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
                    QueryInsertBrand.Parameters.AddWithValue("@RefNom", BrandName);
                    CountInsertRowBrand += QueryInsertBrand.ExecuteNonQuery();

                    LastRefBrand++;
                }

                return LastId + 1;
            }

            return Brand.GetSetIdBrand;
        }

        /*
         *  Get Family id
         *
         *  @return id of family or -1 if it does not exist
         */
        private int GetFamilyId(string FamilyName)
        {
            SQLiteCommand QueryGetFamily = new SQLiteCommand();
            QueryGetFamily.Connection = M_dbConnection;

            // Get family if it exists
            int IdFamily = 0;
            QueryGetFamily.CommandText = "SELECT * FROM Familles WHERE Nom = @Nom;";
            QueryGetFamily.Parameters.AddWithValue("@Nom", FamilyName);
            SQLiteDataReader GetFamilyReader = QueryGetFamily.ExecuteReader();

            if (!GetFamilyReader.HasRows)
            {
                return -1;
            }

            GetFamilyReader.Read();
            IdFamily = GetFamilyReader.GetInt32(0);

            return IdFamily;
        }

        /*
         *  Get Name of Family
         *
         *  @return string of family or null if it does not exist
         */
        public string GetFamilyName(int RefFamily)
        {
            SQLiteCommand QueryGetFamily = new SQLiteCommand();
            QueryGetFamily.CommandText = "SELECT Nom FROM Familles WHERE RefFamille = @RefFamille;";
            QueryGetFamily.Parameters.AddWithValue("@RefFamille", RefFamily);
            QueryGetFamily.Connection = SingletonBD.GetInstance.GetDB();
            SQLiteDataReader FamilyReader = QueryGetFamily.ExecuteReader();
            string Family = null;
            if (FamilyReader.Read())
            {
                Family = FamilyReader.GetString(0);
            }

            return Family;
        }

        /*
         *  Get Family id of SubFamily
         *
         *  @return id of family or -1 if it does not exist
         */
        public int GetFamilyIdOfSubFamily(string SubFamily)
        {
            SQLiteCommand QueryGetFamily = new SQLiteCommand();
            QueryGetFamily.Connection = M_dbConnection;

            // Get family if it exists
            int IdFamily = 0;
            QueryGetFamily.CommandText = "SELECT RefFamille FROM SousFamilles WHERE Nom = @Nom;";
            QueryGetFamily.Parameters.AddWithValue("@Nom", SubFamily);
            SQLiteDataReader GetFamilyReader = QueryGetFamily.ExecuteReader();

            if (!GetFamilyReader.HasRows)
            {
                return -1;
            }

            GetFamilyReader.Read();
            IdFamily = GetFamilyReader.GetInt32(0);

            return IdFamily;
        }

        /*
         *  Get or create a family
         *
         *  @return id of family
         */
        private int GetOrCreateFamily(string FamilyName)
        {
            // Check family syntax
            Family Family;
            Family = ControllerFurniture.CheckFamilySyntax(FamilyName);

            if (Family == null)
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

            return Family.GetSetIdFamily;
        }      

        /*
         *  Get Name of SubFamily
         *
         *  @return string of subfamily or null if it does not exist
         */
        private string GetSubFamilyName(int RefSubFamily)
        {
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

            return SubFamily;
        }

        /*
         *  Get or create a sub family
         *
         *  @return id of sub family
         */
        private int GetOrCreateSubFamily(string SubFamilyName, string FamilyName)
        {
            // Check SubFamily syntax
            SubFamily SubFamily;
            SubFamily = ControllerFurniture.CheckSubFamilySyntax(SubFamilyName);

            // Create if it does not exist
            if (SubFamily == null)
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

                SQLiteCommand QueryCreateModify = new SQLiteCommand();
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

            return SubFamily.GetSetIdSubFamily;
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
                int RefBrand = ArticlesReader.GetInt32(3);
                int RefFamily = 0;
                int RefSubFamily =  ArticlesReader.GetInt32(2);                
                string PriceHT = ArticlesReader.GetString(4);
                int Quantity =  ArticlesReader.GetInt32(5);

                // Get the name of SubFamily
                string SubFamily = GetSubFamilyName(RefSubFamily);

                // Get the name of Family
                RefFamily = GetFamilyIdOfSubFamily(SubFamily);
                string Family = GetFamilyName(RefFamily);

                // Get the name of Brand
                string Brand = GetBrandName(RefBrand);

                // Create a new object Article
                Article Article = new Article(RefArticle, Description, Family, SubFamily, Brand, PriceHT, Quantity);

                // Add this article into the list
                ListArticles.Add(Article);
            }

            return ListArticles;
        }

        public List<Brand> GetAllBrands()
        {
            List<Brand> ListBrands = new List<Brand>();

            SQLiteCommand QueryGetAllBrands = new SQLiteCommand();
            QueryGetAllBrands.CommandText = "SELECT DISTINCT * FROM Marques;";
            QueryGetAllBrands.Connection = SingletonBD.GetInstance.GetDB();
            SQLiteDataReader BrandsReader = QueryGetAllBrands.ExecuteReader();

            while (BrandsReader.Read())
            {
                int RefBrand = BrandsReader.GetInt32(0);
                string Name = BrandsReader.GetString(1);

                // Create a new object Article
                Brand Brand = new Brand(RefBrand, Name);

                // Add this article into the list
                ListBrands.Add(Brand);
            }

            return ListBrands;
        }

        public List<Family> GetAllFamily()
        {
            List<Family> ListFamily = new List<Family>();

            SQLiteCommand QueryGetAllFamily = new SQLiteCommand();
            QueryGetAllFamily.CommandText = "SELECT DISTINCT * FROM Familles;";
            QueryGetAllFamily.Connection = SingletonBD.GetInstance.GetDB();
            SQLiteDataReader FamilyReader = QueryGetAllFamily.ExecuteReader();

            while (FamilyReader.Read())
            {
                int RefFamily = FamilyReader.GetInt32(0);
                string Name = FamilyReader.GetString(1);

                // Create a new object Article
                Family Family = new Family(RefFamily, Name);

                // Add this article into the list
                ListFamily.Add(Family);
            }

            return ListFamily;
        }

        public List<SubFamily> GetAllSubFamily()
        {
            List<SubFamily> ListSubFamily = new List<SubFamily>();

            SQLiteCommand QueryGetAllSubFamily = new SQLiteCommand();
            QueryGetAllSubFamily.CommandText = "SELECT DISTINCT * FROM SousFamilles;";
            QueryGetAllSubFamily.Connection = SingletonBD.GetInstance.GetDB();
            SQLiteDataReader SubFamilyReader = QueryGetAllSubFamily.ExecuteReader();

            while (SubFamilyReader.Read())
            {
                int RefSubFamily = SubFamilyReader.GetInt32(0);
                string Name = SubFamilyReader.GetString(2);

                // Create a new object Article
                SubFamily SubFamily = new SubFamily(RefSubFamily, Name);

                // Add this article into the list
                ListSubFamily.Add(SubFamily);
            }

            return ListSubFamily;
        }

        public List<SubFamily> GetAllSubFamilyOfFamily(string Family)
        {
            List<SubFamily> ListSubFamily = new List<SubFamily>();
            int RefFamily = GetFamilyId(Family);

            if (RefFamily == -1)
            {
                throw new Exception("Error during convertion of Ref Family from Family string!");
            }

            SQLiteCommand QueryGetAllSubFamily = new SQLiteCommand();
            QueryGetAllSubFamily.CommandText = "SELECT DISTINCT * FROM SousFamilles WHERE RefFamille = @RefFamily;";
            QueryGetAllSubFamily.Parameters.AddWithValue("@RefFamily", RefFamily);
            QueryGetAllSubFamily.Connection = SingletonBD.GetInstance.GetDB();
            SQLiteDataReader SubFamilyReader = QueryGetAllSubFamily.ExecuteReader();

            while (SubFamilyReader.Read())
            {
                int RefSubFamily = SubFamilyReader.GetInt32(0);
                string Name = SubFamilyReader.GetString(2);

                // Create a new object Article
                SubFamily SubFamily = new SubFamily(RefSubFamily, Name);

                // Add this article into the list
                ListSubFamily.Add(SubFamily);
            }

            return ListSubFamily;
        }

        public bool DeleteArticle(string RefArticle)
        {
            SQLiteCommand QueryDelete = new SQLiteCommand();
            QueryDelete.Connection = M_dbConnection;
            QueryDelete.CommandText = "DELETE FROM Articles WHERE RefArticle = @RefArticle;";
            QueryDelete.Parameters.AddWithValue("@RefArticle", RefArticle);
            int NumberRow = QueryDelete.ExecuteNonQuery();

            if (NumberRow == 1)
                return true;
            else
                return false;
        }

        public bool ArticleExist(string RefArticle)
        {
            SQLiteCommand QueryExistArticle = new SQLiteCommand();
            QueryExistArticle.CommandText = "SELECT * FROM Articles WHERE RefArticle = '@RefArticle';";
            QueryExistArticle.Parameters.AddWithValue("@RefArticle", RefArticle);
            QueryExistArticle.Connection = SingletonBD.GetInstance.GetDB();
            SQLiteDataReader ArticleReader = QueryExistArticle.ExecuteReader();

            // Create if it does not exist
            if (ArticleReader.HasRows)
            {
                return true;
            }

            return false;
        }
    }
}
