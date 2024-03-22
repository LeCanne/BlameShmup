using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private bool alive = true;
    public TimeManager timeManager;
    private Rigidbody2D rb;
    private SpriteRenderer SpriteRend;
    public AudioSource dash;
    public AudioSource damage;
    public SpriteRenderer Wheels, arm;
    public bool onleft = true;
    public Transform left, right;
    public int PlayerHealth;
    public float cooldown;
    public bool keepDamage;
    public float timerdamage;
    public GameObject shooter;
    public GameObject particle1, particle2;
    public float timer;
    private Collider2D collider;
    public TMP_Text textdone;
    public Animator animIcon;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRend = GetComponent<SpriteRenderer>();
        collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float inputY = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + new Vector2(0, inputY) * speed * Time.fixedDeltaTime);





       
    }

    private void Update()
    {
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
            collider.enabled = false;
        }
        
    }

    public void Grapple()
    {
        if ((Input.GetButtonDown("Fire2") && cooldown <= 0))
        {
            dash.Play();
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
            arm.flipY = false;
            Wheels.flipX = false;
            shooter.transform.localPosition = new Vector3(0.0554f, shooter.transform.localPosition.y, shooter.transform.localPosition.z);
        }
        if (onleft == false & waw > 0.1f)
        {

            transform.position = Vector3.Lerp(transform.position, right.position, Time.deltaTime / 0.05f);
            SpriteRend.flipX = true;
            Wheels.flipX = true;
            arm.flipY = true;
            shooter.transform.localPosition = new Vector3(-0.0554f, shooter.transform.localPosition.y, shooter.transform.localPosition.z);
        }
    }
            
        
       
      



    public void CheckHealth()
    {
        if (PlayerHealth <= 0)
        {
            alive = false;
            timeManager.lost = true;
            //gameObject.SetActive(false);
            
        }

        //Damage over time

        
    }
    public void Invincibility()
    {
        if(timer < 0)
        {
            
            Color alpha = SpriteRend.color;
            animIcon.Play("Life_hurt");
            alpha.a = 0.5f;
            SpriteRend.color = alpha;
            Wheels.color = alpha;
            
            gameObject.layer = 6;
        }
        else
        {
            animIcon.Play("Life_idle");
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
             PlayerHealth--;
            timer = -1f;
            damage.Play();
            Destroy(collision.gameObject);
            ControllerRumble.controllerrumble.Rumble(0.5f, 1, 1);
            
        }

        if (collision.gameObject.tag == "TimeDamage")
        {
            PlayerHealth--;
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
