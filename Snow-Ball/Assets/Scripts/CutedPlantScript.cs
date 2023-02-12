using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutedPlantScript : MonoBehaviour
{
    [SerializeField] private Transform starBar;
    [SerializeField] private float speed;

    
    void Update()
    {
       Move();
    }

    void Move(){
        var current = transform.position;
        var currentX = Mathf.Lerp(current.x,starBar.position.x,speed*Time.deltaTime);
        var currentY = Mathf.Lerp(current.y,starBar.position.y,speed*Time.deltaTime);
        transform.position = new Vector3(currentX,currentY,current.z);
    }
}
