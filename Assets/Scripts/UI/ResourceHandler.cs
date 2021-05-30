using System;
using Characters;
using Scriptables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ResourceHandler : MonoBehaviour
    {
        [SerializeField] private Image resourceBar;
        [SerializeField] private TMP_Text text;
        [SerializeField] private IntegerReference max;

        private void Awake()
        {
            text.SetText(max.Value.ToString());
        }

        public void UpdateResourceBar(IntegerReference integer, int amount)
        {
            text.SetText(integer.Value.ToString());
            var percentage = (float) integer.Value / max.Value;
            resourceBar.fillAmount = percentage;
        }
    }
}