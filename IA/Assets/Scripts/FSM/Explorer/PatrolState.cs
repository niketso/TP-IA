using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExplorerNS
{
    public class PatrolState : State
    {
        public PatrolState(ExplorerManager explorerManager) : base(explorerManager)
        {
           
        }

        public override IEnumerator Start()
        {
            Debug.Log("PatrolState::Start()");
            //GetRandomPos
            
            //SetExplorerToNewPos
            //ExplorerManager.explorer.MoveTo();
            return base.Start();
        }

        public override IEnumerator Update()
        {
            //find new spot to mine
            if (ExplorerManager.explorer.HasSpot())
            {
                ExplorerManager.explorer.SpotDetection(false);
                ExplorerManager.SetState(new MarkingState(ExplorerManager));
            }
            
            return base.Update();
        }
    }
}

