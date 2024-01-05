using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersetup : MonoBehaviour
{
    public GameObject cammera;
    public movement movement;
    public string nickname;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setnickname(string _name)
    {
        nickname= _name;
    }
    public void IsLocalplayer(){
 cammera.SetActive(true);
        movement.enabled=true;
    }

}
