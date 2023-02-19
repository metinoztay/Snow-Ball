using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject CannonBallObject;
    private int ballLevelUpCoin;

    [SerializeField] private Button ballLevelUpButton;
    [SerializeField] private GameObject CoinsObject;

    int ballLevel;
    int ballMaxLevel;

    int ballNeedCoin;

    int coins;



    public void Start(){
        BallLevelUpControl();
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
        int coins = CoinsObject.GetComponent<CoinsManager>().Coins;

        if (ballLevel==ballMaxLevel || ballNeedCoin > coins)
        {
            ballLevelUpButton.interactable = false;
        }else
        {
            ballLevelUpButton.interactable = true;
        }

    }
}
