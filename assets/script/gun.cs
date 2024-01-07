using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Timeline;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class gun : MonoBehaviour
{


    private const bool V = false;
    public float damage = 10f;
    public float range = 150f;
    public Camera cam;
    public ParticleSystem muzzle;
    public int allammo = 140;
    public float reloaddelay = 0.25f;
    public int maxammo = 14;
    private int curentammo;
    private bool isreload = false;
    private int currentallammo;
    [Header("holle")]
    public float minholl = 300;
    public float maxholl = 500;
    public Transform holeeject;
    public GameObject hole;
    [Header("Animation")]
    public Animation anim;
    public AnimationClip Reo;
    [Header("anim shake")]
    public Animation animshake;
    [Header("anim zoom")]
    public Animation animzoom;
    public AnimationClip zoom;
    [Header("unzoom")]
    public Animation animunzoom;
    public AnimationClip unzoom;
    [Header("ammo text")]
    public TextMeshProUGUI ammotext;

    // Start is called before the first frame update
   private void OnEnable()
    {
        curentammo = maxammo;
        currentallammo = allammo;
        updateui();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animzoom.Play(zoom.name);
        }
        if (Input.GetMouseButtonUp(1))
        {
            animunzoom.Play(unzoom.name);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            reload();
        }

        if (currentallammo <= 0 && curentammo <= 0)
        {
            return;

        }
        if (isreload)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(reload());
            return;
        }
        if (curentammo <= 0)
        {
            StartCoroutine(reload());
            return;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        makehole();
        animshake.Play("new");
        muzzle.Play();
        RaycastHit hit;
        curentammo--;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            enemy enemy = hit.transform.GetComponent<enemy>();
            if (enemy != null)
            {
                enemy.Takedamage(damage);
            }
                    updateui();
        }


    }
    private IEnumerator reload()
    {
        anim.Play(Reo.name);

        if (currentallammo > 0)
        {
            isreload = true;
            print("reloaded");
            yield return new WaitForSeconds(reloaddelay);
            if (currentallammo < maxammo)
            {
                curentammo = currentallammo;
                currentallammo = 0;
            }
            else
            {
                currentallammo -= maxammo - curentammo;
                curentammo = maxammo;
            }
            isreload = false;
        }
        updateui();
    }
    public void makehole()
    {
        float randomforce = Random.Range(minholl, maxholl);
        GameObject hulerb = Instantiate(hole, holeeject.transform.position, Quaternion.identity);
        hulerb.GetComponent<Rigidbody>().AddForce(holeeject.transform.right * randomforce);
        hulerb.GetComponent<Rigidbody>().AddTorque(hulerb.transform.up * 20000, ForceMode.Impulse);
        Destroy(hulerb, 5f);
    }
public void updateui(){
        ammotext.text=currentallammo+"/"+curentammo;
    }
}
