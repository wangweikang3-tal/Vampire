using UnityEngine;

public class SnotMonster : MonsterBase
{
    //构造方法
    public SnotMonster() : base(MonsterType.Normal, "SnotMonster", 1, 100, 0.3f, 10, 5, 50, 10, 0) { }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MonsterMove();
    }
}
