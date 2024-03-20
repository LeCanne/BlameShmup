using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Rendering;

public class WallCrawler : MonoBehaviour, InterfaceEnemy
{

    [Header ("AttackProcess")]
    public bool shotSide, ShotProcess;
    public GameObject Shot1, Shot2;
    
    public float TimerSwitch;

    [Header ("GeneralProcess")]
    public BossBodyPart head;
    public int Health;

    [Header("HeadMovement")]
    public Transform A;
    public Transform B;

    public float moveSpeed;

    private Transform current;
    private Transform target;

    private float sinTime;


    // Start is called before the first frame update
    void Start()
    {
        current = A;
            target = B;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        CheckHP();
        HeadMovement();
        Health = head.HP;
    }

    public void HeadMovement()
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
        TimerSwitch += Time.deltaTime;
      
        if (TimerSwitch > 2)
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

                if (TimerSwitch > 3f)
                {
                    TimerSwitch = 0;
                    Shot2.SetActive(false);
                    Shot1.SetActive(false);
                   ShotProcess = false;
                }
            
            
        }
    }

    public void CheckHP()
    {
        if(Health <= 0)
        {
            isDead();
            gameObject.SetActive(false);    
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
