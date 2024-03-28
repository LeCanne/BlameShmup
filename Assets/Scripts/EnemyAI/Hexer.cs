using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Hexer : MonoBehaviour, InterfaceEnemy
{
    public float speed;
    bool initate;
    public float health;
    public GameObject[] Shooters;
    private Transform centerPos;
    public float timer;
    public int Score;

    private FlashEnemy flashenemy;

    [SerializeField] private AudioClip ouchFX;

    [SerializeField] private AudioClip damageFX;

    [SerializeField] private GameObject ExplosionFX;
    // Start is called before the first frame update
    void Start()
    {
        centerPos = GameObject.FindWithTag("Center").transform;
        flashenemy = GetComponent<FlashEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
        Attack();
        Move();
    }

    public void Attack()
    {
        timer += Time.deltaTime;
        if(timer > 2)
        {
            if(initate == false)
            {
                
                foreach (GameObject objec in Shooters)
                {
                    objec.SetActive(true);
                }
                initate = true;
            }
           
            
        }

        CheckHP();
       
    }

    public void Move()
    {
        if (timer < 2)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector2(centerPos.transform.position.x, centerPos.transform.position.y), 10 * Time.deltaTime);
        }
    }

    public void CheckHP()
    {
        if (health <= 0)
        {
            isDead();
            ParticleManager.m_Instance.ParticleSpawner(ExplosionFX, GetComponent<Collider2D>(), 1);
            AudioManager.instance.PlaySoundFXClip(damageFX, transform, 0.2f);
            ScreenShaker.screenshaker.cameraShake(0.3f, 1.4f);
            ControllerRumble.controllerrumble.Rumble(0.4f, 0.7f, 0.2f);
            ScoreManager.Score += Score * ScoreManager.Multiplier;
            gameObject.SetActive(false);
        }
    }
    public bool isDead()
    {
        if (health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            AudioManager.instance.PlaySoundFXClip(ouchFX, transform, 0.2f);
            health--;
            flashenemy.CallDamageFlash();
            Destroy(collision.gameObject);
        }
    }
}
