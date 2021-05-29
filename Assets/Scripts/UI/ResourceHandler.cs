using Characters;
using Scriptables;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ResourceHandler : MonoBehaviour
    {
        [SerializeField] private Image resourceBar;
        [SerializeField] private IntegerReference max;
        
        public void UpdateResourceBar(IntegerReference integer, int amount)
        {
            var percentage = (float) integer.Value / max.Value;
            resourceBar.fillAmount = percentage;
        }
    }
}