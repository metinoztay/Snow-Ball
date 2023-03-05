using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using PathCreation;

public class SnowController : MonoBehaviour
{
    [SerializeField] private PathCreator[] paths;
    [SerializeField] private GameObject[] snowPrefabs;
    [SerializeField] private GameObject timeControllerSnowPrefab;
    bool isTimeControllerSnowSpawned;
    [SerializeField] private GameObject progressBar;
    [SerializeField] private int totalSnowAmount;
    [SerializeField] private int maxSnowAmount;
    [SerializeField] private int minSnowAmount;
    [SerializeField] private float spawnDelay;
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
    
    Coroutine spawnCoroutine;
    int randomSnow;
    int randomPath;
    int randomAmount;    
    int spawnedAmount = 0;
    int lastSnowPrefab=-1;
    int lastSnowAmount=-1;
    int lastPath=-1;

    private void Start()
    {
        progressBar.GetComponent<ProgressBarScript>().maxValue = totalSnowAmount;
    }

    public void StartSpawn(){
        spawnCoroutine = StartCoroutine(Spawn());
    }

    public void StopSpawn(){
        StopCoroutine(spawnCoroutine);
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            randomSnow = RandomUniqueNumber(0, snowPrefabs.Length, lastSnowPrefab,false);
            randomPath = RandomUniqueNumber(0,paths.Length,lastPath, false);
            randomAmount = RandomUniqueNumber(minSnowAmount,maxSnowAmount+1,lastSnowAmount,true);
            if (spawnedAmount == totalSnowAmount)
            {
                StopSpawn();
                break;
            }
            
            if (!isTimeControllerSnowSpawned && spawnedAmount > totalSnowAmount/2)
            {
                TimeControllerSnowSpawn();
                yield return new WaitForSecondsRealtime(spawnDelay);
                continue;
            }

            GameObject newSnow = Instantiate(snowPrefabs[randomSnow],transform);
            newSnow.GetComponent<SnowBallScript>().pathCreator = paths[randomPath];
            newSnow.GetComponent<SnowBallScript>().snowSize = randomAmount;            

            spawnedAmount += randomAmount;
            lastSnowPrefab = randomSnow;
            lastSnowAmount = randomAmount;
            lastPath = randomPath;

            yield return new WaitForSecondsRealtime(spawnDelay);
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
            if (random >= max)
            {
                random=min;
            }
        }

        if (control)
        {   
            int diff = totalSnowAmount - spawnedAmount;

            if (diff <= random)
            {   
                return diff;
            }
        }

        return random;
    }

    public void DestroyedSnow(int size){
        destroyedSnowCount += size;
        progressBar.GetComponent<ProgressBarScript>().IncrementProgress(size);
    }

    private void TimeControllerSnowSpawn(){
        GameObject newSnow = Instantiate(timeControllerSnowPrefab,transform);
        newSnow.GetComponent<TimeControllerSnowScript>().pathCreator = paths[randomPath];
        isTimeControllerSnowSpawned = true;
    }
}
