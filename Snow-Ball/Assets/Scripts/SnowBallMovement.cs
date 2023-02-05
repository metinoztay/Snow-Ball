using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnowBallMovement : MonoBehaviour
{
    [SerializeField] private float gravity;
    [SerializeField] private float horSpeed;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sky") 
        {
            Debug.Log("Edge");
            ChangeDirection();
        }
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 position = transform.position;
        
        position.x += horSpeed*Time.deltaTime;
        position.y -= gravity*Time.deltaTime;

        transform.position = position;

    }
   
    private void ChangeDirection()
    {
        horSpeed *= -1;
        
    }
}
