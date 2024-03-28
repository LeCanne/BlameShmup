using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BossBodyPart : MonoBehaviour
{
    public int HP;
    public int MaxHP;
    private FlashEnemy flashEnemy;
    public AudioClip ouchFX;
    public float timerdamage;
    public Light2D lite;
    void Start()
    {
        flashEnemy = GetComponent<FlashEnemy>();
        MaxHP = 80;
        DisplayBoss.enableBossBar = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(lite.enabled == true)
        {
            timerdamage += Time.deltaTime;
            if(timerdamage > 0.1f)
            {
                
                lite.enabled = false;
            }
        }
        DisplayBoss.maxHealthBoss = MaxHP;
        DisplayBoss.healthBoss = HP;

        if(HP <= 0)
        {
            DisplayBoss.enableBossBar = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayerBullet")
        {
            Destroy(other.gameObject);
            HP--;
            flashEnemy.CallDamageFlash();
            AudioManager.instance.PlaySoundFXClip(ouchFX, transform, 0.2f);
            timerdamage = 0;
            lite.enabled = true;
        }
    }
}
