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

    int bounce = 0;

    
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up*ballSpeed;
        Destroy(gameObject,destroyTimer);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "SnowBall")
        {
            //GameObject explosion = Instantiate(ballExplosionParticle,transform.position,transform.rotation,other.transform);  
            //Destroy(explosion,0.75f);
        }
        else if(other.tag == "MainCamera")
        {
            if (bounce == 0)
            {
                bounce++;                
            }else
            {
                Destroy(gameObject);
            }
        }
    }
}
