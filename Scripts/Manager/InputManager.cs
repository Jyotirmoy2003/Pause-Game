using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
   [SerializeField] GameEvent touchEvent;
   [SerializeField] GameEvent buttonEvent;
   [SerializeField] KeyCode restartKey=KeyCode.R;
   [SerializeField] KeyCode nextLeve=KeyCode.N;
    

   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            touchEvent.Raise(this,true);
        }else if(Input.GetMouseButtonUp(0))
        {
            touchEvent.Raise(this,false);
        }

        

        if(Input.GetKeyDown(restartKey))
        {
            buttonEvent.Raise(this,2);
        }
        if(Input.GetKeyDown(nextLeve))
        {
            buttonEvent.Raise(this,3);
        }
    }
}
