using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonetizaonStrategy : MonoBehaviour
{
    [SerializeField] GameObject doubleMoneyAdPanel;
    [SerializeField] private float doubleMoneyAdInterval = 60f;
    [SerializeField] private float skippableAdInterval = 150f;
    void Start()
    {
        StartCoroutine(DoubleMoneyAdRoutine());
        StartCoroutine(SkippableVideoAdRoutine());
    }

    void Update()
    {
        
    }

    IEnumerator DoubleMoneyAdRoutine(){

        doubleMoneyAdPanel.SetActive(false);

        while(true){

            yield return new WaitForSeconds(doubleMoneyAdInterval);

            if(!doubleMoneyAdPanel.activeSelf){

                doubleMoneyAdPanel.SetActive(true);
            }
        }
    }

    IEnumerator SkippableVideoAdRoutine(){

        while(true){

            if(PlayerPrefs.GetInt("adsRemoved", 0) == 1){
                yield break;
            }

            yield return new WaitForSeconds(skippableAdInterval);

            GetComponent<AdsManager>().ShowSkippableAd();
        }
    }
}
