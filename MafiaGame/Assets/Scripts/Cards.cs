using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using RoleManager_mine;
using TMPro;

namespace Card
{
    public class Card : MonoBehaviour
{
    // Properties to hold the card's information
    public RoleManager.Role cardRole;            // The role assigned to this card
    public bool isFlipped = false;    // Tracks if the card is currently flipped
    
    // UI Elements
    public TextMeshProUGUI roleText;             // Text element to show the role on the card
    public Button acceptButton;       // Button to confirm the role after flipping

    // Initialization of card role and UI setup
    public void InitializeCard(RoleManager.Role role)
    {
        cardRole = role;                            // Assign role to the card
        roleText.text = role.ToString();            // Set the role text
        roleText.gameObject.SetActive(false);       // Hide role text initially
        acceptButton.gameObject.SetActive(false);   // Hide accept button initially
        Debug.Log(roleText.text);
    }

    // Method called when the card is clicked to flip it
    public void OnCardClick()
    {
        if (!isFlipped)
        {
            isFlipped = true;                       // Mark the card as flipped
            roleText.gameObject.SetActive(true);    // Show the role text
            acceptButton.gameObject.SetActive(true);// Show the accept button
            StartCoroutine(RotateCard(0, 180));     // Start rotation animation
        }
    }

    // Method called when the "Accept" button is clicked
    public void OnAcceptClick()
    {
        
        if (!isFlipped)
        {
            StartCoroutine(RotateCard(30, 0));     // Rotate back to hide the role
            acceptButton = acceptButton.GetComponent<Button>();
            // roleText.gameObject.SetActive(false);   // Hide the role text
            acceptButton.gameObject.SetActive(false); // Hide the accept button
            isFlipped = true;                      // Reset flip status

            // Disable the card after accepting the role
            GetComponent<Button>().interactable = false;
            GetComponent<Image>().color = Color.gray; // Set card color to gray
        }
        Debug.Log("kjfjkesfjsjfsbjk00");
    }

    // Coroutine to animate the rotation of the card
    private IEnumerator RotateCard(float startAngle, float endAngle)
    {
        float rotationTime = 0.5f;                  // Duration of rotation
        for (float t = 0; t < 1; t += Time.deltaTime / rotationTime)
        {
            float angle = Mathf.Lerp(startAngle, endAngle, t); // Interpolate angle
            transform.rotation = Quaternion.Euler(0, angle, 0); // Apply rotation
            yield return null;
        }
        transform.rotation = Quaternion.Euler(0, endAngle, 0); // Finalize rotation
    }
    
}

}
