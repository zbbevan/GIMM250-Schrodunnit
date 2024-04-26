using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoClip : MonoBehaviour
{

    VideoPlayer videoPlayer;


    void Start()
    {

        videoPlayer = GetComponent<VideoPlayer>();
    }

    private void Update()
    {
        Invoke("LoadMenuScene", 27f);
    }

    void LoadMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
