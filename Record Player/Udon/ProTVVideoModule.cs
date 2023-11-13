using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using ArchiTech;

namespace RecordPlayer
{
    public class ProTVVideoModule : UdonSharpBehaviour
    {
        public TVManagerV2 tv;
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
            isPlaying = tv.currentState == 1; // PLAYING
            length = tv.videoDuration;
            currentTime = tv.currentTime;
        }

        public void _UpdateCanControlVideoPlayer()
        {
            canControlVideoPlayer = tv._IsPrivilegedUser();
        }

        void Start()
        {
            tv._RegisterUdonSharpEventReceiver(this);
        }

        public void _PlayVideoViaModule()
        {
            tv._ChangeMediaTo(url);
        }
    }
}