using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBodyPart : MonoBehaviour
{
    public int HP;
    private FlashEnemy flashEnemy;
    public AudioClip ouchFX;
    void Start()
    {
        flashEnemy = GetComponent<FlashEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
