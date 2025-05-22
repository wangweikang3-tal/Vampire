using System;
using UnityEngine;
using UnityEngine.UI;

public class FightBGController : XSingleton<FightBGController>
{
    public Joystick joystick;//虚拟移动杆
    public Button normalAttackButton;//普通攻击按钮
    public Button dashButton;
    public Button rageButton;
    public Button shieldButton;
    public Button iceArrowButton;
    public Button iceExButton;

    private void Awake()
    {
        joystick=GameController.S.transform.Find("FightBG(Clone)/Canvas/Fixed Joystick").GetComponent<Joystick>();
        normalAttackButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/NormalAttack").GetComponent<Button>();
        dashButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/Dash").GetComponent<Button>();
        rageButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/Rage").GetComponent<Button>();
        shieldButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/Shield").GetComponent<Button>();
        iceArrowButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/IceArrow").GetComponent<Button>();
        iceExButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/IceEx").GetComponent<Button>();
        normalAttackButton.onClick.AddListener(() =>
        {
            GameController.S.gamePlayer.currentGun.Shot();
        });
        dashButton.onClick.AddListener(() =>
        {
            SkillController.S. IsDash = true;
        });
        rageButton.onClick.AddListener(() =>
        {
            GameController.S.gamePlayer.transform.Find("Rage").gameObject.SetActive(true);
        });
        shieldButton.onClick.AddListener(() =>
        {
            GameController.S.gamePlayer.transform.Find("Shield").gameObject.SetActive(true);
        });
        iceArrowButton.onClick.AddListener(() =>
        {
            SkillController.S.IceArrow.Play();
            SkillController.S.IceArrow.transform.Find("Trail").gameObject.SetActive(true);        });
        iceExButton.onClick.AddListener(() =>
        {
            SkillController.S.IceExplosion1.Play();
            SkillController.S.IceExplosion2.Play();
            SkillController.S.IceExplosion3.Play();        
        });
    }
}