using System;
using Unity.VisualScripting;
using UnityEngine;

public class SkillController : XSingleton<SkillController>
{

    [NonSerialized]public bool IsDash=false;
    [NonSerialized]public int ShadowCount = 5;
    [NonSerialized]public int CurrentDashCount = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //如果按下了h
        if (Input.GetKeyDown(KeyCode.H))
        {
            IsDash = true;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            GameController.S.gamePlayer.transform.Find("Shield").gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameController.S.gamePlayer.transform.Find("Rage").gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            GameController.S.IceArrow.Play();
            GameController.S.IceArrow.transform.Find("Trail").gameObject.SetActive(true);
        }
        if (IsDash ==true)
        {
            GlobalPlayerAttribute.PlayerMoveSpeed = 20;
            GameObject playerShadow = Instantiate(Resources.Load("Prefabs/Skill/DashShadow"),transform).GameObject();
            playerShadow.gameObject.SetActive(true);
            playerShadow.transform.localPosition = new Vector3(GameController.S.gamePlayer.transform.position.x, GameController.S.gamePlayer.transform.position.y,GameController.S.gamePlayer.transform.position.z);
            playerShadow.GetComponent<DashShadow>().StartA = 120+CurrentDashCount*10;
            CurrentDashCount++;
            if (CurrentDashCount > ShadowCount)
            {
                CurrentDashCount = 0;
                IsDash = false;
            }
        }
        else
        {
            GlobalPlayerAttribute.PlayerMoveSpeed = 3;
        }
    }
}
