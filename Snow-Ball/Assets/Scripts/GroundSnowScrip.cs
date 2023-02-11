using System.Collections;
using System.Collections.Generic;
 using UnityEngine.UI;
using UnityEngine;

public class GroundSnowScrip : MonoBehaviour
{
    [SerializeField] private GameObject[] groundSnowPrefabs;
    [SerializeField] private List<GameObject> groundSnowPoints;
    
     private void Awake() {
        int random = Random.Range(0,groundSnowPrefabs.Length);
        Instantiate(groundSnowPrefabs[random],transform.position,transform.rotation,transform);
        foreach (var groundSnowPoint in GameObject.FindGameObjectsWithTag("GroundSnowPoint"))
        {
            groundSnowPoints.Add(groundSnowPoint);
        }
        
    }
    private void Start() {
        GetComponentInChildren<Image>().enabled=false;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "SnowBall"){
             Destroy(other.gameObject);
             if(GetComponentInChildren<Image>().enabled){                
                ChangeSnowTouchingPoint();
             }
             else{
                GetComponentInChildren<Image>().enabled=true; 
             }
             
             
        }
    }

    private void ChangeSnowTouchingPoint(){
        int index = groundSnowPoints.IndexOf(gameObject);
        bool left = Random.Range(0,2) == 0;
        
       if (left && (index == 0 || groundSnowPoints[index-1].GetComponentInChildren<Image>().enabled))
        {
            left = !left;
        }
        else if(!left && (index == groundSnowPoints.Count-1 || groundSnowPoints[index+1].GetComponentInChildren<Image>().enabled))
        {
            left = !left;
        }

        if (left)
        {   Debug.Log("Sol");
            groundSnowPoints[index-1].GetComponentInChildren<Image>().enabled = true;
        }
        else
        {   Debug.Log("Sağ");
            groundSnowPoints[index+1].GetComponentInChildren<Image>().enabled = true;
        }
        

    }
   
    
}
