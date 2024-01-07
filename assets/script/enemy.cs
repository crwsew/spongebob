using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class enemy : MonoBehaviour
{
    public float health = 30f;
    public Animation walk;
    public AnimationClip walkenemy;


    public void Takedamage(float damage)
    {
        health = -damage;
        if (health <= 0f)
        {
            die();
        }
    }
    private void die()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        walk.Play(walkenemy.name);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
