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
            Debug.Log("PatrolStateExplorer::Start()");
            Vector3 destination = PathfindingManager.Instance.GetRandomPathNodePos();
            ExplorerManager.explorer.SetDestination(destination);
           
            return base.Start();
        }

        public override IEnumerator Update()
        {
            //find new spot to mine
            Debug.Log("PatrolStateExplorer::Update()");
            if (ExplorerManager.explorer.HasSpot())
            {

                //ExplorerManager.explorer.SpotDetection(false);
                ExplorerManager.explorer.ResetSpot();
                ExplorerManager.SetState(new MarkingState(ExplorerManager));
            }
            else
            {
                Vector3 destination = PathfindingManager.Instance.GetRandomPathNodePos();
                ExplorerManager.explorer.SetDestination(destination);
            }

            /*if (ExplorerManager.explorer.HasArrived())
            {
                Vector3 destination = PathfindingManager.Instance.GetRandomPathNodePos();
                ExplorerManager.explorer.SetDestination(destination);
            }*/
           
           
            return base.Update();
        }
    }
}

