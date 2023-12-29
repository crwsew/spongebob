using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage=10f;
    public float range=150f;
    public Camera cam;
    public ParticleSystem muzzle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetButtonDown("Fire1"))
    {
        Shoot();
    }    
    }
    private void Shoot(){
        muzzle.Play();
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position,cam.transform.forward,out hit,range))
        {
            print(hit.transform.name);
        }
    }
}
