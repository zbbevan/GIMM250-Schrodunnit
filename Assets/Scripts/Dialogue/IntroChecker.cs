using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroChecker : MonoBehaviour
{
    [SerializeField] private GameObject freyja;
    [SerializeField] private GameObject jean;
    [SerializeField] private GameObject bingus;
    [SerializeField] private GameObject stubbs;
    [SerializeField] private BoxCollider2D triggerCollider;

    private void Awake()
    {
        triggerCollider.enabled = false;
    }
   private void Update()
    {
        if (freyja.GetComponent<IntroductionTrigger>().hasPlayed && jean.GetComponent<IntroductionTrigger>().hasPlayed && bingus.GetComponent<IntroductionTrigger>().hasPlayed && stubbs.GetComponent<IntroductionTrigger>().hasPlayed)
        {
            triggerCollider.enabled = true;
        }
    }
}
