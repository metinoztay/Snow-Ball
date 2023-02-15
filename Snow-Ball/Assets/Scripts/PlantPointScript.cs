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
    
    [SerializeField] Animator animator;
    
    private void Awake() {
        animator = GetComponent<Animator>();
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
        foreach (GameObject field in isSnowedFields)
        {
            if (!field.GetComponent<GroundSnowScript>().isSnowed)
            {
                return false;
            }
        }

        return true;
    }

    public void CollectFall(){        
        bool left = Random.Range(0, 2) == 1;
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
