using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    GameObject Player;

    private void Awake()
    {
        Player = GameObject.Find("Player");
    }
    public void BLeft()
    {
        Player.GetComponent<NewBehaviourScript>().Left();
    }

    public void BRight()
    {
        Player.GetComponent<NewBehaviourScript>().Right();
    }

    public void BJump()
    {
        Player.GetComponent<NewBehaviourScript>().Jump();
    }
}
