using UnityEngine;

namespace Audio
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        private void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
            PlayMusic();
        }

        public void PlayMusic()
        {
            if (audioSource.isPlaying) return;
            audioSource.Play();
        }

        public void StopMusic()
        {
            audioSource.Stop();
        }
    }
}