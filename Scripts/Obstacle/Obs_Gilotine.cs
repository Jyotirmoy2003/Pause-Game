using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs_Gilotine : Obstacle
{
    [SerializeField]float SpeedAbove=0.02f,SpeedBottom=0.06f,waitTimeAbove=3f,waitTimeBottom=3f;
    [SerializeField] Transform bladeTrsnform,groundPosition;
    [SerializeField] Vector3 intialPosition,targetPositon;
    [SerializeField] LineRenderer line;
    [SerializeField] int Mode=1;

    void Start()
    {
        intialPosition=bladeTrsnform.position;
        targetPositon=groundPosition.position;
        line.SetPosition(0,bladeTrsnform.position);
    }

   
    void Update()
    {
        //check remaning distance 
        if(Vector3.Distance(bladeTrsnform.position,targetPositon)<0.1f && Mode!=0)
        {
            //let the blade wait for little
            StartCoroutine(WaitTimmer());
        }

        //keep moving the blade
        if(Mode==1)
            bladeTrsnform.position=Vector3.Lerp(bladeTrsnform.position,groundPosition.position,SpeedBottom);
        else if(Mode==2)
        {
            bladeTrsnform.position=Vector3.Lerp(bladeTrsnform.position,intialPosition,SpeedAbove);
        }

        if(Mode!=0)
        {
            line.SetPosition(1,bladeTrsnform.position);
        }
    }


    IEnumerator WaitTimmer()
    {
        if(Mode==1){
                Mode=0;
                yield return new WaitForSeconds(waitTimeBottom);
                
                targetPositon=intialPosition;
                Mode=2;
            }
        else{
                Mode=0;
                yield return new WaitForSeconds(waitTimeAbove);
            
                targetPositon=groundPosition.position;
                Mode=1;
            }
        
    }
}
