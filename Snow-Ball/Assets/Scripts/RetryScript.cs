using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour
{

    [SerializeField] private HandCutScript handCutScript;

    private void Start() {
        handCutScript.SelectorAnimation(true);
    }
    public void Retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
