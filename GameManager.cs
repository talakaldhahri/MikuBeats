using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatsScroller theBS;
    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text MultiplierText;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    public GameObject resultsScreen;
    public Text normalHitText, goodHitText, perfectHitText, missedHitText, finalScoreText, rankText, percentHitText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        startPlaying = true;
        theBS.hasStarted = true;
        theMusic.Play();

        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        totalNotes = FindObjectsOfType<NotesObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;
                theMusic.Play();
            }
        } else
        {
            if (!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);
                normalHitText.text = "" + normalHits;
                goodHitText.text = "" + goodHits;
                perfectHitText.text = "" + perfectHits;
                missedHitText.text = "" + missedHits;
               

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100f;
                percentHitText.text = percentHit.ToString("F1") + "%";

                string rankVal = "F";
                if (percentHit >= 40f)
                {
                    rankVal = "D";
                    if (percentHit >= 55f)
                    {
                        rankVal = "C";
                        if (percentHit >= 70f)
                        {
                            rankVal = "B";
                            if (percentHit >= 85f)
                            {
                                rankVal = "A";
                                if (percentHit >= 95f)
                                {
                                    rankVal = "S";
                                }
                            }
                        }
                    }
                }

                rankText.text = rankVal;

                finalScoreText.text = "" + currentScore;
            }
        }
    }
    public void Note_Hit()
    {
        Debug.Log("Hit on time");
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierTracker >= multiplierThresholds[currentMultiplier - 1])
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        MultiplierText.text = "Multiplier: x" + currentMultiplier;

        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void Note_Missed()
    {
        Debug.Log("Missed Note");

        currentMultiplier = 1;
        multiplierTracker = 0;
        MultiplierText.text = "Multiplier: x" + currentMultiplier;
        missedHits++;
    }

    public void Normal_Hit(){
        currentScore += scorePerNote * currentMultiplier;
        Note_Hit();
        normalHits++;
    } 

    public void Good_Hit(){
        currentScore += scorePerGoodNote * currentMultiplier;
        Note_Hit();
        goodHits++;
    }

    public void Perfect_Hit(){
        currentScore += scorePerPerfectNote * currentMultiplier;
        Note_Hit();
        perfectHits++;
    }

 

}
