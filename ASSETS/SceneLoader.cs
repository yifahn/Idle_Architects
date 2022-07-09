using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject menuKeeper, plane;
    public void Start()
    {
        menuKeeper = this.gameObject;
        plane = GameObject.Find("Plane");
    }

    public void NewGame()
    {
        ScoreState.IsLoad = false;
        SaveAndLoad.IsReady = true;
        SaveAndLoad.IsReadyPlay = true;
        SaveAndLoad.IsReadyDrawMap = true;
        SceneManager.LoadScene(1);
    }
    public void LoadGameViaOK()
    {
        CellState.MapListL1Allocate();
        CellState.MapListL2Allocate();
        ScoreState.IsLoad = true;
        menuKeeper.GetComponent<MenuTransition>().setFileRef();
        SaveAndLoad.IsReadyDrawMap = false; 
        SaveAndLoad.IsReadyPlay = false;
        SceneManager.LoadScene(1); 
    }
    public void LoadGame()
    {
        menuKeeper.GetComponent<MenuTransition>().isLoadBtnSelected = true;
        menuKeeper.GetComponent<MenuTransition>().ShowLoadElement();
    }
    public void MainMenuSave()
    {
        CellState.MapListL1Allocate();
        CellState.MapListL2Allocate();

        plane.GetComponent<Map>().SaveBoard();
        SaveAndLoad.IsReadyDrawMap = false;
        SaveAndLoad.IsReadyPlay = false;
        SaveAndLoad.IsReady = false;
         // ScoreState.isLoad = false;


        SaveAndLoad.SaveGame();
        SceneManager.LoadScene(0); 
    }
    public void MainMenuExit()
    {
        SaveAndLoad.IsReadyDrawMap = false;
        SaveAndLoad.IsReadyPlay = false;
        SaveAndLoad.IsReady = false;
       // ScoreState.IsLoad = false; EDIT1
        plane.GetComponent<Map>().mapListL1.Clear();
        CellState.MapListL1Allocate();
        CellState.MapListL1Allocate();
        SceneManager.LoadScene(0);
    }


}
