using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingAnimationController : MonoBehaviour
{
    Animator animator;
    
    private void Awake() {
        animator = GetComponent<Animator>(); 
    }

    private void Update() {
       ResetPlant();
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
