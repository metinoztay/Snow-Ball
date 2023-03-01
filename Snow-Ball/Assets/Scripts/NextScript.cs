using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScript : MonoBehaviour
{   
    [SerializeField] private HandCutScript handCutScript;

    private void Start() {
        handCutScript.SelectorAnimation(true);
    }
    private void NextLevel(){
        int level = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("level",level+1); 
        SceneManager.LoadScene(level+1);
    }

}
