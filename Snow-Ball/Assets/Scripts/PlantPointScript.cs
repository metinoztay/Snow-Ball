using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantPointScript : MonoBehaviour
{
    [SerializeField] private Transform grossPoint;
    [SerializeField] private float grossAmount;
    [SerializeField] private GameObject cutPrefab;
    
    [SerializeField] private Transform cuttingLine;

    [SerializeField] public List<GameObject> isSnowedFields;
    
    private int maxPlantCount;

    private int plantCount;
    private bool isGross;

        
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
        else if(other.tag=="Hand")
        {
            Cut();
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

    [ContextMenu(nameof(Cut))]
    public void Cut(){
       for (int i = 0; i < 2; i++)
       {
        var current = gameObject.transform.GetChild(i).transform.position;
        current = new Vector3(current.x,cuttingLine.position.y,current.z);
        gameObject.transform.GetChild(i).transform.position = current;
       }
        
        Instantiate(cutPrefab,transform.position,transform.rotation,transform);

    }

}
