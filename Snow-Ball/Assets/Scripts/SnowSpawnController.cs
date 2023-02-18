using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SnowSpawnController : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] snowPrefabs;
    [SerializeField] private int totalSnowAmount;
    [SerializeField] private int maxSnowAmount;
    [SerializeField] private int minSnowAmount;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnDelay;
    [SerializeField] public bool startSnow;


    
    private int _ds=0;
    public int destroyedSnowCount
    {
        get { return _ds; }
        set { _ds = value; 
                if (totalSnowAmount == destroyedSnowCount)
                {
                    GameManager.Instance.UpdateGameState(GameManager.GameState.Win);
                }
            }
    }
    
    
    int spawnAmount = 0;
    int lastSnowPrefab=-1;
    int lastSpawnPoint=-1;
    int lastSnowAmount=-1;

    private void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnDelay);
    }

    private void Spawn()
    {
        if (startSnow)
        {
            int randomSnow = RandomUniqueNumber(0, snowPrefabs.Length, lastSnowPrefab,false);
            int randomSpawnPoint = RandomUniqueNumber(0,spawnPoints.Length, lastSpawnPoint,false);
            int randomAmount = RandomUniqueNumber(minSnowAmount,maxSnowAmount,lastSnowAmount,true);
            if (spawnAmount == totalSnowAmount)
            {
                startSnow =false;
                return;
            }
            

            GameObject newSnow = Instantiate(snowPrefabs[randomSnow],spawnPoints[randomSpawnPoint].transform);
            newSnow.GetComponent<SnowBallScript>().snowSize = randomAmount;

            spawnAmount += randomAmount;
            lastSnowPrefab = randomSnow;
            lastSpawnPoint = randomSpawnPoint;
            lastSnowAmount = randomAmount;
        }       

    }

    private int RandomUniqueNumber(int min , int max, int last, bool control)
    {
        if (max == min)
        {
            return min;
        }
        else if(max < min)
        {
            return -1;
        }

        int random = Random.Range(min,max);        
        if(random == last)
        {
            random++;
            if (random > max)
            {
                random=min;
            }
        }

        if (control)
        {   
            int diff = totalSnowAmount - spawnAmount;

            if (diff <= random)
            {   
                return diff;
            }
        }

        return random;
    }
}
