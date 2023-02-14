using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float fillSpeed = 0.5f;
    [SerializeField] private float targetValue;

    [SerializeField] float maxCollect;
    float addValue;

    private void Awake() {
        slider = GetComponent<Slider>();
    }
    void Start()
    {
        addValue = (1 / maxCollect);
        Debug.Log(addValue);
    }

    
    void Update()
    {
        if (slider.value<targetValue)
        {
            slider.value += fillSpeed*Time.deltaTime;
        }   
    }

    public void IncrementProgress(){
        
        targetValue = slider.value+addValue;
        Debug.Log(targetValue);
    }


}
