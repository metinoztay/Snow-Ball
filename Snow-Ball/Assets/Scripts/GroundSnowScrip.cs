using System.Collections;
using System.Collections.Generic;
 using UnityEngine.UI;
using UnityEngine;

public class GroundSnowScrip : MonoBehaviour
{
    [SerializeField] private GameObject[] groundSnowPrefabs;
    [SerializeField] private List<GameObject> touchingGroundPoints;
    
     private void Awake() {
        int random = Random.Range(0,groundSnowPrefabs.Length);
        Instantiate(groundSnowPrefabs[random],transform.position,transform.rotation,transform);
        foreach (var touchingGroundPoint in GameObject.FindGameObjectsWithTag("GroundSnowPoint"))
        {
            touchingGroundPoints.Add(touchingGroundPoint);
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
        int index = touchingGroundPoints.IndexOf(gameObject);
        bool left = Random.Range(0,2) == 0;
        if (left && index > 0 && !touchingGroundPoints[index-1].GetComponentInChildren<Image>().enabled)
        {
            touchingGroundPoints[index-1].GetComponentInChildren<Image>().enabled = true;
        }
        else if(index < touchingGroundPoints.Count-1 && !touchingGroundPoints[index+1].GetComponentInChildren<Image>().enabled)
        {
            touchingGroundPoints[index+1].GetComponentInChildren<Image>().enabled = true;
        }
        

    }
   
    
}
