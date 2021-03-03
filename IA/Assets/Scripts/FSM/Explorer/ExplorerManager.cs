using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExplorerNS;

public class ExplorerManager : StateMachine
{
    [SerializeField] public Explorer explorer;
   
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
