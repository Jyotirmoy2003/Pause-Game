using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float Speed=10;
    [SerializeField] bool Pause=false;
    [SerializeField] Stack<Transform> petrolPoint=new Stack<Transform>();
    [SerializeField] GameEvent gameOverEvent;
    [SerializeField] int layerIndex=3;
    [SerializeField] Animator animator;
    [SerializeField] bool IsGround=true;
    [SerializeField] LayerMask ground;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance=0.1f;
    private Transform myTransform;
    private Rigidbody rb;
    [SerializeField] bool IsGameOver=false;
    [Header("Power Up")]
    [SerializeField] float speedIncrase=13f;
    [SerializeField] float powerUpTime=10f;
    [SerializeField] GameEvent playerGotPowerUp,ProgressEvent;
    [SerializeField] ParticleSystem speedPaticel;
    
    
   
    void Start() 
    {
       
        speedPaticel.Stop();
        VolumeController.instance.ToggleVigentte(false);
        rb=GetComponent<Rigidbody>();
        myTransform=GetComponent<Transform>();
        if(!agent) agent=GetComponent<NavMeshAgent>();
        agent.speed=Speed;

        //set up next destination
        GetNextPoint();

    }
   
   
    void Update()
    {
        if(IsGameOver) return;
        Move();
    }
    void FixedUpdate()
    {
        ApplyGravity();
    }


    void Move()
    {
        if(agent.remainingDistance<0.5f) 
        {
            GetNextPoint();
        }

        if(!Pause) agent.Resume();
        else agent.Stop();

        animator.SetBool("Run",!Pause);
        ProgressEvent.Raise(this,myTransform.position.z);
    }

    void ApplyGravity()
    {
        IsGround=Physics.CheckSphere(groundCheck.position,groundDistance,ground);
        if(!IsGround)
        {
            agent.Stop();
            transform.position=Vector3.Lerp(myTransform.position,new Vector3(myTransform.position.x,myTransform.position.y+3f,myTransform.position.z),0.3f);
            gameOverEvent.Raise(this,true);
            IsGameOver=true;
        }
    }

    void GetNextPoint()
    {
        if(petrolPoint.Count==0)
        {
            return;
        }
        agent.destination=petrolPoint.Pop().position;
    }

    void OnCollisionEnter(Collision Info)
    {
        if(Info.gameObject.layer==layerIndex)
        {
            gameOverEvent.Raise(this,true);
            IsGameOver=true;
            agent.Stop();
            
            // myTransform.position=GameManager.instacne.lastCheckPoint.position;
          
        }
    }

    void RestartGame()
    {
        agent.Resume();
        myTransform.position=GameManager.instacne.lastCheckPoint.position;
        IsGameOver=false;
        animator.Play("Run");
          
    }



    #region  Called From Another Script
    public void AddItemsInStack(Transform data)
    {
        petrolPoint.Push(data);
        
    }

    public void GivePowerUp()
    {
        agent.speed=speedIncrase;
        speedPaticel.Play();
        VolumeController.instance.ToggleVigentte();
        StartCoroutine(ResetPowerUp());
    }
    #endregion
    #region events
    //listen to touch input
    public void ListenToTouch(Component sender,object data)
    {
        if(data is bool)
        {
            Pause=(bool)data;
        }
    }

     public void ListenButtonEvent(Component sender,object data)
    {
        if(data is int)
        {
            if((int)data==2 || (int)data==3)
            {
                RestartGame();
            }
        }
    }


    public void ListenGotPowerUp(Component sender,object data)
    {
        if((bool)data)
        {
            GivePowerUp();
        }
    }

    //Game Win Event
    public void ListenToGameWinEvent(Component sender,object data)
    {
        if(data is bool)
            if((bool)data)
            {
                IsGameOver=true;
                animator.SetTrigger("Win");
                animator.SetBool("Run",false);
            }
    }


    #endregion

    IEnumerator ResetPowerUp()
    {
        yield return new WaitForSeconds(powerUpTime);

        agent.speed=Speed;//reset speed
        VolumeController.instance.ToggleVigentte();
        playerGotPowerUp.Raise(this,false);//let other know that we lost the powerup
    }
}
