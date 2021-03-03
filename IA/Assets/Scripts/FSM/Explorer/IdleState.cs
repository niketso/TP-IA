using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExplorerNS
{
    public class IdleState : State
    {
        Timer t = new Timer(5f);

        public IdleState(ExplorerManager explorerManager) : base(explorerManager)
        {
            
        }

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
                ExplorerManager.SetState(new ExplorerNS.PatrolState(ExplorerManager));
            }

            return base.Update();
        }

    }
}


