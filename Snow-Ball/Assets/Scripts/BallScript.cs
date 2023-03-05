using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] public int level;

    public Queue<GameObject> ballsQueue;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("SnowBall") || other.CompareTag("TimeSnowBall"))
        {
            ResetBall();
        }
        else if(other.CompareTag("PlantPoint"))
        {
           GetComponentInParent<ComboCounter>().comboCount = 0;
        }
    } 

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("MainCamera"))
        {
            ResetBall();
        }
    }

    public void ResetBall(){
        ballsQueue.Enqueue(gameObject);
        gameObject.SetActive(false);
    }


}
