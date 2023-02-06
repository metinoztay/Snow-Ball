using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SnowBallMovement : MonoBehaviour
{
    [SerializeField] private float gravity;
    [SerializeField] private float horSpeed;
    [SerializeField] private TextMeshProUGUI snowSize;

    private void Start()
    {
        DirectionSelector();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "MainCamera":
                ChangeDirection();
                break;
            case "Flame":
                snowSize.SetText((int.Parse(snowSize.text) - 1).ToString());
                if (int.Parse(snowSize.text) - 1 == 0)
                {
                    Destroy(gameObject);
                }                
                break;
            case "Grass":
                Destroy(gameObject);
                break;

            default:
                break;
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

    private void DirectionSelector()
    {
        bool left = Random.Range(0, 2) == 1;
        if (left)
        {
            ChangeDirection();
        }
    }
}
