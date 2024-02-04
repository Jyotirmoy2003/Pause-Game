using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakblePlatfrom : MonoBehaviour
{
    [SerializeField] ParticleSystem brakeParticel;
    [SerializeField] float duration=2f;

    void Start()
    {
        
    }

   void OnCollisionEnter(Collision Info)
    {
       
        if(Info.gameObject.CompareTag("Player"))
        {
           Invoke("DestroyThePlatfrom",duration);
        }
    }

  

    void DestroyThePlatfrom()
    {
        this.gameObject.SetActive(false);
    }
}
