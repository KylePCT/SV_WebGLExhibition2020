using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayer : MonoBehaviour
{
    VideoPlayer vidReference;
    string url;
    public GameObject VideoToPlay;

    private void Awake()
    {
        VideoPlayer vidReference = GetComponent<VideoPlayer>();
        url = Application.streamingAssetsPath + "/" + VideoToPlay.name + ".mp4";
    }
}
