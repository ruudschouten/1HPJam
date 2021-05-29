using Buildings;
using Characters;
using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(RawImage))]
    public class BuildingUIElement : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Sprite spriteToHold;
        [SerializeField] private SpriteRenderer heldItem;
        [SerializeField] private BaseBuilding building;

        public void OnClick()
        {
            if (player.GameState != GameState.Building)
            {
                return;
            }

            heldItem.sprite = spriteToHold;
            player.ActiveBuilding = building;
        }
    }
}