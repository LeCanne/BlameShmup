using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBreaker : MonoBehaviour
{
    public bool EnemyBreaker = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(EnemyBreaker == false)
        {
            if (collision.gameObject.tag == "PlayerBullet")
            {
                Destroy(collision.gameObject);
            }
        }
        else
        {
            if (collision.gameObject.tag == "EnemyBullet")
            {
                Destroy(collision.gameObject);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
