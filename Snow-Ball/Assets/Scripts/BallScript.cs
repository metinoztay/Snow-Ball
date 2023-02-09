using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float ballSpeed;
    [SerializeField] private float destroyTimer;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up*ballSpeed; 
        Destroy(gameObject,destroyTimer);
        
    }

}
