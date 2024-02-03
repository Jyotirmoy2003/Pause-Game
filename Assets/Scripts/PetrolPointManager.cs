using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetrolPointManager : MonoBehaviour
{
   [SerializeField] List<Transform> petrolpoints=new List<Transform>();
   [SerializeField] PlayerController controller;
    void Awake()
    {
        foreach (var item in petrolpoints)
        {
            controller.AddItemsInStack(item);
        }
    }

   
}
