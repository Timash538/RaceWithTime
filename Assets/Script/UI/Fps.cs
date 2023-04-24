using UnityEngine;
using System.Collections;

public class Fps : MonoBehaviour
{
    private float _count;
    private float _fps;

    private IEnumerator Start()
    {
        GUI.depth = 2;
        Application.targetFrameRate = 60;
        while (true)
        {
            _fps = _count;
            _count = 0;
            yield return new WaitForSeconds(1f);
        }
    }

    private void Update()
    {
        _count++;
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.richText = true;
        GUI.Label(new Rect(5, 40, 200, 125), "<color=#FF0000><size=24>FPS: " + Mathf.Round(_fps) + "</size></color>");
    }
}