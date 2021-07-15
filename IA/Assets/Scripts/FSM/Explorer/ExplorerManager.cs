using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExplorerNS;

public class ExplorerManager : StateMachine
{
    [SerializeField] public Explorer explorer;
      
    private void Start()
    {
        SetState(new ExplorerNS.IdleState(this));
    }

    private void Update()
    {
        UpdateState();
    }
}
