using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePos : MonoBehaviour
{
    public RectTransform sprite;
    public RectTransform Object;
    public float offsetX, offsetY;
    public Camera cam;
    public Canvas canvas;
    private void Start()
    {
        
    }
    private void Update()
    {
        Vector3 bigboombadaboom = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 anchoredPos;
        if (bigboombadaboom.x <= 0)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(Object, Input.mousePosition + new Vector3(offsetX, offsetY, 0) * canvas.scaleFactor, canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : cam, out anchoredPos);
            sprite.anchoredPosition = anchoredPos;
        }
         if (bigboombadaboom.x > 0)
        {
            
            RectTransformUtility.ScreenPointToLocalPointInRectangle(Object, Input.mousePosition + new Vector3(-offsetX, offsetY, 0) * canvas.scaleFactor, canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : cam, out anchoredPos);
            sprite.anchoredPosition = anchoredPos;
        }

        
        
          
        

    }

}

