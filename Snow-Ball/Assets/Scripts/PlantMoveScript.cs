using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantMoveScript : MonoBehaviour
{
    [SerializeField] private Transform grossPoint;
    [SerializeField] private float grossSpeed;

    
    void Update()
    {
        Gross();
    }


    private void Gross()
    {
        Vector3 current = transform.position;
        var newCurrent = Mathf.Lerp(current.y,grossPoint.position.y,Time.deltaTime*grossSpeed);
        transform.position = new Vector3(current.x,newCurrent,current.z);
    }
}
