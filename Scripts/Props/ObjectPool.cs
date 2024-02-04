using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> pool=new List<GameObject>();
    private int index=0;

    public void CreateObjectPool(Transform parent,GameObject prefabObject,int numberOfObjects)
    {
      
      for(int i=0;i<numberOfObjects;i++)
      {
        pool.Add(Instantiate(prefabObject,parent));  
      }
      
      
      DeactivateAll();
    }

    public void DeactivateAll()
    {
        foreach (GameObject item in pool)
        {
            item.SetActive(false);
        }
    }

    public GameObject GetGameObject()
    {
        index=(index+1)%pool.Count;
        pool[index].SetActive(true);
        return pool[index];
    }

    public void Deactivate(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void Deactivate(GameObject obj,float timmer)
    {
       StartCoroutine(waitTimer(obj,timmer));
    }









    IEnumerator waitTimer(GameObject obj,float timmer)
    {
        yield return new WaitForSeconds(timmer);
        obj.SetActive(false);
    }
}
