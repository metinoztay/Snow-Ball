using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    [SerializeField] private Transform grossPoint;
    [SerializeField] private Transform plantPoint;
    [SerializeField] private float grossSpeed;
    [SerializeField] private GameObject plantController;

    [SerializeField] private GameObject cuttingLine;
    [SerializeField] bool collectable;

    private void Start() {
        collectable = false;    
    }
    void Update()
    {
        if (!collectable)
        {
            Gross();
        }  
    }
    private void Gross()
    {
        Vector3 current = transform.position;
        var newCurrent = Mathf.Lerp(current.y,grossPoint.position.y,Time.deltaTime*grossSpeed);
        transform.position = new Vector3(current.x,newCurrent,current.z);
    }

    private void OnTriggerStay2D(Collider2D other) {
         if (other.tag=="PlantPoint")
        {
           collectable = false;
           gameObject.tag="Plant";
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag=="PlantPoint")
        {
            collectable = true;
            gameObject.tag="Collectable";
        }
    }

    public void Collect(){
        grossPoint.position = plantPoint.position;
        transform.position = plantPoint.position;
         
        collectable = false;
        gameObject.tag="Plant";
        plantController.GetComponent<PlantController>().plantCount--;
        GetComponentInParent<PlantPointScript>().isGross = false;
    }
}