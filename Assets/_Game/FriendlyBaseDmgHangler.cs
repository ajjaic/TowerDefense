using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBaseDmgHangler : MonoBehaviour
{
    [SerializeField] private BaseHealthChangeEvent baseHealthChangeEvent;
    [SerializeField] private int baseHealth = 10;

    // messages
    private void Start()
    {
        baseHealthChangeEvent.RaiseEvent(baseHealth); 
    }
    
    private void OnTriggerEnter(Collider other)
    {
        baseHealth -= 1;
        baseHealthChangeEvent.RaiseEvent(baseHealth);
    }
}