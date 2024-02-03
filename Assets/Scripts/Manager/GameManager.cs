using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instacne;
    public Transform startPosition;
    public Transform lastCheckPoint;
    [SerializeField] Transform playerTransform;
    [SerializeField] GameEvent gameWinEvent;


    void Awake()
    {
        instacne=this;
    }

    void Start()
    {
        if(!playerTransform) playerTransform=FindObjectOfType<PlayerController>().transform;
    }

    void RestartGame()
    {
        gameWinEvent.Raise(this,false);
    }

    #region  Events
    public void ListenButtonEvent(Component sender,object data)
    {
        if(data is int)
        {
            if((int)data==2)
            {
                //RestartGame();
            }
        }
    }


    #endregion
    
}
