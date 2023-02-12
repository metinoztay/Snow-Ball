using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCutScript : MonoBehaviour
{
   [SerializeField] private float direction;
   [SerializeField] private bool move;
   
   [SerializeField] private float speed;

   private Transform startingPosition;

   private void Start() {
      startingPosition = transform;
   }
   private void Update() {
      /*if(Mathf.Approximately(startingPosition.position.x,transform.position.x))
      {
         move=false;
      }*/

      if (move)
      {
         var current = transform.position;
         var newCurrent = Mathf.Lerp(current.x,current.x-direction,speed*Time.deltaTime);
         transform.position = new Vector3(newCurrent,current.y,current.z);
      }
   }

   public void Move(){
      move = true;
      direction=1;
   }
   private void OnTriggerEnter2D(Collider2D other) {
      if (other.tag=="MainCamera"&&direction==1)
      {
         direction *= -1;
      }
      else if(other.tag=="MainCamera")
      {
         move=false;
      }
   }
}
