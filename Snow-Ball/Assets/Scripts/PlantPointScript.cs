using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantPointScript : MonoBehaviour
{
    [SerializeField] private Transform grossPoint;
    [SerializeField] private float grossAmount;
    [SerializeField] public List<GameObject> isSnowedFields;
    
    private int maxPlantCount;
    [SerializeField] public int plantCount;
    [SerializeField] public bool isGross;



    
    private void OnTriggerEnter2D(Collider2D other) {
        GetPlantCount();
        if (other.tag=="Water")
        {  
            Destroy(other.gameObject); 
            if (!isSnowed())
            {
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

    private bool isSnowed(){
        foreach (GameObject field in isSnowedFields)
        {
            if (!field.GetComponent<GroundSnowScript>().isSnowed)
            {
                return false;
            }
        }

        return true;
    }

}
