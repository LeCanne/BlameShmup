using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private SpriteRenderer SpriteRend;
    public bool onleft = true;
    public Transform left, right;
    public int PlayerHealth;
    public bool keepDamage;
    public float timerdamage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        float inputY = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + new Vector2(0, inputY) * speed * Time.fixedDeltaTime);





        Grapple();
        CheckHealth();
    }

    public void Grapple()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            onleft = !onleft;
        }


        if (onleft == true && transform.position != left.position)
        {
            transform.position = Vector3.Lerp(transform.position, left.position, Time.deltaTime / 0.05f);
            SpriteRend.flipX = false;
        }
        if (onleft == false & transform.position != right.position)
        {

            transform.position = Vector3.Lerp(transform.position, right.position, Time.deltaTime / 0.05f);
            SpriteRend.flipX = true;
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
