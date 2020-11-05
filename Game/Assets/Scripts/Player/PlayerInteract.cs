﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] private byte interactDistance; 

    // Components
    private PlayerInput input;
    private PlayerRays ray;


    private void Start()
    {
        input = GetComponent<PlayerInput>();
        ray = GetComponent<PlayerRays>();
    }

    private void Update()
    {
        if (input.LeftClick)
        {
            if (Physics.Raycast(ray.Forward, out RaycastHit hit, 
                interactDistance))
            {
                if (hit.collider.gameObject.TryGetComponent
                    (out IInterectableController other))
                {
                    other.RunCoroutine();
                }
            }
        }
    }
}