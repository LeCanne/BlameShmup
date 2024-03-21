using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private bool alive = true;
    public TimeManager timeManager;
    private Rigidbody2D rb;
    private SpriteRenderer SpriteRend;
    public SpriteRenderer Wheels;
    public bool onleft = true;
    public Transform left, right;
    public int PlayerHealth;
    public float cooldown;
    public bool keepDamage;
    public float timerdamage;
    public GameObject shooter;
    public GameObject particle1, particle2;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float inputY = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + new Vector2(0, inputY) * speed * Time.fixedDeltaTime);





       
    }

    private void Update()
    {
        if(alive == true)
        {
            Grapple();
            CheckHealth();
            Invincibility();
            timer += Time.deltaTime;
        }
        
    }

    public void Grapple()
    {
        if ((Input.GetButtonDown("Fire2") && cooldown <= 0))
        {
            onleft = !onleft;
            cooldown = 0.5f;
            particle1.transform.localPosition = -particle1.transform.localPosition;
            particle2.transform.localPosition = new Vector3(-particle2.transform.localPosition.x, particle2.transform.localPosition.y);
        }
        else
        {
            cooldown -= Time.deltaTime;
        }

        float wow = Vector3.Distance(new Vector2(transform.position.x,0), new Vector2(left.position.x,0));
        float waw = Vector3.Distance(new Vector2(transform.position.x, 0), new Vector2(right.position.x, 0));
        if (onleft == true && wow > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, left.position, Time.deltaTime / 0.05f);
            SpriteRend.flipX = false;
            Wheels.flipX = false;
            shooter.transform.localPosition = new Vector3(0.0554f, shooter.transform.localPosition.y, shooter.transform.localPosition.z);
        }
        if (onleft == false & waw > 0.1f)
        {

            transform.position = Vector3.Lerp(transform.position, right.position, Time.deltaTime / 0.05f);
            SpriteRend.flipX = true;
            Wheels.flipX = true;
            shooter.transform.localPosition = new Vector3(-0.0554f, shooter.transform.localPosition.y, shooter.transform.localPosition.z);
        }
    }
            
        
       
      



    public void CheckHealth()
    {
        if (PlayerHealth <= 0)
        {
            alive = false;
            timeManager.lost = true;
            gameObject.SetActive(false);
            
        }

        //Damage over time

        
    }
    public void Invincibility()
    {
        if(timer < 0)
        {
            
            Color alpha = SpriteRend.color;
            
            alpha.a = 0.5f;
            SpriteRend.color = alpha;
            Wheels.color = alpha;
            
            gameObject.layer = 6;
        }
        else
        {
           Color alpha =  SpriteRend.color;
            alpha.a = 1f;
            SpriteRend.color = alpha;
            Wheels.color = alpha;
            gameObject.layer = 0;
                
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            PlayerHealth--;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "TimeDamage")
        {
            keepDamage = true;

        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "TimeDamage")
        {
            keepDamage = false;

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
             PlayerHealth--;
            timer = -1f;
           
            Destroy(collision.gameObject);
            
        }

        if (collision.gameObject.tag == "TimeDamage")
        {
            PlayerHealth--;
            timer = -1f;


        }







    }
    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "TimeDamage")
        {
            keepDamage = false;

        }
    }
}
