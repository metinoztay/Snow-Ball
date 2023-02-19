using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject CannonBallObject;
    private int ballLevelUpCoin;

    [SerializeField] private Button ballLevelUpButton;
    [SerializeField] private Button speedUpButton;
    [SerializeField] private GameObject CoinsObject;

    int ballLevel, ballMaxLevel, ballNeedCoin;

    float fireSpeed , minDelay; 
    int speedNeedCoin;
    int coins;



    public void Start(){
        BallLevelUpControl();
        FireSpeedUpControl();
    }

    public void StartGame(){
        GameManager.Instance.UpdateGameState(GameManager.GameState.Start);
    }

    public void BallLevelUp(){
        CoinsObject.GetComponent<CoinsManager>().Coins -= ballNeedCoin;
        CannonBallObject.GetComponent<FireScript>().BallLevelUp();
        BallLevelUpControl();
    }

    private void BallLevelUpControl(){
        ballLevel = CannonBallObject.GetComponent<FireScript>().level;
        ballMaxLevel = CannonBallObject.GetComponent<FireScript>().maxLevel;
        ballNeedCoin = (int)(Mathf.Pow(2,(ballLevel-1))*10);
        coins = CoinsObject.GetComponent<CoinsManager>().Coins;

        if (ballLevel==ballMaxLevel || ballNeedCoin > coins)
        {
            ballLevelUpButton.interactable = false;
        }else
        {
            ballLevelUpButton.interactable = true;
        }
    }

    public void FireSpeedUp(){
        CoinsObject.GetComponent<CoinsManager>().Coins -= speedNeedCoin;
        CannonBallObject.GetComponent<FireScript>().FireSpeedUp();
        FireSpeedUpControl();
    }

    private void FireSpeedUpControl(){
        fireSpeed = CannonBallObject.GetComponent<FireScript>().spawnDelay;
        minDelay = CannonBallObject.GetComponent<FireScript>().minDelay;
        speedNeedCoin = (int)(Mathf.Pow(2,(1.6f-fireSpeed)*10)*10);                
        coins = CoinsObject.GetComponent<CoinsManager>().Coins;
        Debug.Log(speedNeedCoin);
        if (fireSpeed==minDelay || speedNeedCoin > coins)
        {
            speedUpButton.interactable = false;   
        }else
        {
            speedUpButton.interactable=true;
        }
    }
}
