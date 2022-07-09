/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProcesses : MonoBehaviour
{
    public List<GameObject> mapStateList;
    public GameObject cell, panel, house, library, factory, cityCentre, wonder, score;
    public List<GameObject> cellList;
    private void Start()
    {
        cell = GameObject.Find("Plane");
        cellList = new List<GameObject>();
    }
    public SaveAndLoad CreateSaveGameObject()
    {
        cellList = cell.gameObject.GetComponent<Map>().cellList;
        panel = GameObject.Find("PanelBuild");
        house = panel.GetComponent<Building>().house;
        library = panel.GetComponent<Building>().library;
        factory = panel.GetComponent<Building>().factory;
        cityCentre = panel.GetComponent<Building>().citycentre;
        wonder = panel.GetComponent<Building>().wonder;
        score = GameObject.Find("Score");
        SaveAndLoad save = new SaveAndLoad();
        mapStateList = new List<GameObject>();
        int i = 0;
        foreach (GameObject cell in cellList )
        {


            i++;
        }
        return save;
    }
}
*/