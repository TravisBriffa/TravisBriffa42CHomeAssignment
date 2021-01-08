using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaths : MonoBehaviour
{
    
    [SerializeField] float carMoveSpeed = 2f;

    WaveConfig waveConfig;
     
    List<Transform> waypoints = new List<Transform>();

    int waypointIndex = 0; 

    
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        
        transform.position = waypoints[waypointIndex].transform.position;
    }

    
    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        
        if (waypointIndex <= waypoints.Count -1) 
        {

            var targetPosition = waypoints[waypointIndex].transform.position;

            targetPosition.z = 0f;

            var enemyMovement = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;

            
            
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemyMovement);
            if (transform.position == targetPosition)
            {
                waypointIndex++; 
            }
        }
        else 
        {
            
            Destroy(gameObject);

        }
    }
    
    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }
}
    