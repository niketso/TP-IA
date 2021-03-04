using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] HQ hq = null;
    [SerializeField] GameObject minerPrefab = null;
    [SerializeField] GameObject explorerPrefab = null;
    [SerializeField] GameObject miners = null;
    [SerializeField] GameObject explorers = null;
    [SerializeField] int minerValue = 0;
    [SerializeField] int explorerValue = 0;
    [SerializeField] Text minerCostText = null;
    [SerializeField] Text explorerCostText = null;
    [SerializeField] Text goldText = null;
    private int currentGold;
    private Vector3 spawnPosition = Vector3.zero;

    private void Start()
    {
        currentGold = hq.GetCurrentGold();
        goldText.text = (" Current Gold : " + currentGold);
        explorerCostText.text = ("Add Explorer -" + explorerValue +"G");
        minerCostText.text = ("Add Miner -" + minerValue +"G");
    }

    private void Update()
    {       
        CurrentGoldDisplay();
       // currentGold = currentGold + hq.GetCurrentGold();
    }

    public void AddMiner()
    {
        if (currentGold >= minerValue)
        {
            hq.ExtractGold(minerValue);
            spawnPosition = PathfindingManager.Instance.GetRandomPathNodePos();
            spawnPosition.y = 1f;
            Instantiate(minerPrefab,spawnPosition,Quaternion.identity,miners.transform);
        }
    }

    public void AddExplorer()
    {
        if (currentGold >= explorerValue)
        {
            hq.ExtractGold(explorerValue);
            spawnPosition = PathfindingManager.Instance.GetRandomPathNodePos();
            spawnPosition.y = 1f;
            Instantiate(explorerPrefab, spawnPosition, Quaternion.identity, explorers.transform);
        }
    }

    public void CurrentGoldDisplay()
    {
        currentGold = hq.GetCurrentGold();
        goldText.text = (" Current Gold : " + currentGold);       
    }

    
}
