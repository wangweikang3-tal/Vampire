using UnityEngine;
using UnityEngine.UI;

public class MainWindow : BasePanel
{
   public MainWindow(): base(new UIType("Prefabs/Window/MainWindow")) { }
   public override void OnEnter()
   {
      UITool.S.GetChildGameObject("StartGameButton").gameObject.GetComponent<Button>().onClick.AddListener(() =>
      {
         Debug.Log("点击进入末世");
         PanelManager.S.PushPanel(new GameBGWindow());
      });
   }

   public override void OnPause()
   {
      Debug.Log("主界面隐藏");
     UITool.S.GetChildGameObject("GameBG").gameObject.SetActive(false);
     UITool.S.GetChildGameObject("StartGameButton").gameObject.SetActive(false);
   }
   
   public override void OnResume()
   {
      UITool.S.GetChildGameObject("MainWindow").GetComponent<GraphicRaycaster>().enabled = true;
   }
   
   public override void OnExit()
   {
      UIManager.S.DestroyUIWindow(new UIType("Prefabs/MainWindow"));
   }
}
