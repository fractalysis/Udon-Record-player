using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using ArchiTech.ProTV;

namespace RecordPlayer
{
    public class ProTVVideoModule : UdonSharpBehaviour
    {
        public TVManager tv;
        [HideInInspector] public VRCUrl url = VRCUrl.Empty;
        [HideInInspector] public bool canControlVideoPlayer;
        [HideInInspector] public bool isPlaying;
        [HideInInspector] public float length;
        [HideInInspector] public float currentTime;
        [HideInInspector] public VRCUrl currentURL = VRCUrl.Empty;

        public void _CheckURL()
        {
            currentURL = tv.url;
        }

        public void _UpdateVideoPlayerStatus()
        {
            isPlaying = (int)tv.state == 2; // PLAYING
            length = tv.videoDuration;
            currentTime = tv.currentTime;
        }

        public void _UpdateCanControlVideoPlayer()
        {
            canControlVideoPlayer = tv._IsAuthorized();
        }

        void Start()
        {
            tv._RegisterListener(this);
        }

        public void _PlayVideoViaModule()
        {
            tv._ChangeMedia(url);
        }
    }
}
