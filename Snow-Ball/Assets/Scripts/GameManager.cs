using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    public GameState State; 

    private void Awake() {
        Instance = this;
    }
    
    public void UpdateGameState(GameState newState){
        State = newState;

        switch (State)
        {
             case GameState.Menu:
                break;
             case GameState.Start:
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

    private void HandleWin(){

    }

    private void HandleLose(){

    }
       
    
    public enum GameState{
        Menu,
        Start,
        Pause,
        Win,
        Lose  
        
    }
}
