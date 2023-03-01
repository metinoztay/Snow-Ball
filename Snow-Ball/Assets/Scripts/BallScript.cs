using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class BallScript : MonoBehaviour
{
    [SerializeField] public int level;

    public Queue<GameObject> ballsQueue;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "SnowBall" || other.tag == "MainCamera")
        {
            ballsQueue.Enqueue(gameObject);
            gameObject.SetActive(false);
        }
        
    }


}
