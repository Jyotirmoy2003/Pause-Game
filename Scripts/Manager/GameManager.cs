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
    [SerializeField] Material skybixMat;
    [SerializeField] List<ParticleSystem> particleSystems=new List<ParticleSystem>();


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
        foreach (var item in particleSystems)
        {
                item.Pause();
        }
    }
   

    #region  Events
    public void ListenButtonEvent(Component sender,object data)
    {
        if(data is int)
        {
            if((int)data==2)
            {
                RestartGame();
            }
        }
    }

    public void ListenWin(Component sender,object data)
    {
        if((bool)data)
        {
            foreach (var item in particleSystems)
            {
                item.Play();
            }
        }
    }
    public void ListenRestart(Component sender,object data)
    {
        if((bool)data)
        {
            RestartGame();
        }
    }


    #endregion
    
}
