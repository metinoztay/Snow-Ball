using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    [SerializeField] public int plantCount;
    [SerializeField] public int maxPlantCount;

    [Space]
    [SerializeField] private List<GameObject> groundSnowFields;

    // ! Lose Control Yazılacak

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
            Debug.Log(isSnowed);
            if (!isSnowed)
            {
                return;
            }
        }

        GameManager.Instance.UpdateGameState(GameManager.GameState.Lose);
    }

}
