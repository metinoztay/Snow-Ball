using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSnowScript : MonoBehaviour
{

    [SerializeField] private GameObject waterExpolisonParticle;
    [SerializeField] private GameObject frostExplosionParticle;

    [SerializeField] private float freezeTime;

    private SpriteRenderer spriteRenderer;
    
    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="Ball" && gameObject.tag == "TimeSnowBall")
        {
            StartCoroutine(SlowTheTime());
        }
        else if(other.tag=="PlantPoint")
        {
            StartCoroutine(DestroyTimer());
        }
    }

    IEnumerator SlowTheTime(){
        gameObject.tag = "Untagged";
        GameObject explosion = Instantiate(frostExplosionParticle,transform);
        GameObject waterExplosion = Instantiate(waterExpolisonParticle,transform.position,transform.rotation);
        explosion.transform.parent = waterExplosion.transform;
        spriteRenderer.enabled=false;   
        Destroy(explosion,0.75f);        
        Destroy(waterExplosion,0.75f); 
        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(freezeTime);
        Time.timeScale = 1f;
        Destroy(gameObject);
    }

    IEnumerator DestroyTimer(){
        yield return new WaitForSecondsRealtime(freezeTime+1);
        Destroy(gameObject);
    }


}

