using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private GameObject gameUI;

    [SerializeField]
    private GameObject gameOverScreen;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text healthText;

    [SerializeField]
    private Image healthFill;

    [SerializeField]
    private Animation LevelUpAnimation;

    [SerializeField]
    private Text highScoreText;


    public void Awake()
    {
        scoreText.text = "";
        gameOverScreen.SetActive(false);
        gameUI.SetActive(true);
    }

    /// <summary>
    /// Update health of the player.
    /// </summary>
    /// <param name="value">Can be an float number between 0 and Player.MaxHealth.
    /// It's not normalized between 0f and 1f</param>
    public void UpdateHealth(float value)
    {
        if (value > 0)
        {
            healthText.text = $"{value}";
            healthFill.fillAmount = Mathf.InverseLerp(0, 100, value);
        }
        else
        {
            gameOverScreen.SetActive(true);
            gameUI.SetActive(false);
        }
    }

    public void UpdateScore(int value)
    {
        scoreText.text = $"{value}";
    }

    public void LevelUpSign()
    {
        LevelUpAnimation.Play("LevelUpText");
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
