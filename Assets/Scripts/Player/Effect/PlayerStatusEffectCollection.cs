using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Implementation.Player.Effect
{
    public class PlayerStatusEffectCollection : MonoBehaviour, IPlayerStatusEffectCollection
    {
        private List<IPlayerStatusEffect> playerStatusEffects = new List<IPlayerStatusEffect>();

        private void OnDestroy()
        {
            foreach (IPlayerStatusEffect playerStatusEffect in playerStatusEffects)
            {
                if (playerStatusEffect is MonoBehaviour monoBehaviour)
                {
                    Destroy(monoBehaviour);
                }
            }
            playerStatusEffects.Clear();
        }

        public void AddPlayerStatusEffect(IPlayerStatusEffect playerStatusEffect)
        {
            playerStatusEffects.Add(playerStatusEffect);
        }

        public void AddPlayerStatusEffect<TEffect>() where TEffect : MonoBehaviour, IPlayerStatusEffect
        {
            TEffect effect = gameObject.AddComponent<TEffect>();
            playerStatusEffects.Add(effect);
        }

        public void RemovePlayerStatusEffect(IPlayerStatusEffect playerStatusEffect)
        {
            if (!playerStatusEffects.Remove(playerStatusEffect))
            {
                throw new InvalidOperationException("Cannot remove player status effect which does not belong to this collection.");
            }
        }

        public IPlayerStatusEffect GetPlayerStatusEffect<TEffect>() where TEffect : IPlayerStatusEffect
        {
            return playerStatusEffects.FirstOrDefault(effect => effect is TEffect);
        }
    }
}
