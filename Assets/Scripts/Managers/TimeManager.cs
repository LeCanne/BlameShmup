using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public bool lost;
    float timestop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lost == true)
        {
            timestop += Time.unscaledDeltaTime;
            if (Time.timeScale > 0 && timestop > 0.1f)
            {
                timestop = 0;
                Time.timeScale -= 0.05f;
            }
        }
       
    }


}
