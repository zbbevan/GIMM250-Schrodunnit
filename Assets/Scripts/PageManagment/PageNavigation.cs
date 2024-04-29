using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PageNavigation : MonoBehaviour
{
    /*This script controls the camera navigation from each panel to the big camera that oversees the whole page. I realize I could redo this using 
    array objects, like I did on the panel-to-panel navigation script, but that would require me to also redo the methods that change the 
    active cameras, so I opted to leave this script as it.*/

    [SerializeField] private Button butt1;
    [SerializeField] private Button butt2;
    [SerializeField] private Button butt3;
    [SerializeField] private Button butt4;
    [SerializeField] private Button butt5;
    [SerializeField] private Button butt6;
    [SerializeField] private Button ExitButton;
    [SerializeField] private GameObject BigButton;
    [SerializeField] private Button LeftButt;
    [SerializeField] private Button RightButt;


    [SerializeField] private GameObject PanelCam_1;
    [SerializeField] private GameObject PanelCam_2;
    [SerializeField] private GameObject PanelCam_3;
    [SerializeField] private GameObject PanelCam_4;
    [SerializeField] private GameObject PanelCam_5;
    [SerializeField] private GameObject PanelCam_6;
    [SerializeField] private GameObject MainCam;
    [SerializeField] private BoxCollider2D[] triggerBlocks;


    private void Start() //I know this is not at "optimal" as making a for loop would be, but it's what I did at the time.
                         //I didn't figure out the array and for loop strategy until I did the panel-nav script.
    {
        butt1.onClick.AddListener(() => EnterPanelCam(PanelCam_1));
        butt2.onClick.AddListener(() => EnterPanelCam(PanelCam_2));
        butt3.onClick.AddListener(() => EnterPanelCam(PanelCam_3));
        butt4.onClick.AddListener(() => EnterPanelCam(PanelCam_4));
        butt5.onClick.AddListener(() => EnterPanelCam(PanelCam_5));
        butt6.onClick.AddListener(() => EnterPanelCam(PanelCam_6));
        ExitButton.onClick.AddListener(ExitAllPanels);
    }    

     public void EnterPanelCam(GameObject panCam)
    {
        panCam.SetActive(true);
        BigButton.SetActive(false);
        ExitButton.gameObject.SetActive(true);
        MainCam.SetActive(false);
        LeftButt.gameObject.SetActive(true);
        RightButt.gameObject.SetActive(true);

        for (int i = 0; i < triggerBlocks.Length; i++)
        {
            triggerBlocks[i].enabled = true;
        }
    }
    public void ExitPanelCam(GameObject panCam)
    {
        panCam.SetActive(false);
        BigButton.SetActive(true);
        ExitButton.gameObject.SetActive(false);
        MainCam.SetActive(true);
        LeftButt.gameObject.SetActive(false);
        RightButt.gameObject.SetActive(false);
        for (int i = 0; i < triggerBlocks.Length; i++)
        {
            triggerBlocks[i].enabled = false;
        }
    }

    public void ExitAllPanels()
    {
        ExitPanelCam(PanelCam_1);
        ExitPanelCam(PanelCam_2);
        ExitPanelCam(PanelCam_3);
        ExitPanelCam(PanelCam_4);
        ExitPanelCam(PanelCam_5);
        ExitPanelCam(PanelCam_6);
    }
}
