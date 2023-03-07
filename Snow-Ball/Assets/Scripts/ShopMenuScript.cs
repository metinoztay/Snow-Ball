using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuScript : MonoBehaviour
{
    [SerializeField] private FireScript fireScript;
    private int ballLevelUpCoin;
    [SerializeField] private Button incomeLevelUpButton;
    [SerializeField] private TMP_Text incomeButtonText;
    [SerializeField] private Button ballLevelUpButton;
    [SerializeField] private TMP_Text ballLevelButtonText;
    [SerializeField] private Button fireSpeedUpButton;
    [SerializeField] private TMP_Text fireSpeedUpButtonText;
    [SerializeField] private CoinsManager coinsManager;
    [SerializeField] private GameObject settingsMenu;


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

    private void ButtonsControl(){
        BallLevelUpControl();
        FireSpeedUpControl();
        IncomeLevelUpControl();
    }
    public void BallLevelUp(){
        coinsManager.coins -= ballNeedCoin;
        fireScript.BallLevelUp();
        ButtonsControl();
        Save();       
    }

    private void BallLevelUpControl(){
        ballLevel = fireScript.ballLevel;
        ballMaxLevel = fireScript.maxLevel;
        ballNeedCoin = (int)(Mathf.Pow(3,(ballLevel-1))*10);
        coins = coinsManager.coins;
        ballLevelButtonText.text = ballNeedCoin.ToString();
        

        if (ballLevel >= ballMaxLevel || ballNeedCoin > coins)
        {
            ballLevelUpButton.interactable = false;
            ballLevelButtonText.color = new Color32(170,183,116,255);
        }else
        {
            ballLevelUpButton.interactable = true;
            ballLevelButtonText.color = new Color32(242,231,34,255);   
        }
    }

    public void FireSpeedUp(){
        coinsManager.coins -= fireSpeedNeedCoin;
        fireScript.FireSpeedUp();
        ButtonsControl();
        Save();
    }

    private void FireSpeedUpControl(){
        fireSpeed = fireScript.fireSpeed;
        minDelay = fireScript.minDelay;
        fireSpeedNeedCoin = (int)(Mathf.Pow(2,(1.0f-fireSpeed)*20)*10);           
        coins = coinsManager.coins;
        fireSpeedUpButtonText.text = fireSpeedNeedCoin.ToString();

        if (fireSpeed <= minDelay || fireSpeedNeedCoin > coins)
        {
            fireSpeedUpButton.interactable = false;
            fireSpeedUpButtonText.color = new Color32(170,183,116,255);   
        }else
        {
            fireSpeedUpButton.interactable = true;
            fireSpeedUpButtonText.color = new Color32(242,231,34,255);   
        }
    }

    public void IncomeLevelUp(){
        coinsManager.coins -= incomeLevelNeedCoin;
        coinsManager.CoinsValueUp(); 
        ButtonsControl();
        Save();
    }
    
    private void IncomeLevelUpControl(){
        coinsValue = coinsManager.coinsValue;
        maxCoinValue = coinsManager.maxCoinValue;
        incomeLevelNeedCoin = (int)Mathf.Pow(2,coinsValue)*10;
        coins = coinsManager.coins;
        incomeButtonText.text = incomeLevelNeedCoin.ToString();
        
        
        if (coinsValue >= maxCoinValue || incomeLevelNeedCoin > coins)
        {
            incomeLevelUpButton.interactable = false; 
            incomeButtonText.color = new Color32(170,183,116,255);

        }else
        {
            incomeLevelUpButton.interactable = true;
            incomeButtonText.color = new Color32(242,231,34,255);   
        }
    }
    
    private void Save(){
        PlayerPrefs.SetInt(nameof(coins),coins);
        PlayerPrefs.SetInt(nameof(ballLevel),ballLevel);
        PlayerPrefs.SetFloat(nameof(fireSpeed),fireSpeed);
        PlayerPrefs.SetInt(nameof(coinsValue),coinsValue);
    }

    private void Load(){
        coinsManager.coins = PlayerPrefs.GetInt(nameof(coins));
        fireScript.ballLevel = PlayerPrefs.GetInt(nameof(ballLevel));
        fireScript.fireSpeed = PlayerPrefs.GetFloat(nameof(fireSpeed));
        coinsManager.coinsValue = PlayerPrefs.GetInt(nameof(coinsValue));
    }

    public void SettingsOnOff(){
        bool isActive = settingsMenu.activeInHierarchy;
       if (isActive)
       {
        settingsMenu.SetActive(false);
       }else
       {
        settingsMenu.SetActive(true);
       }
    }


}
