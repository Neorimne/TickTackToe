using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GamePlay game;
    [SerializeField] private Text text;
    [SerializeField] private KeyCode key;

    private EnemyController enemy;


    private void Start()
    {
        enemy = FindObjectOfType<EnemyController>();
    }


    private void Update()
    {
        if (Input.GetKey(key))
        {
            pausePanel.SetActive(true);
        }
        if (game.playerWin || game.enemyWin || enemy.standoff)
        {
            StartCoroutine(PanelShow());
        } 
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Continue()
    {
        pausePanel.SetActive(false);
    }

    private IEnumerator PanelShow()
    {
        yield return new WaitForSeconds(1.5f);
        panel.SetActive(true);
        if (game.playerWin) text.text = "You win :)";
        else if (game.enemyWin) text.text = "You lose :(";
        else if (enemy.standoff) text.text = "Standoff!";
    }

}
