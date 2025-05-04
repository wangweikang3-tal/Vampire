using System.Collections.Generic;
using MySqlConnector;
using UnityEngine;

public class ConnectMysql : XSingleton<ConnectMysql>
{
    private string _connectionString;
    private MySqlConnection _connection;
    public List<User> Users;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 根据你的 MySQL 服务器配置填写这些信息
        string server = "localhost";
        string database = "Vampire";
        string user = "root";
        string password = "BaiChen123456+";

        _connectionString = $"server={server};database={database};uid={user};pwd={password};";
        ConnectToDatabase();
        GetUserTable();
    }

    void ConnectToDatabase()
    {
        _connection = new MySqlConnection(_connectionString);
        try
        {
            _connection.Open();
            Debug.Log("Connected to MySQL database");
            // 在这里执行数据库操作，如查询、插入等
            QueryDatabase();
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Error connecting to MySQL database: " + ex.Message);
        }
    }
    
    //将User表中的数据存储全部到Users中
    void GetUserTable()
    {
        string query = "SELECT * FROM user";
        MySqlCommand command = new MySqlCommand(query, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        Users = new List<User>();
        try
        {
            while (reader.Read())
            {
                User user = new User
                {
                    UserId = reader.GetInt32("userid"),
                    Username = reader.GetString("username"),
                    Password = reader.GetString("passward")
                };
                Users.Add(user);
            }
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Error querying database: " + ex.Message);
        }
        finally
        {
            reader.Close();
        }
    }
    
    void QueryDatabase()
    {
        string query = "SELECT * FROM user";
        MySqlCommand command = new MySqlCommand(query, _connection);
        MySqlDataReader reader = command.ExecuteReader();

        try
        {
            while (reader.Read())
            {
                // 假设 user 表有 id、username、email 三个字段
                int id = reader.GetInt32("userid");
                string username = reader.GetString("username");
                string email = reader.GetString("passward");

                Debug.Log($"ID: {id}, Username: {username}, Email: {email}");
            }
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Error querying database: " + ex.Message);
        }
        finally
        {
            reader.Close();
        }
    }
    // Update is called once per frame
    void OnDestroy()
    {
        if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
        {
            _connection.Close();
        }
    }
}
