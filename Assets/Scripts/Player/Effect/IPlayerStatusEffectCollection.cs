using UnityEngine;

namespace Implementation.Player.Effect
{
    public interface IPlayerStatusEffectCollection
    {
        public void AddPlayerStatusEffect(IPlayerStatusEffect playerStatusEffect);

        public void AddPlayerStatusEffect<TEffect>() where TEffect : MonoBehaviour, IPlayerStatusEffect;

        public void RemovePlayerStatusEffect(IPlayerStatusEffect playerStatusEffect);

        public IPlayerStatusEffect GetPlayerStatusEffect<TEffect>() where TEffect : IPlayerStatusEffect;
    }
}
