﻿using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    private bool isFollowing;
    private Transform target;
    private Transform battletarget;
    private Vector3 pos;
    private Quaternion rotation;
    private float height, distance, xRotation;
    private Vector3 veloc;



    void Init()
    {
        target = GameObject.Find("Player").transform;
        battletarget = GameObject.Find("BattleTarget").transform;
        isFollowing = true;
        height = 4;
        distance = 10;
        xRotation = 45;
    }
    void Start()
    {
        Init();
    }

    void LateUpdate()
    {
        switch (Game.instance.state)
        {
            case GameState.InWorld:
                WorldCamera();
                break;

            case GameState.InBattle:
                BattleCamera();
                break;
        }
        

    }

    void BattleCamera()
    {
        rotation = Quaternion.Euler(xRotation, 0, 0);
        pos = rotation * new Vector3(0, height, -distance) + battletarget.position + new Vector3(0, 0, -6);
        if (isFollowing)
            transform.position = Vector3.SmoothDamp(transform.position, pos, ref veloc, .2f);
    }

    void WorldCamera()
    {
        rotation = Quaternion.Euler(xRotation, 0, 0);
        pos = rotation * new Vector3(0, height, -distance) + target.position + new Vector3(0, 0, -6);
        if (isFollowing)
            transform.position = Vector3.SmoothDamp(transform.position, pos, ref veloc, .2f);
    }
}
