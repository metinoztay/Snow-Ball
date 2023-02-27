using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScript : MonoBehaviour
{   
    [SerializeField] private GameObject hand;
    [SerializeField] private GameObject cuttingLine;
    private void NextLevel(){
        int level = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("level",level+1); 
        SceneManager.LoadScene(level+1);
    }

    public void ControlPlants(){

        bool isHandActive = hand.GetComponent<HandCutScript>().animator.GetBool("Collect");
        if (isHandActive)
        {
            hand.GetComponent<HandCutScript>().Move();
            Invoke("NextLevel",3f);
        }else
        {
            NextLevel();
        }   
    }

}
