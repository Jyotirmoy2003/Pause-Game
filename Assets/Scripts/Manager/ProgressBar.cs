
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float maxValue=1,minValue=0;
    [SerializeField] float currentValue=0;

    void Start()
    {
        slider.maxValue=maxValue;
        slider.minValue=minValue;
        slider.value=currentValue;
    }

   public void SetValue(float amount)
   {
        slider.value=amount;
   }

   public void SetMaxValue(float amount)
   {
        slider.maxValue=amount;
   }

   public void ListenToPlayerProgress(Component sender,object data)
   {
   
        slider.value=(float)data;
   }
}
