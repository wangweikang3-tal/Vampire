using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLevelWindow : BasePanel
{
    public GameLevelWindow(): base(new UIType("Prefabs/Window/GameLevel")) { }
    public override void OnEnter()
    {
        UITool.S.GetChildGameObject("GameLevelFight").gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            GameObject.Find("UIRoot").SetActive(false);
            //跳转到Fight场景
            SceneManager.LoadScene("FightScene");
        });
    }
}
