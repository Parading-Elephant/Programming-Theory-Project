using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI counter;
    [SerializeField] private Button restartButton;

    private float timeSurvived = 0;
    private bool gameOngoing = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOngoing) {
            timeSurvived += Time.deltaTime;
            counter.text = $"{(int)(timeSurvived / 1)}";
        }
        
    }

    public void OnPlayerDied()
    {
        gameOngoing = false;
        gameOverText.gameObject.SetActive(true);
        Invoke("ShowRestart", 0.8f);
    }

    public void ShowRestart()
    {
        restartButton.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
