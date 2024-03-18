using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NormalBug : MonoBehaviour
{
    public BulletSpawner bulletSpawner;
    Vector2 startPos;
    public float attacktimer;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpawner.enabled = false;
        startPos.x = transform.position.x;
        bulletSpawner.timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Shake();
        Move();
        Attack();
    }

    private void Move()
    {
        transform.Translate(new Vector3(0, 1 * Time.deltaTime, 0));
    }

    private void Attack()
    {
        attacktimer += Time.deltaTime;
        if(attacktimer > 2f && attacktimer < 5f)
        {
          
            bulletSpawner.enabled = true;
        }
        else if (attacktimer > 5f)
        {
            bulletSpawner.enabled = false;
            attacktimer = 0f;
            bulletSpawner.timer = 0;

        }
    }

    public void Shake()
    {
        var speed = 20f; //how fast it shakes
        var amount = 0.2f; //how much it shakes
        Vector3 transformed = transform.position;
       
            transformed.x = startPos.x + Mathf.Sin(Time.time * speed) * amount;
        
        transform.position = transformed;
    }
}
