using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressBarScript : MonoBehaviour
{
    [SerializeField] Image fillImage;
    [SerializeField] public int maxValue;
    [SerializeField] private int currentValue;
    [SerializeField] private float fillSpeed;
    [SerializeField] private float targetValue;

    private void Start() {
        fillImage.fillAmount = 0;
    }


    private void Update() {
        Fill();
    }

    private void Fill(){
        targetValue = Mathf.InverseLerp(0,maxValue,currentValue);
      
        if (fillImage.fillAmount < targetValue)
        {
           fillImage.fillAmount += fillSpeed;
        }
    }

    public void IncrementProgress(int value){
        currentValue += value;
    }



}
