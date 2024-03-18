using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public bool onleft = true;
    public Transform left, right;
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
}
