using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectMe : MonoBehaviour
{
    public EventSystem eventSystem;
    public Button button;
    public bool done;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (done == false)
        {


            eventSystem.SetSelectedGameObject(button.gameObject); 
            done = true;
        }
    }
}
