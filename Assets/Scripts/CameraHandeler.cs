using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandeler : MonoBehaviour
{
    [SerializeField] Transform cameraAxies;
    [SerializeField] float rotaionSpeed=1f;
    private bool GameWin=false;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameWin){
            Vector3 rot=new Vector3(cameraAxies.localRotation.x,cameraAxies.localRotation.y+rotaionSpeed,cameraAxies.localRotation.z);
            cameraAxies.Rotate(rot);
        }

    }

    public void ListenToGameWinEvent(Component sender,object data)
    {
        if(data is bool)
            if((bool)data)
            {
                GameWin=true;
            }else{
                GameWin=false;
                cameraAxies.localEulerAngles=Vector3.zero;
            }
    }
}
