using System;
using UnityEngine;
using UnityEngine.UI;

public class BagPanel : MonoBehaviour
{
    public Button playerButton;
    public Button attributeButton;


    private void Awake()
    {
        playerButton.onClick.AddListener(() =>
        {
            BagController.S.ShowPlayerPanel();
        });
        attributeButton.onClick.AddListener(() =>
        {
            BagController.S.ShowAttributePanel();
        });
    }
}
