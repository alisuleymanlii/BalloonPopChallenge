using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    private int score = 0;
    private int maxScore = 0;

    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;

    public GameObject bitti;

    public int heart = 3;

    public GameObject[] randomTexts;

    public GameObject iyidurum;
    public GameObject kotudurum;

    public Animator animator;
    public Animator animator2;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        maxScore = PlayerPrefs.GetInt("MaxScore", 0);
        UpdateScoreUI();
        UpdateHearts();



    }

    void Start()
    {
        bitti.SetActive(false);
        kotudurum.SetActive(false);
        iyidurum.SetActive(false);
    }

    public void AddScore(int amount)
    {
    int oldScore = score;
    score += amount;

    if (score > maxScore)
    {
        maxScore = score;
        PlayerPrefs.SetInt("MaxScore", maxScore);
    }

    UpdateScoreUI();

    // Hər 100 xaldan sonra yoxlama
    if (score / 100 > oldScore / 100)
    {
        StartCoroutine(ShowIyiDurum());
    }
    }

    public void randomtext()
    {
        if (randomTexts.Length > 0)
        {
            int randomIndex = Random.Range(0, randomTexts.Length);
            StartCoroutine(ShowRandomText(randomTexts[randomIndex]));
        }
    }

    public void LoseHeart()
    {
        if (heart > 0)
        {
            SoundManager.instance.PlayEffect1();
            heart--;
            UpdateHearts();
            StartCoroutine(ShowKotuDurum());
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Xal: " + score + "\nZ-Xal: " + maxScore;
    }

    void UpdateHearts()
    {
        Heart1.SetActive(heart == 1);
        Heart2.SetActive(heart == 2);
        Heart3.SetActive(heart == 3);

        if (heart == 0)
        {
            bitti.SetActive(true);
        }
    }

    IEnumerator ShowRandomText(GameObject textObj)
    {
        textObj.SetActive(true);
        yield return new WaitForSeconds(1f);
        textObj.SetActive(false);
    }

    IEnumerator ShowIyiDurum()
    {
        iyidurum.SetActive(true);
        animator.SetBool("dur", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("get", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("get", false);
        iyidurum.SetActive(false);
    }

    IEnumerator ShowKotuDurum()
    {
        kotudurum.SetActive(true);
        animator2.SetBool("dur", true);
        yield return new WaitForSeconds(1f);
        animator2.SetBool("get", true);
        yield return new WaitForSeconds(1f);
        animator2.SetBool("get", false);
        kotudurum.SetActive(false);
    }
}
