using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private PlayerController player;
    private GamePlay gamePlay;
    private List<Transform> cells;
    public bool standoff = false;

    void Start()
    {
        gamePlay = FindObjectOfType<GamePlay>();
        cells = new List<Transform>();
        GameObject[] temp  = GameObject.FindGameObjectsWithTag("cell");
        foreach (GameObject i in temp)
        {
            cells.Add(i.GetComponent<Transform>());
        }
    }

    private void Update()
    {
        if (!(gamePlay.enemyWin || gamePlay.playerWin)) StartCoroutine(EnemyTurn());
        if (cells.Count == 0) standoff = true;
    }
    private IEnumerator EnemyTurn()
    {
        if (player.move)
        {
            while (player.move && cells.Count > 0)
            {
                int tmp = Random.Range(0, cells.Count -1);
                if (!cells[tmp].GetComponent<SpriteRenderer>().sprite)
                {
                    cells[tmp].GetComponent<SpriteRenderer>().sprite = sprite;
                    cells.RemoveAt(tmp);
                    player.move = false;
                    yield return new WaitForSeconds(0.5f);
                }
                else cells.RemoveAt(tmp);
            }
        }          
    }
}
