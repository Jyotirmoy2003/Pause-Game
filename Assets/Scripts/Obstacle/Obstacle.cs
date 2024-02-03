using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float spaceNeeded=5f;
    [SerializeField] GameEvent playerCrossedEvent;

   


    public virtual void PlayerDetected()
    {
        
    }

    void OnTriggerEnter(Collider info)
    {
        if(info.CompareTag("Player"))
        {
            playerCrossedEvent.Raise(this,true);
        }
    }

    public virtual void PlaceObs(Vector3 pos,Transform parent)
    {
        Instantiate(this.gameObject,parent).transform.position=pos;
    }
    
}
