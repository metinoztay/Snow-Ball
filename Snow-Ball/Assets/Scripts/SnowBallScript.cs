using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using PathCreation;

public class SnowBallScript : MonoBehaviour
{  
    
    [SerializeField] public PathCreator pathCreator;
    [SerializeField] private float speed;
    private float distanceTravelled;
   
    [SerializeField] public bool isMove;
    [SerializeField] private TMP_Text snowSizeText;
    [SerializeField] private GameObject waterPrefab;

    [SerializeField] private GameObject waterExpolisonParticle;
    [SerializeField] private GameObject ballExplosionParticle;

    private int snowStartSize;
    private int _ss;
    public int snowSize
    {
        get { return _ss; }
        set { _ss = value; 
            snowSizeText.text = snowSize.ToString();
        }
    }
    

    private void Start()
    {
        snowStartSize = snowSize;
        isMove = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ball"){
            BallCrash(other);
        }
    }

    void Update()
    {
        Move();
        
    }

    private void Move(){
        distanceTravelled += speed*Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
    }
   

    private void BallCrash(Collider2D other){
        int ballLevel = other.GetComponent<BallScript>().level;
        snowSize -= ballLevel;
        Destroy(other.gameObject);
        GameObject explosion = Instantiate(ballExplosionParticle,transform);
        Destroy(explosion,0.75f); 
                
        if (snowSize <= 0)
        {   
            Instantiate(waterPrefab,transform.position,transform.rotation,GameObject.Find("SnowCanvas").transform);
            GameObject waterExplosion = Instantiate(waterExpolisonParticle,transform.position,transform.rotation);
            explosion.transform.parent = waterExplosion.transform;   

            DestroySnow();
            Destroy(waterExplosion,0.75f);                    
                    
        }      
    }

    public void DestroySnow() {
        GetComponentInParent<SnowSpawnController>().destroyedSnowCount += snowStartSize;
        Destroy(gameObject);
    }
}
