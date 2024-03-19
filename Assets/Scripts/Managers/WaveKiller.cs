using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveKiller : MonoBehaviour
{
    public GameObject enemy;
    public float rate;
    private bool wavestarted;
    private List<InterfaceEnemy> enemyList = new List<InterfaceEnemy>();
    public int waves;
    public float timer;
    private bool wavebool = true;
    public float startWave;
    public float endWave;
    private SpriteRenderer sprRend;
    public float nextwave;
    // Start is called before the first frame update
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
        sprRend.enabled = false;
        
        Invoke("SpawnEnemy", 1);
    }

    private void Update()
    {
        if(wavestarted == true)
        {
           
            if (enemyList.Count == 0)
            {
                
                timer += Time.deltaTime;
                
            }
            else
            {
                if (enemyList[0].isDead() == true)
                {
                    enemyList.RemoveAt(0);
                }
            }
        }

        if(timer > 2)

        {
            WaveManager.wavenumber += 1;
            WaveManager.wavemanagement = true;
            gameObject.SetActive(false);
        }
       
       

        
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        if (wavebool == true)
        {

            GameObject enemiesleft = Instantiate(enemy, gameObject.transform.position, gameObject.transform.rotation);
            InterfaceEnemy enemyint = enemiesleft.GetComponent<InterfaceEnemy>();
            enemyList.Add(enemyint);
            wavestarted = true;

        }
    }

    
    
}
