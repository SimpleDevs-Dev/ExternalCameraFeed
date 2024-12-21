using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class WebcamSetup : MonoBehaviour
{
    private Renderer m_renderer;

    private WebCamDevice[] m_devices;       // List of detected devices
    public WebCamDevice[] devices => m_devices;
    private WebCamTexture m_webcamTexture;  // This is created every time we select a device
    private WebCamDevice m_currentDevice;   // The current device

    private void Awake() {
        m_renderer = GetComponent<Renderer>();
        m_currentDevice = new WebCamDevice();
    }

    private void Start() {
        DetectDevices();
    }

    public void DetectDevices() {
        m_devices = WebCamTexture.devices;
        for(int i = 0; i < m_devices.Length; i++) Debug.Log($"Detected device: {m_devices[i].name}");
    }

    public void SelectDevice(int i) {
        if (m_webcamTexture != null) m_webcamTexture.Stop();
        m_currentDevice = m_devices[i];
        m_webcamTexture = new WebCamTexture(m_currentDevice.name);
        GetComponent<Renderer>().material.mainTexture = m_webcamTexture;
        m_webcamTexture.Play();

        float videoRatio = (float)m_webcamTexture.width / (float)m_webcamTexture.height;
        transform.localScale = new Vector3(m_webcamTexture.width, m_webcamTexture.height, 1f);
    }
}
