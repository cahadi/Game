using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    void Start()
    {
        _videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if(vp == _videoPlayer)
            vp.enabled = false;
    }
}
