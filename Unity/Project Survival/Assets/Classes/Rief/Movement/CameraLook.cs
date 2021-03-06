﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {

    public float speedH;
    public float speedV;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private Transform player;

    void Start() {
        player = transform.parent;
    }

    void Update() {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis ("Mouse Y");
        player.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        transform.eulerAngles = new Vector3 (Mathf.Clamp (pitch, -90f, 90f), yaw, 0.0f); //issues met locken op de clamps die zijn aangegeven.
    }
}
