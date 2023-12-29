using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changegun : MonoBehaviour
{
    private int currentgun=0;
    // Start is called before the first frame update
    void Start()
    {
        ChangeGun();
        
    }

    // Update is called once per frame
    void Update()
    {

        
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
