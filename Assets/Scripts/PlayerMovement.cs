using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public bool alive = true;
    public TimeManager timeManager;
    private Rigidbody2D rb;
    private SpriteRenderer SpriteRend;
    public AudioSource dash;
    public AudioSource damage;
    public SpriteRenderer Wheels, arm;
    public bool onleft = true;
    public Transform left, right;
    public int PlayerHealth;
    public float cooldown, timerBlink;
    public bool keepDamage;
    public float timerdamage;
    public GameObject shooter;
    public GameObject particle1, particle2;
    public float timer;
    private float inputY;
    private Collider2D collisiontoget;
    public LayerMask layerMask;
    public LayerMask collidWalls;
    public TMP_Text textdone;
    public Animator animIcon;
    float distanceLeft;
    float distanceRight;
    private RaycastHit2D hit1, hit2;
    private bool gothit, changeBlink;
        
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRend = GetComponent<SpriteRenderer>();
        collisiontoget = GetComponent<CircleCollider2D>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {





     
        if ((inputY >= 0 && hit1.collider == null) || (inputY <= 0 && hit2.collider == null))
        {
            if(inputY != 0)
            {
                rb.MovePosition(rb.position + new Vector2(0, inputY) * speed * Time.fixedDeltaTime);
            }
               
            
        }
         
        
          

        
       
       
       
           
        
        





       
    }

    private void Update()
    {
        hit1 = Physics2D.Raycast(transform.position, transform.up,  1f, collidWalls);
        hit2 = Physics2D.Raycast(transform.position, -transform.up, 1f, collidWalls);
        inputY = Input.GetAxisRaw("Vertical");
        textdone.text = PlayerHealth.ToString("x 00");
        if(alive == true)
        {
            Grapple();
            CheckHealth();
            Invincibility();
            timer += Time.deltaTime;
        }
        else
        {
            transform.Rotate(0, 0, -50 * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, -20, 0), 1 * Time.deltaTime);
            collisiontoget.enabled = false;
        }
        
    }

    public void Grapple()
    {

       
       
        if ((Input.GetButtonDown("Fire2") && cooldown <= 0))
        {
            dash.Play();
            distanceRight = 1;
            distanceLeft = 1;
            onleft = !onleft;
            cooldown = 0.5f;
            particle1.transform.localPosition = -particle1.transform.localPosition;
            particle2.transform.localPosition = new Vector3(-particle2.transform.localPosition.x, particle2.transform.localPosition.y);
           
           

        }
        if (onleft == true && distanceLeft > 0.5f)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right, 20, layerMask);
            distanceLeft = Vector3.Distance(new Vector2(transform.position.x, 0), new Vector2(hit.point.x, 0));
           
          if(hit.collider != null)
            {
                if (hit.collider.gameObject?.tag == "Wall")
                {
                    


                    SpriteRend.flipX = false;
                    arm.flipY = false;
                    Wheels.flipX = false;
                    shooter.transform.localPosition = new Vector3(0.0554f, shooter.transform.localPosition.y, shooter.transform.localPosition.z);
                    transform.position = Vector3.Lerp(transform.position, new Vector3(hit.point.x + 0.1f, hit.point.y), Time.deltaTime / 0.05f);
                    gameObject.transform.parent = hit.collider.gameObject.transform;
                }
            }
                
            
            
           
        }

        if (onleft == false && distanceRight > 0.5f)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 20, layerMask);
            distanceRight = Vector3.Distance(new Vector2(transform.position.x, 0), new Vector2(hit.point.x, 0));
            if (hit.collider != null)
            {


                if (hit.collider.gameObject?.tag == "Wall")
                {
                   

                    SpriteRend.flipX = true;
                    arm.flipY = true;
                    Wheels.flipX = true;
                    shooter.transform.localPosition = new Vector3(-0.0554f, shooter.transform.localPosition.y, shooter.transform.localPosition.z);
                    transform.position = Vector3.Lerp(transform.position, new Vector3(hit.point.x - 0.1f, hit.point.y), Time.deltaTime / 0.05f);
                    gameObject.transform.parent = hit.collider.gameObject.transform;
                }
            }
           
        }

        else
        {
            cooldown -= Time.deltaTime;
        }

       
        //if (onleft == true && wow > 0.1f)
        //{
        //    transform.position = Vector3.Lerp(transform.position, left.position, Time.deltaTime / 0.05f);
        //    SpriteRend.flipX = false;
        //    arm.flipY = false;
        //    Wheels.flipX = false;
        //    shooter.transform.localPosition = new Vector3(0.0554f, shooter.transform.localPosition.y, shooter.transform.localPosition.z);
        //}
        //if (onleft == false & waw > 0.1f)
        //{

        //    transform.position = Vector3.Lerp(transform.position, right.position, Time.deltaTime / 0.05f);
        //    SpriteRend.flipX = true;
        //    Wheels.flipX = true;
        //    arm.flipY = true;
        //    shooter.transform.localPosition = new Vector3(-0.0554f, shooter.transform.localPosition.y, shooter.transform.localPosition.z);
        //}

        
    }
            
        
       
      



    public void CheckHealth()
    {
        if (PlayerHealth <= 0)
        {
            gameObject.transform.parent = null;
            alive = false;
            timeManager.lost = true;

            Color alpha = SpriteRend.color;
            PlayerHealth = 0;
            alpha.a = 1f;
            SpriteRend.color = alpha;
            Wheels.color = alpha;
            arm.color = alpha;
            //gameObject.SetActive(false);

        }

        //Damage over time

        
    }
    public void Invincibility()
    {
        if(timer < 0 )
        {
            if(gothit == false && PlayerHealth > 0)
            {
                PlayerHealth--;
                gothit = true;
            }

            timerBlink += Time.deltaTime;

            if(timerBlink > 0.05f)
            {
                changeBlink = !changeBlink;

                if(changeBlink == true)
                {
                   
                    Color alpha = SpriteRend.color;
                    animIcon.Play("Life_hurt");
                    alpha.a = 0.1f;
                    SpriteRend.color = alpha;
                    Wheels.color = alpha;
                    arm.color = alpha;
                }
                
                if(changeBlink == false)
                {
                    Color alpha = SpriteRend.color;
                    animIcon.Play("Life_hurt");
                    alpha.a = 1f;
                    SpriteRend.color = alpha;
                    Wheels.color = alpha;
                    arm.color = alpha;
                }
               
              

                gameObject.layer = 6;

                timerBlink = 0;
            }
           
        }
        else
        {
            gothit = false;
            animIcon.Play("Life_idle");
            Color alpha =  SpriteRend.color;
            alpha.a = 1f;
            SpriteRend.color = alpha;
            Wheels.color = alpha;
            arm.color = alpha;
            gameObject.layer = 2;
                
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
            PlayerHealth--;
            Destroy(collision.gameObject);

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
            
            timer = -1f;
            damage.Play();
            Destroy(collision.gameObject);
            if(Gamepad.current != null)
            {
                ControllerRumble.controllerrumble.Rumble(0.5f, 1, 1);
            }
         
            
        }

        if (collision.gameObject.tag == "TimeDamage")
        {
           
            timer = -1f;
            damage.Play();


        }

        if (collision.gameObject.tag == "DEATH")
        {
           
            PlayerHealth = 0;
            timer = -1f;
            damage.Play();


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
