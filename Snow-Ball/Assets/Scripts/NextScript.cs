using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScript : MonoBehaviour
{   
    [SerializeField] private GameObject hand;
    private void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void ControlPlants(){

        hand.GetComponent<HandCutScript>().Move();

        Invoke("NextLevel",3f);
    }

}
