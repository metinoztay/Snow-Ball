using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
   
    [SerializeField] GameObject shopCanvas;
    [SerializeField] GameObject inputCanvas;
    [SerializeField] GameObject winCanvas;

    [SerializeField] GameObject loseCanvas;
    [SerializeField] GameObject snowSpawner;
    [SerializeField] GameObject fireScript;
    
    [SerializeField] private TMP_Text levelText;
    public GameState State; 
    
    private void Awake() {
        Instance = this;
        LoadLevel();
    }
    
    private void Start() {
      UpdateGameState(GameState.ShopMenu);
    }
    public void UpdateGameState(GameState newState){
         
         if (newState == GameState.Win && State == GameState.Lose)
               return;

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
      snowSpawner.GetComponent<SnowController>().startSnow = false;
    }

    private void HandleStart(){
      inputCanvas.SetActive(true);
      shopCanvas.SetActive(false);
      snowSpawner.GetComponent<SnowController>().startSnow = true;
      fireScript.GetComponent<FireScript>().StartFire();
      
    }
    private void HandleWin(){
      inputCanvas.SetActive(false);
      fireScript.GetComponent<FireScript>().startFire = false;
      winCanvas.SetActive(true);
    }

    private void HandleLose(){
      inputCanvas.SetActive(false);
      fireScript.GetComponent<FireScript>().startFire = false;
      snowSpawner.GetComponent<SnowController>().startSnow = false;
      loseCanvas.SetActive(true);
    }

   private void LoadLevel(){
      int activeLevel = SceneManager.GetActiveScene().buildIndex;
      int savedLevel = PlayerPrefs.GetInt("level");
      if (activeLevel != savedLevel)
      {
         SceneManager.LoadScene(savedLevel);
      }
      levelText.text = savedLevel.ToString();
   }

    public enum GameState{
        ShopMenu,
        Start,
        Pause,
        Win,
        Lose  
        
    }
}
