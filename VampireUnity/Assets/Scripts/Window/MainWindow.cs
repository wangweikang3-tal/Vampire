using UnityEngine;
using UnityEngine.UI;

public class MainWindow : BasePanel
{
   public MainWindow(): base(new UIType("Prefabs/MainWindow")) { }
   public override void OnEnter()
   {
      UITool.S.ActivePanelGetOrAddComponentInChild<Button>("Button").onClick.AddListener(() =>
      {
         Debug.Log("kkkkkkk");
         PanelManager.S.PushPanel(new test());
      });
   }

   public override void OnPause()
   {
     UITool.S.GetChildGameObject("MainWindow").GetComponent<GraphicRaycaster>().enabled = false;
   }
}
