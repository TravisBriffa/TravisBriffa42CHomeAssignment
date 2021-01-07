using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
     * With regards to collisions there are 2 main built-in methods OnCollisionEnter2D() and
     * OnTriggerEnter2d(). These built in methods are called by the Unity compiler whenever the 
     * object that this script is controlling has its collider hit by another collider. So in this
     * case when the Shredder's collider gets hit by another collider.
     * The decision to call between OnCollision and OnTrigger depends on the Shredder's type of 
     * collider. OnCollisionEnter2D() is called if the default collider is used (the on trigger
     * property is unticked) and we will actually see the physical collision occur.
     * OnTriggerEnter2D() is called if a trigger collider is used (the on trigger property is 
     * ticked) and the physical collision won't be seen.
     */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // just for testing since we will be using the tigger collider
        print("Collision Hit!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* Destroy is a function which destroys objects or components.
         * The collision parameters give us information about the collision which has just 
         * occurred. This includes the other gameObject which hit our current object (Shredder).
         * The other object which can hit the Shredder is a laser and it is important to know 
         * which one since we only need to destroy those lasers which have already passed through
         * the shredder.
         */

        //print("Trigger Hit!");
        Destroy(collision.gameObject);
    }
}
