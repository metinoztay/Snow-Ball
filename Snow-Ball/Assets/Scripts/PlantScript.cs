using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    [SerializeField] private Transform grossPoint;
    [SerializeField] private Transform plantPoint;
    [SerializeField] private float grossSpeed;
    [SerializeField] private PlantController plantController;
    [SerializeField] private Animator cuttingLineAnimator;
    [SerializeField] private FallingAnimationController fallingAnimationController;
    [SerializeField] public bool collectable;

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
         if (other.transform == plantPoint)
        {
            collectable = false;
            gameObject.tag="Plant";
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.transform == plantPoint)
        {   
            collectable = true;
            gameObject.tag="Collectable";
            SetCuttingAnimatorActive();
        }
    }
    public void Collect(){
       
        grossPoint.transform.position = transform.position;
        fallingAnimationController.CollectFall();
         
        collectable = false;
        gameObject.tag="Plant";
        plantController.plantCount--;
        plantPoint.GetComponent<PlantPointScript>().isGross = false;
    }

    private void SetCuttingAnimatorActive(){
        bool isActive = cuttingLineAnimator.GetBool("Collect");
        if(isActive){
            Invoke("SetCuttingAnimatorActive",1);
        }
        else if(gameObject.tag == "Collectable")
        {
            cuttingLineAnimator.SetBool("Collect",true);
        }

    }
}