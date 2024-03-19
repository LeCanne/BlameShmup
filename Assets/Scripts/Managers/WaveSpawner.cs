using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemy;
    public float rate;
    public int waves;
    private bool wavebool;
    public float startWave;
    public float endWave;
    private SpriteRenderer sprRend;
    public float nextwave;
    // Start is called before the first frame update
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
        sprRend.enabled = false;
        StartCoroutine(Enemytimer());
        InvokeRepeating("SpawnEnemy", rate, rate);
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        if (wavebool == true)
        {


            for (int i = 0; i < waves; i++)
                Instantiate(enemy, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    IEnumerator Enemytimer()
    {
      
        wavebool = true;
        yield return new WaitForSeconds(endWave);
        wavebool = false;
        yield return new WaitForSeconds(nextwave);
        WaveManager.wavenumber += 1;
        WaveManager.wavemanagement = true;
        
        gameObject.SetActive(false);




    }
}
