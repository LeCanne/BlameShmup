using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Rendering;

public class WallCrawler : MonoBehaviour, InterfaceEnemy
{

    [Header ("AttackProcess")]
    public bool shotSide, ShotProcess;
    public bool Positioned;
    public GameObject Shot1, Shot2;
    
    public float TimerSwitch;

    [Header ("GeneralProcess")]
    public BossBodyPart head;
    public int Health;
    public float TimerBegin;
    

    [Header("HeadMovement")]
    public Transform A;
    public Transform B;

    public float moveSpeed;

    private Transform current;
    private Transform target;
    private Vector3 beginPos;
    [SerializeField] private GameObject explosionFx;
    [SerializeField] private GameObject damage;
    private float sinTime;
    public bool dead;
   


    // Start is called before the first frame update
    void Start()
    {
        beginPos = transform.position;
        current = A;
            target = B;
    }

    // Update is called once per frame
    void Update()
    {
      
        if (dead == false)
        {


            //Begins
            TimerBegin += Time.deltaTime;
            if (TimerBegin >= 2)
            {
                Positioned = true;
                head.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(beginPos.x, beginPos.y - 7, beginPos.z), Time.deltaTime / 1);
            }

            Attack();
          
            HeadMovement();
            Health = head.HP;
            CheckHP();
        }
        else
        {
            Shot1.SetActive(false);
            Shot2.SetActive(false);
            Debug.Log("ded");
            TimerBegin += Time.deltaTime;
            if(TimerBegin > 3)
            {
               
                Destroy(gameObject);
            }
        }
    }

    public void HeadMovement()
    {
        if(Positioned == true)
        {
            if (head.transform.position != target.position)
            {
                sinTime += Time.deltaTime * moveSpeed;
                sinTime = Mathf.Clamp(sinTime, 0, Mathf.PI);
                float t = evaluate(sinTime);
                head.transform.position = Vector3.Lerp(current.position, target.position, t);
            }
            swap();
        }
     
    }

    public float evaluate(float x)
    {
        return 0.5f * Mathf.Sin(x - Mathf.PI / 2f) + 0.5f;
    }

    public void swap()
    {
        if (head.transform.position != target.position)
        {
            return;
        }

        Transform t = current;
        current = target;
        target = t;
        sinTime = 0;
    }

    public void Attack()
    {
        if(Positioned == true)
        {
            TimerSwitch += Time.deltaTime;

            if (TimerSwitch > 1)
            {
                if (ShotProcess == false)
                {



                    shotSide = !shotSide;

                    if (shotSide == false)
                    {
                        Shot1.SetActive(true);
                        Shot2.SetActive(false);
                    }
                    else
                    {
                        Shot2.SetActive(true);
                        Shot1.SetActive(false);
                    }
                    ShotProcess = true;
                }

                if (TimerSwitch > 2f)
                {
                    TimerSwitch = 0;
                    Shot2.SetActive(false);
                    Shot1.SetActive(false);
                    ShotProcess = false;
                }


            }
        }
       
    }

    public void CheckHP()
    {
        if(Health <= 0)
        {
            TimerBegin = 0;
            ParticleManager.m_Instance.ParticleSpawner(explosionFx, damage.GetComponent<Collider2D>(), 30);
            ScreenShaker.screenshaker.cameraShake(3f, 0.5f);
            ControllerRumble.controllerrumble.Rumble(1, 2, 3f);
            ScoreManager.Score += 30000;

            dead = true;



        }
    }

    public bool isDead()
    {
      if(Health <= 0)
      {
            return true;
      }
        else
        {
            return false;
        }
    }
}
