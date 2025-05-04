using MySqlConnector;
using UnityEngine;

public class ConnectMysql : MonoBehaviour
{
    private string connectionString;
    private MySqlConnection connection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 根据你的 MySQL 服务器配置填写这些信息
        string server = "localhost";
        string database = "Vampire";
        string user = "root";
        string password = "BaiChen123456+";

        connectionString = $"server={server};database={database};uid={user};pwd={password};";
        ConnectToDatabase();
    }

    void ConnectToDatabase()
    {
        connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            Debug.Log("Connected to MySQL database");
            // 在这里执行数据库操作，如查询、插入等
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Error connecting to MySQL database: " + ex.Message);
        }
    }
    // Update is called once per frame
    void OnDestroy()
    {
        if (connection != null && connection.State == System.Data.ConnectionState.Open)
        {
            connection.Close();
        }
    }
}
