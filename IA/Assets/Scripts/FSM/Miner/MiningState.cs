using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningState : State
{
    public MiningState(MinerManager minerManager) : base(minerManager)
    {

    }

    public override IEnumerator Start()
    {

        //MinerManager.miner.StopMoving();
        //Mine mine = MinerManager.miner.lastMine;
       // MinerManager.miner.SetDestination(mine.transform.position);
       // MinerManager.miner.Mine(mine);

        return base.Start();
    }

    public override IEnumerator Update()
    {
        Debug.Log("MiningStateMiner::Update()");
        if (!MinerManager.miner.CanMine(MinerManager.miner.lastMine) || !MinerManager.miner.HasCapacity() || !MinerManager.miner.lastMine.IsActive())
        {
            MinerManager.SetState(new ReturningState(MinerManager));
        }
        else
        {
            MinerManager.miner.Mine(MinerManager.miner.lastMine);
        }

        return base.Update();
    }
}
