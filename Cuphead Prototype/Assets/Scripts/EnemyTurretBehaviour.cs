using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretBehaviour : MonoBehaviour
{
    public PickupBehaviour Pickup;
    public float range;

    public Transform target;

    public bool Detected = false;

    Vector2 Direction;

    public GameObject Gun;
    public GameObject turretBullet;

    public float FireRate;

    float nextTimeToShoot = 0;

    public Transform shootPoint;

    public float Force;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = target.position;

        // Calculates where it should shoot based on the position of the player
        Direction = targetPos - (Vector2)transform.position;

        // Sets up a raycast to detect the player
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, range);

        if (rayInfo)
        {

            // if the player is detected set detected to true
            if(rayInfo.collider.gameObject.name == "hero")
            {
                if(Detected == false)
                {
                    Detected = true;
                }
            }
            else
            {

                if (Detected == true)
                {
                    Detected = false;
                }

            }
        }

        if (Detected)
        {
            // Change the direction of the shot if the player is detected
            Gun.transform.up = Direction;

            // Calls the shoot mechanic if allowed by the time contraint 
            if(Time.time > nextTimeToShoot)
            {
                nextTimeToShoot = Time.time + 1 / FireRate;
                shoot();
            }
        }
    }

    void shoot()
    {
        // create a game object using the bullet prefab 
        GameObject BulletIns = Instantiate(turretBullet, shootPoint.position, Quaternion.identity);

        // fire the bullet towards the player
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Bullet")
        {
            // create the pick ups when the enemy is destroyed 
            Instantiate(Pickup, transform.position, transform.rotation);
            Instantiate(Pickup, transform.position, transform.rotation);
            Instantiate(Pickup, transform.position, transform.rotation);
            Instantiate(Pickup, transform.position, transform.rotation);

            // Destroy the Turret when it has been hit by a bullet
            Destroy(gameObject);

        }


    }
}
