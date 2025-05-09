using UnityEngine;
using UnityEngine.UI;

public class EquipAttributePanel : MonoBehaviour
{
    public Button exitButton;
    public Button installButton;
    public Button sellButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        exitButton.onClick.AddListener(() =>
        {
            Destroy(gameObject);
            BagController.S.DestroyMaskLayer();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
