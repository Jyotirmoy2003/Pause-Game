using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;
using Util;

public class Car :MonoBehaviour
{
   [SerializeField] float carSpeed=2f;
   [SerializeField] NavMeshAgent agent;
   [SerializeField] Vector3 startPosition,endPosition;
   [SerializeField] float distanceTobeCovered=15f;
   [SerializeField] Axis alignment=Axis.X_Axis;
   public bool CrossedZebraCrossing=false; 
   public bool stop=false;
   private TrafficLight_Mode mode=TrafficLight_Mode.Red;
   private Transform myTransform;


   void AutoSetupPositon()
   {
        startPosition=transform.position;
        switch (alignment)
        {
            case Axis.X_Axis:
                endPosition=new Vector3(startPosition.x+distanceTobeCovered,startPosition.y,startPosition.z);
                break;
            case Axis.Y_Axis:
                endPosition=new Vector3(startPosition.x,startPosition.y+distanceTobeCovered,startPosition.z);
                break;
            case Axis.Z_Axis:
                endPosition=new Vector3(startPosition.x+distanceTobeCovered,startPosition.y,startPosition.z+distanceTobeCovered);
                break;

           
            
        }
   }

    public void InitializeCar(float carSpeed,float distanceTobeCovered,Axis ax)
    {
        this.carSpeed=carSpeed;
        this.distanceTobeCovered=distanceTobeCovered;
        alignment=ax;
        CrossedZebraCrossing=false;
        AutoSetupPositon();
        agent.destination=endPosition;
        agent.speed=carSpeed;
    }

    void ResetCarPosition()
    {
        myTransform.position=startPosition;
        CrossedZebraCrossing=false;
        LightChanged();
    }

    void Start()
    {
        myTransform=transform;
        
    }


    void FixedUpdate()
    {
        if(agent.remainingDistance<=0.5f)
        {
            ResetCarPosition();
        }
    }


    void LightChanged()
    {
        if(mode==TrafficLight_Mode.Green &&!CrossedZebraCrossing)
        {
            agent.speed=0;
        }else if(mode==TrafficLight_Mode.Red)
        {
            agent.speed=carSpeed;
        }
        else if(mode==TrafficLight_Mode.Yellow && !CrossedZebraCrossing)
        {
            agent.speed=0;
        }
    }


    public void ListenFromTrafficLight(Component sender,object data)
    {
        if(data is TrafficLight_Mode)
        {
            mode=(TrafficLight_Mode)data;
            LightChanged();
        }
    }
}
