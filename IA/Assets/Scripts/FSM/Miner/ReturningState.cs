using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturningState : State
{
    public ReturningState(MinerManager minerManager) : base(minerManager)
    {

    }

    public override IEnumerator Start()
    {
        return base.Start();
    }

    public override IEnumerator Update()
    {
        return base.Update();
    }
}
