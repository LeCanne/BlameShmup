using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ElecticBarrier : MonoBehaviour, InterfaceEnemy
{
    public GameObject electricBarrier;
    public LayerMask layer;
    public float timer;
    public float speed;
    public int randomDir;
    private bool checkWall;
    private float randomTime;
    public bool vulnerable;
    public int health;
    public int score;
    public float maxScale;

    private FlashEnemy flashEnemy;
    // Start is called before the first frame update
    void Start()
    {
        randomDir = Random.Range(1, 3);
        randomTime = Random.Range(1f, 3f);
        flashEnemy = GetComponent<FlashEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        Move();
        CheckHP();
    }

    public void Move()
    {
        if(timer < randomTime)
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        else
        {
            if(checkWall == false)
            {
                if (randomDir == 1)
                {


                    transform.Translate(new Vector3(speed * Time.deltaTime, 0));
                }
                else
                {
                    transform.Translate(new Vector3(-speed * Time.deltaTime, 0));
                }
            }
            else
            {
                if (electricBarrier.transform.localScale.y < maxScale)
                {
                    electricBarrier.transform.localScale += new Vector3(0, 20 * Time.deltaTime, 0);
                }
            }
           
        }

        if (Physics2D.Raycast(transform.position, transform.right, 1f, layer) || Physics2D.Raycast(transform.position, -transform.right, 1f, layer))
        {
            
            checkWall = true;
            electricBarrier.SetActive(true);
            vulnerable = true;
           
            
        }

        
    }
    
    
    public void CheckHP()
    {
        if (health <= 0)
        {
            isDead();
            ScreenShaker.screenshaker.cameraShake(0.3f, 1f);
            ControllerRumble.controllerrumble.Rumble(0.4f, 0.7f, 0.2f);
            ScoreManager.Score += score;
            gameObject.SetActive(false);
          
            
        }

        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(vulnerable == true)
        {
            if (other.gameObject.tag == "PlayerBullet")
            {
                health--;
                flashEnemy.CallDamageFlash();
                Destroy(other.gameObject);
            }
        }
       
    }

    public bool isDead()
    {
        if(health <= 0)
        {
            return true;
           

        }
        else
            return false;
    }
}
