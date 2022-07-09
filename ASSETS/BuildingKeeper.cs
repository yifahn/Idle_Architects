using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingKeeper
{
    private GameObject house, library, factory, cityCentre, wonder, road, blockade, forest, grassland, towerAA, towerM, farm;
    private GameObject selectedCell;
    private List<GameObject> mapList;
    private List<int> mapListXL1, mapListYL1;

    public BuildingKeeper(GameObject house, GameObject library, GameObject factory, GameObject cityCentre, GameObject wonder, GameObject road, GameObject blockade, GameObject forest, GameObject grassland, GameObject towerAA, GameObject towerM, GameObject farm)
    {
        this.House = house;
        this.Library = library;
        this.Factory = factory;
        this.CityCentre = cityCentre.gameObject;
        this.Wonder = wonder;
        this.Road = road;
        this.Blockade = blockade;
        this.Forest = forest;
        this.Grassland = grassland.gameObject;
        this.TowerAA = towerAA;
        this.TowerM = towerM;
        this.Farm = farm;
        SelectedCell = null;
        mapList = new List<GameObject>();
        mapListXL1 = new List<int>();
        mapListYL1 = new List<int>();


    }//ss
    public void AddToMapList(GameObject cell, int x, int y)
    {

        mapList.Add(cell);
        mapListXL1.Add(x);
        mapListYL1.Add(y);
    }
    public GameObject GetBuilding(string building)
    {
        GameObject buildingObject = null;
        switch (building)
        {
            case "City Centre":
                buildingObject = CityCentre;
                break;
            case "House":
                buildingObject = House;
                break;
            case "Library":
                buildingObject = Library;
                break;
            case "Factory":
                buildingObject = Factory;
                break;
            case "Wonder":
                buildingObject = Wonder;
                break;
            case "TowerAA":
                buildingObject = TowerAA;
                break;
            case "TowerM":
                buildingObject = TowerM;
                break;
            case "Farm":
                buildingObject = Farm;
                break;
            case "Grassland":
                buildingObject = Grassland;
                break;
            case "Road":
                buildingObject = Road;
                break;
            case "Blockade":
                buildingObject = Blockade;
                break;
            case "Forest":
                buildingObject = Forest;
                break;
        }
        return buildingObject.gameObject;
    }
    public void UpdateSelectedCell(GameObject cellToUpdate)
    {
        SelectedCell = cellToUpdate;
    }
    public GameObject GetSelectedCell()
    {
        GameObject cellObject = SelectedCell;//ss
        return cellObject;
    }
    public GameObject SelectedCell
    {
        get { return selectedCell; }
        set { selectedCell = value; }
    }
    public GameObject House
    {
        get { return house; }
        set { house = value; }
    }
    public GameObject Library
    {
        get { return library; }
        set { library = value; }
    }
    public GameObject Factory
    {
        get { return factory; }
        set { factory = value; }
    }
    public GameObject CityCentre
    {
        get { return cityCentre; }
        set { cityCentre = value; }
    }
    public GameObject Wonder
    {
        get { return wonder; }
        set { wonder = value; }
    }
    public GameObject Road
    {
        get { return road; }
        set { road = value; }
    }
    public GameObject Blockade
    {
        get { return blockade; }
        set { blockade = value; }
    }
    public GameObject Forest
    {
        get { return forest; }
        set { forest = value; }
    }
    public GameObject Grassland
    {
        get { return grassland; }
        set { grassland = value; }
    }
    public GameObject TowerAA
    {
        get { return towerAA; }
        set { towerAA = value; }
    }
    public GameObject TowerM
    {
        get { return towerM; }
        set { towerM = value; }
    }
    public GameObject Farm
    {
        get { return farm; }
        set { farm = value; }
    }



}

