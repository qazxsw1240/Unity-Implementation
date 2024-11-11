using Unity.VisualScripting;
using UnityEngine;

namespace Implementation
{
    public class DebugGUI : MonoBehaviour
    {
        private static readonly float NativeHeight = 1080f;

        private static DebugGUI _instance;

        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            if (_instance != null)
            {
                return;
            }
            GameObject gameObject = new GameObject("GUI", typeof(DebugGUI));
            _instance = gameObject.GetComponent<DebugGUI>();
            _instance.enabled = true;
            DontDestroyOnLoad(gameObject);
        }

        private GUIStyle _guiStyle;
        private FrameRate _frameRate;
        private StatusEffectModifier _statusEffectModifier;

        private void Awake()
        {
            _guiStyle = new GUIStyle();
            _guiStyle.fontSize = (int)(20.0f * (Screen.height / NativeHeight));

            _frameRate = gameObject.GetOrAddComponent<FrameRate>();
            _statusEffectModifier = gameObject.GetOrAddComponent<StatusEffectModifier>();

            _frameRate.GUIStyle = _guiStyle;
            _statusEffectModifier.GUIStyle = _guiStyle;
        }
    }
}
