using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState
    {
        SPAWNING,
        WAITING,
        COUNTING
    };

    [Serializable]
    public class Wave
    {
        public string name; //name of the wave
        public Transform enemy; //prefab of the enemy we are spawning 
        public int count; //the number of enemies spawned per wave
        public float spawnRate; //spawn rate, pretty self explanatory

    }

    //array of waves you can edit in the Editor:
    public Wave[] waves;
    //time between waves in seconds
    public float timeBetweenWaves = 5f;
    //this is going to be private after
    public float waveCountDown;

    
    //the index of the next wave
    private int nextWave = 0;
    //spawn state
    private SpawnState state = SpawnState.COUNTING;

    private float searchCountdown = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        waveCountDown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            //check if enemies are still alive: 
            if (!EnemyIsAlive())
            {
                //begin a new round
                Debug.Log("wave completed");
            }
            else
            {
                return; 
            }
        }
        
        if (waveCountDown <= 0) //if time to start spawning waves 
        {
            //check if we have already started spawning 
            if (state != SpawnState.SPAWNING)
            {
                //start spawning waves
                //since SpawnWave returns an IEnumerator, you need to call this
                //function that does the enumerating for us:
                StartCoroutine(SpawnWave(waves[nextWave])); 
            } 
        }
        else
        {
            waveCountDown -= Time.deltaTime; //waits to spawn zombies until counts down to 0
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Zombie") == null)
            {
                return false;
            }
        }
        return true; 
    }
    
    IEnumerator SpawnWave(Wave givenWave)
    {
        Debug.Log("Spawning wave: " + givenWave.name);
        state = SpawnState.SPAWNING;
        
        //Spawn enemies here:
        for (int i = 0; i < givenWave.count; i++)
        {
            SpawnEnemy(givenWave.enemy);
            yield return new WaitForSeconds(1f / givenWave.spawnRate);
        }

        state = SpawnState.WAITING; //we wait for the player to kill off all the enemies 
        
        yield break; // this is to make sure that it returns smth for IEnumerator
    }

    void SpawnEnemy(Transform givenEnemy)
    {
        //Spawn enemy
        Debug.Log("Spawn Enemy: " + givenEnemy.name);
        Instantiate(givenEnemy, transform.position, transform.rotation);
    }
}
