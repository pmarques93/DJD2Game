﻿using System.Collections;
using UnityEngine;
public abstract class Interaction_CR : MonoBehaviour, IInteractable
{
    protected Coroutine ThisCoroutine { private get; set;}
    public void InteractionAction()
    {
        if (ThisCoroutine == null)
            ThisCoroutine = StartCoroutine(CoroutineInteraction());
    }

    protected abstract IEnumerator CoroutineInteraction();
}