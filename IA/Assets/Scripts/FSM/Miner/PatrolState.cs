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
            //GetRandomPOS
            //Minermanager.miner.MoveTo(pos);

            return base.Start();
        }

        public override IEnumerator Update()
        {

            if (MinerManager.miner.HasMine())
            {
                MinerManager.SetState(new MiningState(MinerManager));
                MinerManager.miner.MineDetection(false);
            }
            return base.Update();
        }
    }
}

