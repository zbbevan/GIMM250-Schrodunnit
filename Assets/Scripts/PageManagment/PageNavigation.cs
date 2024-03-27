using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PageNavigation : MonoBehaviour
{
    [SerializeField] private Button butt1;
    [SerializeField] private Button butt2;
    [SerializeField] private Button butt3;
    [SerializeField] private Button butt4;
    [SerializeField] private Button butt5;
    [SerializeField] private Button butt6;
    [SerializeField] private GameObject BigButton;


    [SerializeField] private GameObject PanelCam_1;
    [SerializeField] private GameObject PanelCam_2;
    [SerializeField] private GameObject PanelCam_3;
    [SerializeField] private GameObject PanelCam_4;
    [SerializeField] private GameObject PanelCam_5;
    [SerializeField] private GameObject PanelCam_6;
    [SerializeField] private GameObject MainCam;


    private void Start()
    {
        butt1.onClick.AddListener(() => EnterPanelCam(PanelCam_1));
        butt2.onClick.AddListener(() => EnterPanelCam(PanelCam_2));
        butt3.onClick.AddListener(() => EnterPanelCam(PanelCam_3));
        butt4.onClick.AddListener(() => EnterPanelCam(PanelCam_4));
        butt5.onClick.AddListener(() => EnterPanelCam(PanelCam_5));
        butt6.onClick.AddListener(() => EnterPanelCam(PanelCam_6));
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ExitPanelCam(PanelCam_1);
            ExitPanelCam(PanelCam_2);
            ExitPanelCam(PanelCam_3);
            ExitPanelCam(PanelCam_4);
            ExitPanelCam(PanelCam_5);
            ExitPanelCam(PanelCam_6);
        }

    }

            public void EnterPanelCam(GameObject panCam)
    {
        panCam.SetActive(true);
        BigButton.SetActive(false);
        MainCam.SetActive(false);
    }
    public void ExitPanelCam(GameObject panCam)
    {
        panCam.SetActive(false);
        BigButton.SetActive(true);
        MainCam.SetActive(true);
    }

}
