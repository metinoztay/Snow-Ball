using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    [SerializeField] public int plantCount;
    [SerializeField] public int maxPlantCount;

    [Space]
    [SerializeField] private List<GameObject> groundSnowFields;

    private void Start() {
        GetGroundSnowFields();
    }

    private void GetGroundSnowFields(){
          foreach (GameObject field in GameObject.FindGameObjectsWithTag("GroundSnow"))
          {
               groundSnowFields.Add(field);
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

    public void ChangeGroundSnowPoint(int index){
        if (index==0)
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        else if (index==4)
            transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = true;
        else
        {
            int random = Random.Range(0,2);

            if(random == 0 && transform.GetChild(index-1).GetComponent<SpriteRenderer>().enabled)
                random = 1;
            
            if (random == 1 && transform.GetChild(index+1).GetComponent<SpriteRenderer>().enabled)
                random = 0;

            if (random == 0)
            {
                transform.GetChild(index-1).GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                transform.GetChild(index+1).GetComponent<SpriteRenderer>().enabled = true;
            }
        }      

    }

}
