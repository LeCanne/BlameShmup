using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NormalBug : MonoBehaviour, InterfaceEnemy
{
    public BulletSpawner bulletSpawner;
    Vector2 startPos;
    public float attacktimer;
    public int healthPoints;
    public float speed;
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
        CheckHP();
    }

    private void Move()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
    }

    private void Attack()
    {
       
       
          
            bulletSpawner.enabled = true;
        
        
    }

    public void Shake()
    {
        var speed = 20f; //how fast it shakes
        var amount = 0.2f; //how much it shakes
        Vector3 transformed = transform.position;
       
            transformed.x = startPos.x + Mathf.Sin(Time.time * speed) * amount;
        
        transform.position = transformed;
    }

    public void CheckHP()
    {
        if(healthPoints <= 0)
        {
            isDead();
            gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
       
        if(other.gameObject.tag == "PlayerBullet")
        {
            healthPoints--;
            Destroy(other.gameObject);
        }
    }

    public bool isDead()
    {
        if (healthPoints <= 0)
        {
            return true;
        }
        else
            return false;
    }
}
