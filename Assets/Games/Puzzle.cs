using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzzle : MonoBehaviour
{
    public NumberBox boxPrefab;
    public NumberBox[,] boxes = new NumberBox[4, 4];
    public Sprite[] sprites;
    public int ShuffleAmount;

    [Space(10)]

    public GameObject MainPuzzleBoard;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI MoveCountText;
    private float Timer;
    private float MoveCount;

    private float secondsCount;
    private int minuteCount;
    private int hourCount;

    //Start is called before the first frame update.
    void Start()
    {
        Init();

        Timer = 0f;
        MoveCount = 0f;

        for (int i = 0; i < ShuffleAmount; i++)
        {
            Shuffle();
        }
    }

    void Update()
    {
        UpdateTimerUI();
        MoveCountText.SetText("Moves: " + MoveCount);
    }

    //Initilization.
    void Init()
    {
        int n = 0;
        for (int y = 3; y >= 0; y--)
        {
            for (int x = 0; x < 4; x++)
            {
                NumberBox box = Instantiate(boxPrefab, new Vector2(x, y), Quaternion.identity);

                box.Init(x, y, n + 1, sprites[n], ClickToSwap);
                boxes[x, y] = box;
                box.transform.SetParent(MainPuzzleBoard.transform, false);
                //box.CorrectBoxPosition = new Vector2Int(x, y);
                n++;
            }
        }
    }

    void ClickToSwap(int x, int y)
    {
        int dx = getDx(x, y);
        int dy = getDy(x, y);

        MoveCount = MoveCount + 1;

        Swap(x, y, dx, dy);
        boxes[x, y].CurrentBoxPosition = new Vector2Int(x, y);

        TestIfWon();
    }

    void Swap(int x, int y, int dx, int dy)
    {

        //Targets.
        var from = boxes[x, y];
        var target = boxes[x + dx, y + dy];

        //Swap the boxes.
        boxes[x, y] = target;
        boxes[x + dx, y + dy] = from;

        //Update position.
        Debug.Log("Tile moved from: " + from.index + " to " + target.index + ".");
        from.UpdatePos(x + dx, y + dy);
        target.UpdatePos(x, y);

        Debug.Log(boxes[x,y].CurrentBoxPosition + "    " + boxes[x,y].CorrectBoxPosition);

    }

    public void UpdateTimerUI()
    {
        //Set timer UI.
        secondsCount += Time.deltaTime;
        TimerText.SetText("Timer: " + hourCount + "h " + minuteCount.ToString("00") + "m " + ((int)secondsCount).ToString("00") + "s");

        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
    }

    void TestIfWon()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (boxes[i, j].CurrentBoxPosition != boxes[i, j].CorrectBoxPosition)
                {
                    return;
                }
            }
        }

        Debug.Log("Victory!");
    }

    //Methods.
    int getDx(int x, int y)
    {
        //Depends on the position of the empty -> is the right box empty?
        if (x < 3 && boxes[x + 1, y].isEmpty()) //Prevent boundary overlap.
        {
            return 1;
        }

        //Depends on the position of the empty -> is the left box empty?
        if (x > 0 && boxes[x - 1, y].isEmpty()) //Prevent boundary overlap.
        {
            return -1;
        }

        return 0;
    }

    int getDy(int x, int y)
    {
        //Depends on the position of the empty -> is the top box empty?
        if (y < 3 && boxes[x, y + 1].isEmpty()) //Prevent boundary overlap.
        {
            return 1;
        }

        //Depends on the position of the empty -> is the bottom box empty?
        if (y > 0 && boxes[x, y - 1].isEmpty()) //Prevent boundary overlap.
        {
            return -1;
        }

        return 0;
    }

    void Shuffle()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                boxes[i, j].CurrentBoxPosition = boxes[i, j].CorrectBoxPosition;

                if(boxes[i,j].isEmpty())
                {
                    Vector2 pos = getValidMove(i, j);
                    Swap(i, j, (int)pos.x, (int)pos.y);
                    boxes[i, j].CurrentBoxPosition = new Vector2Int((boxes[i,j].CurrentBoxPosition.x + (int)pos.x), (boxes[i,j].CurrentBoxPosition.y + (int)pos.y));
                }
            }
        }
    }

    private Vector2 lastMove;

    Vector2 getValidMove(int x, int y)
    {
        Vector2 pos = new Vector2();

        do
        {
            int n = Random.Range(0, 4);

            if (n == 0)
            {
                pos = Vector2.left;
            }

            else if (n == 1)
            {
                pos = Vector2.right;
            }

            else if (n == 2)
            {
                pos = Vector2.up;
            }

            else if (n == 3)
            {
                pos = Vector2.down;
            }
        }
        
        //If the move would cause it to go out of the grid or is a repeated move, do it again.
        while (!(isValidRange(x + (int)pos.x) && isValidRange(y + (int)pos.y)) || isRepeatMove(pos));

        lastMove = pos;
        return pos;
    }

    bool isValidRange(int n)
    {
        return n >= 0 && n <= 3;
    }

    bool isRepeatMove(Vector2 pos)
    {
        return pos * -1 == lastMove;
    }
}
