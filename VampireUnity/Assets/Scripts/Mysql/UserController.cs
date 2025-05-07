
using System;
using System.Collections.Generic;
using MySqlConnector;
using UnityEngine;

namespace Mysql
{
    public class UserController : XSingleton<UserController>
    {
        public List<UserTable> Users;

        public int maxUserid;

        //向User表中插入数据
        public void InsertUser(string username, string password)
        {
            string query = "INSERT INTO user (userid, username, passward) VALUES (@userid, @username, @passward)";
            MySqlCommand command = new MySqlCommand(query, ConnectMysql.Connection);
            command.Parameters.AddWithValue("@userid", maxUserid + 1);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@passward", password);

            try
            {
                command.ExecuteNonQuery();
                Debug.Log("UserTable inserted successfully");
                GetMaxUserId();
                GetUserTable();
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error inserting user: " + ex.Message);
            }
        }

        //获取User表中最大的userid
        public void GetMaxUserId()
        {
            string query = "SELECT MAX(userid) FROM user";
            MySqlCommand command = new MySqlCommand(query, ConnectMysql.Connection);
            object result = command.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                maxUserid = Convert.ToInt32(result);
            }
        }

        //将User表中的数据存储全部到Users中
        public void GetUserTable()
        {
            string query = "SELECT * FROM user";
            MySqlCommand command = new MySqlCommand(query, ConnectMysql.Connection);
            MySqlDataReader reader = command.ExecuteReader();
            Users = new List<UserTable>();
            try
            {
                while (reader.Read())
                {
                    UserTable userTable = new UserTable
                    {
                        UserId = reader.GetInt32("userid"),
                        Username = reader.GetString("username"),
                        Password = reader.GetString("passward")
                    };
                    Users.Add(userTable);
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

        public void QueryDatabase()
        {
            string query = "SELECT * FROM user";
            MySqlCommand command = new MySqlCommand(query, ConnectMysql.Connection);
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
    }
}