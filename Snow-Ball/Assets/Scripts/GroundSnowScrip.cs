using System.Collections;
using System.Collections.Generic;
 using UnityEngine.UI;
using UnityEngine;

public class GroundSnowScrip : MonoBehaviour
{
    [SerializeField] GameObject[] groundSnowPrefabs;
    private void Awake() {
        int random = Random.Range(0,groundSnowPrefabs.Length);
        Instantiate(groundSnowPrefabs[random],transform.position,transform.rotation,transform);
    }
    private void Start() {
        GetComponentInChildren<Image>().enabled=false;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "SnowBall"){
             Destroy(other.gameObject);
             GetComponentInChildren<Image>().enabled=true;
        }
    }
    
}
