using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Variables
    [SerializeField] List<WaveConfig> waveConfig;
    [SerializeField] bool looping = false;
    int startWave = 0;
    int waveIndex;

    // This is called as the first frame of the image of the game
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(spawnAllWaves());
        } while (looping);
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {

            GameObject newEnemyClone = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].position, Quaternion.identity);
            newEnemyClone.GetComponent<EnemyPaths>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
    IEnumerator spawnAllWaves()
    {
        for (waveIndex = startWave; waveIndex < waveConfig.Count; waveIndex++)
        {
            WaveConfig currentWave = waveConfig[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    public int GetIndex()
    {
        return waveIndex;
    }
}
