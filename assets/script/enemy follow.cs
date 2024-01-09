using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfollow : MonoBehaviour
{
    public GameObject enemy;
    public Transform player;
    [SerializeField] private float timer = 0.1f;
    private float bullettime;
    public GameObject enemybullet;
    public Transform spawnpoint;
    public float enemyspeed=1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shootatplayer();

    }
    void shootatplayer()
    {
        bullettime -= Time.deltaTime;
        if (bullettime > 0) return;
        bullettime = timer;
        GameObject bulletobj = Instantiate(enemybullet, spawnpoint.transform.position, spawnpoint.transform.rotation) as GameObject;
        Rigidbody bulletrb = bulletobj.GetComponent<Rigidbody>();

        bulletrb.AddForce(bulletrb.transform.forward * enemyspeed);

        Destroy(bulletobj, 1f);
    }
}
