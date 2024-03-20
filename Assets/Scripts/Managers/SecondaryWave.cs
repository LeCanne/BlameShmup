using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryWave : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public float rate;
    public int waves;
    private bool wavebool = false;
    public float startWave;
    public float endWave;
    public float timerspawn;
    public float requiredTime;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Enemytimer());
        
    }

    
    void Update()
    {
        timerspawn += Time.deltaTime;

        if(requiredTime < timerspawn)
        {
            if (wavebool == true)
            {
                Instantiate(enemy, gameObject.transform.position, gameObject.transform.rotation);
            }
            timerspawn = 0;
        }
        
           
               
    }

    IEnumerator Enemytimer()
    {
        yield return new WaitForSeconds(startWave);
        wavebool = true;
        yield return new WaitForSeconds(endWave);
        wavebool = false;
        
        
        gameObject.SetActive(false);
    }
}
