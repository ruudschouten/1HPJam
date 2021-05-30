using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameButtons : MonoBehaviour
    {
        public void Restart(int index)
        {
            SceneManager.LoadScene(index);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}