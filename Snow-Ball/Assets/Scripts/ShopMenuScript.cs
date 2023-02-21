using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject CannonBallObject;
    private int ballLevelUpCoin;

    [SerializeField] private Button incomeLevelUpButton;
    [SerializeField] private Button ballLevelUpButton;
    [SerializeField] private Button speedUpButton;
    [SerializeField] private GameObject CoinsObject;

    int ballLevel, ballMaxLevel, ballNeedCoin;

    int coinsValue, coinsValueNeedCoin , maxCoinValue;

    float fireSpeed , minDelay; 
    int speedNeedCoin;
    int coins;


    public void Start(){
       ButtonsControl();
    }

    public void StartGame(){
        GameManager.Instance.UpdateGameState(GameManager.GameState.Start);
    }

    public void BallLevelUp(){
        CoinsObject.GetComponent<CoinsManager>().coins -= ballNeedCoin;
        CannonBallObject.GetComponent<FireScript>().BallLevelUp();
        ButtonsControl();        
        Save();
    }

    private void BallLevelUpControl(){
        ballLevel = CannonBallObject.GetComponent<FireScript>().ballLevel;
        ballMaxLevel = CannonBallObject.GetComponent<FireScript>().maxLevel;
        ballNeedCoin = (int)(Mathf.Pow(2,(ballLevel-1))*10);
        coins = CoinsObject.GetComponent<CoinsManager>().coins;
        

        if (ballLevel==ballMaxLevel || ballNeedCoin > coins)
        {
            ballLevelUpButton.interactable = false;
        }else
        {
            ballLevelUpButton.interactable = true;
        }
    }

    public void FireSpeedUp(){
        CoinsObject.GetComponent<CoinsManager>().coins -= speedNeedCoin;
        CannonBallObject.GetComponent<FireScript>().FireSpeedUp();
        ButtonsControl();
        Save();
    }

    private void FireSpeedUpControl(){
        fireSpeed = CannonBallObject.GetComponent<FireScript>().fireSpeed;
        minDelay = CannonBallObject.GetComponent<FireScript>().minDelay;
        speedNeedCoin = (int)(Mathf.Pow(2,(1.1f-fireSpeed)*10)*10);                
        coins = CoinsObject.GetComponent<CoinsManager>().coins;
        if (fireSpeed==minDelay || speedNeedCoin > coins)
        {
            speedUpButton.interactable = false;   
        }else
        {
            speedUpButton.interactable = true;
        }
    }

    public void IncomeLevelUp(){
        CoinsObject.GetComponent<CoinsManager>().coins -= coinsValueNeedCoin;
        CoinsObject.GetComponent<CoinsManager>().CoinsValueUp(); 
        ButtonsControl();
        Save();
    }
    
    private void IncomeLevelUpControl(){
        coinsValue = CoinsObject.GetComponent<CoinsManager>().coinsValue;
        maxCoinValue = CoinsObject.GetComponent<CoinsManager>().maxCoinValue;
        coinsValueNeedCoin = coinsValue * 10;
        coins = CoinsObject.GetComponent<CoinsManager>().coins;
        
        
        if (coinsValue == maxCoinValue || coinsValueNeedCoin > coins)
        {
            incomeLevelUpButton.interactable = false;
        }else
        {
            incomeLevelUpButton.interactable = true;
        }
    }
    
    private void Save(){
        PlayerPrefs.SetInt(nameof(coins),100);
        PlayerPrefs.SetInt(nameof(ballLevel),ballLevel);
        PlayerPrefs.SetFloat(nameof(fireSpeed),fireSpeed);
        PlayerPrefs.SetInt(nameof(coinsValue),coinsValue);
    }

    private void ButtonsControl(){
        BallLevelUpControl();
        FireSpeedUpControl();
        IncomeLevelUpControl();
    }
}
