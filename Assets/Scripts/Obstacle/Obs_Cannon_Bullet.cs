
using UnityEngine;

public class Obs_Cannon_Bullet : Obstacle
{
    [SerializeField] float speed=4;
    [SerializeField] float destroyTimer=10f;
    void Start()
    {
        
       // Destroy(this.gameObject,destroyTimer);
    }

   
    void FixedUpdate()
    {
        transform.Translate(Vector3.right*Time.deltaTime*speed);
    }
}
