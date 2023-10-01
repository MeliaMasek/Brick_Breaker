using UnityEngine;
using UnityEngine.UI;

public class GameoverManager : MonoBehaviour
{
    public IntData health;
    public Text gameoverText; // Reference to the UI Text component to display the game over message

    public void Gameover()
    {
        // Check if health is less than or equal to zero to trigger game over
        if (health.value <= 0)
        {
            // Enable the game over text
            gameoverText.enabled = true;
        }
        else
        {
            // Disable the game over text if health is greater than zero
            gameoverText.enabled = false;
        }
    }
}
