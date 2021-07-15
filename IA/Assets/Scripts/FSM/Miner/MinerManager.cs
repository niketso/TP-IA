using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinerNS;

public class MinerManager : StateMachine
{
    [SerializeField] public Miner miner;
    [SerializeField] public HQ hq;

       
    private void Start()
    {
        SetState(new MinerNS.IdleState(this));
        hq = FindObjectOfType<HQ>();
    }

    private void Update()
    {
        UpdateState();
    }
    
}
