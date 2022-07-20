using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private static string androidId = "4849030";
    [SerializeField] private static string doubleMoneyVideoPlacementId="doubleMoneyVideo";
    [SerializeField] private static string skippableVideoPlacementId= "SkippableVideo";
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(androidId);
    }

    public void ShowDoubleMoneyAd(){

        Advertisement.Show(doubleMoneyVideoPlacementId);
    }

    public void ShowSkippableAd(){
        Advertisement.Show(skippableVideoPlacementId);
    }

    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {

        if (showResult == ShowResult.Finished){

            if(placementId == doubleMoneyVideoPlacementId){
                MoneyManager.instance.AddMoney(MoneyManager.instance.Money);
            }
        }
        
    }

    public void OnUnityAdsReady (string placementId) {
       
    }

    public void OnUnityAdsDidError (string message) {
        
    }

    public void OnUnityAdsDidStart (string placementId) {
       
    }


}
