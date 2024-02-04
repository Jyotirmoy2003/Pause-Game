using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObserver : MonoBehaviour
{
    [SerializeField] GameEvent playerGotPowerUp;
   [SerializeField] int numberOfObsToGetPowerUp=3;
   [SerializeField] private int alredyCrossedWithoutPause=0;
   private bool alreadyGotPowerUp=false;
    void Start()
    {
        
    }

   
    void CheckForPowerUp()
    {
        if(alreadyGotPowerUp) return; //if player already has the powerup then dont count it

        if(alredyCrossedWithoutPause>=numberOfObsToGetPowerUp)
        {
            playerGotPowerUp.Raise(this,true);
            alreadyGotPowerUp=true;
        }
    }


    #region Event
    public void ListenToTouchEvent(Component sender,object data)
    {
        if((bool)data)
            alredyCrossedWithoutPause=0;
    }

    public void ListenToPlayerCrossed(Component sender,object data)
    {
        alredyCrossedWithoutPause++;
        CheckForPowerUp();
    }
    //Listen to player lost powerup
    public void ListenToPlayerGotPowerUp(Component sender,object data)
    {
        if(sender!=this)//comfirm its not the same script
            if(!(bool)data)
            {
                alreadyGotPowerUp=false;
            }
    }

    #endregion
}
