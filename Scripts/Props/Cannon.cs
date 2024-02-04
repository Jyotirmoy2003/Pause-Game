using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
   [SerializeField] float amountOfTimeDiffer=2f;
   [SerializeField] float fireTimerAfter=3f;
   [SerializeField] Transform shootPoint;
   [SerializeField] GameObject bulletPrefab;
   private float timmer=0;
   private ObjectPool objectPool;

    void Start()
    {
        objectPool=GetComponent<ObjectPool>();
        StartCoroutine(waitTimer());
        objectPool.CreateObjectPool(this.transform,bulletPrefab,5);
    }

  

    void Shoot()
    {
        //Instantiate(bulletPrefab,shootPoint.position,Quaternion.identity);
        GameObject obj= objectPool.GetGameObject();
        obj.transform.position=shootPoint.position;

        objectPool.Deactivate(obj,5f); //deactivate game object after certian point of time
        StartCoroutine(waitTimer());
    }

    IEnumerator waitTimer()
    {
        timmer=Random.Range(fireTimerAfter+amountOfTimeDiffer,fireTimerAfter-amountOfTimeDiffer);
        yield return new WaitForSeconds(timmer);
        Shoot();
    }
}
