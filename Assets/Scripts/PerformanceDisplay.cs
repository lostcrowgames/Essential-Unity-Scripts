using UnityEngine;
using UnityEngine.UI;
using System;

public class PerformanceDisplay : MonoBehaviour
{
    public Text performanceText;

    private float deltaTime = 0.0f;

    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    private void OnGUI()
    {
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        long memory = GC.GetTotalMemory(false) / 1024 / 1024; // Convert to MB

        int activeObjects = GameObject.FindObjectsOfType<GameObject>().Length;

        string text = string.Format("{0:0.0} ms ({1:0.} fps)\nMemory: {2} MB\nActive Objects: {3}", msec, fps, memory, activeObjects);
        performanceText.text = text;
    }
}
