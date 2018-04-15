using System;
using System.Data.SQLite;
using System.Windows.Forms;

public class SingletonBD
{
    private static SingletonBD Instance;
    private static SQLiteConnection M_dbConnection;

    /// <summary>
    /// Default constructor
    /// </summary>
    private SingletonBD() {
        InitDB();
    }

    /// <summary>
    /// Getter Instance BD Singleton
    /// </summary>
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

    /// <summary>
    /// Get DataBase
    /// </summary>
    /// <returns> The DB connected </returns>
    public SQLiteConnection GetDB()
    {
        return M_dbConnection;
    }

    /// <summary>
    /// Initialise the DataBase
    /// </summary>
    private static void InitDB()
    {
        try
        {
            M_dbConnection = new SQLiteConnection();
            M_dbConnection.ConnectionString = @"Data Source=./Mercure.SQLITE; Version=3;";
            M_dbConnection.Open();

            Mercure.MainWindow.StatusSQL_Label.Text = "Database connection successful.";
        }
        catch (SQLiteException e)
        {
            MessageBox.Show("Error database ! " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Open DB
    /// </summary>
    public static void Open()
    {
        InitDB();
    }

    /// <summary>
    /// Close DB
    /// </summary>
    public static void Close()
    {
        try
        {
            if (M_dbConnection != null && M_dbConnection.State == System.Data.ConnectionState.Open)
            {
                M_dbConnection.Close();
            }
        }
        catch (Exception e)
        {
            MessageBox.Show("Error database ! " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }   
    }
}
