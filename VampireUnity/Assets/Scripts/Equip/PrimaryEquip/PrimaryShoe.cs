using Mysql;
using UnityEngine;
using Random = System.Random;

namespace Equip
{
    public class PrimaryShoe:EquipBase
    {
        public PrimaryShoe() : base( "PrimaryShoeFight", new EquipTable()){}

        private void Awake()
        {
            SpriteRenderer = transform.Find("PrimaryShoeSprite").GetComponent<SpriteRenderer>();
            // EquipAttributes.EquipQuality = EquipQuality.White;
            // //添加防御，随机10-20
            Random random = new Random();
            // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
            // //添加生命值，随机10-20
            // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
            EquipAttributes.Quality = 1;
            EquipAttributes.MoveSpeed=random.Next(3,7);
            EquipAttributes.Denfense=random.Next(2,4);
            
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PickUp"))
            {
                isPickUp= true;
            }else if (other.CompareTag("Player"))
            {
                //将这件装备的属性添加到数据库
                EquipAttributes.Equipid= EquipController.S.MaxShoeID() + 1;
                EquipController.S.InsertEquip(EquipAttributes);
                //将这件装备的属性添加到BagController上
                BagController.S.EquipidDic.Add(EquipAttributes.Equipid,SpriteRenderer.sprite);
                //如果被拾取，销毁装备
                Destroy(gameObject);
            }
        }
    }
}