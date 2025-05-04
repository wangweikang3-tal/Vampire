using UnityEngine;
using UnityEngine.UI;

public class MainWindow : BasePanel
{
   public MainWindow(): base(new UIType("Prefabs/Window/MainWindow")) { }
   private bool _isgameStart = false;
   public override void OnEnter()
   {
      UITool.S.GetChildGameObject("StartGameButton").gameObject.GetComponent<Button>().onClick.AddListener(() =>
      {
         Debug.Log("点击进入末世");
         _isgameStart = true;
         PanelManager.S.PushPanel(new GameBGWindow());
      });
      UITool.S.GetChildGameObject("Login").gameObject.GetComponent<Button>().onClick.AddListener(() =>
      {
         _isgameStart = false;
         Debug.Log("进入登陆界面");
         PanelManager.S.PushPanel(new LoginWindow());
      });
   }

   public override void OnPause()
   {
      Debug.Log("主界面隐藏");
      if (_isgameStart)
      {
         UITool.S.GetChildGameObject("GameBG").gameObject.SetActive(false);
         UITool.S.GetChildGameObject("StartGameButton").gameObject.SetActive(false);
      }
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
