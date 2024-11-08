using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using RoleManager_mine;

namespace CardController
{
    public class CardController : MonoBehaviour
    {
        public Text roleText;           // UI Text element to show the role
        public Button acceptButton;      // Button to confirm the role after revealing
        private RoleManager.Role assignedRole;       // Role assigned to this card
        private bool isFlipped = false;  // Tracks if the card is flipped

        public void SetRole(RoleManager.Role role)
        {
            assignedRole = role;
            roleText.text = assignedRole.ToString();
            roleText.gameObject.SetActive(false);  // Initially hide the role text
            acceptButton.gameObject.SetActive(false); // Hide accept button initially
        }

        // Function to handle flipping the card
        public void OnCardClick()
        {
            if (!isFlipped)
            {
                isFlipped = true;
                roleText.gameObject.SetActive(true);
                acceptButton.gameObject.SetActive(true);
                StartCoroutine(RotateCard(0, 180));
            }
        }

        // Function to handle accepting the role
        public void OnAcceptClick()
        {
            if (isFlipped)
            {
                StartCoroutine(RotateCard(180, 0));
                roleText.gameObject.SetActive(false);
                acceptButton.gameObject.SetActive(false);
                isFlipped = false;

                // Disable the card after accepting the role
                GetComponent<Button>().interactable = false;
                GetComponent<Image>().color = Color.gray; // Graying out the card
            }
        }

        // Coroutine to rotate the card
        private IEnumerator RotateCard(float startAngle, float endAngle)
        {
            float rotationTime = 0.5f;
            for (float t = 0; t < 1; t += Time.deltaTime / rotationTime)
            {
                float angle = Mathf.Lerp(startAngle, endAngle, t);
                transform.rotation = Quaternion.Euler(0, angle, 0);
                yield return null;
            }
            transform.rotation = Quaternion.Euler(0, endAngle, 0);
        }
    }    
}

