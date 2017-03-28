using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    [SerializeField]
    private GameObject scorePrefab;
    public GameObject ScorePrefab
    {
        get
        {
            return scorePrefab;
        }
    }

    //[SerializeField]
    //private Text scoreText;
    private static int score = 0;
    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            //scoreText.text = value.ToString();
            score = value;
        }
    }
    [SerializeField]
    private int scoreToWin;
    [SerializeField]
    private string nextSceneName;

    //[SerializeField]
    //private Text livesText;
    [SerializeField]
    private static int lives = 7;
    public int Lives
    {
        get
        {
            return lives;
        }
        set
        {
            lives = value;
        }
    }

    private static int specialAmmo = 0;
    public int SpecialAmmo
    {
        get
        {
            return specialAmmo;
        }
        set
        {
            specialAmmo = value;
        }
    }

    private static int currentWeapon = 0;
    public int CurrentWeapon
    {
        get
        {
            return currentWeapon;
        }
        set
        {
            currentWeapon = value;
        }
    }

    // Use this for initialization
    void Awake()
    {
        //livesText.text = "x" + lives.ToString();
        //if (score == 0)
        //{
        //    scoreText.text = score.ToString();
        //}
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.text = score.ToString();
        //livesText.text = "x" + lives.ToString();
        if (score >= scoreToWin)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
