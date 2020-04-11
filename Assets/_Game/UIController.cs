using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private BaseHealthChangeEvent baseHealthChangeEvent;
    [SerializeField] private ScoreChangedEvent scoreChangedEvent;
    [SerializeField] private Text baseHealthUITxt;
    [SerializeField] private Text scoreUITxt;
    private int _score;

    // messages
    private void Start()
    {
        scoreUITxt.text = "score: " + 0;
    }

    private void OnEnable()
    {
        baseHealthChangeEvent.BaseHealthChangeInstance += OnBaseHealthChange;
        scoreChangedEvent.ScoreChangedInstance += OnScoreChange;
    }

    private void OnDisable()
    {
        scoreChangedEvent.ScoreChangedInstance -= OnScoreChange;
        baseHealthChangeEvent.BaseHealthChangeInstance -= OnBaseHealthChange;
    }

    private void OnScoreChange(int scoredelta)
    {
        _score += scoredelta;
        scoreUITxt.text = "score: " + _score;
    }
    
    private void OnBaseHealthChange(int newHealth)
    {
        baseHealthUITxt.text = "base health: " + newHealth;
    }
}
