using UnityEngine;
using UnityEngine.UI;

public class GameBGWindow : BasePanel
{
    public GameBGWindow() : base(new UIType("Prefabs/Gamebg")) { }
    
    public override void OnEnter()
    {
        Debug.Log("GameBGWindow OnEnter");
        UITool.S.GetChildGameObject("GameBGContinueBtn").GetComponent<Button>().onClick.AddListener(() =>
        {
            PanelManager.S.PushPanel(new RoleWindow());
        });
    }

    public override void OnExit()
    {
        Debug.Log("GameBGWindow OnExit");
        // Add your cleanup code here
    }

    public override void OnPause()
    {
       UITool.S.GetChildGameObject("content").SetActive(false);
       UITool.S.GetChildGameObject("title").SetActive(false);
       UITool.S.GetChildGameObject("GameBGContinueBtn").SetActive(false);
    }
}
