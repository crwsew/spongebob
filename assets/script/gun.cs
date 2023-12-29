using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UIElements;

public class gun : MonoBehaviour
{
    private const bool V = false;
    public float damage=10f;
    public float range=150f;
    public Camera cam;
    public ParticleSystem muzzle;
    public int allammo=150;
    public float reloaddelay=2f;
    public int maxammo=10;
    private int curentammo;
    private bool isreload=false;
    private int currentallammo;
    // Start is called before the first frame update
    void Start()
    {
        curentammo=maxammo;
        currentallammo=allammo;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentallammo<=0 && curentammo<=0)
        {
            return;
            
        }
        if(isreload)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.R)){
            StartCoroutine(reload());
            return;
        }
        if (curentammo<=0){
           StartCoroutine(reload());
            return;
        }
    if (Input.GetButtonDown("Fire1"))
    {
        Shoot();
    }    
    }
    private void Shoot(){
        muzzle.Play();
        RaycastHit hit;
        curentammo--;
        if(Physics.Raycast(cam.transform.position,cam.transform.forward,out hit,range))
        {
            print(hit.transform.name);
             enemy enemy= hit.transform.GetComponent<enemy>();
             if (enemy != null){
            enemy.Takedamage(damage);
        }
        }
        

    }
    private IEnumerator reload()
    {
        if (currentallammo>0)
        {
        isreload=true;
        print("reloaded");
        yield return new WaitForSeconds(reloaddelay);
        if(currentallammo<maxammo){
            curentammo=currentallammo;
            currentallammo=0;
        }
        else
        {
        currentallammo-=maxammo-curentammo;
        curentammo=maxammo;
        }
        isreload=false;
            }
        }
}
