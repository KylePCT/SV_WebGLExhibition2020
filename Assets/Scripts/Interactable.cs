﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Interactable : MonoBehaviour
{
    public GameObject Player;
    public bool ShowMouse = false;

    public UnityEvent InteractionEvent;
    public UnityEvent EndInteractionEvent;

    public SphereCollider InteractableRadiusCollision;
    private GameObject InteractableObject;

    private bool HasText;

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

        if (this.gameObject.GetComponentInChildren<TextMeshProUGUI>())
        {
            HasText = true;
            InteractableTextUI = GetComponentInChildren<TextMeshProUGUI>();
            InteractableTextUI.text = InteractableText;
            InteractableTextUI.gameObject.SetActive(false);
        }
        else
        {
            HasText = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (HasText)
            {
                InteractableTextUI.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractionEvent.Invoke();

            if (ShowMouse)
            {
                Player.GetComponent<FirstPersonAIO>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }

        if (InteractableObject.GetComponentInChildren<UnityEngine.Video.VideoPlayer>() != null)
        {
            if (InteractableObject.GetComponentInChildren<UnityEngine.Video.VideoPlayer>().isPlaying)
            {
                InteractableTextUI.text = InteractableText;
                InteractableTextUI.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            EndInteractionEvent.Invoke();

            if (HasText)
            {
                InteractableTextUI.gameObject.SetActive(false);
            }
        }
    }

    public void ReenableMouse()
    {
        Player.GetComponent<FirstPersonAIO>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void DisplayLoadingText()
    {
        if (InteractableObject.GetComponentInChildren<UnityEngine.Video.VideoPlayer>() != null)
        {
            if (InteractableObject.GetComponentInChildren<UnityEngine.Video.VideoPlayer>().isPlaying == false && HasText)
            {
                InteractableTextUI.SetText("Loading...");
            }
            else
            {
                InteractableTextUI.text = InteractableText;
                InteractableTextUI.gameObject.SetActive(false);
            }
        }
    }

}
