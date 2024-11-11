using Implementation.Player;
using Implementation.Player.Effect;
using UnityEngine;

namespace Implementation
{
    public class StatusEffectModifier : MonoBehaviour
    {
        private PlayerComponent _player;

        public GUIStyle GUIStyle { get; set; }

        private void Awake()
        {
            _player = FindAnyObjectByType<PlayerComponent>();
        }

        private void OnGUI()
        {
            if (GUI.Button(new Rect(10, 160, 200, 50), "Apply Boost"))
            {
                _player.StatusEffectCollection.AddPlayerStatusEffect<BoostEffect>();
            }

            if (GUI.Button(new Rect(10, 260, 200, 50), "Apply Knock Back"))
            {
                _player.StatusEffectCollection.AddPlayerStatusEffect<KnockBackEffect>();
            }
        }
    }
}
