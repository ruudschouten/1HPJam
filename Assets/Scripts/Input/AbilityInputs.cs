using Combat;
using Events;
using UnityEngine;

namespace Input
{
    public class AbilityInputs : MonoBehaviour
    {
        [SerializeField] private KeyCode offensiveAbilityCode = KeyCode.E;
        [SerializeField] private KeyCode defensiveAbilityCode = KeyCode.R;
        [SerializeField] private KeyCode mobilityAbilityCode = KeyCode.LeftShift;
        [SerializeField] private KeyCode utilityAbilityCode = KeyCode.Q;

        [SerializeField] private Ability offensiveAbility;
        [SerializeField] private Ability defensiveAbility;
        [SerializeField] private Ability mobilityAbility;
        [SerializeField] private Ability utilityAbility;

        [SerializeField] private KeyCodeEvent onKeyPress;

        public void Update()
        {
            if (UnityEngine.Input.GetKeyDown(offensiveAbilityCode)) { offensiveAbility.Use(); }
            if (UnityEngine.Input.GetKeyDown(defensiveAbilityCode)) { defensiveAbility.Use(); }
            if (UnityEngine.Input.GetKeyDown(mobilityAbilityCode)) { mobilityAbility.Use(); }
            if (UnityEngine.Input.GetKeyDown(utilityAbilityCode)) { utilityAbility.Use(); }
        }
    }
}