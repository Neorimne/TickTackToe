using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsControll : MonoBehaviour
{
    [SerializeField] private Transform cellParent;
    [SerializeField] private GameObject cell;

    private float x = -2.0f;
    private float y = 2.0f;

    private void Awake()
    {
        InstField();
    }

    private void InstField()
    {
        for (int i = 1; i < 10; i++)
        {
            Vector2 position = new Vector2(x, y);
            Instantiate(cell, position, Quaternion.identity, cellParent);

            x += 2.0f;
            if (i % 3 == 0)
            {
                y -= 2.0f;
                x = -2.0f;
            }
        }
        
    }
}
