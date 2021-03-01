using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinerNS;

public class MinerManager : StateMachine
{
    [SerializeField] public Miner miner;
    [SerializeField] public HQ hq;
    [SerializeField] public Mine[] mines;
    public Mine currentMine;

    private void Start()
    {
        SetState(new MinerNS.IdleState(this));
    }

    private void Update()
    {
        UpdateState();
    }
    
}
