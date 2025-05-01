using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    }

    private void CreateMonster()
    {
        //从子物体里随机选择一个
        int randomIndex = UnityEngine.Random.Range(1, monsterBirthPoints.Length);
        //获取随机选择的子物体    
        Transform randomPoint = monsterBirthPoints[randomIndex];
        //生成怪物
        GameObject monster = Instantiate(snotMonster.gameObject, randomPoint.position, Quaternion.identity);
        monster.transform.SetParent(monsterBirthPoints[randomIndex]);
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
            nearMonsterPosition = Vector3.right;
        }
        
        
        //主角操作
        gamePlayer.PlayerMove();
        gamePlayer.PlayerMoveAnimation();
        gamePlayer.SetGunRotate(nearMonsterPosition);
        gamePlayer.currentGun.Shot();
    }
}