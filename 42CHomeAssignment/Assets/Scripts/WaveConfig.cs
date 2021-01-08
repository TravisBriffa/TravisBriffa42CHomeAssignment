﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    
    [SerializeField] GameObject enemyPrefab;

    
    [SerializeField] GameObject pathPrefab;

   
    [SerializeField] float timeBetweenSpawns = 0.5f;

    
    [SerializeField] float spawnRandomFactor = 0.3f;

    
    [SerializeField] int numberOfEnemies = 5;

    
    [SerializeField] float enemyMoveSpeed;


    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();

      
        foreach (Transform waypoint in pathPrefab.transform)
        {
            waypoints.Add(waypoint);
        }

        return waypoints;
    }
    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }
    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }
    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }
    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }

}
