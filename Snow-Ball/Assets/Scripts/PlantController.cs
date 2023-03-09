using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantController : MonoBehaviour
{
    
    [SerializeField] public int plantCount;
    [SerializeField] public int maxPlantCount;

    [Space]
    [SerializeField] private List<GameObject> groundSnowFields;

    private void Start() {
        Invoke("GetGroundSnowFields",1f);
    }

    private void GetGroundSnowFields(){
        GameObject plantPoint;
        for (int i = 0; i < 5; i++)
        {
            plantPoint = transform.GetChild(i).gameObject;
            groundSnowFields.Add(plantPoint.transform.GetChild(1).gameObject);
        }
    }
    public void GroundControl(){
        bool isSnowed;
        foreach (GameObject field in groundSnowFields)
        {
            isSnowed = field.GetComponent<SpriteRenderer>().enabled;
            if (!isSnowed)
            {
                return;
            }
        }
        GameManager.Instance.UpdateGameState(GameManager.GameState.Lose);
    }

    //? Eski Script
    /*
    public void ChangeGroundSnowPoint(int index){
        if (index==0)
            groundSnowFields[1].GetComponent<SpriteRenderer>().enabled = true;
        else if (index==4)
            groundSnowFields[3].GetComponent<SpriteRenderer>().enabled = true;
        else
        {
            int random = Random.Range(0,2);

            if(random == 0 && groundSnowFields[index-1].GetComponent<SpriteRenderer>().enabled)
                random = 1;
            
            if (random == 1 && groundSnowFields[index+1].GetComponent<SpriteRenderer>().enabled)
                random = 0;

            if (random == 0)
            {
                groundSnowFields[index-1].GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                groundSnowFields[index+1].GetComponent<SpriteRenderer>().enabled = true;
            }
        }     
    }
    */
    public void ChangeGroundSnowPoint(int index, int indexRange){
        bool goLeft;
        bool isEnabledLeft = true;
        bool isEnabledRight = true;

        if (index - indexRange < 0)
        {
            isEnabledLeft = true;
            isEnabledRight = groundSnowFields[index+indexRange].GetComponent<SpriteRenderer>().enabled;
            goLeft = false;
        }
        else if (index + indexRange > 4)
        {
            isEnabledRight = true;
            isEnabledLeft = groundSnowFields[index-indexRange].GetComponent<SpriteRenderer>().enabled;
            goLeft = true;
        }
        else
        {
            isEnabledLeft = groundSnowFields[index-indexRange].GetComponent<SpriteRenderer>().enabled;
            isEnabledRight = groundSnowFields[index+indexRange].GetComponent<SpriteRenderer>().enabled; 
            goLeft = Random.Range(0,2) == 0;
        }
           
        
        if (isEnabledLeft && isEnabledRight)
        {
            ChangeGroundSnowPoint(index, indexRange+1);
        }
        else if (isEnabledLeft && !isEnabledRight)
        {
            groundSnowFields[index+indexRange].GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (!isEnabledLeft && isEnabledRight)
        {
            groundSnowFields[index-indexRange].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            if (goLeft)
            {
                groundSnowFields[index-indexRange].GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                groundSnowFields[index+indexRange].GetComponent<SpriteRenderer>().enabled = true;
            }
        }

    }
}
