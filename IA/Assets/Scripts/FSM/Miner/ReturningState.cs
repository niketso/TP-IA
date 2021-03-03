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
        //Minermanager.miner.MoveTo(Hq)
        //Minermanager.miner.DepositGold();

        return base.Start();
    }

    public override IEnumerator Update()
    {
        if (MinerManager.currentMine)
        {
            MinerManager.SetState(new MiningState(MinerManager));
        }
        else
        {
            MinerManager.SetState(new MinerNS.PatrolState(MinerManager));
        }

        return base.Update();
    }
}
