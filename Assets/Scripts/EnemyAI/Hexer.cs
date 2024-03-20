using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Hexer : MonoBehaviour
{
    public float speed;
    bool initate;
    public GameObject[] Shooters;
    private Transform centerPos;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        centerPos = GameObject.FindWithTag("Center").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
        Attack();
        Move();
    }

    public void Attack()
    {
        timer += Time.deltaTime;
        if(timer > 2)
        {
            if(initate == false)
            {
                
                foreach (GameObject objec in Shooters)
                {
                    objec.SetActive(true);
                }
                initate = true;
            }
           
        }
       
    }

    public void Move()
    {
        if (timer < 2)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector2(centerPos.transform.position.x, centerPos.transform.position.y), 10 * Time.deltaTime);
        }
    }
}
