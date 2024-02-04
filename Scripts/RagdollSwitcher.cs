using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollSwitcher : MonoBehaviour
{
   [SerializeField] BoxCollider mainCollider;
   [SerializeField] Rigidbody mainRigidbody;
   [SerializeField] GameObject chracterRig;
   [SerializeField] Animator animator;
   private Collider[] rigColliders;
   private Rigidbody[] rigRigidbodys;




    void Start()
    {
        GetRagDollBits();
        RagDollModeOff();
    }

   


    void GetRagDollBits()
    {
        rigColliders= chracterRig.GetComponentsInChildren<Collider>();
        rigRigidbodys=chracterRig.GetComponentsInChildren<Rigidbody>();
    }

    public void RagDollModeOn()
    {
        animator.enabled=false;
        foreach (Collider item in rigColliders)
        {
            item.enabled=true;
        }

        foreach (Rigidbody item in rigRigidbodys)
        {
            item.isKinematic=false;
        }

        mainCollider.enabled=false;
        mainRigidbody.isKinematic=true;
    }


   public void RagDollModeOff()
    {
        animator.enabled=true;
        foreach (Collider item in rigColliders)
        {
            item.enabled=false;
        }

        foreach (Rigidbody item in rigRigidbodys)
        {
            item.isKinematic=true;
        }
        mainCollider.enabled=true;
        mainRigidbody.isKinematic=false;
        
    }


    public void ListenToGameOverEvent(Component sender,object data)
    {
        if(sender is PlayerController)
        {
            if((bool)data) RagDollModeOn();
            else RagDollModeOff();
        }
    }

    public void ListenButton(Component sender,object data)
    {
        if(data is int)
        {
            if((int)data==2 || (int)data==3)
            {
                RagDollModeOff();
            }
        }
    }
}
