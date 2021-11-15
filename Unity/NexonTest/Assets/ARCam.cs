/* 
*   NatCorder ARFoundation Integration
*   Copyright (c) 2021 Yusuf Olokoba.
*/

namespace NatSuite.Examples {

    using UnityEngine;
    using NatSuite.Recorders;
    using NatSuite.Recorders.Clocks;
    using NatSuite.Recorders.Inputs;
    using NatSuite.Sharing;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    using System.IO;

    public sealed class ARCam : MonoBehaviour {
        
        [Header(@"Recording")]
        public Camera videoCamera;
        public int videoWidth = 1440;
        public Button videoMsgBtn;
        private MP4Recorder recorder;
        private Coroutine recordVideoCoroutine;
        private CameraInput cameraInput;
        private string lastVideoPath;

        void DelayVideo()
        {
            videoMsgBtn.gameObject.SetActive(false);
        }

        #region --Recording--
        
        public void StartRecording () {
            // Compute the video width dynamically to match the screen's aspect ratio
            var videoHeight = (int)(videoWidth / videoCamera.aspect);
            videoHeight = videoHeight >> 1 << 1; // Ensure divisible by 2
            // Create recorder and camera input
            var clock = new RealtimeClock();
            recorder = new MP4Recorder(videoWidth, videoHeight, 30);
            // On Android, create an optimized texture input for better performance
            if (Application.platform == RuntimePlatform.Android)
            {
                var textureInput = new GLESTextureInput(recorder, multithreading: true);
                cameraInput = new CameraInput(textureInput, clock, videoCamera);
            }
            // Otherwise create the camera input directly
            else
                cameraInput = new CameraInput(recorder, clock, videoCamera);
        }

        public async void StopRecording () {
            // Stop camera input and recorder
            cameraInput.Dispose();
            lastVideoPath = await recorder.FinishWriting();
            //save video to gallery
            NativeGallery.Permission permission = NativeGallery.SaveVideoToGallery(lastVideoPath, "CameraTest", "testVideo.mp4", (success, path) => Debug.Log("Media save result: " + success + " " + path));
            // string filepath = Application.persistentDataPath + lastVideoPath;
            // var prefix = Application.platform == RuntimePlatform.Android ? "file://" : "";
            videoMsgBtn.gameObject.SetActive(true);
            Invoke("DelayVideo", 3f);
        }
        #endregion


        #region --Sharing--
        
        public void ShareRecording () {
            // Create a share payload with video path
            var payload = new SharePayload();
            payload.AddMedia(lastVideoPath);
            // Present native share dialog
            payload.Commit();
        }
        #endregion
    }
}