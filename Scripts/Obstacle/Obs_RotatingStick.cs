using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using Util;

public class Obs_RotatingStick : Obstacle
{
   [SerializeField] Transform baseTransform;
   [SerializeField] float speed=2f;
   [SerializeField] bool isReverseing=false;
   private VoidFun rotateFun; //delegate
   
   
    void Start()
    {
        if(isReverseing) rotateFun=ReverseRotate;
        else rotateFun=Rotate;
    }
    
    void FixedUpdate()
    {
        rotateFun();
    }



    void ReverseRotate()
    {
        baseTransform.Rotate(0,speed,0);
        if( baseTransform.localRotation.y<0)
        {
            speed*=-1;
        }
    }

    void Rotate()
    {
        baseTransform.Rotate(0,speed,0);
    }


    public override void PlaceObs(Vector3 pos,Transform parent)
    {
        Instantiate(this.gameObject,parent).transform.position=pos;
        int val=Random.Range(0,1);
        if(val==0) isReverseing=true;

        Start();

    }
}
