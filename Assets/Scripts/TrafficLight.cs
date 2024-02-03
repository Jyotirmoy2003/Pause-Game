using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class TrafficLight : MonoBehaviour
{
  

    public TrafficLight_Mode mode;
    [SerializeField] float WaitTime=6f;
    [SerializeField] float waitForYellow=2f;
    [SerializeField] GameEvent trafficLightEvent;
    
    [SerializeField] List<Renderer> lights=new List<Renderer>();
    [SerializeField] Material sub_Material,main_Material;
    private bool isComingFromRed=true;
    void Start()
    {
       StartCoroutine(LightTimmer());   
    }


    void ChangeMaterial(Renderer Obj,Material material)
    {
        Obj.material=material;
    }

    IEnumerator LightTimmer()
    {
        if(mode!=TrafficLight_Mode.Yellow)
            yield return new WaitForSeconds(WaitTime);
        else 
            yield return new WaitForSeconds(waitForYellow);
        
        NextMode();

    }

    void NextMode()
    {
        
        
        if(mode==TrafficLight_Mode.Red) 
        {
            mode=TrafficLight_Mode.Yellow;
            ChangeMaterial(lights[1],main_Material);
            ChangeMaterial(lights[0],sub_Material);
            ChangeMaterial(lights[2],sub_Material);
            
            isComingFromRed=true;

        }
        else if(mode==TrafficLight_Mode.Yellow)
        { 
            ChangeMaterial(lights[0],sub_Material);
            ChangeMaterial(lights[2],sub_Material);
            ChangeMaterial(lights[1],sub_Material);

            if(isComingFromRed)
                {
                    mode=TrafficLight_Mode.Green;
                    ChangeMaterial(lights[2],main_Material);
                }
            else
               { 
                mode=TrafficLight_Mode.Red;
                ChangeMaterial(lights[0],main_Material);
               }
           
            
            
        }
        else 
        {
            mode=TrafficLight_Mode.Yellow;
            ChangeMaterial(lights[1],main_Material);
            ChangeMaterial(lights[2],sub_Material);
            ChangeMaterial(lights[0],sub_Material);
            isComingFromRed=false;
        }
        //Invoke event to let other know
        trafficLightEvent.Raise(this,mode);
        StartCoroutine(LightTimmer());
    }
}
