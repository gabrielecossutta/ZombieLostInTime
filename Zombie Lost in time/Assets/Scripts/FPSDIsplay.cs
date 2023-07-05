using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    private float deltaTime;

    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    private void OnGUI()
    {
        int fps = Mathf.RoundToInt(1.0f / deltaTime);
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.normal.textColor = Color.white;
        style.fontSize = 20;
        Rect rect = new Rect(15, 15, 100, 25);
        GUI.Label(rect, "FPS: " + fps, style);
    }
}