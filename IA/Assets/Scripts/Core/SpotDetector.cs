using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpotDetector : MonoBehaviour
{
    public UnityAction<GameObject> checkCollisionExplorer;


    private void OnTriggerEnter(Collider other)
    {
        //spot 11
        
        if (other.gameObject.layer == 11)
        {
            if (checkCollisionExplorer != null)
            {
                checkCollisionExplorer(other.gameObject);
            }
        }
    }
}
