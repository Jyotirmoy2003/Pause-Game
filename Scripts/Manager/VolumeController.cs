using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class VolumeController : MonoBehaviour
{
   public static VolumeController instance;
   void Awake()
   {
        instance=this;
   }

   
   [SerializeField] Volume volume;
   [SerializeField] Vignette vignette;
   private bool togVigentte;
    void Start()
    {
        if(volume.profile.TryGet(out vignette))
        {
            togVigentte=vignette.active;
        }
    }
    public void ToggleVigentte()
    {
      
        togVigentte=!togVigentte;
        vignette.active=togVigentte;
      
    }
     public void ToggleVigentte(bool val)
    {
      
        togVigentte=val;
        vignette.active=togVigentte;
      
    }
    
}
