using System;
using System.Collections.Generic;
using MySqlConnector;
using UnityEngine;

namespace Mysql
{
    public class EquipController:XSingleton<EquipController>
    {
        public List<EquipBase> equipList = new List<EquipBase>();//Mysql中所有的装备

        
        public void InsertEquip(EquipTable equip)
        {
            //插入装备到Mysql,包括equipname
            string sql = $"INSERT INTO equip (equipid, equipname, quality, damage, crit, critdamage, damagespeed, bloodsuck, denfense, hp, movespeed, goodfortune) " +
                         $"VALUES ({equip.Equipid}, '{equip.EquipName}', {equip.Quality}, {equip.Damage}, {equip.CRIT}, {equip.CRITDamage}, {equip.DamageSpeed}, {equip.BloodSuck}, {equip.Denfense}, {equip.HP}, {equip.MoveSpeed}, {equip.GoodFortune})";
            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            try
            {
                command.ExecuteNonQuery();
                Debug.Log("Insert equip success");
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error inserting equip: " + ex.Message);
            }
        }

        public int MaxPropID()
        {
            //获取mysql的equip表中的equipid在10000000-19999999之间的最大值
            string sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 10000000 AND 19999999";
            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            int maxID = 0;
            try
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting max equipid: " + ex.Message);
            }
            return maxID>10000000?maxID:10000000;
        }
        
        public int MaxPrimaryWeaponID()
        {
            //获取mysql的equip表中的equipid在10000000-19999999之间的最大值
            string sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 20000000 AND 29999999";
            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            int maxID = 0;
            try
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting max equipid: " + ex.Message);
            }
            return maxID>20000000?maxID:20000000;
        }
        
        public int MaxSecondaryWeaponID()
        {
            //获取mysql的equip表中的equipid在10000000-19999999之间的最大值
            string sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 30000000 AND 39999999";
            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            int maxID = 0;
            try
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting max equipid: " + ex.Message);
            }
            return maxID>30000000?maxID:30000000;
        }
        
        public int MaxClothID()
        {
            //获取mysql的equip表中的equipid在10000000-19999999之间的最大值
            string sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 40000000 AND 49999999";
            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            int maxID = 0;
            try
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting max equipid: " + ex.Message);
            }
            return maxID>40000000?maxID:40000000;
        }
        
        public int MaxShoeID()
        {
            //获取mysql的equip表中的equipid在10000000-19999999之间的最大值
            string sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 50000000 AND 59999999";
            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            int maxID = 0;
            try
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting max equipid: " + ex.Message);
            }
            return maxID>50000000?maxID:50000000;
        }
        
        public int MaxRingID()
        {
            //获取mysql的equip表中的equipid在10000000-19999999之间的最大值
            string sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 60000000 AND 69999999";
            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            int maxID = 0;
            try
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting max equipid: " + ex.Message);
            }
            return maxID>60000000?maxID:60000000;
        }
        
        public int MaxNecklaceID()
        {
            //获取mysql的equip表中的equipid在10000000-19999999之间的最大值
            string sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 70000000 AND 79999999";
            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            int maxID = 0;
            try
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting max equipid: " + ex.Message);
            }
            return maxID>70000000?maxID:70000000;
        }
        
        public int MaxHelmetID()
        {
            //获取mysql的equip表中的equipid在10000000-19999999之间的最大值
            string sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 80000000 AND 89999999";
            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            int maxID = 0;
            try
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting max equipid: " + ex.Message);
            }
            return maxID>80000000?maxID:80000000;
        }
        
        public int MaxCloakID()
        {
            //获取mysql的equip表中的equipid在10000000-19999999之间的最大值
            string sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 90000000 AND 99999999";
            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            int maxID = 0;
            try
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting max equipid: " + ex.Message);
            }
            return maxID>90000000?maxID:90000000;
        }

        public EquipTable GetEquipAttributeFromMysql(int equipId)
        {
            //根据equipId从Mysql中获取装备属性
            string sql = $"SELECT * FROM equip WHERE equipid = {equipId}";
            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            MySqlDataReader reader = command.ExecuteReader();
            EquipTable equipTable = null;
            try
            {
                if (reader.Read())
                {
                    equipTable = new EquipTable
                    {
                        Equipid = reader.GetInt32("equipid"),
                        EquipName = reader.GetString("equipname"),
                        Quality = reader.GetInt32("quality"),
                        Damage = reader.GetInt32("damage"),
                        CRIT = reader.GetInt32("crit"),
                        CRITDamage = reader.GetInt32("critdamage"),
                        DamageSpeed = reader.GetInt32("damagespeed"),
                        BloodSuck = reader.GetInt32("bloodsuck"),
                        Denfense = reader.GetInt32("denfense"),
                        HP = reader.GetInt32("hp"),
                        MoveSpeed = reader.GetInt32("movespeed"),
                        GoodFortune = reader.GetInt32("goodfortune")
                    };
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting equip attribute: " + ex.Message);
            }
            finally
            {
                reader.Close();
            }
            return equipTable;
        }
    }
}