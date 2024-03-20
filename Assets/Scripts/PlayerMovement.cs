using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
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
        Grapple();
        CheckHealth();
    }

    public void Grapple()
    {
        if ((Input.GetButtonDown("Fire2") && cooldown <= 0))
        {
            onleft = !onleft;
            cooldown = 0.5f;
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
            Destroy(gameObject);
        }

        //Damage over time

        timerdamage += Time.deltaTime;
        if (timerdamage > 2 && keepDamage == true)
        {
            PlayerHealth--;
            timerdamage = 0;
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
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "TimeDamage")
        {
            keepDamage = true;

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
