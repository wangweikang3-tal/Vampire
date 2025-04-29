using UnityEngine;
using UnityEngine.UI;

public class RoleWindow : BasePanel
{
    public RoleWindow(): base(new UIType("Prefabs/RoleWindow")) { }

    public override void OnEnter()
    {
        UITool.S.GetChildGameObject("Portal").gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            Debug.Log("点击进入关卡界面");
            PanelManager.S.PushPanel(new GameLevelWindow());
        });
    }
    
    public override void OnPause()
    {
        UITool.S.GetChildGameObject("RoleWindow").SetActive(false);
    }
    
    public override void OnResume()
    {
        base.OnResume();
    }
    
    public override void OnExit()
    {
        base.OnExit();
    }
}
