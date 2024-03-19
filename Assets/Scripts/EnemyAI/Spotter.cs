using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spotter : MonoBehaviour, InterfaceEnemy
{
    public BulletSpawner spawner, one,two;
    public Transform playerPos;
    public float timerbullet;
    public int healthPoint;
    public bool newPos = true, firstcheck = true;
    private Vector3 newposition;
    public float distance = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
      
        timerbullet += Time.deltaTime;
        Vector3 v = transform.position;
        if (firstcheck == true)
        {
            newposition = playerPos.transform.position;
            firstcheck = false;
            distance = 1;
        }
        
            distance = Vector3.Distance(new Vector3(0, newposition.y, 0), new Vector3(0, transform.position.y, 0));


        if (playerPos != null)
        {
            if (timerbullet >= 2)
            {
                spawner.enabled = false;
                if (newPos == true)
                {
                    newposition = playerPos.transform.position;
                    newPos = false;
                    distance = 1;

                }
                transform.position = Vector3.Lerp(v, new Vector3(v.x, newposition.y, v.z), Time.deltaTime / 0.2f);

                if (distance < 0.5f)
                {
                    if (playerPos.transform.position.x > transform.position.x)
                    {
                        spawner = one;

                    }
                    else
                    {
                        spawner = two;
                    }
                    spawner.enabled = true;
                    newPos = true;
                    firstcheck=true;
                    timerbullet = 0;
                   
                    
                    
                    
                }

            }

           
         
           
        }
       
    }

    public bool isDead()
    {
        if (healthPoint <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
