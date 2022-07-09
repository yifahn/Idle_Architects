using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject gameKeeper,menuPanel, removeBtn, backBtn, exitBtn, buildBtn, houseBuild, libraryBuild, cityCentreBuild, factoryBuild, wonderBuild, roadBuild, blockadeBuild, towerMBuild, towerAABuild;
    public GameObject leftPanel,plane;
    public GameObject confirmSaveExit, confirmExit, confirmBack;
    public GameObject[] UIComponents;
    private enum stateUI
    {
        UIMainMenu,
        Build,
        UIConfirmExit
    }
    private stateUI state;

    void Start()
    {
        plane = GameObject.Find("Plane");
        gameKeeper = GameObject.Find("GameKeeper");
        UIComponents = GameObject.FindGameObjectsWithTag("UIComponent");
        MainMenuUI();
        leftPanel = GameObject.Find("LeftPanel");
        menuPanel = GameObject.Find("MenuPanel");
        menuPanel.SetActive(false);
      
    }

    public void onClickBuild()
    {
        state = stateUI.Build;
        foreach (GameObject UIComponent in UIComponents)
        {
            UIComponent.SetActive(false);
        }
        removeBtn.SetActive(true);
        roadBuild.SetActive(true);
        blockadeBuild.SetActive(true);
        towerMBuild.SetActive(true);
        towerAABuild.SetActive(true);
        houseBuild.SetActive(true);
        libraryBuild.SetActive(true);
        cityCentreBuild.SetActive(true);
        factoryBuild.SetActive(true);
        wonderBuild.SetActive(true);
        backBtn.SetActive(true);

    }

    public void MainMenuUI()
    {
        state = stateUI.UIMainMenu;
        foreach (GameObject UIComponent in UIComponents)
        {
            UIComponent.SetActive(false);
        }
        buildBtn.SetActive(true);
      
        exitBtn.SetActive(true);

    }

    public void onClickBack()
    {
        switch (state)
        {
            case stateUI.UIMainMenu:
                break;
            case stateUI.Build:
                MainMenuUI();
                plane.GetComponent<Map>().SelectNone();
                break;
            case stateUI.UIConfirmExit:
                onClickConfirmBack();
                break;
        }
    }
    public void onClickExit()
    {
        foreach (GameObject UIComponent in UIComponents)
        {
            UIComponent.SetActive(false);
        }
        menuPanel.SetActive(true);
        confirmBack.SetActive(true);
        confirmExit.SetActive(true);
        confirmSaveExit.SetActive(true);
        buildBtn.SetActive(true);
        removeBtn.SetActive(true);
        exitBtn.SetActive(true);

    }
    public void onClickConfirmSaveExit()
    {
        gameKeeper.GetComponent<SceneLoader>().MainMenuSave();
    }
    public void onClickConfirmExit()
    {
        gameKeeper.GetComponent<SceneLoader>().MainMenuExit();
    }
    public void onClickConfirmBack()
    {
        menuPanel.SetActive(false);
    }
    
}

