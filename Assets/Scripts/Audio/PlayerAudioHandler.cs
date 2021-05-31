using Characters;
using UnityEngine;

namespace Audio
{
    public class PlayerAudioHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        [SerializeField] private AudioClip bulletClip;
        [SerializeField] private AudioClip tramplingClip;
        [SerializeField] private AudioClip reachedKitchenClip;
        [SerializeField] private AudioClip drownedClip;

        private bool _playedDeathAudio;
        
        public void PlayAudioForDeath(DeathCause cause)
        {
            if (_playedDeathAudio) return;
            
            switch (cause)
            {
                case DeathCause.Bullet:
                    source.clip = bulletClip;
                    break;
                case DeathCause.Trampled:
                    source.clip = tramplingClip;
                    break;
                case DeathCause.ReachedKitchen:
                    source.clip = reachedKitchenClip;
                    break;
                case DeathCause.Drowned:
                    source.clip = drownedClip;
                    break;
            }

            source.Play();
            _playedDeathAudio = true;
        }
    }
}