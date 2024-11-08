using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using RoleManager_mine;
using CardController;
using UnityEditor.SceneManagement;

namespace Gamemanager
{
    public class GameManager : MonoBehaviour
    {
        public GameObject cardPrefab;           // Reference to the card prefab
        public Transform cardContainer;          // Parent container for the card layout
        private int playerCount;

        void Start()
        {
            // RoleManager roleManager;
            //
            // // Define player count based on scene (adjust this according to the specific scene)
            // playerCount = 8; // or 10, or 12 based on scene
            //
            // var roles = roleManager.GetRoles(playerCount);
            // Debug.Log(roles.Count);
            // // Instantiate cards and assign roles
            // for (int i = 0; i < roles.Count; i++)
            // {
            //     GameObject card = Instantiate(cardPrefab, cardContainer);
            //     CardController.CardController cardController = card.GetComponent<CardController.CardController>();
            //     cardController.SetRole(roles[i]);
            }
        // }
    }
}

