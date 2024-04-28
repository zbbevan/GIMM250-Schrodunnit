using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroChecker : MonoBehaviour
{
    [SerializeField] private GameObject freja;
    [SerializeField] private GameObject jean;
    [SerializeField] private GameObject bingus;
    [SerializeField] private GameObject stubbs;
    [SerializeField] private BoxCollider2D triggerCollider;

    void Update()
    {
        if(freja.GetComponent<IntroductionTrigger>().hasPlayed && jean.GetComponent<IntroductionTrigger>().hasPlayed && bingus.GetComponent<IntroductionTrigger>().hasPlayed && stubbs.GetComponent<IntroductionTrigger>().hasPlayed)
        {
            triggerCollider.enabled = true;
        }
    }
}
