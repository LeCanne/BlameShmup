using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerRumble : MonoBehaviour
{
    
   
    public static ControllerRumble controllerrumble;
    private void Awake() => controllerrumble = this;
    // Start is called before the first frame update
  


    public void Rumble(float minrumble, float maxrumble, float rumbletime)
    {


        StartCoroutine(Rumbling(minrumble, maxrumble, rumbletime ));
    }

    IEnumerator Rumbling(float min, float max, float rumbletime)
    {
        if (Gamepad.current != null)
        {


            Gamepad.current.SetMotorSpeeds(min, max);
            yield return new WaitForSecondsRealtime(rumbletime);
            Gamepad.current.SetMotorSpeeds(0, 0);
        }

    }
}
