using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject CannonBallObject;
    private int ballLevelUpCoin;

    [SerializeField] private Button incomeLevelUpButton;
    [SerializeField] private Button ballLevelUpButton;
    [SerializeField] private Button fireSpeedUpButton;
    [SerializeField] private GameObject CoinsObject;

    int ballLevel, ballMaxLevel, ballNeedCoin;

    int coinsValue, incomeLevelNeedCoin , maxCoinValue;

    float fireSpeed , minDelay; 
    int fireSpeedNeedCoin;
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
        ballLevelUpButton.GetComponentInChildren<TMP_Text>().text = ballNeedCoin.ToString();
        

        if (ballLevel >= ballMaxLevel || ballNeedCoin > coins)
        {
            ballLevelUpButton.interactable = false;
            ballLevelUpButton.GetComponentInChildren<TMP_Text>().color = new Color32(170,183,116,255);
        }else
        {
            ballLevelUpButton.interactable = true;
            ballLevelUpButton.GetComponentInChildren<TMP_Text>().color = new Color32(242,231,34,255);   
        }
    }

    public void FireSpeedUp(){
        CoinsObject.GetComponent<CoinsManager>().coins -= fireSpeedNeedCoin;
        CannonBallObject.GetComponent<FireScript>().FireSpeedUp();
        ButtonsControl();
        Save();
    }

    private void FireSpeedUpControl(){
        fireSpeed = CannonBallObject.GetComponent<FireScript>().fireSpeed;
        minDelay = CannonBallObject.GetComponent<FireScript>().minDelay;
        fireSpeedNeedCoin = (int)(Mathf.Pow(2,(1.0f-fireSpeed)*10)*10);           
        coins = CoinsObject.GetComponent<CoinsManager>().coins;
        fireSpeedUpButton.GetComponentInChildren<TMP_Text>().text = fireSpeedNeedCoin.ToString();

        if (fireSpeed <= minDelay || fireSpeedNeedCoin > coins)
        {
            fireSpeedUpButton.interactable = false;
            fireSpeedUpButton.GetComponentInChildren<TMP_Text>().color = new Color32(170,183,116,255);   
        }else
        {
            fireSpeedUpButton.interactable = true;
            fireSpeedUpButton.GetComponentInChildren<TMP_Text>().color = new Color32(242,231,34,255);   
        }
    }

    public void IncomeLevelUp(){
        CoinsObject.GetComponent<CoinsManager>().coins -= incomeLevelNeedCoin;
        CoinsObject.GetComponent<CoinsManager>().CoinsValueUp(); 
        ButtonsControl();
        Save();
    }
    
    private void IncomeLevelUpControl(){
        coinsValue = CoinsObject.GetComponent<CoinsManager>().coinsValue;
        maxCoinValue = CoinsObject.GetComponent<CoinsManager>().maxCoinValue;
        incomeLevelNeedCoin = coinsValue * 10;
        coins = CoinsObject.GetComponent<CoinsManager>().coins;
        incomeLevelUpButton.GetComponentInChildren<TMP_Text>().text = incomeLevelNeedCoin.ToString();
        
        
        if (coinsValue >= maxCoinValue || incomeLevelNeedCoin > coins)
        {
            incomeLevelUpButton.interactable = false; 
            incomeLevelUpButton.GetComponentInChildren<TMP_Text>().color = new Color32(170,183,116,255);

        }else
        {
            incomeLevelUpButton.interactable = true;
            incomeLevelUpButton.GetComponentInChildren<TMP_Text>().color = new Color32(242,231,34,255);   
        }
    }
    
    private void Save(){
        PlayerPrefs.SetInt(nameof(coins),500);
        PlayerPrefs.SetInt(nameof(ballLevel),1);
        PlayerPrefs.SetFloat(nameof(fireSpeed),1f);
        PlayerPrefs.SetInt(nameof(coinsValue),1);
    }

    private void ButtonsControl(){
        BallLevelUpControl();
        FireSpeedUpControl();
        IncomeLevelUpControl();
    }
}
