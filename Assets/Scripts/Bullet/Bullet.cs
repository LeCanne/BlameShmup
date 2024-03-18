using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletlife = 1f;
    public float rotation = 0f;
    public float speed = 1f;
    // Start is called before the first frame update
    private Vector2 spawnpoint;
    private float timer = 0f;
    void Start()
    {
        spawnpoint = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > bulletlife) Destroy(this.gameObject);
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }

    private Vector2 Movement(float timer)
    {
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        return new Vector2(x+spawnpoint.x, y+spawnpoint.y);
    }
}
