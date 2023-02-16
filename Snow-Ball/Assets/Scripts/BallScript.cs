using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D rb;    
    [SerializeField] private float ballSpeed;
    [SerializeField] private float destroyTimer;

    [SerializeField] private GameObject destroyParticle;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up*ballSpeed;
        Destroy(gameObject,destroyTimer);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "SnowBall")
        {
            Debug.Log("Destroy");
            GameObject explosion = Instantiate(destroyParticle,transform.position,transform.rotation);
            Destroy(explosion,0.75f);
        }
    }
}
