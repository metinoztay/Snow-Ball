using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputController : MonoBehaviour, IDragHandler
{
    [SerializeField] Slider sensivitySlider;
    [SerializeField] Transform cannonBall;
    [SerializeField] float sensivity;
    [SerializeField] float maxTurnAngle;

    private void Awake() {
       sensivity = PlayerPrefs.GetFloat("Sensivity");
        if (sensivity == 0)
        {
            sensivity = 0.2f;
        }
        //sensivitySlider.value = sensivity*100;
    }
    public void OnDrag(PointerEventData eventData)
    {
        var rotation = cannonBall.rotation;
        float current = rotation.eulerAngles.z;
        current -= eventData.delta.x * sensivity;  
        if(current>300){
            current = current-360;
        }
        rotation.eulerAngles = new Vector3(0, 0, current);
        if(current>maxTurnAngle||current<-maxTurnAngle){
            return;
        }
        cannonBall.rotation = rotation;
    }   

    public void UpdateSensivity(){
        sensivity = (float)sensivitySlider.value / 100;
        PlayerPrefs.SetFloat("Sensivity",sensivity);
    }

}
