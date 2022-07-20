using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;

public class Building : MonoBehaviour
{   
    [SerializeField] private GameObject buildingVisuals;
    [SerializeField] private GameObject buyButton, collectProfitButton, upgradeButton;
    [SerializeField] private string costRespesentation;
    [SerializeField] private int buildingLvl = 1;
    [SerializeField] private int profitMultiplier = 1;
    [SerializeField] private int upgradeCostMultiplier = 10;
    [SerializeField] BigInteger profit;
    private TMP_Text buyButtonTexT, collectProfitButtonText, upgradeButtonText;
    private bool isUnlocked = false;
    public BigInteger Cost{

        get { return BigInteger.Parse(costRespesentation);}
        set { costRespesentation = value.ToString();}
    }

    private BigInteger NextUpgradeCost{

        get{
            return buildingLvl * upgradeCostMultiplier;
        }
    }
    void Start()
    {
        buyButtonTexT = buyButton.GetComponentInChildren<TMP_Text>();
        buyButtonTexT.text = MoneyFormatter.FormatMoney(Cost);
        buyButton.SetActive(!isUnlocked);
        buildingVisuals.SetActive(isUnlocked);
        collectProfitButtonText = collectProfitButton.GetComponentInChildren<TMP_Text>();
        collectProfitButton.SetActive(isUnlocked);
        upgradeButtonText = upgradeButton.GetComponentInChildren<TMP_Text>();
        upgradeButton.SetActive(isUnlocked);

        UpdateUpgradeUI();
        StartCoroutine(MakeProfit());
    }

    
    void Update()
    {
        
    }

    public void OnBuyButton(){

        if(!isUnlocked){

            if(MoneyManager.instance.Buy(Cost)){
                isUnlocked = true;
                buildingVisuals.SetActive(isUnlocked);
                buyButton.SetActive(!isUnlocked);
                collectProfitButton.SetActive(isUnlocked);
                upgradeButton.SetActive(isUnlocked);
            }
        }

        
    }

    IEnumerator MakeProfit(){

        while(true){

            if(isUnlocked){
                profit += buildingLvl * profitMultiplier;
                UpdateProfitUI();
            }
            yield return new WaitForSecondsRealtime(1f);
        }
    }
    private void UpdateProfitUI(){

        collectProfitButtonText.text = MoneyFormatter.FormatMoney(profit);
    }

    public void OnCollectProfitButton(){

        MoneyManager.instance.AddMoney(profit);
        profit = 0;
        UpdateProfitUI();
    }

    private void UpdateUpgradeUI(){
        upgradeButtonText.text= $"^\nLVL {buildingLvl}\n{MoneyFormatter.FormatMoney(NextUpgradeCost)}";
    }

    public void OnUpgradeButton(){

        if(MoneyManager.instance.Buy(NextUpgradeCost)){

            buildingLvl += 1;
            UpdateUpgradeUI();
        }
    }
}
