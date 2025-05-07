using UnityEngine;
using UnityEngine.UI;

public class BagButtonFight : MonoBehaviour
{
    public Button bagButtonFight;
    void Start()
    {
        bagButtonFight.onClick.AddListener(() =>
        {
            //暂停游戏
            Time.timeScale = 0;
            Instantiate(Resources.Load("Prefabs/Window/Bag"),GameController.S.transform) ;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
