using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantController : MonoBehaviour
{
    
    [SerializeField] public int plantCount;
    [SerializeField] public int maxPlantCount;

    [Space]

    [SerializeField] private List<SpriteRenderer> groundSnowSprites;
    [SerializeField] private List<GameObject> groundSnowFields;

    private void Start() {
        Invoke("GetGroundSnowFields",1f);
    }

    private void GetGroundSnowFields(){
        GameObject plantPoint;
        for (int i = 0; i < 5; i++)
        {
            plantPoint = transform.GetChild(i).gameObject;
            //?groundSnowFields.Add(plantPoint.transform.GetChild(1).gameObject); 
            groundSnowSprites.Add(plantPoint.transform.GetChild(1).GetComponent<SpriteRenderer>());
        }
    }
    public void GroundControl(){
        bool isSnowed;
        foreach (SpriteRenderer sprite in groundSnowSprites)
        {
            isSnowed = sprite.enabled;
            if (!isSnowed)
            {
                return;
            }
        }
        GameManager.Instance.UpdateGameState(GameManager.GameState.Lose);
    }

    public void ChangeGroundSnowPoint(int index, int indexRange){
        bool goLeft;
        bool isEnabledLeft = true;
        bool isEnabledRight = true;

        if (index - indexRange < 0)
        {
            isEnabledLeft = true;
            isEnabledRight = groundSnowSprites[index+indexRange].enabled;
            goLeft = false;
        }
        else if (index + indexRange > 4)
        {
            isEnabledRight = true;
            isEnabledLeft = groundSnowSprites[index-indexRange].enabled;
            goLeft = true;
        }
        else
        {
            isEnabledLeft = groundSnowSprites[index-indexRange].enabled;
            isEnabledRight = groundSnowSprites[index+indexRange].enabled; 
            goLeft = Random.Range(0,2) == 0;
        }
           
        
        if (isEnabledLeft && isEnabledRight)
        {
            ChangeGroundSnowPoint(index, indexRange+1);
        }
        else if (isEnabledLeft && !isEnabledRight)
        {
            groundSnowSprites[index+indexRange].enabled = true;
        }
        else if (!isEnabledLeft && isEnabledRight)
        {
            groundSnowSprites[index-indexRange].enabled = true;
        }
        else
        {
            if (goLeft)
            {
                groundSnowSprites[index-indexRange].enabled = true;
            }
            else
            {
                groundSnowSprites[index+indexRange].enabled = true;
            }
        }

    }
}
