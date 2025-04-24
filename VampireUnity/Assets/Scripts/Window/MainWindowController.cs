using UnityEngine;

public class MainWindowController : MonoBehaviour
{
    void Start()
    {
        PanelManager.S.PushPanel(new MainWindow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
