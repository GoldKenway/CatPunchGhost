using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public enum SpawnState { spawning, waiting, counting };

    public GameObject Progress;
    // Start is called before the first frame update
    void Start()
    {
        waveCountdown = timeBetweenWaves;
        Progress = GameObject.FindWithTag("ProgressBar");
    }

    // Update is called once per frame
    void Update()
    {
        if (Progress.GetComponent<ProgressBar>().GetProgress() < Progress.GetComponent<ProgressBar>().slider.maxValue)
        {

            if (state == SpawnState.waiting)
            {
                //check if enemies are still alive
                if (!enemyIsAlive())
                {
                    //Begin a new round
                    WaveCompleted();
                    return;
                }
                else
                {
                    return;
                }

            }


            if (waveCountdown <= 0)
            {
                if (state != SpawnState.spawning)
                {
                    // Start spawning wave
                    StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }
    }

    void WaveCompleted ()
    {
        Debug.Log("Wave Completed!");
        state = SpawnState.counting;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = -1;
            Debug.Log("All waves complete! Looping...");
        }
        nextWave++;

    }
    bool enemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
        }

        

        return true;
    }



    // Defining what a wave is
    [System.Serializable]
    public class Wave
    {
        public string name;         //name of wave
        public Transform[] enemy;     //enemies
        //public int count;           //count of enemies
        public float rate;          //rate of which enemies spawn


    }

    public Wave[] waves;
    private int nextWave = 0;
    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f; 

    private SpawnState state = SpawnState.counting;


    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.spawning;

        //Spawn 
        for (int i = 0; i < _wave.enemy.Length; i++)
        {
            SpawnEnemy(_wave.enemy[i]);
            yield return new WaitForSeconds(1f / _wave.rate);

        }

        state = SpawnState.waiting;



        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        //Spawn enemy
        Debug.Log("Spawning Enemy: " + _enemy.name);

        Instantiate(_enemy, transform.position, transform.rotation);

    }

}
