using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class playerstate : MonoBehaviour
{
    [SerializeField] private float maxhealth=100;
    private float currenhealth;
    public helthbar helthbar;
    public bool isloacal;
      void Start(){
        currenhealth=maxhealth;
        helthbar.SetSliderMax(maxhealth);
      }
      public void takedamage(float amout){
        currenhealth -=amout;
        helthbar.SetSlider(currenhealth);
      }
      void Update(){
        if (currenhealth>maxhealth){
          currenhealth=maxhealth;
        }
        if (currenhealth<=0)
        {
          Die();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            takedamage(10f);
        }
      }
  
      private void Die()
      {
        if (isloacal)
        Debug.Log("you died!");
        Destroy(gameObject);
        roommanager.instance.Respawn();
              }
}
