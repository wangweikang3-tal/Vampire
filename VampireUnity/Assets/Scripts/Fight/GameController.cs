using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : XSingleton<GameController>
{
    public Player gamePlayer;
    public GameObject monsterBirthPoint;
    public SnotMonster snotMonster;
    public float monsterBirthTimeScale = 1f; //间隔一秒钟生成一个怪物
    public float currentTime = 0f;
    public GameObject fightBG;
    public Transform[] monsterBirthPoints;
    //怪物探测器，检测最近的怪物
    public List<MonsterBase> monsterDetetor1 ;
    public List<MonsterBase> monsterDetetor2 ;
    public List<MonsterBase> monsterDetetor3 ;
    //最近怪物位置
    public Vector3 nearMonsterPosition;
    //怪物血条
    public GameObject monsterHpSliderPrefabs;

    private void Awake()
    {
        Application.targetFrameRate = 30;
        gamePlayer = Instantiate(Resources.Load<GameObject>("Prefabs/Player/Player"), transform).GetComponent<Player>();
        fightBG=Instantiate(Resources.Load<GameObject>("Prefabs/Window/FightBG"), transform);
        fightBG.transform.position = new Vector3(0, 0, 0.1f);
        gamePlayer.transform.position = new Vector3(0, 0, 0f);
        monsterBirthPoint = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/MonsterBirthPoint"), transform);
        monsterBirthPoint.transform.position = new Vector3(0, 0, 0f);
        snotMonster = Resources.Load<GameObject>("Prefabs/Monster/SnotMonster").GetComponent<SnotMonster>();
        monsterBirthPoints=monsterBirthPoint.GetComponentsInChildren<Transform>();
        monsterDetetor1 = new List<MonsterBase>();
        monsterDetetor2 = new List<MonsterBase>();
        monsterDetetor3 = new List<MonsterBase>();
        monsterHpSliderPrefabs=Resources.Load<GameObject>("Prefabs/Tool/MonsterHPBloodBar");
        //实例化UI
        Instantiate(Resources.Load<GameObject>("Prefabs/UI/RoleInfoFight"), transform);
    }

    private void CreateMonster()
    {
        //从子物体里随机选择一个
        int randomIndex = UnityEngine.Random.Range(1, monsterBirthPoints.Length);
        //获取随机选择的子物体    
        Transform randomPoint = monsterBirthPoints[randomIndex];
        //生成怪物
        GameObject monster = Instantiate(snotMonster.gameObject, randomPoint.position, Quaternion.identity);
        MonsterBase monsterBase = monster.GetComponent<MonsterBase>();
        monsterBase.CurrentHp=monsterBase.MaxHp;
        monster.transform.SetParent(monsterBirthPoints[randomIndex]);
        //生成怪物血条
        GameObject monsterHpBar = Instantiate(monsterHpSliderPrefabs.gameObject, monster.transform);
        Slider monsterHpSlider = monsterHpBar.transform.Find("Canvas/MonsterHPSlider").GetComponent<Slider>();
        monsterBase.hpSlider = monsterHpSlider;
        monsterHpBar.transform.position = new Vector3(monsterHpBar.transform.position.x, monsterHpBar.transform.position.y + 0.2f, monsterHpBar.transform.position.z-0.1f);

    }

    private void Update()
    {
        //生成怪物
        currentTime += Time.deltaTime;
        if (currentTime >= monsterBirthTimeScale)
        {
            CreateMonster();
            currentTime = 0f;
        }
        //获得距离最近的怪物位置
        // 在排序之前清理无效的怪物引用
        monsterDetetor1.RemoveAll(monster => monster == null);
        monsterDetetor2.RemoveAll(monster => monster == null);
        monsterDetetor3.RemoveAll(monster => monster == null);
        monsterDetetor1 = SortMonsterDistance(monsterDetetor1);
        monsterDetetor2 = SortMonsterDistance(monsterDetetor2);
        monsterDetetor3 = SortMonsterDistance(monsterDetetor3);
        if (monsterDetetor1.Count > 0)
        {
            nearMonsterPosition = monsterDetetor1[0].transform.position;
        }
        else if (monsterDetetor2.Count > 0)
        {
            nearMonsterPosition = monsterDetetor2[0].transform.position;
        }
        else if (monsterDetetor3.Count > 0)
        {
            nearMonsterPosition = monsterDetetor3[0].transform.position;
        }
        else
        {
           //朝向player的右边
           if(gamePlayer.spriteRenderer.flipX)
               nearMonsterPosition = gamePlayer.transform.position + new Vector3(-1, 0, 0);
           else
              nearMonsterPosition = gamePlayer.transform.position + new Vector3(1, 0, 0);
        }
        
        //主角操作
        gamePlayer.PlayerMove();
        gamePlayer.PlayerMoveAnimation();
        gamePlayer.SetGunRotate(nearMonsterPosition);
        //按空格键射击
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gamePlayer.currentGun.Shot();
        }
    }

    private List<MonsterBase> SortMonsterDistance(List<MonsterBase> monsters)
    {
        // 首先移除所有已经被销毁的怪物
        monsters.RemoveAll(monster => monster == null);

        //按monsters距离player的距离排序，越小越在前面
        monsters.Sort((a, b) =>
        {
            float distanceA = Vector3.Distance(gamePlayer.transform.position, a.transform.position);
            float distanceB = Vector3.Distance(gamePlayer.transform.position, b.transform.position);
            return distanceA.CompareTo(distanceB);
        });
        return monsters;
    }
}