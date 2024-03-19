using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] waves;
    public static bool wavemanagement = true;
    public static int wavenumber = 0;

    private bool loader = false;
    public AudioSource musicmanager;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Loading());
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(wavemanagement == true && loader == true)
        {
            if(wavenumber < waves.Length)
            {
                waves[wavenumber].SetActive(true);
                wavemanagement = false;
            }
           
        }

        if (wavenumber >= 28)
        {
            if (timer >= 0.8)
            {


                musicmanager.volume -= 0.1f;
                timer = 0;
            }
        }
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(1);
        loader = true;
        
    }
    
}