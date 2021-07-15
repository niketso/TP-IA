using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 namespace MinerNS
{
    public class PatrolState : State
    {
        public PatrolState(MinerManager minerManager) : base(minerManager)
        {

        }

        public override IEnumerator Start()
        {
           
            Debug.Log("PatrolStateMiner::Start()");
            MinerManager.miner.MineDetection(true);
            Vector3 destination = PathfindingManager.Instance.GetRandomPathNodePos();
            MinerManager.miner.SetDestination(destination);

            return base.Start();
        }

        public override IEnumerator Update()
        {
            Debug.Log("PatrolStateMiner::Update()");
            if (MinerManager.miner.HasMine())
            {
                MinerManager.miner.MineDetection(false);
                MinerManager.SetState(new MiningState(MinerManager));               
            }
            else
            {
                Vector3 destination = PathfindingManager.Instance.GetRandomPathNodePos();
                MinerManager.miner.SetDestination(destination);
            }

            return base.Update();
        }
    }
}

