using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCutScript : MonoBehaviour
{
   [SerializeField] private float direction;
   [SerializeField] private bool move;   
   [SerializeField] private float speed;
   [SerializeField] CoinsManager coinsManager;
   [SerializeField] private Animator animator;
   private List<GameObject> collectables;
   private void Update() {
      if (move)
      {
         var current = transform.position;
         var newCurrent = Mathf.Lerp(current.x,current.x-direction,speed*Time.deltaTime);
         transform.position = new Vector3(newCurrent,current.y,current.z);
      }
   }

   public void Move(){
      move = true;
      direction = -1;
      SelectorAnimation(false);
   }

   private void OnTriggerEnter2D(Collider2D other) {
      if (other.CompareTag("MainCamera") && direction==-1)
      {         
         direction *= -1;
      }
      else if(other.CompareTag("MainCamera"))
      {
         move=false;
         direction = -1;
         animator.SetBool("Collect",false);
         
      }
      else if(other.tag=="Collectable")
      {
         Collect(other);         
      }
   }

   private void Collect(Collider2D other){
      if(other.CompareTag("Collectable") && move){
            coinsManager.AddCoins(other.transform.position,10);
            other.GetComponent<PlantScript>().Collect();            
        }
   }

   public void SelectorAnimation(bool isActive){
      animator.SetBool("Selector",isActive);  
   }
}