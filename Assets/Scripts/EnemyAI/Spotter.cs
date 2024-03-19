using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spotter : MonoBehaviour
{
    public BulletSpawner spawner;
    public Transform playerPos;
    private float timerbullet;
    public bool newPos;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(newPos == true)
        {
            newPos = false;
        }
        timerbullet += Time.deltaTime;
        Vector3 v = transform.position;

        if(playerPos != null)
        {
            if (timerbullet >= 2)
            {
                transform.position = Vector3.Lerp(v, new Vector3(v.x, playerPos.transform.position.y, v.z), Time.deltaTime / 0.2f);

            }
            float distance = Vector3.Distance(new Vector3(0,playerPos.transform.position.y,0), new Vector3(0,transform.position.y,0));
           
            if (distance < 0.5f)
            {
                timerbullet = 0;
                newPos = true;
            }
        }
       
    }
}
