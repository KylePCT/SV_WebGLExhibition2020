using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NumberBox : MonoBehaviour
{
    //Inheritence.
    public int index = 0;
    public int x = 0;
    public int y = 0;

    public Vector2Int CorrectBoxPosition;
    public Vector2Int CurrentBoxPosition;

    private Action<int, int> swapFunc = null;

    public bool isEmpty()
    {
        return index == 16;
    }

    public void Init(int i, int j, int index, Sprite sprite, Action<int, int> swapFunc)
    {
        this.index = index;
        this.GetComponent<Image>().sprite = sprite;
        UpdatePos(i, j);
        this.swapFunc = swapFunc;

        CorrectBoxPosition = new Vector2Int(x, y);
    }

    public void UpdatePos(int i, int j)
    {
        x = i;
        y = j;

        CurrentBoxPosition = new Vector2Int(x, y);

        //this.gameObject.transform.localPosition = new Vector2(i, j);
        StartCoroutine(Move());
    }

    //Movement animation.
    IEnumerator Move()
    {
        float elapsedTime = 0;
        float duration = 0.2f;

        Vector2 start = this.gameObject.transform.localPosition;
        Vector2 end = new Vector2(x, y);

        while (elapsedTime < duration)
        {
            this.gameObject.transform.localPosition = Vector2.Lerp(start, end, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        this.gameObject.transform.localPosition = end;
    }

    public void OnMouseDown()
    {
        Debug.Log("Tile " + index + " has been clicked.");

        if (swapFunc != null)
        {
            swapFunc(x, y);
        }
    }
}
