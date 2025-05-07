using Mysql;
using MySqlConnector;
using UnityEngine;
using UnityEngine.UI;

public class LoginWindow : BasePanel
{
    public LoginWindow() : base(new UIType("Prefabs/Window/LoginWindow")) { }
    private InputField _usernameInputField;
    private InputField _passwordInputField;
    
    public void GetInputField()
    {
        _usernameInputField = UITool.S.GetChildGameObject("UserNameText").GetComponent<InputField>();
        _passwordInputField = UITool.S.GetChildGameObject("PassWardText").GetComponent<InputField>();
    }
    
    public override void OnEnter()
    {
        Debug.Log("LoginWindow OnEnter");
        UITool.S.GetChildGameObject("LoginExitButton").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
        {
            UITool.S.GetChildGameObject("LoginWindow").SetActive(false);
        });
        UITool.S.GetChildGameObject("RegisterButton").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
        {
            GetInputField();
            UserController.S.InsertUser(_usernameInputField.text,_passwordInputField.text);
            Debug.Log("注册成功");
            PanelManager.S.PopPanel();

            //UITool.S.GetChildGameObject("LoginWindow").SetActive(false);

        });
            
        
        UITool.S.GetChildGameObject("LoginButton").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
        {
            Debug.Log("点击登陆按钮");
            GetInputField();
            string username = _usernameInputField.text;
            string password = _passwordInputField.text;
            //到ConnectMysql中的Users列表验证用户名和密码
            bool isLogin = false;
            foreach (var user in UserController.S.Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    isLogin = true;
                    Debug.Log("登陆成功");
                    break;
                }
            }
            if (isLogin)
            {
                // 登陆成功，进入游戏
                PanelManager.S.PopPanel();
               // UITool.S.GetChildGameObject("LoginWindow").SetActive(false);
            }
            else
            {
                Debug.Log("登陆失败");
                // 提示用户登陆失败
            }
        });
    }
    
    public override void OnExit()
    {
         UITool.S.GetChildGameObject("LoginWindow").SetActive(false);
        Debug.Log("LoginWindow OnExit");
        // Add your cleanup code here
    }
    
    public override void OnPause()
    {
        UITool.S.GetChildGameObject("Login").SetActive(false);
        UITool.S.GetChildGameObject("title").SetActive(false);
        UITool.S.GetChildGameObject("content").SetActive(false);
    }
    
    public override void OnResume()
    {
        UITool.S.GetChildGameObject("Login").SetActive(true);
        UITool.S.GetChildGameObject("title").SetActive(true);
        UITool.S.GetChildGameObject("content").SetActive(true);
    }
   
}
