using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    public float speed = 4.5f;

    // Update is called once per frame
    void Update()
    {
        // Moves the bullet along the screen
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroies the bullet once it has collided with another Game Object
        Destroy(gameObject);
    }
}
