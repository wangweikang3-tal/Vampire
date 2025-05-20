using UnityEngine;

public class CameraContraller : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //摄像机跟随玩家
        if (GameController.S.gamePlayer != null)
        {
            transform.position = new Vector3(GameController.S.gamePlayer.transform.position.x, GameController.S.gamePlayer.transform.position.y, -10);
        }

        // if (transform.position.x < -9.5f)
        //     transform.position =new Vector3(-9.5f, transform.position.y, transform.position.z);
        // if (transform.position.x > 9.5f)
        //     transform.position =new Vector3(9.5f, transform.position.y, transform.position.z);
        // if(transform.position.y < -5f)
        //     transform.position =new Vector3(transform.position.x, -5f, transform.position.z);
        // if(transform.position.y > 5f)
        //     transform.position =new Vector3(transform.position.x, 5f, transform.position.z);
            
    }
}
