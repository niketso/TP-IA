using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQ : MonoBehaviour
{
    [SerializeField] private int maxCapacity = 0;
    [SerializeField] private int currentGold = 0;

    public bool DepositGold(Miner miner)
    {
        if (currentGold < maxCapacity)
        {
            currentGold += miner.currentGold;
            miner.currentGold = 0;
            Debug.Log("HQ::DepositGold. Gold deposited");
            return true;
        }
        else
        {
            Debug.Log("HQ::DepositGold. Not enought capacity to store in the deposit");
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Deposit::OTE. Arrived to Deposit");
           // minerManager.SetState(new DepositingGoldState(minerManager));
        }
    }
}
