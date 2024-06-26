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
    public AudioSource shootnoise;
    public PlayerMovement player;

    private bool inprocess;

    [Header("bulletProperties")]
    public float speed;
    public float bulletLife;

    [Header("directionControllerSupport")]
    public Transform twistPoint;
    public float inputDedZone;
    private Vector2 rightStickInput;
    private Vector2 inputexternalrightstick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.alive == true)
        {
            Aiming();
            Shooting();
        }
       
    }


    public void Aiming()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if(Gamepad.current == null)
        {
           
            Vector3 dir = mousePosition - transform.position;
            if(Mathf.Abs(dir.x) > 1f || Mathf.Abs(dir.y) > 1f)
            {
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                twistPoint.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                mouseCursor.SetActive(true);
                Cursor3D.SetActive(false);
            }
            
           
        }
        else
        {
            Cursor3D.SetActive(true);
            mouseCursor.SetActive(false);
            float HorizonAxis = inputexternalrightstick.y;
            float VerticalAxis = inputexternalrightstick.x;

            rightStickInput = new Vector2(HorizonAxis, VerticalAxis);
            if(rightStickInput.magnitude < inputDedZone)
            {
                rightStickInput = Vector2.zero;
            }
            else if (Mathf.Abs(HorizonAxis) > 0f || Mathf.Abs(VerticalAxis) > 0)
            {
                Vector3 moveVector = (Vector3.left * rightStickInput.x - Vector3.down * rightStickInput.y);

                twistPoint.transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);

            }
        }
       

    }

    public void Shooting()
    {
        timerProjectile += Time.deltaTime;
        if (rightStickInput.magnitude > inputDedZone || Gamepad.current == null)
        {
            if (( inprocess == true || rightStickInput.magnitude != 0) && projectileCooldown <= timerProjectile)
            {
                shootnoise.Play();
                spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                spawnedBullet.GetComponent<Bullet>().speed = speed;
                spawnedBullet.GetComponent<Bullet>().bulletlife = bulletLife;
                spawnedBullet.transform.rotation = transform.rotation;
                timerProjectile = 0;
            }
        }
           



    }

    public void ShootingV2(InputAction.CallbackContext shoot)
    {
        
        if (shoot.performed)
        {
            inprocess = true;
         
        }

        if (shoot.canceled)
        {
            inprocess = false;
        }
    }

    public void ShootAim(InputAction.CallbackContext aim)
    {
        inputexternalrightstick = aim.ReadValue<Vector2>();
    }
}
