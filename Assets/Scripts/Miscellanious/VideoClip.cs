using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoClip : MonoBehaviour
{
    //This script plays the opening animation at the start of the comic.
    VideoPlayer videoPlayer;


    void Start()
    {

        videoPlayer = GetComponent<VideoPlayer>(); //Get the video player component
    }

    private void Update()
    {
        Invoke("LoadMenuScene", 27f); //The animation is 27 seconds long, so this opens the menu after it ends.
    }

    void LoadMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu"); //Scene manager has been broken this whole project so I have to type the whole UnityEngine crap every time.
    }
}
