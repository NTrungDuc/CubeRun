using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameEvent : Singleton<GameEvent>
{
    [SerializeField] public Transform Player;
    [SerializeField] private Vector3 oldPos;
    [SerializeField] public Text txtScore;
    [SerializeField] public Text txtPlay;
    [SerializeField] public Text txtHighScore;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private CubeController cubeController;
    private void Awake()
    {
        base.Awake();
        oldPos = Player.position;
    }
    public void showWinPanel()
    {
        winPanel.SetActive(true);
        txtScore.transform.DOScale(0, 1f);
        PlayerPrefs.SetInt("Point", int.Parse(txtScore.text));
        txtHighScore.text= "HighScore: " + PlayerPrefs.GetInt("Point").ToString();
    }
    public void showLosePanel()
    {
        losePanel.SetActive(true);
    }
    public void Point()
    {

        txtScore.text = Player.position.z.ToString("0");
    }
    public void resetPosPlayer()
    {
        Player.position = oldPos;
        Player.rotation = Quaternion.identity;
        cubeController.speed = 0;
        cubeController.checkTouch=false;
        if (cubeController.checkWin)
        {
            winPanel.SetActive(false);
        }
        else
        {
            losePanel.SetActive(false);
        }
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
