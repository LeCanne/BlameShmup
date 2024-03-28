using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedActive : MonoBehaviour
{
    public GameObject toSetActive;
    public float delayTime;
    public float endtransiton;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Toset());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Toset()
    {
        yield return new WaitForSeconds(delayTime);
        toSetActive.SetActive(true);
        yield return new WaitForSeconds(endtransiton);
        toSetActive.SetActive(false);
    }
}
