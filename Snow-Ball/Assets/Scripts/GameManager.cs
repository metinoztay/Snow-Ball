using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    [SerializeField] GameObject shopCanvas;
    [SerializeField] GameObject winCanvas;

    [SerializeField] GameObject loseCanvas;
    [SerializeField] GameObject snowSpawner;
    [SerializeField] GameObject fireScript;

    
    public GameState State; 
    
    private void Awake() {
        Instance = this;
    }
    
    private void Start() {
      UpdateGameState(GameState.ShopMenu);
    }
    public void UpdateGameState(GameState newState){
        State = newState;

        switch (State)
        {
             case GameState.ShopMenu:
                HandleShopMenu();
                break;
             case GameState.Start:
                HandleStart();
                break;
             case GameState.Pause:
                break;
             case GameState.Win:
                HandleWin();
                break;
             case GameState.Lose:
                HandleLose();
                break;
        
            
             default:
                break;
        }
    }

    private void HandleShopMenu()
    {
      shopCanvas.SetActive(true);
      fireScript.GetComponent<FireScript>().startFire = false;
      snowSpawner.GetComponent<SnowSpawnController>().startSnow = false;
    }

    private void HandleStart(){
      shopCanvas.SetActive(false);
      snowSpawner.GetComponent<SnowSpawnController>().startSnow = true;
      fireScript.GetComponent<FireScript>().startFire = true;
      
    }
    private void HandleWin(){
      fireScript.GetComponent<FireScript>().startFire = false;
      winCanvas.SetActive(true);
    }

    private void HandleLose(){
      fireScript.GetComponent<FireScript>().startFire = false;
      snowSpawner.GetComponent<SnowSpawnController>().startSnow = false;
      snowSpawner.SetActive(false);
      loseCanvas.SetActive(true);
    }
       
    
    public enum GameState{
        ShopMenu,
        Start,
        Pause,
        Win,
        Lose  
        
    }
}
