using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScreenShaker : MonoBehaviour
{
    
    public CamShake camshake;
    public static ScreenShaker screenshaker;
    private void Awake() => screenshaker = this;
    
        
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

   
  
   
    

    
        

        

    

    public void cameraShake(float duration, float magnitude)
    {

      
            StartCoroutine(camshake.Shake(duration, magnitude));
        

    }

  

  


}



   


