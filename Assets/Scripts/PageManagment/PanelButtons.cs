using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelButtons : MonoBehaviour
{
    [SerializeField] protected GameObject[] cams; //Sets up camera array for panel navigation.
 
    [SerializeField] protected Button butt1; //The left and right buttons
    [SerializeField] protected Button butt2;
    // Start is called before the first frame update
    void Start()
    {
        butt1.onClick.AddListener(LastPanel); //Adds the listener to the left button
        butt2.onClick.AddListener(NextPanel); //Adds the listener to the right button
    }


    void LastPanel() //Changes the previous panel to the active camera.
    {
        for (int i = 0; i < cams.Length; i++)
        {
            if (cams[i].activeSelf)
            {
                
                if (i == 0)
                {
                    break;
                }
                else
                {
                    cams[i].SetActive(false);
                    cams[i - 1].SetActive(true);
                }
                break;
            }
        }
    }

    void NextPanel() //Changes the next panel to the active camera.
    {
        for (int i = 0; i < cams.Length; i++)
        {
            if (cams[i].activeSelf)
            {

                if (i == cams.Length - 1)
                {
                    break;
                }
                else
                {
                    cams[i].SetActive(false);
                    cams[i + 1].SetActive(true);
                }
                break;
            }
        }
    }


}
