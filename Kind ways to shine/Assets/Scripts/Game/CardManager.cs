using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public List<Image> cardImages; // List of card images
    public List<Transform> cardStartPositions; // List of individual start positions for each card
    public List<Image> targetBoxes; // List of blue boxes
    public List<int> correctOrder; // Define the correct order of card indexes

    private List<int> placedOrder = new List<int>(); // Track the order of placed cards
    private int nextBoxIndex = 0; // Tracks the next available box

    public TMP_Text loseText;  // Reference to the UI text element for displaying loss message
    public Image medalImage; // Reference to the medal image in the UI
    private MedalManager medalManager; // Reference to the medal manager script

    void Start()
    {
        ResetCards();
        medalManager = GameObject.FindObjectOfType<MedalManager>();
        loseText.gameObject.SetActive(false); // Hide lose text at the start
        medalImage.gameObject.SetActive(false); // Hide the medal at the start
    }

    public void OnCardClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Image clickedCard = GetCardAtPosition(mousePosition);

            if (clickedCard != null && nextBoxIndex < targetBoxes.Count)
            {
                clickedCard.transform.position = targetBoxes[nextBoxIndex].transform.position;
                placedOrder.Add(cardImages.IndexOf(clickedCard));

                nextBoxIndex++;

                if (nextBoxIndex == targetBoxes.Count)
                {
                    CheckWinCondition();
                }
            }
        }
    }

    private Image GetCardAtPosition(Vector2 position)
    {
        foreach (var card in cardImages)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(card.rectTransform, position))
            {
                return card;
            }
        }
        return null;
    }

    public void ResetCards()
    {
        nextBoxIndex = 0;
        placedOrder.Clear();

        List<Transform> shuffledPositions = new List<Transform>(cardStartPositions);
        ShuffleList(shuffledPositions);

        for (int i = 0; i < cardImages.Count; i++)
        {
            cardImages[i].transform.position = shuffledPositions[i].position;
        }
    }

    void ShuffleList(List<Transform> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Transform temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    void CheckWinCondition()
    {
        if (placedOrder.Count != correctOrder.Count)
        {
            Debug.LogError("The number of placed cards doesn't match the correct number of cards.");
            return;
        }

        bool isCorrect = true;
        for (int i = 0; i < correctOrder.Count; i++)
        {
            if (placedOrder[i] != correctOrder[i])
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            Debug.Log("You win!");
            medalManager.ShowMedalWithFill();
           // StartCoroutine(ShowMedalWithFill());
        }
        else
        {
            Debug.Log("You lose!");
            StartCoroutine(HandleLoss());
        }
    }

    IEnumerator HandleLoss()
    {
        // Display "You Lose" text
        loseText.gameObject.SetActive(true);

        // Wait for a couple of seconds
        yield return new WaitForSeconds(2f);

        // Hide the lose text
        loseText.gameObject.SetActive(false);

        // Animate the cards back to their random positions
        StartCoroutine(AnimateCardsBack());
    }

    IEnumerator AnimateCardsBack()
    {
        List<Transform> shuffledPositions = new List<Transform>(cardStartPositions);
        ShuffleList(shuffledPositions);

        // Animate each card back to a random start position
        for (int i = 0; i < cardImages.Count; i++)
        {
            StartCoroutine(MoveCardToPosition(cardImages[i].rectTransform, shuffledPositions[i].position, 1f));
        }

        // Wait for the animations to finish
        yield return new WaitForSeconds(1f);

        // Reset game after cards transition
        ResetCards();
    }

    IEnumerator MoveCardToPosition(RectTransform card, Vector3 targetPosition, float duration)
    {
        Vector3 startPosition = card.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            card.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        card.position = targetPosition;
    }

   /* IEnumerator ShowMedalWithFill()
    {
        medalImage.gameObject.SetActive(true);  // Show the medal
        float duration = 5f;  // 5 seconds to fill the color
        float elapsedTime = 0f;

        // Set the initial desaturated color (e.g., grayscale or less vibrant)
        Color initialColor = new Color(0.66f, 0.66f, 0.66f, 1f); // Example desaturated color (grayscale)

        // Set the target vibrant color (e.g., full gold)
        Color targetColor = new Color(1f, 0.84f, 0f, 1f); // Example vibrant gold color (fully opaque)

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            // Interpolate the color based on elapsed time
            medalImage.color = Color.Lerp(initialColor, targetColor, t);
            yield return null;
        }

        // Ensure the final color is set
        medalImage.color = targetColor;
    } */
}
