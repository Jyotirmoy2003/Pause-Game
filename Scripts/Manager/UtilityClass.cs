using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Util
{
     public enum Axis
     {
        X_Axis,
        Y_Axis,
        Z_Axis
    }

      public enum TrafficLight_Mode{
        Red,
        Yellow,
        Green,
    }
    delegate void VoidFun();
    public enum LevelMode{
        simple,
        mixed,
    }
    
    [System.Serializable]
    public struct Map{
        public int level;
        public Obstacle obj;
    }
    

  public class UtilityClass 
  { 
    
  }

}
