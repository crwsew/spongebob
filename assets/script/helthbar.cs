using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helthbar : MonoBehaviour
{
   public Slider hralthbar;
   public void SetSlider(float amout){
    hralthbar.value=amout;
   }
   public void SetSliderMax(float amout){
    hralthbar.maxValue=amout;
    SetSlider(amout);
   }
}

