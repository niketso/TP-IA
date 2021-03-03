using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MineDetector : MonoBehaviour
{
    public UnityAction<GameObject> checkCollisionMiner;
   

    private void OnTriggerEnter(Collider other)
    {
        //mine 12
        if (other.gameObject.layer == 12 )
        {
            if (checkCollisionMiner != null)
            {
                checkCollisionMiner(other.gameObject);
            }
        }
    }
}
