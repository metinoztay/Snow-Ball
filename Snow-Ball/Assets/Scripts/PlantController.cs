using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    [SerializeField] public int plantCount;
    [SerializeField] public int maxPlantCount;

    [SerializeField] private List<GameObject> groundSnowPoints;
    [SerializeField] private List<GameObject> plantPoints;

   private void Awake() {
        plantCount = 0;

        foreach (var groundSnowPoint in GameObject.FindGameObjectsWithTag("GroundSnowPoint"))
         {
              
               groundSnowPoints.Add(groundSnowPoint);
         }

       foreach (var plantPoint in GameObject.FindGameObjectsWithTag("PlantPoint"))
         {
              plantPoints.Add(plantPoint);
         }
   }

   private void Start() {
     int field = groundSnowPoints.Count / plantPoints.Count;
     for (int i = 0; i < plantPoints.Count; i++)
     {    
          for (int j = 0; j < field; j++)
          {   
               plantPoints[i].GetComponent<PlantPointScript>().isSnowedField=(groundSnowPoints[i]);
               
          }
     }
   }
}
