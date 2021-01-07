using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;

    List<Transform> waypoints = new List<Transform>();// a collection to store different waypoints
    //set in Unity. These waypoints will represent the path that the enemy needs to move along.

    int waypointIndex = 0; // used to keep track of the current point we are working with. The index is the 
    //position of the current waypoint.

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        /* Setting the current enemy to be located on the first waypoint in the list.
         * Different properties are fetched from their components. Our list is made up of just Transform components
         * so each item is a trasform component, thus, waypoints[waypointIndex] will be translated to transform.
         * That way, we just call the position property from this current transform. 
         */
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        //checking if there are any more points in the list
        if (waypointIndex < waypoints.Count) // if(waypointIndex <= waypoints.Count - 1)
        {
            float movementThisFrame = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            // making the enemy movement frame independent
            Vector3 targetPosition = waypoints[waypointIndex].position;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++; // waypointIndex = waypointIndex + 1;
            }
        }
        else // there are no more waypoints left in the list (all of them have been traversed)
        {
            /* The keyword gameObject refers to the object which has this current script attached to it. Therefore,
             * we will be destroying the current enemy which has reached the end of the path.
             */
            Destroy(gameObject);
        }
    }
    /* This method is required since different enemies are part of different waves so whenever a new enemy
     * is cloned, this method will be called to set the wave for this enemy. It is vital that the Wave is
     * set properly since the path on which this current enemy will move is found within the wave.
     * This method has been declared as public since it needs to be called from OUTSIDE this script.
     * A parameter is also required since the value of the wave will be different for different groups of 
     * enemies AND the value of the correspoiding wave cannot be accessed from this script ( so we need it
     * as input).
     */
    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }
}
    