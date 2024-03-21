using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    private Vector3 mousePosition;
    public float projectileCooldown;
    private float timerProjectile;
    public GameObject bullet;
    private GameObject spawnedBullet;
    public GameObject mouseCursor, Cursor3D;

    [Header("bulletProperties")]
    public float speed;
    public float bulletLife;

    [Header("directionControllerSupport")]
    public Transform twistPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Aiming();
        Shooting();
    }


    public void Aiming()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if(Gamepad.current == null)
        {
            Vector3 dir = mousePosition - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            twistPoint.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            mouseCursor.SetActive(true);
            Cursor3D.SetActive(false);
        }
        else
        {
            Cursor3D.SetActive(true);
            mouseCursor.SetActive(false);
            float HorizonAxis = Input.GetAxis("HorizontalJoystick");
            float VerticalAxis = Input.GetAxis("VerticalJoystick");

           if(HorizonAxis == 0f && VerticalAxis == 0)
            {
                Vector3 currentRotation = twistPoint.transform.localEulerAngles;
                Vector3 homeRotation;

                if(currentRotation.z > 180f)
                {
                    homeRotation = new Vector3(0,0,359.999f);
                }
                else
                {
                    homeRotation = Vector3.zero;
                }

                twistPoint.transform.localEulerAngles = Vector3.Slerp(currentRotation, homeRotation, Time.deltaTime * 3);
            }

            else
            {

                twistPoint.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Atan2(HorizonAxis, VerticalAxis) * -190 / Mathf.PI + 90);
            }
        }
       

    }

    public void Shooting()
    {
        timerProjectile += Time.deltaTime;
        if (( Input.GetAxis("VerticalJoystick") != 0 || Input.GetAxis("HorizontalJoystick") != 0 || Input.GetButton("Fire1")) && projectileCooldown <= timerProjectile)
        {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Bullet>().speed = speed;
            spawnedBullet.GetComponent<Bullet>().bulletlife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
            timerProjectile = 0;
        }



    }
}
