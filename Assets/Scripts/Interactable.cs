﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Interactable : MonoBehaviour
{
    public UnityEvent InteractionEvent;
    public UnityEvent EndInteractionEvent;

    public SphereCollider InteractableRadiusCollision;
    private GameObject InteractableObject;

    [SerializeField]
    private string InteractableText;
    public string InteractionText //Set for accessors.
    {
        get { return InteractableText; }
        protected set { InteractableText = value; }
        //Set with 'InteractionText = "<Text String>";' in inherited methods.
    }

    private TextMeshProUGUI InteractableTextUI;

    private void Awake()
    {
        InteractableObject = this.gameObject;

        InteractableTextUI = GetComponentInChildren<TextMeshProUGUI>();
        InteractableTextUI.text = InteractableText;
        InteractableTextUI.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            InteractableTextUI.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractionEvent.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            InteractableTextUI.gameObject.SetActive(false);
            EndInteractionEvent.Invoke();
        }
    }
}