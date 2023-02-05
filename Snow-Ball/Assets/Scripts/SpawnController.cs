using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] spawnObjects;
    [SerializeField] private int snowAmount;
    int spawnAmount = 0;
    int lastSnow;
    int lastPoint;



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            spawn();
        }
        
    }

    
    public void spawn()
    {
        int randomEnemy = Random.Range(0, spawnObjects.Length);
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        
        if ( spawnAmount+randomEnemy + 1 > snowAmount || randomEnemy == lastSnow || lastPoint == randSpawnPoint)
        {
            return;
        }

        Instantiate(spawnObjects[randomEnemy], spawnPoints[randSpawnPoint]);
        spawnAmount += randomEnemy + 1;
        lastSnow = randomEnemy;
        lastPoint = randSpawnPoint;


    }
}
