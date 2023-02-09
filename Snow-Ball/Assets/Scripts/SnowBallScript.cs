using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SnowBallScript : MonoBehaviour
{
    [SerializeField] private GameObject[] karlanma;
    [SerializeField] private float gravity;
    [SerializeField] private float horSpeed;
    [SerializeField] private TextMeshProUGUI snowSize;
    [SerializeField] private bool isMove;

    private void Start()
    {
        isMove = true;
        DirectionSelector();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "MainCamera":
                ChangeDirection();
                break;
            case "Ball":
                snowSize.SetText((int.Parse(snowSize.text) - 1).ToString());
                Destroy(other.gameObject);
                if (int.Parse(snowSize.text) <= 0)
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
        if (isMove)
        {
            Move();
        }
        
    }

    private void Move()
    {

        Vector3 position = transform.position;
        
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
