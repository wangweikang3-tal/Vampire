using UnityEngine;
using UnityEngine.UI;

public class MainWindow : BasePanel
{
   public MainWindow(): base(new UIType("Prefabs/MainWindow")) { }
   public override void OnEnter()
   {
      UITool.S.GetChildGameObject("StartGameButton").gameObject.GetComponent<Button>().onClick.AddListener(() =>
      {
         Debug.Log("kkkkkkk");
         PanelManager.S.PushPanel(new test());
      });
   }

   public override void OnPause()
   {
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
