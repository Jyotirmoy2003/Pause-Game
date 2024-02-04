using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs_Pendulum : Obstacle
{
    [SerializeField] float speed=1f;
    [SerializeField] float magnitate=1f;
    float timmer=0;
    int phase=0;
    [SerializeField] Transform myTransform;
    void Start()
    {
        if(!myTransform) myTransform=this.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timmer+=Time.fixedDeltaTime;

        if(timmer>magnitate)
        {
            phase++;
            phase%=4;
            timmer=0;
        }

        switch (phase)
        {
            case 0:
                myTransform.Rotate(0f,0f,speed*(1-timmer));
                break;
            case 1:
                myTransform.Rotate(0f,0f,-speed*timmer);
                break;
            case 2:
                myTransform.Rotate(0f,0f,-speed*(1-timmer));
                break;
            case 3:
                myTransform.Rotate(0f,0f,speed*timmer);
                break;
            default:
                break;
        }
    }
}
