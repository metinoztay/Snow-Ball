using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    
    [SerializeField] private float verSpeed;
    private GameObject coins;

    private void Start()
    {
        coins = GameObject.Find("Coins");
    }
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SnowBall")
        {
            coins.GetComponent<CoinScript>().AddGold();
        }
    }


    private void Move()
    {
        Vector2 position = transform.position;

        position.y += verSpeed * Time.deltaTime;

        transform.position = position;
    }
}
