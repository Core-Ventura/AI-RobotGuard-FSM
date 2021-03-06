﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAI : MonoBehaviour
{
    Animator anim;
    public GameObject player;
    public GameObject bullet;
    public GameObject gun;

    public GameObject GetPlayer()
    {
        return player;
    }
    void Fire()
    {
        GameObject b = Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(gun.transform.right * 1000, ForceMode.Impulse);
    }
    public void StopFiring()
    {
        CancelInvoke("Fire");
    }
    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 0.5f);
    }

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));
    }
}
