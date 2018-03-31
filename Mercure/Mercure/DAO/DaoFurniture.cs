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

        public DaoFurniture()
        {
            ListNameTables = GetAllNameTables();
        }

        // --- Create or modify section

        /*  
         *  Create or modify a brand
         */
        public int CreateOrModifyArticle(Article Article)
        {
            List<string> List = new List<string>();
            string NameTableSQL = "SELECT name FROM sqlite_master WHERE type='table';";
            int countInsertRow = 0;

            SQLiteCommand NameTableCommand = new SQLiteCommand(NameTableSQL, SingletonBD.GetInstance.GetDB());
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
                    return 0;
                }
                finally
                {
                    NameTableReader.Close();
                }
            }

            if (exist)
            {
                /*SQLiteCommand InsertFamily = new SQLiteCommand();
                InsertFamily.CommandText = "INSERT OR IGNORE INTO Familles (RefFamille,Nom) VALUES (1,'');";
                InsertFamily.Parameters.Add(1);
                InsertFamily.Parameters.Add(1);
                InsertFamily.Parameters.Add(1);
                InsertFamily.Connection = SingletonBD.GetInstance.GetDB();
                InsertFamily.ExecuteNonQuery();

                try
                {
                    InsertSubFamily.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error during insert article. " + ex.Message);
                }*/
            }
            else
            {
                /*SQLiteCommand InsertFamily = new SQLiteCommand();
                InsertFamily.CommandText = "INSERT OR IGNORE INTO Familles (RefFamille,Nom) VALUES (1,'');";
                InsertFamily.Parameters.Add(1);
                InsertFamily.Parameters.Add(1);
                InsertFamily.Parameters.Add(1);
                InsertFamily.Connection = SingletonBD.GetInstance.GetDB();
                InsertFamily.ExecuteNonQuery();

                try
                {
                    InsertSubFamily.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error during insert article. " + ex.Message);
                }*/
            }
        }

        /*  
         *  Create or modify a brand
         */
        private int CreateOrModifyBrand(string Brand)
        {
            // Get brand if it exists
            int IdBrand;
            SQLiteCommand QueryGetBrand= new SQLiteCommand();
            QueryGetBrand.Connection = SingletonBD.GetInstance.GetDB();
            QueryGetBrand.CommandText = "SELECT RefMarque FROM Marques WHERE Nom = @Nom;";
            QueryGetBrand.Parameters.AddWithValue("@Nom", Brand);
            SQLiteDataReader GetBrandReader = QueryGetBrand.ExecuteReader();   

            // Create if it does not exist
            if (!GetBrandReader.HasRows)
            {
                // Get last id for autoincrement
                int LastId = 0;
                SQLiteCommand QueryLastInsertId = new SQLiteCommand();
                QueryLastInsertId.Connection = SingletonBD.GetInstance.GetDB();
                QueryLastInsertId.CommandText = "SELECT last_insert_rowid() FROM Marques;";
                SQLiteDataReader LastInsertReader = QueryLastInsertId.ExecuteReader();
                LastId = LastInsertReader.GetInt32(0);
                LastInsertReader.Close();

                // Insert new brand
                SQLiteCommand QueryInsertBrand = new SQLiteCommand();
                QueryInsertBrand.CommandText = "INSERT INTO Marques (RefMarque, Nom) VALUES (@RefMarque, @RefNom);";
                QueryInsertBrand.Parameters.AddWithValue("@RefMarque", LastId + 1);
                QueryInsertBrand.Parameters.AddWithValue("@RefNom", Brand);
                QueryInsertBrand.Connection = SingletonBD.GetInstance.GetDB();
                QueryInsertBrand.ExecuteNonQuery();

                return LastId;
            }
            else
            {
                IdBrand = GetBrandReader.GetInt32(0);
            }

            GetBrandReader.Close();
            return IdBrand;
        }

        /*  
         *  Create or modify a brand
         */
        private bool CreateOrModifyFamily(string family)
        {
            return false;
        }

        /*  
         *  Create or modify a brand
         */
        private bool CreateOrModifySubFamily(string family, string subFamily)
        {
            return false;
        }

        // Delete

        /*
         * Delete All entries of tables
         */
        public bool DeleteAllEntriesTables()
        {
            int countResetTable = 0;
            SQLiteCommand Delete;

            foreach (String tableName in ListNameTables)
            {
                Delete = new SQLiteCommand();
                Delete.CommandText = "DELETE FROM " + tableName + ";";
                Delete.Connection = SingletonBD.GetInstance.GetDB();
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
            string NameTableSQL = "SELECT name FROM sqlite_master WHERE type='table';";

            SQLiteCommand NameTableCommand = new SQLiteCommand(NameTableSQL, SingletonBD.GetInstance.GetDB());
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
                finally
                {
                    NameTableReader.Close();
                }
            }

            return List;
        }
    }
}
