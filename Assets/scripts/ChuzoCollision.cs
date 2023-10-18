using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuzoCollision : MonoBehaviour
{
    
   void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Player"))
        {
            playerControll pc = col.gameObject.GetComponent<playerControll>();

            if (pc != null)
            {
                pc.playerHealth--;
                if (pc.playerHealth <= 0)
                {
                    pc.explode();
                }
            }

        }
   } 
}
