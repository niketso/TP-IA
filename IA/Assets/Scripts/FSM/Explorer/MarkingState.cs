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
        //ExplorerManager.explorer.StopMoving();
       Vector3 destination =  ExplorerManager.explorer.lastSpot.transform.position;
       // ExplorerManager.explorer.SetDestination(destination);
        Spawner.Instance.ResetSpot(ExplorerManager.explorer.lastSpot);
        Spawner.Instance.CreateMine(destination);

        ExplorerManager.SetState(new ExplorerNS.PatrolState(ExplorerManager));

        return base.Start();
    }

    public override IEnumerator Update()
    {
        return base.Update();
    }
}
