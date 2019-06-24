using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    private GamePlay gamePlay;
    private Camera _camera;
    public bool move = false;

    private void Start()
    {
        gamePlay = FindObjectOfType<GamePlay>();
        _camera = FindObjectOfType<Camera>();
    }
    private void Update()
    {
        if (!(gamePlay.playerWin || gamePlay.enemyWin))
        {
           if (Input.GetButtonDown("Fire1") && !move) PlayerTurn();
        }  
    }
    private IEnumerator PlayerMove()
    {
        yield return new WaitForSeconds(0.5f);
        move = true;
    }

    private void PlayerTurn()
    {
        Vector2 position = _camera.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
        if (hit.collider)
        {
            Transform cell = hit.transform;
            if (!cell.transform.GetComponent<SpriteRenderer>().sprite)
            {
                cell.transform.GetComponent<SpriteRenderer>().sprite = sprite;
                StartCoroutine(PlayerMove());
            }
            
        }
        
    }
}
