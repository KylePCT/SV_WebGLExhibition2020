using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    //http://dreamlo.com/lb/2ffda6i6wkCElK-Db3ZStAT-VFD_Hh_UyFQxCe-aOb8g <- URL for our high-score database.

    const string privateCode = "2ffda6i6wkCElK-Db3ZStAT-VFD_Hh_UyFQxCe-aOb8g";
    const string publicCode = "5faa9784eb371a09c4d40bd2";
    const string webURL = "http://dreamlo.com/lb/";

    static Leaderboard instance;

    public HighScore[] HighScoresList;
    DisplayHighScores highscoresDisplay;

    private int storedMoveValue;

    //For testing.
    void Awake()
    {
        instance = this;

        highscoresDisplay = GetComponent<DisplayHighScores>();
        DownloadScores();

        //AddNewHighScore("Kyle", 200, 12, 25);
        //AddNewHighScore("blah", 12138, 14, 1);
    }

    public static void AddNewHighScore(string username, int moves, int minuteCount, int secondCount)
    {
        instance.StartCoroutine(instance.UploadNewHighScore(username, moves, minuteCount, secondCount));
    }

    IEnumerator UploadNewHighScore(string username, int moves, int minuteCount, int secondCount)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + (100000 - moves) + "/" + minuteCount + "/" + secondCount);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Upload successful!");
            DownloadScores();
        }
        else
        {
            Debug.LogError("Upload failed " + www.error + ".");
        }
    }

    public void DownloadScores()
    {
        StartCoroutine("DownloadHighScores");
    }

    public IEnumerator DownloadHighScores()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Download successful!");
            Debug.Log(www.text);

            FormatHighScores(www.text);
            highscoresDisplay.OnHighscoresDownloaded(HighScoresList);
        }
        else
        {
            Debug.LogError("Download failed " + www.error + ".");
        }
    }

    void FormatHighScores(string textStream)
    {
        string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
        HighScoresList = new HighScore[entries.Length];

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] {'|'});
            string username = entryInfo[0];
            int moves = int.Parse(entryInfo[1]);
            int minuteCount = int.Parse(entryInfo[2]);
            int secondCount = int.Parse(entryInfo[3]);

            HighScoresList[i] = new HighScore(username, (100000 - moves), minuteCount, secondCount);
        }
    }
}

public struct HighScore
{
    public string username;
    public int moves;
    public int minuteCount;
    public int secondCount;

    public HighScore(string _username, int _moves, int _minuteCount, int _secondCount)
    {
        username = _username;
        moves = _moves;
        minuteCount = _minuteCount;
        secondCount = _secondCount;
    }
}