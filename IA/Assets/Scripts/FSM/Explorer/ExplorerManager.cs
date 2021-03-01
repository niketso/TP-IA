using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExplorerNS;

public class ExplorerManager : StateMachine
{
    [SerializeField] public Miner miner;
    [SerializeField] public HQ hq;
    [SerializeField] public Mine[] mines;
    public Mine currentMine;

    private void Start()
    {
        SetState(new ExplorerNS.IdleState(this));
    }

    private void Update()
    {
        UpdateState();
    }
}
