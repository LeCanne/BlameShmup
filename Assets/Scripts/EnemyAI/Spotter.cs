using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Spotter : MonoBehaviour, InterfaceEnemy
{
    public BulletSpawner spawner, one,two;
    public Transform playerPos;
    public GameObject currentShield, Shield1, Shield2;
    private FlashEnemy flashEnemy;
    private Animator animator;
    private SpriteRenderer sprRend;
    public Light2D lightin;

    public float timerbullet;
    float timerdamage;
    public int healthPoint;
    public bool newPos = true, firstcheck = true;
    private Vector3 newposition;
    public float distance = 1;
    public bool inBound;
    public int score;

    [SerializeField] private AudioClip damageFX;
    [SerializeField] private AudioClip ouchFX;
    [SerializeField] private GameObject ExplosionFX;
    // Start is called before the first frame update
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        flashEnemy = GetComponent<FlashEnemy>();
        if(GameObject.FindWithTag("Player") != null)
        {
            playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }
       
    }

    // Update is called once per frame
    void Update()
    {

        if(lightin.enabled == true)
        {
            timerdamage += Time.deltaTime;
            if(timerdamage > 0.1f)
            {
                lightin.enabled = false;
                timerdamage = 0;
            }
        }
      CheckHP();
        timerbullet += Time.deltaTime;
        Vector3 v = transform.position;
        if (firstcheck == true)
        {
            newposition = playerPos.transform.position;
            firstcheck = false;
            distance = 1;
        }
        
            distance = Vector3.Distance(new Vector3(0, newposition.y, 0), new Vector3(0, transform.position.y, 0));


        if (playerPos != null)
        {
            if (timerbullet >= 2)
            {
                animator.Play("Shieldbot_turn");
                inBound = false;
                spawner.enabled = false;
                if(currentShield != null)
                {
                    currentShield.SetActive(false);
                }
                
                if (newPos == true)
                {
                    newposition = playerPos.transform.position;
                    newPos = false;
                    distance = 1;

                }
                transform.position = Vector3.Lerp(v, new Vector3(v.x, newposition.y, v.z), Time.deltaTime / 0.2f);

                if (distance < 0.5f)

                {
                    animator.Play("Shieldbot__shoot");
                    if(currentShield != null)
                    {
                        currentShield.SetActive(false);
                    }
                   
                    if (playerPos.transform.position.x > transform.position.x)
                    {
                        sprRend.flipX = false;
                        spawner = one;
                        currentShield = Shield1;

                    }
                    else
                    {
                        sprRend.flipX = true;
                        currentShield = Shield2;
                        spawner = two;
                    }
                    currentShield.SetActive(true);
                    spawner.enabled = true;
                    newPos = true;
                    firstcheck=true;
                    timerbullet = 0;
                    inBound = true;




                }

            }

           
         
           
        }
       
    }
    public void CheckHP()
    {
        if (healthPoint <= 0)
        {
            isDead();
            ParticleManager.m_Instance.ParticleSpawner(ExplosionFX, GetComponent<Collider2D>(), 1);
            AudioManager.instance.PlaySoundFXClip(damageFX, transform, 0.5f);
            ScoreManager.Score += score * ScoreManager.Multiplier;
            ScreenShaker.screenshaker.cameraShake(0.3f, 1f);
            ControllerRumble.controllerrumble.Rumble(0.4f, 0.7f, 0.2f);
            gameObject.SetActive(false);
        }
    }

    public bool isDead()
    {
        if (healthPoint <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (inBound == true)
        {
            if (other.gameObject.tag == "PlayerBullet")
            {
                AudioManager.instance.PlaySoundFXClip(ouchFX, transform, 0.3f);
                flashEnemy.CallDamageFlash();
                healthPoint--;
                
                Destroy(other.gameObject);
                lightin.enabled = true;
            }
        }
       
    }
}
