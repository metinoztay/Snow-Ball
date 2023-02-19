using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    [SerializeField] GameObject shopCanvas;
    [SerializeField] GameObject inputCanvas;
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
      inputCanvas.SetActive(false);
      shopCanvas.SetActive(true);
      fireScript.GetComponent<FireScript>().startFire = false;
      snowSpawner.GetComponent<SnowSpawnController>().startSnow = false;
    }

    private void HandleStart(){
      Time.timeScale = 1;
      inputCanvas.SetActive(true);
      shopCanvas.SetActive(false);
      snowSpawner.GetComponent<SnowSpawnController>().startSnow = true;
      fireScript.GetComponent<FireScript>().startFire = true;
      
    }
    private void HandleWin(){
      inputCanvas.SetActive(false);
      fireScript.GetComponent<FireScript>().startFire = false;
      winCanvas.SetActive(true);
      Time.timeScale = 0;
    }

    private void HandleLose(){
      inputCanvas.SetActive(false);
      fireScript.GetComponent<FireScript>().startFire = false;
      snowSpawner.GetComponent<SnowSpawnController>().startSnow = false;
      //snowSpawner.SetActive(false);
      loseCanvas.SetActive(true);
      Time.timeScale = 0;
    }
       
    
    public enum GameState{
        ShopMenu,
        Start,
        Pause,
        Win,
        Lose  
        
    }
}
