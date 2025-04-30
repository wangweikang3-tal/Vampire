using UnityEngine;

public class GameController : XSingleton<GameController>
{
    public Player gamePlayer;
    private GameObject _monsterBirthPoint;
    private SnotMonster _snotMonster;
    private float _monsterBirthTimeScale = 1f; //间隔一秒钟生成一个怪物
    private float _currentTime = 0f;
    private GameObject _fightBG;
    private Transform[] monsterBirthPoints;

    private void Awake()
    {
        Application.targetFrameRate = 30;
        gamePlayer = Instantiate(Resources.Load<GameObject>("Prefabs/Player/Player"), transform).GetComponent<Player>();
        _fightBG=Instantiate(Resources.Load<GameObject>("Prefabs/Window/FightBG"), transform);
        _fightBG.transform.position = new Vector3(0, 0, 0.1f);
        gamePlayer.transform.position = new Vector3(0, 0, 0f);
        _monsterBirthPoint = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/MonsterBirthPoint"), transform);
        _monsterBirthPoint.transform.position = new Vector3(0, 0, 0f);
        _snotMonster = Resources.Load<GameObject>("Prefabs/Monster/SnotMonster").GetComponent<SnotMonster>();
        monsterBirthPoints=_monsterBirthPoint.GetComponentsInChildren<Transform>();
    }

    private void CreateMonster()
    {
        //从子物体里随机选择一个
        int randomIndex = UnityEngine.Random.Range(1, monsterBirthPoints.Length);
        //获取随机选择的子物体    
        Transform randomPoint = monsterBirthPoints[randomIndex];
        //生成怪物
        GameObject monster = Instantiate(_snotMonster.gameObject, randomPoint.position, Quaternion.identity);
        monster.transform.SetParent(monsterBirthPoints[randomIndex]);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _monsterBirthTimeScale)
        {
            CreateMonster();
            _currentTime = 0f;
        }
    }
}