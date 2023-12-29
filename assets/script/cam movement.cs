using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammovement : MonoBehaviour
{
    public float sensiti=900f;
    public Transform playerbody;
    private float ymouserotate=0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousex=Input.GetAxis("Mouse X")*sensiti*Time.deltaTime;
        float mousey=Input.GetAxis("Mouse Y")*sensiti*Time.deltaTime;
        ymouserotate-=mousey;
        ymouserotate=Mathf.Clamp(ymouserotate,-80f,80f);
        transform.localRotation=Quaternion.Euler(ymouserotate,0,0);
        playerbody.Rotate(Vector3.up*mousex);

    }
}
