using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public Canvas myCanvas;
    public Image image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = Input.mousePosition;
        RectTransform canvasRectTransform = myCanvas.GetComponent<RectTransform>();
        Vector2 uiLocalPoint;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRectTransform, screenPoint, myCanvas.worldCamera, out uiLocalPoint))
        {
            Debug.Log("UI Local Point: " + uiLocalPoint);
            //设置image的position为uiLocalPoint
            image.rectTransform.anchoredPosition = uiLocalPoint;
        }
    }
}
