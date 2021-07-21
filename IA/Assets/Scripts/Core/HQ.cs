using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQ : MonoBehaviour
{
    [SerializeField] private int maxCapacity = 0;
    [SerializeField] private int currentGold = 0;    
    [SerializeField] public GameObject deployZone = null;
    public bool canDeposit = false;

    public bool DepositGold(Miner miner)
    {
        if (currentGold < maxCapacity)
        {
            currentGold += miner.currentGold;
            miner.currentGold = 0;
            miner.isFull = false;
            canDeposit = false;
            Debug.Log("HQ::DepositGold. Gold deposited");
            return true;
        }
        else
        {
            Debug.Log("HQ::DepositGold. Not enought capacity to store in the deposit");
            return false;
        }
    }

    public bool CanDeposit(Miner miner)
    {

        //canDeposit = deployZone.GetComponent<DeployZone>().deposit;
        float dist = Vector3.Distance(miner.transform.position, deployZone.transform.position);
        Debug.Log("Dist");
        Debug.Log(dist);
        if (dist < 2.0f)
        {
            Deposit();
        }
        if (canDeposit)
        {
            Debug.Log("HQ::CanDeposit. Yes");
            //deployZone.GetComponent<DeployZone>().deposit = false;
            return true;
        }
        else
        {
            Debug.Log("HQ::CanDeposit. No");
           // deployZone.GetComponent<DeployZone>().deposit = false;
            return false;
        }
        
    }

    public int GetCurrentGold()
    {
        return currentGold;
    }

    public void ExtractGold(int value)
    {
        currentGold -= value;
    }

    public void Deposit()
    {
        canDeposit = true;
    }
    
}
