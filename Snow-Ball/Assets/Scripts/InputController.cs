using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IDragHandler
{
    [SerializeField] Transform cannon;
    [SerializeField] float speed;

    public void OnDrag(PointerEventData eventData)
    {
        var position = cannon.position;
        var current = position.x;
        current += eventData.delta.x * speed*Time.deltaTime;
        position = new Vector3(current,position.y , 0);
        cannon.position = position;
    }
}
