using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MinerNS
{
    public class IdleState : State
    {
        public IdleState(MinerManager minerManager) : base(minerManager)
        {
            
        }
        Timer t = new Timer(5f);
        public override IEnumerator Start()
        {
            
            t.Start();
            return base.Start();
        }

        public override IEnumerator Update()
        {
            t.Update(Time.deltaTime);
            if (!t.IsRunning)
            {
                Debug.Log("termino");
                MinerManager.SetState(new MinerNS.PatrolState(MinerManager));
            }
            return base.Update();
        }
    }
}

