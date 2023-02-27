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

    private int _cv=1;
    public int coinsValue
    {
        get { return _cv; }
        set { _cv = value;}
    }
    

    private int c;
    public int coins
    {
        get { return c; }
        set { c = value; 
              coinUIText.text = coins.ToString();
            }
    }

    private void Awake() {
        targetPosition = coinsTarget.position;
        LoadPlayerSaves();
        PrepareCoins();
    }    

    private void Start() {
        
        coinUIText.text = coins.ToString();
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
                        coins+=coinsValue;
                        PlayerPrefs.SetInt(nameof(coins),coins);
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
        PlayerPrefs.SetInt(nameof(coinsValue),coinsValue);
    }

    private void LoadPlayerSaves(){
        coinsValue = PlayerPrefs.GetInt(nameof(coinsValue));
        coins = PlayerPrefs.GetInt(nameof(coins));
        
        if(coinsValue == 0)
            coinsValue = 1;
        
    }

}
