using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    //the enemy
    [SerializeField] GameObject enemyPrefab;

    //the path on which to go
    [SerializeField] GameObject pathPrefab;

    //time between each enemy spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;

    //include this random time difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;

    //number of enemies in the wave/group
    [SerializeField] int numberOfEnemies = 5;

    //enemy movement speed
    [SerializeField] float enemyMoveSpeed = 2f;

    /* By default all elements (variables, properties and methods) in a script have the 
     * private access modifier. This is the most secure access modifier since the elements can
     * only be accessed within the same script.
     * The above variables, will be left private since once a script has access to them, 
     * mistakes can be made and their values may be wrongly changed.
     * Instead of giving full access to the variables, we will create getter methods (below)
     * which will only return the value which is needed (without having access to the variable)
     * Basically, we are setting these variables as READ ONLY.
     */

    /*getter methods
     * These methods need to be set as public so that they can be accessed by other scripts and
     * thus, retrieve (read) the required value from the needed variable.
     * Since they will be returning values, we need to indicate the return type in the method
     * definition.
    */
    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }
    /*public GameObject GetPathPrefab()
    {
        return pathPrefab;
    }*/

    /* Instead of returning the whole path prefab, we are opening the path prefab here and 
     * returning the list of waypoints instead - by going through each child of the path
     * prefab and placing it in a normal list.
     */
    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();

        /* a foreach loop is used to traverse a collection and go through the items one by one
         * The syntax is foreach item (type of item and give it a temp name) in collection
         */
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
