using UnityEngine;
using UnityEngine.UI;
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

    // Use this for initialization
    /*void Awake()
    {
        livesText.text = "x" + lives.ToString();
        if (score == 0)
        {
            scoreText.text = score.ToString();
        }
    }*/

    // Update is called once per frame
    /*void Update()
    {
        scoreText.text = score.ToString();
        livesText.text = "x" + lives.ToString();
    }*/
}
