using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighScores : MonoBehaviour
{
    public TextMeshProUGUI[] highscoreTexts;
    Leaderboard highscoreManager;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < highscoreTexts.Length; i++)
        {
            highscoreTexts[i].text = (i + 1) + " - Fetching...";
        }

        highscoreManager = GetComponent<Leaderboard>();

        StartCoroutine("RefreshHighScores");
    }

    public void OnHighscoresDownloaded(HighScore[] highScoreList)
    {
        for (int i = 0; i < highscoreTexts.Length; i++)
        {
            highscoreTexts[i].text = (i + 1) + ". ";

            if (highScoreList.Length > i)
            {
                highscoreTexts[i].text += highScoreList[i].username + " | " + highScoreList[i].moves + " | " + highScoreList[i].minuteCount + "m " + highScoreList[i].secondCount + "s";
            }
        }
    }

    IEnumerator RefreshHighScores()
    {
        while (true)
        {
            highscoreManager.DownloadHighScores();
            yield return new WaitForSeconds(5);
            Debug.Log("Refreshing highscores...");
        }
    }
}
