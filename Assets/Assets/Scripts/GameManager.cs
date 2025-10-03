using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Elements")]
    [SerializeField] private GameObject obstacle;
    [SerializeField] private Transform spawnPoint;

    [Header("Score Info")]
    [SerializeField] private GameObject player;
    [SerializeField] public TextMeshProUGUI scoreCount;
    [SerializeField] public TextMeshProUGUI GameOverscoreCount;
    [SerializeField] private TextMeshProUGUI highScoreCount;
    private int score = 0;
    private int highScore = 0;
    private int gameOverScore = 0;

    [Header("Canvas Groups")]
    [SerializeField] public CanvasGroup gameCG;
    [SerializeField] public CanvasGroup startCG;
    [SerializeField] public CanvasGroup gameOverCG;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Time.timeScale = 1;
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreCount.text = highScore.ToString();
        ShowCG(startCG);
        HideCG(gameCG);
        HideCG(gameOverCG);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            float waitTime = Random.Range(0.8f, 2f);

            yield return new WaitForSeconds(waitTime);

            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
        }
    }

    private void ScoreUp()
    {
        score++;
        scoreCount.text = score.ToString();

        if (score >= highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", score);
        }
        highScoreCount.text = highScore.ToString();
    }

    public void GameOver()
    {
        GameOverscoreCount.text = score.ToString();

        StopAllCoroutines();
        CancelInvoke();

        Time.timeScale = 0;
    }

    public void GameStart()
    {
        player.SetActive(true);
        HideCG(startCG);
        HideCG(gameOverCG);
        ShowCG(gameCG);

        PlayerPrefs.GetInt("highscore");

        StartCoroutine("SpawnObstacle");
        InvokeRepeating("ScoreUp", 2f, 1f);
    }

    public void ShowCG(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    public void HideCG(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    public void PlayAgainButtonCallBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
