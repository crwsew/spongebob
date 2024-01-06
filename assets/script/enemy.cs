using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class enemy : MonoBehaviour
{
    
    public float health=30f;
    public void Takedamage(float damage){
        health =- damage;
        if(health<=0f){
        die();
        }
    }
    private void die(){
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
