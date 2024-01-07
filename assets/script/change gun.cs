using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changegun : MonoBehaviour
{
    public int currentgun = 0;
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
            currentgun = 0;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            currentgun = 1;

        }


        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (currentgun >= transform.childCount - 1)
            {
                currentgun = 0;
            }
            else
            {
                currentgun++;
            }





        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentgun <= 0)
            {
                currentgun = transform.childCount - 1;
            }
            else
            {
                currentgun--;
            }





        }
        if (perviusegun != currentgun)
        {
            ChangeGun();
        }
    }

    public void ChangeGun()
    {
        int i = 0;
        foreach (Transform gun in transform)
        {
            if (i == currentgun)
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