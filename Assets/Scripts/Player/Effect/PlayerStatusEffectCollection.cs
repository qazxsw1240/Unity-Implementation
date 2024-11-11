using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Implementation.Player.Effect
{
    public class PlayerStatusEffectCollection : MonoBehaviour, IPlayerStatusEffectCollection
    {
        private readonly List<IPlayerStatusEffect> _playerStatusEffects = new List<IPlayerStatusEffect>();

        private void OnDestroy()
        {
            foreach (IPlayerStatusEffect playerStatusEffect in _playerStatusEffects)
            {
                if (playerStatusEffect is MonoBehaviour monoBehaviour)
                {
                    Destroy(monoBehaviour);
                }
            }
            _playerStatusEffects.Clear();
        }

        public void AddPlayerStatusEffect(IPlayerStatusEffect playerStatusEffect)
        {
            _playerStatusEffects.Add(playerStatusEffect);
        }

        public void AddPlayerStatusEffect<TEffect>() where TEffect : MonoBehaviour, IPlayerStatusEffect
        {
            TEffect effect = gameObject.AddComponent<TEffect>();
            _playerStatusEffects.Add(effect);
        }

        public void RemovePlayerStatusEffect(IPlayerStatusEffect playerStatusEffect)
        {
            if (!_playerStatusEffects.Remove(playerStatusEffect))
            {
                throw new InvalidOperationException("Cannot remove player status effect which does not belong to this collection.");
            }
        }

        public IPlayerStatusEffect GetPlayerStatusEffect<TEffect>() where TEffect : IPlayerStatusEffect
        {
            return _playerStatusEffects.FirstOrDefault(effect => effect is TEffect);
        }
    }
}
