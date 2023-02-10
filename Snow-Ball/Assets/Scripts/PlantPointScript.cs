using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPointScript : MonoBehaviour
{
        [SerializeField] private Transform grossPoint;
        [SerializeField] private float grossAmount;
        private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="Water")
        {
             Destroy(other.gameObject);
             Vector3 current = grossPoint.position;
             grossPoint.position = new Vector3(current.x,current.y+grossAmount,current.z);
        }
       
    }

}
