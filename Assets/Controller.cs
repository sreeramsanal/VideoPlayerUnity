using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

[RequireComponent(typeof(VideoPlayer))]

public class Controller : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    public Button PlayButton;
    public Button PauseButton;
    public RectTransform ProgressBar;
    // Use this for initialization
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPlaying)
        {
            ShowPlayButton(false);
            ShowPauseButton(true);
            if (videoPlayer.frameCount < float.MaxValue)
            {
                float frame = (float)videoPlayer.frame;
                float count = (float)videoPlayer.frameCount;

                float progressPercentage = 0;

                if (count > 0)
                    progressPercentage = (frame / count) * 1550.0f;

                if (ProgressBar != null)
                    ProgressBar.sizeDelta = new Vector2((float)progressPercentage, ProgressBar.sizeDelta.y);
            }


        }
        else
        {
            ShowPlayButton(true);
            ShowPauseButton(false);
        }

        


    }
    private void ShowPlayButton(bool enable)
    {
        PlayButton.enabled = enable;
        PlayButton.GetComponent<Image>().enabled = enable;
    }
    private void ShowPauseButton(bool enable)
    {
        PauseButton.enabled = enable;
        PauseButton.GetComponent<Image>().enabled = enable;
    }
}