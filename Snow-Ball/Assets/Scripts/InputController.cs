using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IDragHandler
{
    [SerializeField] Transform main;
    [SerializeField] float speed;

    public void OnDrag(PointerEventData eventData)
    {
        var position = main.position;
        var current = position.x;
        current += eventData.delta.x * speed;
        position = new Vector3(current,position.y , 0);
        main.position = position;
    }
}
