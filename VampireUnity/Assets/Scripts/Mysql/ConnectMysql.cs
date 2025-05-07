using System;
using System.Collections.Generic;
using MySqlConnector;
using UnityEngine;

public class ConnectMysql : XSingleton<ConnectMysql>
{
    private string _connectionString;
    private MySqlConnection _connection;
    public List<User> Users;
    public int maxUserid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 根据你的 MySQL 服务器配置填写这些信息
        string server = "rm-cn-oo0492f6o000rto.rwlb.rds.aliyuncs.com";
        string database = "Vampire";
        string user = "wwk18255113901";
        string password = "BaiChen123456+";

        _connectionString = $"server={server};database={database};uid={user};pwd={password};";
        ConnectToDatabase();
        GetUserTable();
        GetMaxUserId();
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
    
    //向User表中插入数据
    public void InsertUser(string username, string password)
    {
        string query = "INSERT INTO user (userid, username, passward) VALUES (@userid, @username, @passward)";
        MySqlCommand command = new MySqlCommand(query, _connection);
        command.Parameters.AddWithValue("@userid", maxUserid + 1);
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@passward", password);

        try
        {
            command.ExecuteNonQuery();
            Debug.Log("User inserted successfully");
            GetMaxUserId();
            GetUserTable();
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Error inserting user: " + ex.Message);
        }
    }
    
    //获取User表中最大的userid
    void GetMaxUserId()
    {
        string query = "SELECT MAX(userid) FROM user";
        MySqlCommand command = new MySqlCommand(query, _connection);
        object result = command.ExecuteScalar();
        if (result != null && result != DBNull.Value)
        {
            maxUserid = Convert.ToInt32(result);
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
