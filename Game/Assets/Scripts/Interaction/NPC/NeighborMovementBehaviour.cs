﻿using System.Collections;
using UnityEngine;

/// <summary>
/// Class for neighbor behaviour. Extends NPCMovementBehaviour.
/// </summary>
public class NeighborMovementBehaviour : NPCMovementBehaviour
{
    // NPC Head 
    [SerializeField] private Transform lookAt;

    // NPC rotation speed for its animation
    [SerializeField] private float rotationSpeedModifier;

    /// <summary>
    /// Coroutine used to animate the npc and the player at the sametime.
    /// Rotates the npc towards the player and the player towards the npc.
    /// </summary>
    /// <returns>Returns null.</returns>
    public override IEnumerator Behaviour()
    {
        Animator anim = GetComponent<Animator>();
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        PlayerLook playerCamera = player.GetComponentInChildren<PlayerLook>();

        anim.SetTrigger("turn");

        float elapsedTime = 0.0f;

        // Sets desired values
        Quaternion npcFrom = transform.rotation;
        Quaternion npcTo = Quaternion.LookRotation(player.transform.position -
                                                transform.position);

        Quaternion playerFrom = player.transform.rotation;
        Quaternion playerTo = Quaternion.LookRotation(transform.position -
                                                player.transform.position);

        Quaternion pCameraFrom = playerCamera.transform.rotation;
        Quaternion pCameraTo = default;
        if (lookAt != null)
            pCameraTo = Quaternion.LookRotation(lookAt.position -
                                                playerCamera.transform.position);

        // Animation for both NPC and player rotations
        while (elapsedTime < 0.5f)
        {
            // Rotates NPC
            transform.rotation = Quaternion.Slerp(npcFrom, npcTo, elapsedTime *
                rotationSpeedModifier);

            transform.eulerAngles = new Vector3(0f,
                transform.eulerAngles.y, 0f);

            // Rotates Player's Body
            player.transform.rotation = Quaternion.Slerp(playerFrom,
                playerTo, elapsedTime * rotationSpeedModifier);

            player.transform.eulerAngles = new Vector3(0f,
                player.transform.eulerAngles.y, 0f);

            // Rotates Player's Camera
            playerCamera.transform.rotation = Quaternion.Slerp(pCameraFrom,
                pCameraTo, elapsedTime * rotationSpeedModifier);

            // Moves player to desired range
            Vector3 newPosition = transform.position +
                (player.transform.position - transform.position).normalized * 3f;
            player.transform.position =
                Vector3.MoveTowards(player.transform.position,
                new Vector3(newPosition.x, player.transform.position.y,
                            newPosition.z),
                Time.deltaTime * rotationSpeedModifier * 2);


            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Sets VerticalRotation to the same as rotation.eulerAngles.X at the 
        // moment, so the camera stays exactly the same angle after the anim
        playerCamera.VerticalRotation =
            playerCamera.transform.rotation.eulerAngles.x;

        anim.SetTrigger("idle");
    }
}
