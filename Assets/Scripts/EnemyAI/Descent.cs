using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Descent : MonoBehaviour
{
    public float time;
    public float speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      rb.MovePosition(rb.position + new Vector2(0, speed * Time.deltaTime));
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time > 10)
        {
            Destroy(gameObject);
        }
    }
}
