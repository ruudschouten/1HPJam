using Characters;
using Combat;
using Core;
using UnityEngine;

namespace Input
{
    public class AbilityInputs : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Resource resource;
        [SerializeField] private int offensiveAbilityKey = 0;
        [SerializeField] private int secondaryOffensiveAbilityKey = 1;
        [SerializeField] private KeyCode utilityAbilityCode = KeyCode.Q;

        [SerializeField] private Ability offensiveAbility;
        [SerializeField] private Ability secondaryOffensiveAbility;
        [SerializeField] private Ability utilityAbility;

        public void Update()
        {
            if (player.GameState != GameState.Combat)
            {
                return;
            } 
            if (UnityEngine.Input.GetKeyDown(utilityAbilityCode)) { utilityAbility.Use(resource); }
        }

        public void OnMouseClick(int mouseButton)
        {
            if (player.GameState != GameState.Combat)
            {
                return;
            }

            if (mouseButton == offensiveAbilityKey)
            {
                offensiveAbility.Use(resource);
            }

            if (mouseButton == secondaryOffensiveAbilityKey)
            {
                secondaryOffensiveAbility.Use(resource);
            }
        }
    }
}