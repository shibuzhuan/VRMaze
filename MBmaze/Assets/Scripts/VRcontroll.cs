using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRcontroll : MonoBehaviour
{
    public GameObject vr;
    public GameObject ui;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void VR_Off()
    {
        //Cam_PHYRAY.enabled = true;
        vr.SetActive(false);
        ui.SetActive(true);
        //GvrReticlePointer.SetActive(false);
        StartCoroutine(VROFF());
        //UI_2D.SetActive(true);
        //UI_3D.SetActive(false);
        //yuan_dian.SetActive(false);
    }

    IEnumerator VROFF()
    {
        UnityEngine.XR.XRSettings.LoadDeviceByName("");
        yield return null;
        ResetCameras();
    }
    public void VR_on()
    {
        //Cam_PHYRAY.enabled = false;
        vr.SetActive(true);
        ui.SetActive(false);
        //GvrReticlePointer.SetActive(true);
        StartCoroutine(VRON());
        //UI_2D.SetActive(false);
        //UI_3D.SetActive(true);
        //yuan_dian.SetActive(true);
    }
    IEnumerator VRON()
    {
        UnityEngine.XR.XRSettings.LoadDeviceByName("cardboard");
        yield return null;
        UnityEngine.XR.XRSettings.enabled = true;
    }

    void ResetCameras()
    {
        // Camera looping logic copied from GvrEditorEmulator.cs
        for (int i = 0; i < Camera.allCameras.Length; i++)
        {
            Camera cam = Camera.allCameras[i];
            if (cam.enabled && cam.stereoTargetEye != StereoTargetEyeMask.None)
            {
                // Reset aspect ratio based on normal (non-VR) screen size.
                cam.ResetAspect();
                // Don't need to reset camera `fieldOfView`, since it's restored to the original value automatically.
            }
        }
    }
}
