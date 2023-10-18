using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class funnyBusTrigger : MonoBehaviour
{

   public UnityEvent playerDetected; 
   private void OnTriggerEnter(Collider other)
   {
    Debug.Log("trigger"); 
    playerDetected?.Invoke(); 

   }
}
