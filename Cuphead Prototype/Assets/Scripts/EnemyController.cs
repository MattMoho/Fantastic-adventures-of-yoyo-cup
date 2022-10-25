using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public PickupBehaviour Pickup;
    public float dirX;
    public float speed;
    private Rigidbody2D rb;
    private bool isFacingLeft = false;
    private Vector3 localScale;


    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = 1f;
        speed = 3f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // moves the enemmies
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Wall")
        {
            // if the enemy hits an invisable wall change the direction of it
            dirX *= -1;
        }
    }
}
