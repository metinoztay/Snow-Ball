using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D rb;
    private GameObject coinsObject;
    [SerializeField] private float ballSpeed;
    [SerializeField] private float destroyTimer;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up*ballSpeed;
        coinsObject = GameObject.Find("Coins");
        Destroy(gameObject,destroyTimer);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "SnowBall"){
            coinsObject.GetComponent<CoinScript>().AddGold();
        }
    }

}
