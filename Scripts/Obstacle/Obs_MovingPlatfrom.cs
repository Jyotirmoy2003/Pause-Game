using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class Obs_MovingPlatfrom : Obstacle
{
    
    [SerializeField] Transform platfromTransform;
    [SerializeField] float magnititude=5;
    [Range(0f,2f)]
    [SerializeField] int speed=1;
    private Vector3 initalpos,lastPos,targetPos;

    [SerializeField] Axis alignmentAxis=Axis.X_Axis;

    private int Mode=1;

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
       switch (alignmentAxis)
       {
        case Axis.X_Axis:
            initalpos=new Vector3(platfromTransform.position.x-magnititude/2,platfromTransform.position.y,platfromTransform.position.z);
            lastPos=new Vector3(platfromTransform.position.x+magnititude/2,platfromTransform.position.y,platfromTransform.position.z);
            break;
        case Axis.Y_Axis:
            initalpos=new Vector3(platfromTransform.position.x,platfromTransform.position.y-magnititude/2,platfromTransform.position.z);
            lastPos=new Vector3(platfromTransform.position.x,platfromTransform.position.y+magnititude/2,platfromTransform.position.z);
            break;
        case Axis.Z_Axis:
            initalpos=new Vector3(platfromTransform.position.x,platfromTransform.position.y,platfromTransform.position.z-magnititude/2);
            lastPos=new Vector3(platfromTransform.position.x,platfromTransform.position.y,platfromTransform.position.z+magnititude/2);
            break;
        default:
            break;
       }
        targetPos=initalpos;
    }

   
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if(Vector3.Distance(platfromTransform.position,targetPos)<0.1f)
        {
            SwitchTarget();
        }

        platfromTransform.position=Vector3.Lerp(platfromTransform.position,targetPos,speed*Time.deltaTime);
    }

    void SwitchTarget()
    {
        if(Mode==1)
        {
            targetPos=lastPos;
            Mode=2;
        }else{
            targetPos=initalpos;
            Mode=1;
        }
    }

    public override void PlaceObs(Vector3 pos,Transform parent)
    {
        Instantiate(this.gameObject,parent).transform.position=pos;
        speed=Random.Range(1,3);
        if(speed==0)
        {
            speed=1;
        }
    }


   
}
