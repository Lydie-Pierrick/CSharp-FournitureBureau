using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;

public class SingletonBD
{
    private static SingletonBD Instance;
    private static SQLiteConnection M_dbConnection;

    private SingletonBD() {
        M_dbConnection = new SQLiteConnection("Data Source=mercure.sqlite;Version=3;");
    }

    // Getter Instance BD Singleton
    public static SQLiteConnection GetInstanceBD
    {
        get
        {
            if (Instance == null)
            {
                Instance = new SingletonBD();
            }
            return M_dbConnection;
        }
    }

    private static void Open()
    {
        M_dbConnection.Open();
    }

    public static void Close()
    {
        M_dbConnection.Close();
    }
}
