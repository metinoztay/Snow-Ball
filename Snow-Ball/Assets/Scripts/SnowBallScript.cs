using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SnowBallScript : MonoBehaviour
{
    [SerializeField] private float gravity;
    [SerializeField] private float horSpeed;
    [SerializeField] private TextMeshProUGUI snowSize;
    [SerializeField] private bool isMove;
    [SerializeField] private GameObject waterPrefab;

    [SerializeField] private GameObject waterExpolisonParticle;
    [SerializeField] private GameObject ballExplosionParticle;

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
                BallCrash(other);
                break;
            case "Grass":
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

    private void BallCrash(Collider2D other){
        int ballLevel = other.GetComponent<BallScript>().level;
        snowSize.SetText((int.Parse(snowSize.text) - ballLevel).ToString());
        Destroy(other.gameObject);
        GameObject explosion = Instantiate(ballExplosionParticle,transform);
        Destroy(explosion,0.75f); 
                
        if (int.Parse(snowSize.text) <= 0)
        {   
            Instantiate(waterPrefab,transform.position,transform.rotation,GameObject.Find("SnowCanvas").transform);
            GameObject waterExplosion = Instantiate(waterExpolisonParticle,transform.position,transform.rotation);
            explosion.transform.parent = waterExplosion.transform;   
                    
            Destroy(gameObject);
            Destroy(waterExplosion,0.75f);                    
                    
        }      
    }
}
