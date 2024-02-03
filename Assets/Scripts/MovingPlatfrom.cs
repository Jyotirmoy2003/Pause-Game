using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class MovingPlatfrom : Obs_MovingPlatfrom
{
    void OnCollisionEnter(Collision Info)
    {
   
        if(Info.gameObject.CompareTag("Player"))
        {
            Info.transform.SetParent(this.transform);
            
        }
    }

    void OnCollisionExit(Collision Info)
    {
        if(Info.gameObject.CompareTag("Player"))
        {
            Info.transform.SetParent(null);
            Info.transform.localScale=new Vector3(1,1,1);
        }
    }
    
}
