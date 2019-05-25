using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public GameObject LvlPanel, ConfPanel, MainPanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void NewGame()
    {
        Application.LoadLevel(1);
        PlayerPrefs.SetInt("MaxLvl",1);
    }
    public void Confirmation()
    {
        ConfPanel.SetActive(true);
        MainPanel.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void LoadGame(int i)
    {
        Application.LoadLevel(i);
    }
    public void Levels()
    {
        LvlPanel.SetActive(true);
        MainPanel.SetActive(false);
    }
    public void Back()
    {
        MainPanel.SetActive(true);
        ConfPanel.SetActive(false);
        LvlPanel.SetActive(false);
    }
 }
