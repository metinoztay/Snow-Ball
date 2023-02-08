using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SnowSpawnController : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] spawnObjects;
    [SerializeField] private int totalSnowAmount;
    [SerializeField] private int maxSnowAmount;
    [SerializeField] private bool stopSpawning = false;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnDelay;
    int spawnAmount = 0;
    int lastSnow=-1;
    int lastPoint=-1;

    private void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnDelay);
    }

    private void Spawn()
    {
        
        int randomSnow = Random.Range(0, spawnObjects.Length);
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        int randomAmount = Random.Range(0, maxSnowAmount);
        
        if ( spawnAmount+randomSnow + 1 > totalSnowAmount)
        {
            return;
        }

        randomSnow = MakeUnique(randomSnow, lastSnow, spawnObjects.Length);
        randSpawnPoint = MakeUnique(randSpawnPoint,lastPoint, spawnPoints.Length);
        randomAmount = MakeUnique(randomAmount, lastSnow, maxSnowAmount);

        Instantiate(spawnObjects[randomSnow], spawnPoints[randSpawnPoint]);
        spawnObjects[randomSnow].GetComponentInChildren<TextMeshProUGUI>().SetText((randomAmount + 1).ToString());

        spawnAmount += randomSnow + 1;
        lastSnow = randomSnow;
        lastPoint = randSpawnPoint;

        //if (stopSpawning)
        //    CancelInvoke("Spawn");

    }

    private int MakeUnique(int random,int last, int lenght)
    {
        int unique = random;

        if(random == last)
        {
            unique++;
        }

        if (unique == lenght)
        {
            unique = 0;
        }

        return unique;
    }


}
