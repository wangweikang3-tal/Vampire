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
            playerDamageAttributeText.text=GlobalPlayerAttribute.TotalDamage.ToString();
            playerHPAttributeText.text=GlobalPlayerAttribute.TotalMaxHp.ToString();
            playerDefenseAttributeText.text=GlobalPlayerAttribute.TotalDenfense.ToString();
            playerCRITAttributeText.text=GlobalPlayerAttribute.TotalCRIT.ToString();
            playerCRITDamageAttributeText.text=GlobalPlayerAttribute.TotalCRITDamage.ToString();
            playerMoveSpeedAttributeText.text=GlobalPlayerAttribute.TotalMoveSpeed.ToString();
            playerAttackSpeedAttributeText.text=GlobalPlayerAttribute.TotalAttackSpeed.ToString();
            playerGoodfortuneAttributeText.text=GlobalPlayerAttribute.TotalGoodFortune.ToString();
            playerBloodSuckAttributeText.text=GlobalPlayerAttribute.TotalBloodSuck.ToString();
        });
    }
    
}
