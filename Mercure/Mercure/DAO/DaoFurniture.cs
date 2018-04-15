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

        private static int LastRefBrand = 0;
        private static int LastRefFamily = 0;
        private static int LastRefSubFamily= 0;

        public DaoFurniture()
        {
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
                QueryGetQuantiteArticle.Connection = SingletonBD.GetInstance.GetDB();

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
                QueryGetQuantiteArticle.Connection = SingletonBD.GetInstance.GetDB();

                // Get article if it exists
                QueryGetQuantiteArticle.CommandText = "SELECT Quantite FROM Articles WHERE RefArticle = @RefArticle;";
                QueryGetQuantiteArticle.Parameters.AddWithValue("@RefArticle", Article.GetSetRefArticle);
                SQLiteDataReader GetQuantiteArticleReader = QueryGetQuantiteArticle.ExecuteReader();

                GetQuantiteArticleReader.Read();

                if (GetQuantiteArticleReader.HasRows)
                {
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

        /// <summary>
        /// Create an article
        /// </summary>
        /// <param name="Article"> The Article object to add </param>
        private void CreateArticle(Article Article)
        {
            // Create SubFamily or Brand if it does not exist
            int idSubFamily = GetOrCreateSubFamily(Article.GetSetSubFamily, Article.GetSetFamily);
            int idBrand = GetOrCreateBrand(Article.GetSetBrand);

            // Insert new brand
            SQLiteCommand QueryInsertArticle = new SQLiteCommand();
            QueryInsertArticle.Connection = SingletonBD.GetInstance.GetDB();

            QueryInsertArticle.CommandText = "INSERT INTO Articles (RefArticle, Description, RefSousFamille, RefMarque, PrixHT, Quantite) VALUES (@RefArticle, @RefDescription, @RefRefSousFamille, @RefMarque, @RefPrixHT, @RefQuantite);";
            QueryInsertArticle.Parameters.AddWithValue("@RefArticle", Article.GetSetRefArticle);
            QueryInsertArticle.Parameters.AddWithValue("@RefDescription", Article.GetSetDescription);
            QueryInsertArticle.Parameters.AddWithValue("@RefRefSousFamille", idSubFamily);
            QueryInsertArticle.Parameters.AddWithValue("@RefMarque", idBrand);
            QueryInsertArticle.Parameters.AddWithValue("@RefPrixHT", Article.GetSetPriceHT);
            if(Article.GetSetQuantity == 0)
                QueryInsertArticle.Parameters.AddWithValue("@RefQuantite", 1);
            else
                QueryInsertArticle.Parameters.AddWithValue("@RefQuantite", Article.GetSetQuantity);

            QueryInsertArticle.ExecuteNonQuery();
        }

        /// <summary>
        /// Modify article
        /// </summary>
        /// <param name="Article"> The Article object to edit </param>
        private void ModifyArticle(Article Article)
        {
            // Create SubFamily or Brand if it does not exist
            int idSubFamily = GetOrCreateSubFamily(Article.GetSetSubFamily, Article.GetSetFamily);
            int idBrand = GetOrCreateBrand(Article.GetSetBrand);

            // Insert new brand
            SQLiteCommand QueryModifyArticle = new SQLiteCommand();
            QueryModifyArticle.Connection = SingletonBD.GetInstance.GetDB();

            QueryModifyArticle.CommandText = "UPDATE Articles SET Description = @RefDescription, RefSousFamille = @RefRefSousFamille, RefMarque = @RefMarque, PrixHT = @RefPrixHT, Quantite = @RefQuantite WHERE RefArticle = @RefArticle;";
            QueryModifyArticle.Parameters.AddWithValue("@RefArticle", Article.GetSetRefArticle);
            QueryModifyArticle.Parameters.AddWithValue("@RefDescription", Article.GetSetDescription);
            QueryModifyArticle.Parameters.AddWithValue("@RefRefSousFamille", idSubFamily);
            QueryModifyArticle.Parameters.AddWithValue("@RefMarque", idBrand);
            QueryModifyArticle.Parameters.AddWithValue("@RefPrixHT", Article.GetSetPriceHT);
            QueryModifyArticle.Parameters.AddWithValue("@RefQuantite", Article.GetSetQuantity);

             QueryModifyArticle.ExecuteNonQuery();
        }

        /// <summary>
        /// Modify quantity of article
        /// </summary>
        /// <param name="Article"> The Article object to edit quantity </param>
        private void ModifyArticleQuantity(Article Article)
        {
            // Create SubFamily or Brand if it does not exist
            int idSubFamily = GetOrCreateSubFamily(Article.GetSetSubFamily, Article.GetSetFamily);
            int idBrand = GetOrCreateBrand(Article.GetSetBrand);

            // Insert new brand
            SQLiteCommand QueryModifyArticle = new SQLiteCommand();
            QueryModifyArticle.Connection = SingletonBD.GetInstance.GetDB();

            QueryModifyArticle.CommandText = "UPDATE Articles SET Quantite = @RefQuantite WHERE RefArticle = @RefArticle;";
            QueryModifyArticle.Parameters.AddWithValue("@RefArticle", Article.GetSetRefArticle);
            QueryModifyArticle.Parameters.AddWithValue("@RefQuantite", Article.GetSetQuantity);

            QueryModifyArticle.ExecuteNonQuery();
        }

        /// <summary>
        /// Get brand id
        /// </summary>
        /// <param name="Brand"> The brand name to get id</param>
        /// <returns> The id of brand </returns>
        private int GetBrandId(string Brand)
        {
            // Get brand if it exists
            int IdBrand = 0;

            SQLiteCommand QueryGetBrand = new SQLiteCommand();
            QueryGetBrand.CommandText = "SELECT RefMarque FROM Marques WHERE Nom = @Nom;";
            QueryGetBrand.Connection = SingletonBD.GetInstance.GetDB();
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

        /// <summary>
        /// Get brand name
        /// </summary>
        /// <param name="RefBrand"> The brand id to get name</param>
        /// <returns> The name of brand or null if it does not exist </returns>
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

        /// <summary>
        /// Get or create brand
        /// </summary>
        /// <param name="BrandName"> The brand name </param>
        /// <returns> The brand id </returns>
        public int GetOrCreateBrand(string BrandName)
        {
            // Check family syntax
            Brand Brand;
            Brand = ControllerFurniture.CheckBrandSyntax(BrandName);

            // Create if it does not exist
            if (Brand == null)
            {
                SQLiteCommand QueryTestExist = new SQLiteCommand();
                QueryTestExist.Connection = SingletonBD.GetInstance.GetDB();
                QueryTestExist.CommandText = "SELECT COUNT(*) FROM Marques;";
                SQLiteDataReader TestExistReader = QueryTestExist.ExecuteReader();
                TestExistReader.Read();
                if (TestExistReader.GetInt32(0) != 0)
                {
                    SQLiteCommand QueryLastInsertId = new SQLiteCommand();
                    QueryLastInsertId.Connection = SingletonBD.GetInstance.GetDB();
                    QueryLastInsertId.CommandText = "SELECT MAX(RefMarque) FROM Marques;";
                    SQLiteDataReader LastIdReader = QueryLastInsertId.ExecuteReader();
                    LastIdReader.Read();
                    LastRefBrand = LastIdReader.GetInt32(0);
                }
                else
                {
                    LastRefBrand = 0;
                }

                // Insert new brand
                SQLiteCommand QueryInsertBrand = new SQLiteCommand();
                QueryInsertBrand.Connection = SingletonBD.GetInstance.GetDB();

                QueryInsertBrand.CommandText = "INSERT INTO Marques (RefMarque, Nom) VALUES (@RefMarque, @RefNom);";
                QueryInsertBrand.Parameters.AddWithValue("@RefMarque", ++LastRefBrand);
                QueryInsertBrand.Parameters.AddWithValue("@RefNom", BrandName);
                QueryInsertBrand.ExecuteNonQuery();

                return LastRefBrand;
            }
          
            return Brand.GetSetIdBrand;
        }

        /// <summary>
        /// Get family id from familyName
        /// </summary>
        /// <param name="FamilyName"> The brand name </param>
        /// <returns> The id of family or -1 if it does not exist </returns>
        private int GetFamilyId(string FamilyName)
        {
            SQLiteCommand QueryGetFamily = new SQLiteCommand();
            QueryGetFamily.Connection = SingletonBD.GetInstance.GetDB();

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

        /// <summary>
        /// Get family name
        /// </summary>
        /// <param name="RefFamily"> The family id </param>
        /// <returns> The string of family or null if it does not exist </returns>
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

        /// <summary>
        /// Get family id of subFamily
        /// </summary>
        /// <param name="SubFamily"> The SubFamily name </param>
        /// <returns> The id of family or -1 if it does not exist </returns>
        public int GetFamilyIdOfSubFamily(string SubFamily)
        {
            SQLiteCommand QueryGetFamily = new SQLiteCommand();
            QueryGetFamily.Connection = SingletonBD.GetInstance.GetDB();

            // Get family if it exists
            int IdFamily = 0;
            QueryGetFamily.CommandText = "SELECT RefFamille FROM SousFamilles WHERE Nom = @Nom;";
            QueryGetFamily.Parameters.AddWithValue("@Nom", SubFamily);
            SQLiteDataReader GetFamilyReader = QueryGetFamily.ExecuteReader();

            GetFamilyReader.Read();

            if (!GetFamilyReader.HasRows)
            {
                return -1;
            }

            IdFamily = GetFamilyReader.GetInt32(0);

            return IdFamily;
        }

        /// <summary>
        /// Get of create family
        /// </summary>
        /// <param name="FamilyName"> The Family name </param>
        /// <returns> The id of family </returns>
        public int GetOrCreateFamily(string FamilyName)
        {
            // Check family syntax
            Family Family;
            Family = ControllerFurniture.CheckFamilySyntax(FamilyName);

            if (Family == null)
            {
                SQLiteCommand QueryTestExist = new SQLiteCommand();
                QueryTestExist.Connection = SingletonBD.GetInstance.GetDB();
                QueryTestExist.CommandText = "SELECT COUNT(*) FROM Familles;";
                SQLiteDataReader TestExistReader = QueryTestExist.ExecuteReader();
                TestExistReader.Read();
                if (TestExistReader.GetInt32(0) != 0)
                {
                    SQLiteCommand QueryLastInsertId = new SQLiteCommand();
                    QueryLastInsertId.Connection = SingletonBD.GetInstance.GetDB();
                    QueryLastInsertId.CommandText = "SELECT MAX(RefFamille) FROM Familles;";
                    SQLiteDataReader LastIdReader = QueryLastInsertId.ExecuteReader();
                    LastIdReader.Read();
                    LastRefFamily = LastIdReader.GetInt32(0);
                }
                else
                {
                    LastRefFamily = 0;
                }

                SQLiteCommand QueryCreateModify = new SQLiteCommand();
                QueryCreateModify.Connection = SingletonBD.GetInstance.GetDB();

                // Insert new family
                QueryCreateModify.CommandText = "INSERT INTO Familles (RefFamille, Nom) VALUES (@RefFamille, @RefNom);";
                QueryCreateModify.Parameters.AddWithValue("@RefFamille", ++LastRefFamily);
                QueryCreateModify.Parameters.AddWithValue("@RefNom", FamilyName);
                QueryCreateModify.ExecuteNonQuery();

                return LastRefFamily;
            }

            return Family.GetSetIdFamily;
        }

        /// <summary>
        /// Get subFamily name
        /// </summary>
        /// <param name="RefSubFamily"> The SubFamily id </param>
        /// <returns> The string of subfamily or null if it does not exist </returns>
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

        /// <summary>
        /// Get or create a sub family
        /// </summary>
        /// <param name="RefSubFamily"> The SubFamily id </param>
        /// <returns> The id of sub family </returns>
        public int GetOrCreateSubFamily(string SubFamilyName, string FamilyName)
        {
            // Check SubFamily syntax
            SubFamily SubFamily;
            SubFamily = ControllerFurniture.CheckSubFamilySyntax(SubFamilyName);

            // Create if it does not exist
            if (SubFamily == null)
            {

                SQLiteCommand QueryTestExist = new SQLiteCommand();
                QueryTestExist.Connection = SingletonBD.GetInstance.GetDB();
                QueryTestExist.CommandText = "SELECT COUNT(*) FROM SousFamilles;";
                SQLiteDataReader TestExistReader = QueryTestExist.ExecuteReader();
                TestExistReader.Read();
                if (TestExistReader.GetInt32(0) != 0)
                {
                    SQLiteCommand QueryLastInsertId = new SQLiteCommand();
                    QueryLastInsertId.Connection = SingletonBD.GetInstance.GetDB();
                    QueryLastInsertId.CommandText = "SELECT MAX(RefSousFamille) FROM SousFamilles;";
                    SQLiteDataReader LastIdReader = QueryLastInsertId.ExecuteReader();
                    LastIdReader.Read();
                    LastRefSubFamily = LastIdReader.GetInt32(0);
                }
                else
                {
                    LastRefSubFamily = 0;
                }

                // Get Family for this SubFamily
                int IdFamily = GetOrCreateFamily(FamilyName);

                SQLiteCommand QueryCreateModify = new SQLiteCommand();
                QueryCreateModify.Connection = SingletonBD.GetInstance.GetDB();

                // Insert new sub family
                QueryCreateModify.CommandText = "INSERT INTO SousFamilles (RefSousFamille, RefFamille, Nom) VALUES (@RefSousFamille, @RefFamille, @RefNom);";
                QueryCreateModify.Parameters.AddWithValue("@RefSousFamille", LastRefSubFamily + 1);
                QueryCreateModify.Parameters.AddWithValue("@RefFamille", IdFamily);
                QueryCreateModify.Parameters.AddWithValue("@RefNom", SubFamilyName);
                QueryCreateModify.ExecuteNonQuery();

                LastRefSubFamily++;

                return LastRefSubFamily;
            }

            return SubFamily.GetSetIdSubFamily;
        }

        /// <summary>
        /// Delete all entries of tables
        /// </summary>
        /// <returns> The bool true if success </returns>
        public bool DeleteAllEntriesTables()
        {
            int countResetTable = 0;

            foreach (String tableName in ListNameTables)
            {
                SQLiteCommand Delete = new SQLiteCommand();
                Delete.Connection = SingletonBD.GetInstance.GetDB();
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

        /// <summary>
        /// Get all name tables of DB
        /// </summary>
        /// <returns> The list of name table from DB </returns>
        private List<String> GetAllNameTables()
        {
            List<string> List = new List<string>();

            SQLiteCommand NameTableCommand = new SQLiteCommand();
            NameTableCommand.Connection = SingletonBD.GetInstance.GetDB();

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

        /// <summary>
        /// Get list of all articles
        /// </summary>
        /// <returns> The list of articles </returns>
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

        /// <summary>
        /// Get list of all brands
        /// </summary>
        /// <returns> The list of brands </returns>
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

        /// <summary>
        /// Get list of all family
        /// </summary>
        /// <returns> The list of family </returns>
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

        /// <summary>
        /// Get list of all subFamily
        /// </summary>
        /// <returns> The list of subFamily </returns>
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

        /// <summary>
        /// Get list of all quantity of article
        /// </summary>
        /// <returns> The list of quantity </returns>
        public static List<int> GetAllQuantity()
        {
            List<int> ListSubFamily = new List<int>();

            SQLiteCommand QueryGetAllQuantityArticle = new SQLiteCommand();
            QueryGetAllQuantityArticle.CommandText = "SELECT DISTINCT Quantite FROM Articles;";
            QueryGetAllQuantityArticle.Connection = SingletonBD.GetInstance.GetDB();
            SQLiteDataReader QuantiteArticleReader = QueryGetAllQuantityArticle.ExecuteReader();

            while (QuantiteArticleReader.Read())
            {
                int Quantity = QuantiteArticleReader.GetInt32(0);

                ListSubFamily.Add(Quantity);
            }

            return ListSubFamily;
        }

        /// <summary>
        /// Get list of subFamily from family
        /// </summary>
        /// <param name="Family"> The name of the family </param>
        /// <returns> The list of subFamily </returns>
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

        /// <summary>
        /// Delete article
        /// </summary>
        /// <param name="RefArticle"> The ref of article to delete </param>
        /// <returns> The bool true if success </returns>
        public bool DeleteArticle(string RefArticle)
        {
            SQLiteCommand QueryDelete = new SQLiteCommand();
            QueryDelete.Connection = SingletonBD.GetInstance.GetDB();
            QueryDelete.CommandText = "DELETE FROM Articles WHERE RefArticle = @RefArticle;";
            QueryDelete.Parameters.AddWithValue("@RefArticle", RefArticle);
            int NumberRow = QueryDelete.ExecuteNonQuery();

            if (NumberRow == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get the family ID by family name
        /// </summary>
        /// <param name="FamilyName"> Family name </param>
        /// <returns> The family ID or 0 if this family doesn't exist </returns>
        public int GetFamilyIdByName(string FamilyName)
        { 
            SQLiteCommand QueryGetFamilyId = new SQLiteCommand();
            QueryGetFamilyId.CommandText = "SELECT RefFamille FROM Familles WHERE Nom = @FamilyName;";
            QueryGetFamilyId.Parameters.AddWithValue("@FamilyName", FamilyName);
            QueryGetFamilyId.Connection = SingletonBD.GetInstance.GetDB();
            SQLiteDataReader FamilyIdReader = QueryGetFamilyId.ExecuteReader();

            if (FamilyIdReader.Read())
            {
                return FamilyIdReader.GetInt32(0);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Delete a brand
        /// </summary>
        /// <param name="RefBrand"> The ref of brand to delete </param>
        /// <returns> True if successful or false if failed </returns>
        public bool DeleteBrand(int RefBrand)
        {
            SQLiteCommand QueryGetCounterArticle = new SQLiteCommand();
            QueryGetCounterArticle.CommandText = "SELECT COUNT(*) FROM Articles WHERE RefMarque = @RefBrand;";
            QueryGetCounterArticle.Parameters.AddWithValue("@RefBrand", RefBrand);
            QueryGetCounterArticle.Connection = SingletonBD.GetInstance.GetDB();
            SQLiteDataReader CounterReader = QueryGetCounterArticle.ExecuteReader();

            if (CounterReader.Read())
            {
                int Counter = CounterReader.GetInt32(0);
                if (Counter != 0) // If there is an article of this brand, we cannot delete it
                    return false;
            }

            SQLiteCommand QueryDelete = new SQLiteCommand();
            QueryDelete.Connection = SingletonBD.GetInstance.GetDB();
            QueryDelete.CommandText = "DELETE FROM Marques WHERE RefMarque = @RefBrand;";
            QueryDelete.Parameters.AddWithValue("@RefBrand", RefBrand);
            int NumberRow = QueryDelete.ExecuteNonQuery();

            if (NumberRow == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Delete a family
        /// </summary>
        /// <param name="RefFamily"> The ref of family to delete </param>
        /// <returns> True if successful or false if failed </returns>
        public bool DeleteFamily(int RefFamily)
        {
            // revoir
            SQLiteCommand QueryGetAllSubFamily = new SQLiteCommand();
            QueryGetAllSubFamily.CommandText = "SELECT RefSousFamille FROM SousFamilles WHERE RefFamille = @RefFamily;";
            QueryGetAllSubFamily.Parameters.AddWithValue("@RefFamily", RefFamily);
            QueryGetAllSubFamily.Connection = SingletonBD.GetInstance.GetDB();
            SQLiteDataReader SubFamilyReader = QueryGetAllSubFamily.ExecuteReader();

            while (SubFamilyReader.Read())
            {
                int RefSubFamily = SubFamilyReader.GetInt32(0);
                if (!DeleteSubFamily(RefSubFamily))
                    return false;
            }

            SQLiteCommand QueryDelete = new SQLiteCommand();
            QueryDelete.Connection = SingletonBD.GetInstance.GetDB();
            QueryDelete.CommandText = "DELETE FROM Familles WHERE RefFamille = @RefFamily;";
            QueryDelete.Parameters.AddWithValue("@RefFamily", RefFamily);
            int NumberRow = QueryDelete.ExecuteNonQuery();

            if (NumberRow == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Delete a subfamily
        /// </summary>
        /// <param name="RefSubFamily"> The ref of subfamily to delete </param>
        /// <returns> True if successful or false if failed </returns>
        public bool DeleteSubFamily(int RefSubFamily)
        {
            SQLiteCommand QueryGetCounterArticle = new SQLiteCommand();
            QueryGetCounterArticle.CommandText = "SELECT COUNT(*) FROM Articles WHERE RefSousFamille = @RefSubFamily;";
            QueryGetCounterArticle.Parameters.AddWithValue("@RefSubFamily", RefSubFamily);
            QueryGetCounterArticle.Connection = SingletonBD.GetInstance.GetDB();
            SQLiteDataReader CounterReader = QueryGetCounterArticle.ExecuteReader();

            if (CounterReader.Read())
            {
                int Counter = CounterReader.GetInt32(0);
                if (Counter != 0) // If there is an article of this family, we cannot delete it
                    return false;
            }

            SQLiteCommand QueryDelete = new SQLiteCommand();
            QueryDelete.Connection = SingletonBD.GetInstance.GetDB();
            QueryDelete.CommandText = "DELETE FROM SousFamilles WHERE RefSousFamille = @RefSubFamily;";
            QueryDelete.Parameters.AddWithValue("@RefSubFamily", RefSubFamily);
            int NumberRow = QueryDelete.ExecuteNonQuery();

            if (NumberRow == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Modify a brand in DB
        /// </summary>
        /// <param name="RefBrand">Reference of brand </param>
        /// <param name="BrandName"> Brand name </param>
        /// <returns> True if successful or false if failed </returns>
        public bool ModifyBrand(int RefBrand, string BrandName)
        {
            SQLiteCommand QueryModify = new SQLiteCommand();
            QueryModify.Connection = SingletonBD.GetInstance.GetDB();
            QueryModify.CommandText = "UPDATE Marques SET Nom = @BrandName WHERE RefMarque= @RefBrand;";
            QueryModify.Parameters.AddWithValue("@RefBrand", RefBrand);
            QueryModify.Parameters.AddWithValue("@BrandName", BrandName);
            int NumberRow = QueryModify.ExecuteNonQuery();

            if (NumberRow == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Modify a family in DB
        /// </summary>
        /// <param name="RefFamily">Reference of family </param>
        /// <param name="FamilyName"> family name </param>
        /// <returns> True if successful or false if failed </returns>
        public bool ModifyFamily(int RefFamily, string FamilyName)
        {
            SQLiteCommand QueryDelete = new SQLiteCommand();
            QueryDelete.Connection = SingletonBD.GetInstance.GetDB();
            QueryDelete.CommandText = "UPDATE Familles SET Nom = @FamilyName WHERE RefFamille= @RefFamily;";
            QueryDelete.Parameters.AddWithValue("@RefFamily", RefFamily);
            QueryDelete.Parameters.AddWithValue("@FamilyName", FamilyName);
            int NumberRow = QueryDelete.ExecuteNonQuery();

            if (NumberRow == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Modify a subfamily in DB
        /// </summary>
        /// <param name="RefSubFamily">Reference of subfamily </param>
        /// <param name="SubFamilyName"> Subfamily name </param>
        /// <param name="RefFamily"> Ref of family </param>
        /// <returns> True if successful or false if failed </returns>
        public bool ModifySubFamily(int RefSubFamily, string SubFamilyName, int RefFamily)
        {
            SQLiteCommand QueryModify = new SQLiteCommand();
            QueryModify.Connection = SingletonBD.GetInstance.GetDB();
            QueryModify.CommandText = "UPDATE SousFamilles SET Nom = @SubFamilyName, RefFamille = @RefFamily WHERE RefSousFamille= @RefSubFamily;";
            QueryModify.Parameters.AddWithValue("@RefFamily", RefFamily);
            QueryModify.Parameters.AddWithValue("@SubFamilyName", SubFamilyName);
            QueryModify.Parameters.AddWithValue("@RefSubFamily", RefSubFamily);
            int NumberRow = QueryModify.ExecuteNonQuery();

            if (NumberRow == 1)
                return true;
            else
                return false;
        }
    }
}
