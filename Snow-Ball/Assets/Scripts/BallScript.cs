using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D rb;    
    [SerializeField] private float ballSpeed;
    [SerializeField] private float destroyTimer;

    [SerializeField] public int level;

    
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = transform.up*ballSpeed;
        rb.AddForce(transform.up*ballSpeed*50);
        Destroy(gameObject,destroyTimer);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "SnowBall")
        {
            //GameObject explosion = Instantiate(ballExplosionParticle,transform.position,transform.rotation,other.transform);  
            //Destroy(explosion,0.75f);
        }
    }
}
