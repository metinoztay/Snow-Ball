using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenuScript : MonoBehaviour
{
    public void StartGame(){
        GameManager.Instance.UpdateGameState(GameManager.GameState.Start);
    }
}
