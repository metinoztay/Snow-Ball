using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class TimeControllerSnowScript : MonoBehaviour
{
    [SerializeField] public PathCreator pathCreator;
    [SerializeField] private float speed;
    private float distanceTravelled;
    [SerializeField] private GameObject waterExpolisonParticle;
    [SerializeField] private GameObject frostExplosionParticle;
    AudioController audioController;
    [SerializeField] private float freezeTime;
    AudioSource audioSource;
    

    private SpriteRenderer spriteRenderer;
    
    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioController = FindAnyObjectByType<AudioController>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
       Move();
        
    }

    private void Move(){
        distanceTravelled += speed*Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
    }
   
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ball") && gameObject.CompareTag("TimeSnowBall"))
        {
            other.GetComponent<BallScript>().ResetBall();
            StartCoroutine(SlowTheTime());
        }
        else if(other.tag=="PlantPoint")
        {
            if (Time.timeScale!=1)
            {
                StartCoroutine(DestroyTimer());
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }

    IEnumerator SlowTheTime(){
        gameObject.tag = "Untagged";
        audioController.playTimeFreezeMusic();
        audioSource.Play();
        GameObject explosion = Instantiate(frostExplosionParticle,transform);
        GameObject waterExplosion = Instantiate(waterExpolisonParticle,transform.position,transform.rotation);
        explosion.transform.parent = waterExplosion.transform;
        spriteRenderer.enabled=false;   
        Destroy(explosion,0.75f);        
        Destroy(waterExplosion,0.75f); 
        Time.timeScale = 0.4f;
        yield return new WaitForSecondsRealtime(freezeTime);
        Time.timeScale = 1f;
        audioController.playGameMusic();
        Destroy(gameObject);
    }

    IEnumerator DestroyTimer(){
        yield return new WaitForSecondsRealtime(freezeTime+1);
        Destroy(gameObject);
    }


}

