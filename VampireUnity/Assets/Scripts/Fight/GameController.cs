using System;
using UnityEngine;

public class GameController : XSingleton<GameController>
{
    public Player GamePlayer;
    private void Awake()
    {
        GamePlayer=Instantiate(Resources.Load<GameObject>("Prefabs/Player"),transform).GetComponent<Player>();
        Instantiate(Resources.Load<GameObject>("Prefabs/FightBG"),transform);
        GamePlayer.transform.position = new Vector3(0,0,-0.1f);
    }
}
