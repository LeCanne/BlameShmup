using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public bool lost;
    float timestop;
    public GameObject LoseScreen;
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(music.pitch > 0.7f)
        {
            music.pitch = Time.timeScale;
        }
       
        if (lost == true)
        {
            timestop += Time.unscaledDeltaTime;
            if (Time.timeScale > 0.1 && timestop > 0.1f)
            {
                timestop = 0;
                Time.timeScale -= 0.05f;
               
            }
            if(Time.timeScale < 0.1)
            {
                Time.timeScale = 0;
                LoseScreen.SetActive(true);
            }
            
        }
       
    }


}
