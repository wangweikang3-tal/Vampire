using System;
using UnityEngine;
using UnityEngine.UI;

public class BagPanel : MonoBehaviour
{
    public Button playerButton;
    public Button attributeButton;
    
    //属性面板的各个属性的文本
    public Text playerDamageAttributeText;
    public Text playerHPAttributeText;
    public Text playerDefenseAttributeText;
    public Text playerCRITAttributeText;
    public Text playerCRITDamageAttributeText;
    public Text playerMoveSpeedAttributeText;
    public Text playerAttackSpeedAttributeText;
    public Text playerGoodfortuneAttributeText;
    public Text playerBloodSuckAttributeText;


    private void Awake()
    {
        playerButton.onClick.AddListener(() =>
        {
            BagController.S.ShowPlayerPanel();
        });
        attributeButton.onClick.AddListener(() =>
        {
            BagController.S.ComputeTotalAttribute();
            BagController.S.ShowAttributePanel();
            playerDamageAttributeText.text=GlobaPlayerAttribute.TotalDamage.ToString();
            playerHPAttributeText.text=GlobaPlayerAttribute.TotalMaxHp.ToString();
            playerDefenseAttributeText.text=GlobaPlayerAttribute.TotalDenfense.ToString();
            playerCRITAttributeText.text=GlobaPlayerAttribute.TotalCRIT.ToString();
            playerCRITDamageAttributeText.text=GlobaPlayerAttribute.TotalCRITDamage.ToString();
            playerMoveSpeedAttributeText.text=GlobaPlayerAttribute.TotalMoveSpeed.ToString();
            playerAttackSpeedAttributeText.text=GlobaPlayerAttribute.TotalAttackSpeed.ToString();
            playerGoodfortuneAttributeText.text=GlobaPlayerAttribute.TotalGoodFortune.ToString();
            playerBloodSuckAttributeText.text=GlobaPlayerAttribute.TotalBloodSuck.ToString();
        });
    }
    
}
