using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MedalManager : MonoBehaviour
{
    public Image medalImage; // Reference to the medal image in the UI
    public Image fillImage;  // Reference to the fill image that will be animated
    public TMP_Text winText;     // Reference to the UI text element for displaying win message

    void Start()
    {
        winText.gameObject.SetActive(false); // Hide win text at the start
        fillImage.fillAmount = 0f; // Ensure fill image starts empty
    }

    public void ShowMedalWithFill()
    {
        winText.gameObject.SetActive(true); // Display win text
        StartCoroutine(AnimateMedalFill());
    }

    IEnumerator AnimateMedalFill()
    {
        float duration = 5f; // Duration of the fill effect
        float elapsedTime = 0f;

        // Ensure fill image is visible and starts empty
        fillImage.gameObject.SetActive(true);
        fillImage.fillAmount = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            fillImage.fillAmount = Mathf.Lerp(0f, 1f, t); // Animate the fill amount
            yield return null;
        }

        // Ensure the fill amount is set to 1 at the end
        fillImage.fillAmount = 1f;

        // Optionally, you can add a delay here if needed
        // StartCoroutine(ShowMedalColorFill());
    }

    // Optional: Method to show the medal color transition after the filling effect
   /* IEnumerator ShowMedalColorFill()
    {
        float duration = 5f;  // Duration of the color transition
        float elapsedTime = 0f;

        // Set the initial desaturated color (e.g., grayscale or less vibrant)
        Color initialColor = new Color(0.66f, 0.66f, 0.66f, 1f); // Example desaturated color (grayscale)

        // Set the target vibrant color (e.g., full gold)
        Color targetColor = new Color(1f, 0.84f, 0f, 1f); // Example vibrant gold color (fully opaque)

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            medalImage.color = Color.Lerp(initialColor, targetColor, t);
            yield return null;
        }

        // Ensure the final color is set
        medalImage.color = targetColor;
    } */
}
