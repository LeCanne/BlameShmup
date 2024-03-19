using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ElecticBarrier : MonoBehaviour
{
    public GameObject electricBarrier;
    public float timer;
    public float speed;
    public int randomDir;
    private bool checkWall;
    private float randomTime;
    // Start is called before the first frame update
    void Start()
    {
        randomDir = Random.Range(1, 3);
        randomTime = Random.Range(1f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        Move();
    }

    public void Move()
    {
        if(timer < randomTime)
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        else
        {
            if(checkWall == false)
            {
                if (randomDir == 1)
                {


                    transform.Translate(new Vector3(speed * Time.deltaTime, 0));
                }
                else
                {
                    transform.Translate(new Vector3(-speed * Time.deltaTime, 0));
                }
            }
           
           
        }
        
        if (Physics2D.Raycast(transform.position, transform.right, 1f))
        {
            
            checkWall = true;
            electricBarrier.SetActive(true);
        }

        if (Physics2D.Raycast(transform.position, -transform.right, 1f))
        {
            checkWall = true;
            electricBarrier.SetActive(true);
        }
    }
}
