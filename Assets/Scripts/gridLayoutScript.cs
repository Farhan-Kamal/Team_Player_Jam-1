using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridLayoutScript : MonoBehaviour
{
    public bool isFixedRows;
    public int lines;
    public int spacing;

    private int previousChild = 0;

    void Update()
    {
        if (previousChild != transform.childCount)
        {
            previousChild = transform.childCount;
            int currentLine = -1;
            for (int i = 0; i < transform.childCount; i++)
            {
                if (i % lines == 0)
                {
                    currentLine++;
                }
                Debug.Log(currentLine);

                float currentLinePos = (spacing * ((transform.childCount / lines) / -2)) + (currentLine * spacing);

                if (isFixedRows)
                {
                    transform.GetChild(i).localPosition = new Vector3(currentLinePos, (i - currentLine * lines) * spacing, 0);
                }
                else
                {
                    transform.GetChild(i).localPosition = new Vector3((i - currentLine * lines) * spacing, currentLinePos, 0);
                }
            }
        }
    }
}
