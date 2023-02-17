using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private GameObject collectedCoinPrefab;
    [SerializeField] private Transform coinsTarget;
    [SerializeField] private TMP_Text coinUIText;

    [SerializeField] private int addCoinAmount;
    Vector3 targetPosition;

    [Space]
    [Header ("Available coins: (Coins to collect)")]
    [SerializeField] private int maxCoins;
    Queue<GameObject> coinsQueue = new Queue<GameObject>();

    [Space]
    [Header ("Animation Settings")]
    [SerializeField] [Range(0.5f,0.9f)] float minAnimationDuration;
    [SerializeField] [Range(0.9f,2f)] float maxAnimationDuration;

    [SerializeField] Ease easeType;

   
    private int c;
    public int Coins
    {
        get { return c; }
        set { c = value; 
              coinUIText.text = Coins.ToString();
                }
    }
    

    private void Awake() {
        targetPosition = coinsTarget.position;

        PrepareCoins();
    }

    private void PrepareCoins(){

        for (int i = 0; i < maxCoins; i++)
        {
            GameObject coin;
            coin = Instantiate(collectedCoinPrefab);
            coin.transform.parent = transform;
            coin.SetActive(false);
            coinsQueue.Enqueue(coin);
        }
    }

    private void Animate(Vector3 collectedCoinPosition){
       for (int i = 0; i < addCoinAmount; i++)
       {
            if (coinsQueue.Count>0)
            {
                GameObject coin = coinsQueue.Dequeue(); 
                coin.SetActive(true);
                coin.transform.position = collectedCoinPosition;

                float duration = Random.Range(minAnimationDuration,maxAnimationDuration);
                coin.transform.DOMove(targetPosition,duration)
                    .SetEase(easeType)
                    .OnComplete(()=>{
                        coin.SetActive(false);
                        coinsQueue.Enqueue(coin);

                        Coins++;
                    }
                    );
            }        
       }
    }

    public void AddCoins(Vector3 collectedCoinPosition){
        Animate(collectedCoinPosition);
    }





}
