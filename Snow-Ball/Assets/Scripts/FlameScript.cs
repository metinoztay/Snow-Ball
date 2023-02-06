using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameScript : MonoBehaviour
{
    
    [SerializeField] private float verSpeed;
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SnowBall" || collision.tag == "MainCamera")
        {
            Destroy(gameObject);
        }

    }
    

    private void Move()
    {
        Vector2 position = transform.position;

        position.y += verSpeed * Time.deltaTime;

        transform.position = position;
    }
}
