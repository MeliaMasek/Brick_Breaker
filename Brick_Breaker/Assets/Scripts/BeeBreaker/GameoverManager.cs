using UnityEngine;

public class GameoverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public IntData Health;

    private void Start()
    {
        //playerHealth.value = playerHealth.value;
        //gameOverPanel.SetActive(false);
    }

    public void ReduceHealth(int amount)
    {
        Health.value -= amount;

        if (Health.value <= 0)
        {
            Health.value = 0;
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}