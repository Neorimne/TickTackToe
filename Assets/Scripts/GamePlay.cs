using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private GameObject line;
    private GameObject[] cells;
    public bool playerWin = false;
    public bool enemyWin = false;

    private bool croosLineCheck = true;

    private void Start()
    {
        cells = GameObject.FindGameObjectsWithTag("cell");
    }

    private void Update()
    {
        CrossCheck("Cross");
        SquareCheck("Cross");
        CrossCheck("Circle");
        SquareCheck("Circle");
    }

    
    private void CrossCheck(string spriteName) 
    {
        if (cells[4].GetComponent<SpriteRenderer>().sprite) //если в центре есть спрайт
        {            
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            for (int i = 1; i <= 7; i+=3)
            {
                if (cells[i].GetComponent<SpriteRenderer>().sprite) // проверка по вертикали
                {
                    if (cells[i].GetComponent<SpriteRenderer>().sprite.name == spriteName)
                    {
                        count1++;
                    }
                } 
            }
            for (int i = 3; i <= 5; i++)  // проверка по горизантоли
            {
                if (cells[i].GetComponent<SpriteRenderer>().sprite)
                {
                    if (cells[i].GetComponent<SpriteRenderer>().sprite.name == spriteName)
                    {
                        count2++;
                    }
                }
            }

            for (int i = 0; i <= 8; i+=4) // проверка по диагонали от первой к последней ячейки
            {
                if (cells[i].GetComponent<SpriteRenderer>().sprite)
                {
                    if (cells[i].GetComponent<SpriteRenderer>().sprite.name == spriteName)
                    {
                        count3++;
                    }
                }
            }

            for (int i = 2; i <= 6; i+=2)  //проверка по диагонали от третьей к седьмой ячейке
            {
                if (cells[i].GetComponent<SpriteRenderer>().sprite)
                {
                    if (cells[i].GetComponent<SpriteRenderer>().sprite.name == spriteName)
                    {
                        count4++;
                    }
                }
            }
            if (count1 == 3 || count2 == 3 || count3 == 3 || count4 == 3)
            {
                if (spriteName == "Cross") playerWin = true;
                else enemyWin = true;

                if (count1 == 3) DrawLine(1, 0, 0);
                else if (count2 == 3) DrawLine(2, 0, 0);
                else if (count3 == 3) DrawLine(3, 0, 0);
                else if (count4 == 3) DrawLine(4, 0, 0);
            } 
        }
    }

    private void SquareCheck(string spriteName)
    {
        if (cells[0].GetComponent<SpriteRenderer>().sprite) //проверка от точки верхний левый угол вниз и вправо
        {
            int count1 = 0;
            int count2 = 0;
            for (int i = 0; i < 3; i++)
            {
                if (cells[i].GetComponent<SpriteRenderer>().sprite)
                {
                    if (cells[i].GetComponent<SpriteRenderer>().sprite.name == spriteName)
                    {
                        count1++;
                    }
                }
            }
            for (int i = 0; i <= 6; i += 3)
            {
                if (cells[i].GetComponent<SpriteRenderer>().sprite)
                {
                    if (cells[i].GetComponent<SpriteRenderer>().sprite.name == spriteName)
                    {
                        count2++;
                    }
                }
            }
            if (count1 == 3 || count2 == 3)
            {
                if (spriteName == "Cross") playerWin = true;
                else enemyWin = true;
                if (count1 == 3) DrawLine(2, 0, 2);
                else if (count2 == 3) DrawLine(1, -2, 0);
            } 
        }
        if (cells[8].GetComponent<SpriteRenderer>().sprite) //проверка от правой нижней точки влево и вверх
        {
            int count1 = 0;
            int count2 = 0;
            for (int i = 8; i >= 6; i--)
            {
                if (cells[i].GetComponent<SpriteRenderer>().sprite) // если есть спрайт, и в нем проверяемый спрайт, увеличить счетчик
                {
                    if (cells[i].GetComponent<SpriteRenderer>().sprite.name == spriteName)
                    {
                        count1++;
                    }
                }
            }
            for (int i = 8; i >= 2; i -= 3)
            {
                if (cells[i].GetComponent<SpriteRenderer>().sprite)
                {
                    if (cells[i].GetComponent<SpriteRenderer>().sprite.name == spriteName)
                    {
                        count2++;
                    }
                }
            }
            if (count1 == 3 || count2 == 3) // если хоть один из счетчиков = 3, победа либо игрока либо противника
            {
                if (spriteName == "Cross") playerWin = true; // если отслеживаемый спрайт крестик, победил игрок, иначе противник
                else enemyWin = true;
                if (count1 == 3) DrawLine(2, 0, -2); // линия создается в зависимости от того, какой именно счетчик набрал 3 совпадения
                else if (count2 == 3) DrawLine(1, 2, 0);
            }
        }
    }

    private void DrawLine(int angle, int x , int y) 
    {
        while (croosLineCheck) 
        {
            
            switch (angle) // угол задается извне
            {
                case 1:
                    Instantiate(line, new Vector3(x, y, -5),Quaternion.Euler(0,0,90)); // создание линии с учетом угла
                    croosLineCheck = false;
                    break;
                case 2:
                    Instantiate(line, new Vector3(x, y, -5), Quaternion.identity);
                    croosLineCheck = false;
                    break;
                case 3:
                    Instantiate(line, new Vector3(x, y, -5), Quaternion.Euler(0, 0, -45));
                    croosLineCheck = false;
                    break;
                case 4:
                    Instantiate(line, new Vector3(x, y, -5), Quaternion.Euler(0, 0, 45));
                    croosLineCheck = false;
                    break;
            }
        }
        
    }
}
