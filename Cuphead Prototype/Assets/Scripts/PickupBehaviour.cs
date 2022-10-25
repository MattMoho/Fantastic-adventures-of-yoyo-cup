using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Player")
            {
            // Add 1 to the counter when this is collected and then destroy the object
                Counter.rubbish += 1;
                Destroy(gameObject);
            }

        
    }

}
