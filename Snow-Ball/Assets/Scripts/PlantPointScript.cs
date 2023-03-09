using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantPointScript : MonoBehaviour
{
    [SerializeField] private GameObject[] groundSnowPrefabs;
    [SerializeField] private Transform grossPoint;
    [SerializeField] private float grossAmount;
    public GameObject groundSnowField;

    [SerializeField] PlantController plantController;
    
    private int maxPlantCount;
    [SerializeField] public int plantCount;
    [SerializeField] public bool isGross;

    private void Start() {
        GroundSnowInstantiate();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GetPlantCount();
        if (other.CompareTag("Water"))
        {  
            Destroy(other.gameObject); 
            if (!IsSnowed())
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
        else if (other.CompareTag("SnowBall"))
        {   
            other.GetComponent<SnowBallScript>().DestroySnow();
            if (groundSnowField.GetComponent<SpriteRenderer>().enabled)
            {
                int index = transform.GetSiblingIndex();
                plantController.ChangeGroundSnowPoint(index,1);
            }
            else
            {
                groundSnowField.GetComponent<SpriteRenderer>().enabled = true;
            }
            plantController.GroundControl();
        }
    }
    private void GetPlantCount(){
        plantCount = plantController.plantCount;
        maxPlantCount = plantController.maxPlantCount;
    }

    private void AddNewPlant(){
        bool midControl = GetComponentInChildren<Animator>().isActiveAndEnabled;
        if (!isGross && midControl)
        {
            plantController.plantCount++;
            isGross = true;
        }        
    }

    private void Gross(){
        Vector3 current = grossPoint.position;
        grossPoint.position = new Vector3(current.x,current.y+grossAmount,current.z);
    }

    private bool IsSnowed(){
        return groundSnowField.GetComponent<SpriteRenderer>().enabled;
    }

    private void GroundSnowInstantiate(){
        int random = Random.Range(0,groundSnowPrefabs.Length);
        groundSnowField = Instantiate(groundSnowPrefabs[random],transform.position,transform.rotation,transform);
        groundSnowField.GetComponent<SpriteRenderer>().enabled = false;
    }
}
