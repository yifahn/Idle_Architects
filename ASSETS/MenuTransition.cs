using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class MenuTransition : MonoBehaviour
{
    public GameObject btnLoad, btnNew, btnOK, fileSelect, panelLoad;
    public bool isLoadBtnSelected;

    public void Start()
    {
        btnNew = GameObject.Find("BtnNewGame"); //declare and set 
        btnLoad = GameObject.Find("BtnLoadGame");
        panelLoad = GameObject.Find("PanelLoad");
        fileSelect = GameObject.Find("Dropdown");
        btnOK = GameObject.Find("BtnOK");
        isLoadBtnSelected = false;
        panelLoad.SetActive(false);
    }
    public void ShowLoadElement() //on load btn click 
    {
        if (isLoadBtnSelected)
        {
            if (!panelLoad.activeSelf)
            {
                panelLoad.SetActive(true);
                if (Directory.Exists(@"c:\saves\"))
                {
                    SaveAndLoad.saveFileDir = @"c:\saves\";
                    Debug.Log("dir does exist");
                }
                else
                {
                    Debug.Log("dir does NOT exist");
                    Directory.CreateDirectory(@"c:\saves\");
                    SaveAndLoad.saveFileDir = @"c:\saves\";
                }
                string[] files = Directory.GetFiles(SaveAndLoad.saveFileDir, "*.txt", 0);
                foreach (string dir in files)
                {
                    Debug.Log(dir);
                }
                fileSelect.GetComponent<Dropdown>().ClearOptions();
                int i = 0;
                foreach (string dir in files)
                {
                    i++;

                    fileSelect.GetComponent<Dropdown>().options.Add(new Dropdown.OptionData() { text = dir });

                    if (i == 1)
                    {
                        fileSelect.GetComponent<Dropdown>().value = 1;
                    }
                }
            }
        }
    }
    public void setFileRef()
    {
        SaveAndLoad.saveFileSelected = fileSelect.GetComponent<Dropdown>().captionText.@text;
        Debug.Log(SaveAndLoad.saveFileSelected);
    }
}
