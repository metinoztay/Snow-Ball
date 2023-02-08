using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IDragHandler
{
    [SerializeField] Transform cannon;
    [SerializeField] float speed;
    private void Update()
    {
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = cannon.position;
        float current = position.x;
        current += eventData.delta.x * speed * Time.deltaTime;
        position = new Vector2(current, position.y);
        
        cannon.position = new Vector3(position.x, position.y, 0);
        Debug.Log(cannon.position);
    }

}
