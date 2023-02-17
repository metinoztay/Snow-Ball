using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCutScript : MonoBehaviour
{
   [SerializeField] private float direction;
   [SerializeField] private bool move;   
   [SerializeField] private float speed;

   CoinsManager coinsManager;


   

   [SerializeField] private Animator animator;

   private void Start() {
      animator = GetComponentInParent<Animator>();
      coinsManager = FindAnyObjectByType<CoinsManager>();
   }
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
      direction = 1;
   }

   private void OnTriggerEnter2D(Collider2D other) {
      if (other.tag=="MainCamera" && direction==1)
      {         
         direction *= -1;
      }
      else if(other.tag=="MainCamera")
      {
         move=false;
         direction = 1;
         animator.SetBool("Collect",false);
         
      }
      else if(other.tag=="Collectable")
      {
         Collect(other);         
      }
   }

   private void Collect(Collider2D other){
      if(other.tag == "Collectable"){
            coinsManager.AddCoins(other.transform.position);
            other.GetComponent<PlantScript>().Collect();            
        }
   }
   
}
