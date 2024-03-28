using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEditor;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemy;
    public float rate;
    
    public int waves;
    private bool wavebool, endwarn;
    public float startWave;
    public float endWave, timer;
    private SpriteRenderer sprRend;
    public SpriteRenderer otherRender;

    public float nextwave;
    // Start is called before the first frame update
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
        sprRend.enabled = false;
        StartCoroutine(Enemytimer());
        InvokeRepeating("SpawnEnemy", 0, rate);
    }

    private void Update()
    {
        if (wavebool == false && endwarn == false)
        {
            timer += Time.deltaTime;
            if (timer > 0.2f)
            {
               otherRender.gameObject.SetActive(false);
                if(timer > 0.4f)
                {
                    timer = 0;

                }
                
            }
            else
            {
                otherRender.gameObject.SetActive(true);

            }
        }
        else
        {
            otherRender.enabled = false;
        }
        
    }
    // Update is called once per frame
    void SpawnEnemy()
    {
        if (wavebool == true)
        {

            Instantiate(enemy, gameObject.transform.position, gameObject.transform.rotation);


        }
    }
    IEnumerator Enemytimer()
    {
        yield return new WaitForSeconds(startWave);
        wavebool = true;
        yield return new WaitForSeconds(endWave);
        wavebool = false;
        endwarn = true;
        yield return new WaitForSeconds(nextwave);
        WaveManager.wavenumber += 1;
        WaveManager.wavemanagement = true;
        
        gameObject.SetActive(false);




    }
}
