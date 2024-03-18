using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
   
    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;

    [Header("Spawner Attributes")]
    [SerializeField] private float firingRate;

    private GameObject spawnedBullet;
    public float timer = 0f;
    private PlayerMovement playermovement;
    // Start is called before the first frame update
    void Start()
    {
        playermovement = FindAnyObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= firingRate)
        {
            Fire();
            timer = 0;
        }

        Vector3 dir = playermovement.transform.position -transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Debug.Log(playermovement);
    }

    private void Fire()
    {
        if (bullet)
        {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Bullet>().speed = speed;
            spawnedBullet.GetComponent<Bullet>().bulletlife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;


        }

    }
}
