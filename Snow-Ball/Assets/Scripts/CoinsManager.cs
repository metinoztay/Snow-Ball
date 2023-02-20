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

    [SerializeField] public int maxCoinValue;
    Vector3 targetPosition;
    
    private int _cv;
    public int coinsValue
    {
        get { return _cv; }
        set { _cv = value; 
            Debug.Log(coinsValue);
        }
    }
    

    [Space]
    [Header ("Available coins: (Coins to collect)")]
    [SerializeField] private int maxCoins;
    Queue<GameObject> coinsQueue = new Queue<GameObject>();

    [Space]
    [Header ("Animation Settings")]
    [SerializeField] private GameObject coinExplosion;
    [SerializeField] [Range(0.5f,0.9f)] float minAnimationDuration;
    [SerializeField] [Range(0.9f,2f)] float maxAnimationDuration;
    [SerializeField] Ease easeType;
    [SerializeField] private float spread;

   
    private int c=100;
    public int Coins
    {
        get { return c; }
        set { c = value; 
              coinUIText.text = Coins.ToString();
                }
    }
    

    private void Awake() {
        targetPosition = coinsTarget.position;
        coinUIText.text = Coins.ToString();
        coinsValue=1;
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
                coin.transform.position = collectedCoinPosition + new Vector3(Random.Range(-spread,+spread),0f,0f);
                Instantiate(coinExplosion,coin.transform.position,coin.transform.rotation,transform);

                float duration = Random.Range(minAnimationDuration,maxAnimationDuration);
                coin.transform.DOMove(targetPosition,duration)
                    .SetEase(easeType)
                    .OnComplete(()=>{
                        coin.SetActive(false);
                        coinsQueue.Enqueue(coin);
                        Instantiate(coinExplosion,coinsTarget.position,coinsTarget.rotation,transform);
                        Coins+=coinsValue;
                    }
                );
            }        
       }
    }

    public void AddCoins(Vector3 collectedCoinPosition){
         Animate(collectedCoinPosition);
    }

    public void CoinsValueUp(){
        coinsValue *= 2;
    }
}
