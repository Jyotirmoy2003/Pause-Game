using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
   [SerializeField] GameEvent gameWinEvent;

   void OnTriggerEnter(Collider info)
   {
    if(info.gameObject.CompareTag("Player"))
    {
        gameWinEvent.Raise(this,true);
    }
   }
}
