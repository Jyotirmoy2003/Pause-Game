using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class LevelManger : MonoBehaviour
{
    public int currentLevelIndex=5;


    #region Singletone
    public static LevelManger instance;
     void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        
    
        DontDestroyOnLoad(gameObject);

    }
    #endregion
    [SerializeField] List<Map> map=new List<Map>();
    [SerializeField] LevelMode levelMode;
    [SerializeField] Transform ObstacleParenTransform;
    [SerializeField] List<Map> possibleObsForThisLvel=new List<Map>();
    [SerializeField] Coin coin;

    
    
    
    void Start()
    {
        GenerateObstacle();
    }
    void GenerateObstacle()
    {
        foreach (Map item in map)
        {
            if(item.level<=currentLevelIndex)
            {
                possibleObsForThisLvel.Add(item);
            }else{
                break;
            }
        }

        if(levelMode==LevelMode.simple)
        {
            GenerateSimple();
        }else{
            GenerateMixed();
        }

        

    }

    void GenerateSimple()
    {
        float posX=0,posY=0.5f,posZ=10;
        for(int i=0;i<20;i++)
        {
            int randIndex=Random.Range(0,possibleObsForThisLvel.Count);
            int amount=Random.Range(1,3);

            for(int j=0;j<amount;j++)
            {
                Obstacle Obs= possibleObsForThisLvel[randIndex].obj;
                Obs.PlaceObs(new Vector3(posX,posY,posZ+=Obs.spaceNeeded),ObstacleParenTransform);
                    if(posZ>=100)
                    {
                        break;
                    }
            }
            float val=Random.Range(0f,1.1f);
            if(val<coin.chance)
            {
                coin.PlaceObs(new Vector3(posX,posY,posZ+=3),ObstacleParenTransform);
            }
            posZ+=10;
            if(posZ>=100)
            {
                break;
            }
        }
    }


    void GenerateMixed()
    {

    }

    void DestroyChildren(Transform parent)
    {
        // Iterate through all child objects of the parent transform
        for (int i = parent.childCount - 1; i >= 0; i--)
        {
           Destroy(parent.GetChild(i).gameObject);
        }
    }


    public void ListenToButtonEvent(Component sender,object data)
    {
        if((int)data==3) //Next
        {
            DestroyChildren(ObstacleParenTransform);
            GenerateObstacle();
        }
        if((int)data==3) //restart
        {

        }
    }
    
}
