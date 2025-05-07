using System;
using System.Collections.Generic;
using Mysql;
using MySqlConnector;
using UnityEngine;

public class ConnectMysql : XSingleton<ConnectMysql>
{
    public string connectionString;
    public static MySqlConnection Connection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 根据你的 MySQL 服务器配置填写这些信息
        string server = "rm-cn-oo0492f6o000rto.rwlb.rds.aliyuncs.com";
        string database = "Vampire";
        string user = "wwk18255113901";
        string password = "BaiChen123456+";

        connectionString = $"server={server};database={database};uid={user};pwd={password};";
        ConnectToDatabase();
         UserController.S.GetUserTable();
         UserController.S.GetMaxUserId();
    }

    void ConnectToDatabase()
    {
        Connection = new MySqlConnection(connectionString);
        try
        {
            Connection.Open();
            Debug.Log("Connected to MySQL database");
            // 在这里执行数据库操作，如查询、插入等
            UserController.S.QueryDatabase();
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Error connecting to MySQL database: " + ex.Message);
        }
    }
    
   
    // Update is called once per frame
    void OnDestroy()
    {
        if (Connection != null && Connection.State == System.Data.ConnectionState.Open)
        {
            Connection.Close();
        }
    }
}
