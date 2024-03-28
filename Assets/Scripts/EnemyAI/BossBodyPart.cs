using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBodyPart : MonoBehaviour
{
    public int HP;
    public int MaxHP;
    private FlashEnemy flashEnemy;
    public AudioClip ouchFX;
    void Start()
    {
        flashEnemy = GetComponent<FlashEnemy>();
        MaxHP = 80;
        DisplayBoss.enableBossBar = true;
    }

    // Update is called once per frame
    void Update()
    {
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
            AudioManager.instance.PlaySoundFXClip(ouchFX, transform, 0.8f);
        }
    }
}
