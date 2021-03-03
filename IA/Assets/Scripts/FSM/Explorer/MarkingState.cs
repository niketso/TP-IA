using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkingState : State
{
    public MarkingState(ExplorerManager explorerManager) : base(explorerManager)
    {

    }

    public override IEnumerator Start()
    {
        //explorer.MoveTo(spot)
        //setMinePOS
        ExplorerManager.SetState(new ExplorerNS.PatrolState(ExplorerManager));

        return base.Start();
    }

    public override IEnumerator Update()
    {
        return base.Update();
    }
}
