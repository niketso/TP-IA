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
        Debug.Log("ReturningStateMiner::Start()");
        //falta nueva situacion si es que no hay mas para minar. 
        // MinerManager.miner.SetDestination(MinerManager.hq.transform.position);
        //MinerManager.miner.DepositGold(MinerManager.hq);
        return base.Start();
    }

    public override IEnumerator Update()
    {
        if (/*!MinerManager.miner.lastMine.IsEmpty()*/true)
        {
            MinerManager.miner.DepositGold(MinerManager.hq);
            MinerManager.SetState(new MiningState(MinerManager));
        }
        else
        {
            //MinerManager.SetState(new MiningState(MinerManager));
            MinerManager.SetState(new MinerNS.PatrolState(MinerManager));
        }

        return base.Update();
    }
}
