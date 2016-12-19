using UnityEngine;
using System.Collections;

public class FPS : MonoBehaviour
{
    float deltaTime = 0.0f;
    float curSpeed2 = 0.0f;
    private float startTime;
    private float elapsedTime;

    void Start()
    {
        startTime = 0;
    }

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        RAIN.Core.AIRig rig = RAIN.Core.AIRig.FindRig(gameObject);
        curSpeed2 = rig.AI.WorkingMemory.GetItem<float>("speed");
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 50;
        style.normal.textColor = Color.white;
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);

        GUIStyle style2 = new GUIStyle();

        Rect rect2 = new Rect(0, 0, w, h * 2 / 100);
        style2.alignment = TextAnchor.UpperCenter;
        style2.fontSize = h * 2 / 50;
        style2.normal.textColor = Color.white;
        float displaySpeed = curSpeed2 * 0.044704F/2;
        string text2 = string.Format("Speed: {0:0.0} MPH", displaySpeed);
        GUI.Label(rect2, text2, style2);

        GUIStyle style3 = new GUIStyle();

        Rect rect3 = new Rect(0, 0, w, h * 2 / 100);
        style3.alignment = TextAnchor.UpperRight;
        style3.fontSize = h * 2 / 50;
        style3.normal.textColor = Color.white;
        float displayTime = Time.time - startTime;
        string text3 = string.Format("Elapsed Time: {0:0.0} Seconds", displayTime);
        GUI.Label(rect3, text3, style3);
    }
}