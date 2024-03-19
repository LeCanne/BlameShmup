using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public bool onleft = true;
    public Transform left, right;
    public int PlayerHealth;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        float inputY = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + new Vector2(0, inputY) * speed * Time.deltaTime);



        Grapple();
        CheckHealth();
    }

    public void Grapple()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            onleft = !onleft;
        }


            if(onleft == true && transform.position != left.position)
            {
              transform.position = Vector3.Lerp(transform.position, left.position, Time.deltaTime / 0.05f);
            }
            if(onleft == false & transform.position != right.position)
            {
              transform.position = Vector3.Lerp(transform.position, right.position,  Time.deltaTime / 0.05f);
            }
        
    }

    public void CheckHealth()
    {
        if(PlayerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            PlayerHealth--;
            Destroy(collision);
        }
    }
}
