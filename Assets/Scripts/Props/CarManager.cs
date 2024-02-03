using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Util;

public class CarManager : MonoBehaviour
{
   public List<Car> allCars=new List<Car>();
   [SerializeField] float distanceTobeCovered=10f;
   [SerializeField] Axis alignment=Axis.X_Axis;
   [SerializeField] float carSpeed=5;
   private float speed=0;
   
    void Start()
    {
        InitCar();
    }

  void InitCar()
  {
    foreach (Car item in allCars)
    {
      speed=Random.Range(carSpeed-1,carSpeed+1);
      item.InitializeCar(speed,distanceTobeCovered,alignment);
    }
  }


  void OnTriggerEnter(Collider info)
  {
    
      if(info.TryGetComponent<Car>(out var car))
      {
        car.CrossedZebraCrossing=true;
      }
  }
}
