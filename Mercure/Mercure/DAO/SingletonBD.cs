using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public class SingletonBD
{
    private static SingletonBD Instance;
    private static SQLiteConnection M_dbConnection;

    private SingletonBD() {
        M_dbConnection = new SQLiteConnection("Data Source=./Resources/Mercure.SQLITE;Version=3;");
        Open();
    }



    // Getter Instance BD Singleton
    public static SingletonBD GetInstance
    {
        get
        {
            if (Instance == null)
            {
                Instance = new SingletonBD();
            }
            return Instance;
        }
    }

    public SQLiteConnection GetDB()
    {
        return M_dbConnection;
    }

    public void Open()
    {
        try
        {
            M_dbConnection.Open();
        }
        catch (SQLiteException e)
        {
            MessageBox.Show("Error database ! " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static void Close()
    {
        try
        {
            if (M_dbConnection != null || M_dbConnection.State == System.Data.ConnectionState.Open)
            {
                M_dbConnection.Close();
            }
            else
            {
                throw new Exception("Database already close or does not exist !");
            }
        }
        catch (Exception e)
        {
            MessageBox.Show("Error database ! " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
    }
}
