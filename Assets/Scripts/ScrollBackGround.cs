using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScrollBackGround : MonoBehaviour
{

    public float ScrollSpeedX;
    public float ScrollSpeedY;
    public float offsetX;
    public float offsetY;
    private Material mat;
    
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        offsetX += Time.deltaTime * ScrollSpeedX;
        offsetY += Time.deltaTime * ScrollSpeedY;
        mat.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));


    }
}
