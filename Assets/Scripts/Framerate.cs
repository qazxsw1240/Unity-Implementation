using UnityEngine;

namespace Implementation
{
    public class FrameRate : MonoBehaviour
    {
        public GUIStyle GUIStyle { get; set; }

        private void OnGUI()
        {
            float frameRate = 1 / Time.unscaledDeltaTime;
            GUI.Label(new Rect(10, 10, 100, 100), $"{frameRate} fps", GUIStyle);
        }
    }
}
