using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantPointScript : MonoBehaviour
{
    [SerializeField] private GameObject[] groundSnowPrefabs;
    [SerializeField] private Transform grossPoint;
    [SerializeField] private float grossAmount;
    private GameObject groundSnowField;
    
    private int maxPlantCount;
    [SerializeField] public int plantCount;
    [SerializeField] public bool isGross;
    
    [SerializeField] Animator animator;
    
    private void Awake() {
        animator = GetComponent<Animator>();
        int random = Random.Range(0,groundSnowPrefabs.Length);
        groundSnowField = Instantiate(groundSnowPrefabs[random],transform.position,transform.rotation,transform);
        groundSnowField.transform.SetParent(transform.parent);
        groundSnowField.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Update() {
       ResetPlant();
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
           
        }else if (other.tag == "SnowBall")
        {    
            Destroy(other.gameObject); 
            groundSnowField.GetComponent<SpriteRenderer>().enabled = true;
            GetComponentInParent<PlantController>().GroundControl();
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

    private bool IsSnowed(){
        return groundSnowField.GetComponent<SpriteRenderer>().enabled;
    }

    public void CollectFall(){        
        bool left = Random.Range(0, 2) == 1 ? true : false;
        if (left)
        {
            animator.SetTrigger("FallLeft");
        }
        else
        {
            animator.SetTrigger("FallRight");
        }
    }

    private void ResetPlant(){
        var currentAngle = transform.rotation.eulerAngles.z;
  
       if (Mathf.Approximately(90,currentAngle) || Mathf.Approximately(270,currentAngle))
       {
            for (int i = 0; i < 2; i++)
            {
                transform.GetChild(i).transform.position = transform.position;
            }
       }

    }
}
