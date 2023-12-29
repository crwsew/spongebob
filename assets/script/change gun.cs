using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changegun : MonoBehaviour
{
    public int currentgun=0;
    // Start is called before the first frame update
    void Start()
    {
        ChangeGun();
        
    }
    // Update is called once per frame
    void Update()
    {
            int perviusegun = currentgun;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
                    currentgun=0;

        }
           if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >=2)
        {
                    currentgun=1;

        }
        if (perviusegun != currentgun){
            ChangeGun();
        }
       
    }
    private void ChangeGun()
    {
        int i=0;
        foreach(Transform gun in transform){
            if (i==currentgun)
            {
                gun.gameObject.SetActive(true);
            }
            else
            {
                gun.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
