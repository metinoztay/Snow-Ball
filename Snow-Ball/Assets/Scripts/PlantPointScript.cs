using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPointScript : MonoBehaviour
{
    [SerializeField] private Transform grossPoint;
    [SerializeField] private float grossAmount;

    [SerializeField] public GameObject[] isSnowed = new GameObject[2];
    
    private int maxPlantCount;

     private int plantCount;
     private bool isGross;

        
    private void OnTriggerEnter2D(Collider2D other) {
        GetPlantCount();
        if (other.tag=="Water")
        {  
             Destroy(other.gameObject); 
            if (isGross)
            {
                Gross();
            }
            else if (plantCount < maxPlantCount)
            {
                AddNewPlant();
                Gross();
            }           
        }
              
    }

    private void GetPlantCount(){
        plantCount = GetComponentInParent<PlantController>().plantCount;
        maxPlantCount = GetComponentInParent<PlantController>().maxPlantCount;
    }

    private void AddNewPlant(){
        if (!isGross)
        {
            GetComponentInParent<PlantController>().plantCount++;
            isGross = true;
        }        
    }

    private void Gross(){
        Vector3 current = grossPoint.position;
        grossPoint.position = new Vector3(current.x,current.y+grossAmount,current.z);
    }

}
