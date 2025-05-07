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
            //插入装备到Mysql
            string sql = $"INSERT INTO equip (equipid, quality, damage, crit, critdamage, damagespeed, bloodsuck, denfense, hp, movespeed, goodfortune) " +
                         $"VALUES ({equip.Equipid}, {equip.Quality}, {equip.Damage}, {equip.CRIT}, {equip.CRITDamage}, {equip.DamageSpeed}, {equip.BloodSuck}, {equip.Denfense}, {equip.HP}, {equip.MoveSpeed}, {equip.GoodFortune})";
            //执行sql语句
            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            try
            {
                command.ExecuteNonQuery();
                Debug.Log("EquipTable inserted successfully");
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error inserting equip: " + ex.Message);
            }
        }
    }
}