using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Winning : MonoBehaviour
{
    public Puzzle statsRef;
    public Leaderboard Leaderboard;

    public TextMeshProUGUI TimerScore;
    public TextMeshProUGUI MoveScore;

    public GameObject usernameObj;
    private string username;

    // Start is called before the first frame update
    void Awake()
    {
        TimerScore.SetText(statsRef.TimerText.text);
        MoveScore.SetText(statsRef.MoveCountText.text);
    }

    public void SubmitScore()
    {
        username = usernameObj.GetComponent<TMP_InputField>().text;
        Leaderboard.AddNewHighScore(username, (int)statsRef.MoveCount, statsRef.minuteCount, (int)statsRef.secondsCount);
    }
}
