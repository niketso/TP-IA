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
        
        MinerManager.miner.SetDestination(MinerManager.hq.deployZone.transform.position);       
        
      
        return base.Start();
    }

    public override IEnumerator Update()
    {

        if (MinerManager.hq.CanDeposit(MinerManager.miner))
        {
            if (MinerManager.miner.isFull)
            {
                Debug.Log("ReturningStateMiner::Update() Miner Full");
                //if (MinerManager.hq.CanDeposit())

                MinerManager.miner.DepositGold(MinerManager.hq);

                if (MinerManager.miner.lastMine == null)
                {
                    MinerManager.miner.SetHasMine(false);
                    MinerManager.SetState(new MinerNS.PatrolState(MinerManager));
                }
                else
                {
                    MinerManager.SetState(new MiningState(MinerManager));
                }

            }
            else if (MinerManager.miner.lastMine == null || MinerManager.miner.lastMine.IsEmpty())
            {
                Debug.Log("ReturningStateMiner::Update() volver a patrol");
                if (MinerManager.miner.currentGold == 10)
                {
                    MinerManager.miner.DepositGold(MinerManager.hq);
                }
                MinerManager.miner.lastMine = null;
                MinerManager.miner.SetHasMine(false);
                MinerManager.SetState(new MinerNS.PatrolState(MinerManager));
            }
        }
        
        
        Debug.Log("ReturningStateMiner::Update()");
        return base.Update();
    }
}
