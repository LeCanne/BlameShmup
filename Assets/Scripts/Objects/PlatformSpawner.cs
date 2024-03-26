using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject Platform;
    private Descent descent;
    public float speed;
    private SpriteRenderer sprRend;
    public int rate;
    public float endWave, nextwave;
    public bool wavebool;
    public bool SecondWave;

    // Start is called before the first frame update
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
        sprRend.enabled = false;
        descent = Platform.GetComponent<Descent>();
        StartCoroutine(Enemytimer());
        InvokeRepeating("SpawnEnemy", 0, rate);
    }

    // Update is called once per frame
    void Update()
    {
         descent.speed = speed;
    }

    void SpawnEnemy()
    {
        if (wavebool == true)
        {

            Instantiate(Platform, gameObject.transform.position, gameObject.transform.rotation);


        }
    }


    IEnumerator Enemytimer()
    {

        wavebool = true;
        yield return new WaitForSeconds(endWave);
        wavebool = false;
        yield return new WaitForSeconds(nextwave);
        if(SecondWave == false)
        {
            WaveManager.wavenumber += 1;
            WaveManager.wavemanagement = true;
        }
        

        gameObject.SetActive(false);




    }
}
