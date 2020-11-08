﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static TypeOfControl CurrentControl { get; private set; }
    public float ZAxis { get; private set; }
    public float XAxis { get; private set; }
    public float HorizontalMouse { get; private set; }
    public float VerticalMouse { get; private set; }
    public bool LeftClick { get; private set; }
    public bool RightClick { get; private set; }

    public static void ChangeTypeOfControl(TypeOfControl control) =>
        CurrentControl = control;


    private void Update()
    {
        switch (CurrentControl)
        {
            case TypeOfControl.InGameplay:
                Cursor.lockState = CursorLockMode.Locked;

                // Gets movement axis
                ZAxis = Input.GetAxisRaw("Vertical");
                XAxis = Input.GetAxisRaw("Horizontal");

                // Gets mouse axis
                HorizontalMouse = Input.GetAxis("Mouse X");
                VerticalMouse = Input.GetAxis("Mouse Y");

                // Gets left click
                LeftClick = Input.GetButtonDown("Fire1");

                // Gets right click
                RightClick = Input.GetButtonDown("Fire2");

                break;

            case TypeOfControl.InNPCInteraction:
                // Gets left click
                LeftClick = Input.GetButtonDown("Fire1");

                break;

            case TypeOfControl.InInventory:
                Cursor.lockState = CursorLockMode.Confined;
                // Gets right click
                RightClick = Input.GetButtonDown("Fire2");

                break;
        }
    }
}
