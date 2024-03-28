using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBoss : MonoBehaviour
{
    public static int healthBoss = 1;
    public static int maxHealthBoss = 1;
    public static bool enableBossBar;
    public float newfill;
    public Image imgBossHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(enableBossBar == true)
        {
            imgBossHealth.gameObject.transform.parent.gameObject.SetActive(true);
            imgBossHealth.fillAmount = (float)healthBoss / (float)maxHealthBoss;
        }
        else
        {
            imgBossHealth.gameObject.transform.parent.gameObject.SetActive(false);
        }
      

       
    }
}
