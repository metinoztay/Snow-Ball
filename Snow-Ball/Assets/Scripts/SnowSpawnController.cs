using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using PathCreation;

public class SnowSpawnController : MonoBehaviour
{
    [SerializeField] private PathCreator[] paths;
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
                Debug.Log(destroyedSnowCount);
                if (totalSnowAmount == destroyedSnowCount)
                {
                    GameManager.Instance.UpdateGameState(GameManager.GameState.Win);
                }
            }
    }
    
    
    int spawnAmount = 0;
    int lastSnowPrefab=-1;
    int lastSnowAmount=-1;
    int lastPath=-1;

    private void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnDelay);
    }

    private void Spawn()
    {
        if (startSnow)
        {
            int randomSnow = RandomUniqueNumber(0, snowPrefabs.Length, lastSnowPrefab,false);
            int randomPath = RandomUniqueNumber(0,paths.Length,lastPath, false);
            int randomAmount = RandomUniqueNumber(minSnowAmount,maxSnowAmount,lastSnowAmount,true);
            if (spawnAmount == totalSnowAmount)
            {
                startSnow = false;
                return;
            }
            

            GameObject newSnow = Instantiate(snowPrefabs[randomSnow],transform);
            newSnow.GetComponent<SnowBallScript>().snowSize = randomAmount;
            newSnow.GetComponent<SnowBallScript>().pathCreator = paths[randomPath];

            spawnAmount += randomAmount;
            lastSnowPrefab = randomSnow;
            lastSnowAmount = randomAmount;
            lastPath = randomPath;
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
