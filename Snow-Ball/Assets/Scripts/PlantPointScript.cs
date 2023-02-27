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
    
    private int maxPlantCount;
    [SerializeField] public int plantCount;
    [SerializeField] public bool isGross;

    private void Start() {
        GroundSnowInstantiate();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GetPlantCount();
        if (other.tag=="Water")
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
        else if (other.tag == "SnowBall")
        {   
            other.GetComponent<SnowBallScript>().DestroySnow();
            if (groundSnowField.GetComponent<SpriteRenderer>().enabled)
            {
                int index = transform.GetSiblingIndex();
                GetComponentInParent<PlantController>().ChangeGroundSnowPoint(index);
            }
            else
            {
                groundSnowField.GetComponent<SpriteRenderer>().enabled = true;
            }
            GetComponentInParent<PlantController>().GroundControl();
        }
    }
    private void GetPlantCount(){
        plantCount = GetComponentInParent<PlantController>().plantCount;
        maxPlantCount = GetComponentInParent<PlantController>().maxPlantCount;
    }

    private void AddNewPlant(){
        bool midControl = GetComponentInChildren<Animator>().isActiveAndEnabled;
        if (!isGross && midControl)
        {
            GetComponentInParent<PlantController>().plantCount++;
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
