﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    private CharacterController controller;
	
	void Start ()
    {
        controller = GetComponent<CharacterController>();
	}
	
	void Update ()
    {
        Vector3 movedir = new Vector3(Input.GetAxis("Horizontal") * 2.0f, 0.0f, Input.GetAxis("Vertical") * 2.0f);
        controller.Move(movedir * Time.deltaTime * 2.0f);
	}
}
