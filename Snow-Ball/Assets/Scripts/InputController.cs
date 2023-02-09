using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IDragHandler
{
   [SerializeField] Transform cannonBall;
    [SerializeField] float speed;
    [SerializeField] float maxTurnAngle;
    public void OnDrag(PointerEventData eventData)
    {
        var rotation = cannonBall.rotation;
        float current = rotation.eulerAngles.z;
        current -= eventData.delta.x * speed;  
        if(current>300){
            current = current-360;
        }
        rotation.eulerAngles = new Vector3(0, 0, current);
        if(current>maxTurnAngle||current<-maxTurnAngle){
            return;
        }
        cannonBall.rotation= rotation;
    }   

}
