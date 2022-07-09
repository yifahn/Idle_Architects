using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.UI;



//REVISED CODEBASE 18/04/22
public class Map : MonoBehaviour
{
    public bool houseSelected, librarySelected, factorySelected, wonderSelected, cityCentreSelected, roadSelected, blockadeSelected, farmSelected, grasslandSelected, forestSelected, towerAASelected, towerMSelected;
    public GameObject house, library, factory, citycentre, wonder, road, blockade, forest, grassland, towerAA, towerM, farm;
    //public GameObject g_Grassland;
    public GameObject panelBuild, scoreObj;
    public List<GameObject> mapListL1;
    public List<string> mapListL2;
    public GameObject gameKeeper;
    public GameObject playerSpawnCell, opponentSpawnCell; //declare



    //public Dictionary<string, string> mapListL2, mapDictL2;
    BuildingKeeper buildingKeeper;
    List<int> xRowList;
    List<int> zColumnList;
    Vector3 position;
    int xPos;
    int zPos;
    int offSet;

    public GameObject selectBoxBoundsText1, selectBoxBoundsText2;
    public bool boundsSelected1, boundsSelected2;
    public GameObject boundsObj1, boundsObj2;

    public GameObject selectedObj;


    public void Start()
    {

        selectedObj = null;
        selectBoxBoundsText1 = GameObject.Find("SelectedAltBuild1");
        selectBoxBoundsText2 = GameObject.Find("SelectedAltBuild2");
        selectBoxBoundsText1.SetActive(false);
        selectBoxBoundsText2.SetActive(false);
        boundsSelected1 = false;
        boundsSelected2 = false;
        boundsObj1 = null;
        boundsObj2 = null;
        houseSelected = false; librarySelected = false; factorySelected = false; wonderSelected = false; cityCentreSelected = false; roadSelected = false; blockadeSelected = false; farmSelected = false; grasslandSelected = false; forestSelected = false; towerAASelected = false; towerMSelected = false;
        Debug.Log("Initiating start variables for map.cs");
        gameKeeper = GameObject.Find("GameKeeper");
        scoreObj = GameObject.Find("Score");
        panelBuild = GameObject.Find("LeftPanel");
        offSet = 3;
        house = (GameObject)Resources.Load(@"Buildings/House", typeof(GameObject));
        library = (GameObject)Resources.Load(@"Buildings/Library", typeof(GameObject));
        factory = (GameObject)Resources.Load(@"Buildings/Factory", typeof(GameObject));
        wonder = (GameObject)Resources.Load(@"Buildings/Wonder", typeof(GameObject));
        citycentre = (GameObject)Resources.Load(@"Buildings/City Centre", typeof(GameObject));
        farm = (GameObject)Resources.Load(@"Buildings/Farm", typeof(GameObject));
        grassland = (GameObject)Resources.Load(@"Buildings/Grassland", typeof(GameObject));
        towerAA = (GameObject)Resources.Load(@"Buildings/TowerAA", typeof(GameObject));
        towerM = (GameObject)Resources.Load(@"Buildings/TowerM", typeof(GameObject));
        road = (GameObject)Resources.Load(@"Buildings/Road", typeof(GameObject));
        blockade = (GameObject)Resources.Load(@"Buildings/Blockade", typeof(GameObject));
        forest = (GameObject)Resources.Load(@"Buildings/Forest", typeof(GameObject));
    }
    public void Update()
    {
        if (SaveAndLoad.IsReadyDrawMap == true)
        {
            Debug.Log("Ready to generate map");

            DrawBoard();
        }
        if (Input.GetButtonUp("left alt"))//falsify and disable all items related to multi-build/multi-remove IF left alt release
        {
            Debug.Log("Released left alt, bounds variables set to false and null");
            if (boundsSelected1 && boundsSelected2)
            {
                 float boundsObjX1 = boundsObj1.transform.position.x;
                 float boundsObjY1 = boundsObj1.transform.position.z;
                 float boundsObjX2 = boundsObj2.transform.position.x;
                 float boundsObjY2 = boundsObj2.transform.position.z;
                int count = 0;
                if (boundsObjX1 < boundsObjX2)
                {
                    if (boundsObjY1 < boundsObjY2)
                    {
                        for (float y = boundsObjY1; y <= boundsObjY2; y += 3f)//bottom to top Obj1 to Obj2 Y
                        {
                            for (float x = boundsObjX1; x <= boundsObjX2; x += 3f)//left to right Obj1 to Obj2 X 
                            {
                               
                                int i = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                                Component halo = mapListL1[i].GetComponent("Halo");
                                halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                                count++;
                            }
                          
                        }
                    }
                    else if (boundsObjY1 > boundsObjY2)
                    {
                        for (float y = boundsObjY1; y >= boundsObjY2; y -= 3f)//bottom to top Obj1 to Obj2 Y
                        {
                            for (float x = boundsObjX1; x <= boundsObjX2; x += 3f)//left to right Obj1 to Obj2 X
                            {
                                int i = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                                Component halo = mapListL1[i].GetComponent("Halo");
                                halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                                count++;
                               
                            }
                            
                        }
                    }
                    else if (boundsObjY1 == boundsObjY2)
                    {
                        float y = boundsObjY1;
                        for (float x = boundsObjX1; x <= boundsObjX2; x += 3f)//left to right Obj1 to Obj2 X
                        {
                           
                            int i = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                            Component halo = mapListL1[i].GetComponent("Halo");
                            halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                            count++;
                        }

                    }
                }
                else if (boundsObjX1 > boundsObjX2)
                {
                    if (boundsObjY1 < boundsObjY2)
                    {
                        for (float y = boundsObjY1; y <= boundsObjY2; y += 3f)//bottom to top Obj1 to Obj2 Y
                        {
                            for (float x = boundsObjX1; x >= boundsObjX2; x -= 3f)//left to right Obj1 to Obj2 X
                            {
                               
                                int i = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                                Component halo = mapListL1[i].GetComponent("Halo");
                                halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                                count++;
                            }
                           
                        }
                    }
                    else if (boundsObjY1 > boundsObjY2)
                    {
                        for (float y = boundsObjY1; y >= boundsObjY2; y -= 3f)//bottom to top Obj1 to Obj2 Y
                        {
                            for (float x = boundsObjX1; x >= boundsObjX2; x -= 3f)//left to right Obj1 to Obj2 X
                            {
                             
                                int i = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                                Component halo = mapListL1[i].GetComponent("Halo");
                                halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                                count++;
                            }
                          
                        }
                    }
                    else if (boundsObjY1 == boundsObjY2)
                    {
                        float y = boundsObjY1;
                        for (float x = boundsObjX1; x >= boundsObjX2; x -= 3f)//left to right Obj1 to Obj2 X
                        {
                          
                            int i = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                            Component halo = mapListL1[i].GetComponent("Halo");
                            halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                            count++;
                        }
                    }
                }
                else if (boundsObjX1 == boundsObjX2)
                {
                    if (boundsObjY1 < boundsObjY2)
                    {
                        for (float y = boundsObjY1; y <= boundsObjY2; y += 3f)//bottom to top Obj1 to Obj2 Y
                        {
                           
                            float x = boundsObjX1;
                            int i = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                            Component halo = mapListL1[i].GetComponent("Halo");
                            halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                            count++;
                        }
                    }
                    else if (boundsObjY1 > boundsObjY2)
                    {
                        float x = boundsObjX1;
                        for (float y = boundsObjY1; y >= boundsObjY2; y -= 3f)//bottom to top Obj1 to Obj2 Y
                        {
                           
                            int i = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                            Component halo = mapListL1[i].GetComponent("Halo");
                            halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                            count++;
                        }
                    }
                    else if (boundsObjY1 == boundsObjY2)
                    {
                        
                            float y = boundsObjY1;
                            float x = boundsObjX1;
                            int i = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                            Component halo = mapListL1[i].GetComponent("Halo");
                            halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                            count++;
                        
                    }
                }
                Debug.Log("disabled " + count + " halos");
            }
            boundsObj1 = null;
            boundsObj2 = null;
            boundsSelected1 = false;
            boundsSelected2 = false;
            selectBoxBoundsText1.SetActive(false);
            selectBoxBoundsText2.SetActive(false);
           
        }
        if (Input.GetMouseButton(0) && Input.GetButton("left shift"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 500.0f) && !hit.collider.gameObject.name.Contains("Plane"))
            {
                if (!hit.collider.gameObject.name.Contains(NodeSelector().name))
                {
                    selectedObj = hit.collider.gameObject;
                    if (!cityCentreSelected && !houseSelected && !librarySelected && !factorySelected && !roadSelected && !blockadeSelected && !roadSelected && !towerAASelected && !towerMSelected && !grasslandSelected && !farmSelected && !forestSelected)
                    {
                        Debug.Log("Select a building or the remove function before selecting a node");
                    }
                    else
                    {
                        Debug.Log("left click & left shift detected - building at mouse raycast");
                        EditMap(NodeSelector(), selectedObj.transform.position.x, selectedObj.transform.position.z);
                    }
                }
            }
        }
        if (Input.GetButtonUp("left shift"))
        {
            Debug.Log("left shift released");
            selectedObj = null;
        }
    }
    public bool PriceChecker(string node)
    {
        bool returnBool = false;
        if (grasslandSelected == true)//if remove selected - pricecheck is not required as refund will occur
        {
            returnBool = true;
        }
        else //if build is selected - pricecheck required as score will be deducted
        {
            Debug.Log(scoreObj.GetComponent<Score>().score);
            switch (node)
            {
                case "City Centre":
                    returnBool = true;
                    break;
                case "House":
                    if (scoreObj.GetComponent<Score>().score > scoreObj.GetComponent<Score>().housePrice && scoreObj.GetComponent<Score>().numHouses < scoreObj.GetComponent<Score>().maxNumHouses) { returnBool = true; }
                    break;
                case "Library":
                    if (scoreObj.GetComponent<Score>().score > scoreObj.GetComponent<Score>().libraryPrice && scoreObj.GetComponent<Score>().numLibraries < scoreObj.GetComponent<Score>().maxNumLibraries) { returnBool = true; }
                    break;
                case "Factory":
                    if (scoreObj.GetComponent<Score>().score > scoreObj.GetComponent<Score>().factoryPrice && scoreObj.GetComponent<Score>().numFactories < scoreObj.GetComponent<Score>().maxNumFactories) { returnBool = true; }
                    break;
                case "Wonder":
                    if (scoreObj.GetComponent<Score>().score > scoreObj.GetComponent<Score>().wonderPrice && scoreObj.GetComponent<Score>().numWonders < scoreObj.GetComponent<Score>().maxNumWonders) { returnBool = true; }
                    break;
                case "Road":
                    if (scoreObj.GetComponent<Score>().score > scoreObj.GetComponent<Score>().roadPrice) { returnBool = true; }
                    break;
                case "Blockade":
                    if (scoreObj.GetComponent<Score>().score > scoreObj.GetComponent<Score>().blockadePrice) { returnBool = true; }
                    break;
                case "TowerAA":
                    if (scoreObj.GetComponent<Score>().score > scoreObj.GetComponent<Score>().towerAAPrice) { returnBool = true; }
                    break;
                case "TowerM":
                    if (scoreObj.GetComponent<Score>().score > scoreObj.GetComponent<Score>().towerMPrice) { returnBool = true; }
                    break;
                case "Forest":
                    returnBool = true;
                    break;
                case "Farm":
                    returnBool = true;
                    break;
            }
        }
        Debug.Log(returnBool);
        return returnBool;
    }
    public void NodeHandlerOnClick(GameObject node)
    {
        Debug.Log(node.transform.position.x);
        Debug.Log(node.transform.position.z);
        if (!Input.GetButton("left alt") && !Input.GetButton("left shift")) //if single click build
        {
            if (!cityCentreSelected && !houseSelected && !librarySelected && !factorySelected && !roadSelected && !blockadeSelected && !roadSelected && !towerAASelected && !towerMSelected && !grasslandSelected && !farmSelected && !forestSelected)
            {
                Debug.Log("Select a building or the remove function before selecting a node");
            }
            else
            {
                Debug.Log("IF SHIFT CLICK - DO NOT DO THIS");
                EditMap(NodeSelector(), node.transform.position.x, node.transform.position.z);
            }
        }
        else if (Input.GetButton("left alt") && !Input.GetButton("left shift")) //if multi build/remove
        {
            if (!boundsSelected1 && !boundsSelected2)
            {
                boundsObj1 = node;
                boundsSelected1 = true;
                selectBoxBoundsText1.SetActive(true);
                string node1 = String.Format("x={0},y={1}", boundsObj1.transform.position.x / 3, -boundsObj1.transform.position.z / 3);//continue^
                selectBoxBoundsText1.GetComponent<Text>().text = node1;
                Debug.Log("first node selected");
                //add alt text to UI for boundsobj1.name
            }
            else if (boundsSelected1 && !boundsSelected2)
            {////////////////
                boundsObj2 = node;
                boundsSelected2 = true;
                selectBoxBoundsText2.SetActive(true);
                string node2 = String.Format("x={0},y={1}", boundsObj2.transform.position.x / 3, -boundsObj2.transform.position.z / 3);//continue^
                selectBoxBoundsText2.GetComponent<Text>().text = node2;
                Debug.Log("second node selected");

                float boundsObj1X = boundsObj1.GetComponent<Transform>().position.x;
                float boundsObj2X = boundsObj2.GetComponent<Transform>().position.x;
                float boundsObjY1 = boundsObj1.GetComponent<Transform>().position.z;
                float boundsObj2Y = boundsObj2.GetComponent<Transform>().position.z;
                Debug.Log(boundsObj1X + "," + boundsObjY1 + " Obj1 - " + boundsObj2X + "," + boundsObj2Y + " Obj2");
                if (boundsObj1X < boundsObj2X)
                {
                    if (boundsObjY1 < boundsObj2Y)
                    {
                        for (float y = boundsObjY1; y <= boundsObj2Y; y += 3f)//bottom to top Obj1 to Obj2 Y
                        {
                            for (float x = boundsObj1X; x <= boundsObj2X; x += 3f)//left to right Obj1 to Obj2 X
                            {
                                
                                int index = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                                Component halo = mapListL1[index].GetComponent("Halo");
                                halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
                            }
                            
                        }
                    }
                    else if (boundsObjY1 > boundsObj2Y)
                    {
                        for (float y = boundsObjY1; y >= boundsObj2Y; y -= 3f)//bottom to top Obj1 to Obj2 Y
                        {
                            for (float x = boundsObj1X; x <= boundsObj2X; x += 3f)//left to right Obj1 to Obj2 X
                            {
                                
                                int index = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                                Component halo = mapListL1[index].GetComponent("Halo");
                                halo.GetType().GetProperty("enabled").SetValue(halo, true, null);

                            }
                            
                        }
                    }
                    else if (boundsObjY1 == boundsObj2Y)
                    {
                        float y = boundsObjY1;
                        for (float x = boundsObj1X; x <= boundsObj2X; x += 3f)//left to right Obj1 to Obj2 X
                        {
                            
                            int index = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                            Component halo = mapListL1[index].GetComponent("Halo");
                            halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
                        }

                    }
                }
                else if (boundsObj1X > boundsObj2X)
                {
                    if (boundsObjY1 < boundsObj2Y)
                    {
                        for (float y = boundsObjY1; y <= boundsObj2Y; y += 3f)//bottom to top Obj1 to Obj2 Y
                        {
                            for (float x = boundsObj1X; x >= boundsObj2X; x -= 3f)//left to right Obj1 to Obj2 X
                            {
                                
                                int index = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                                Component halo = mapListL1[index].GetComponent("Halo");
                                halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
                            }
                            
                        }
                    }
                    else if (boundsObjY1 > boundsObj2Y)
                    {
                        for (float y = boundsObjY1; y >= boundsObj2Y; y -= 3f)//bottom to top Obj1 to Obj2 Y
                        {
                            for (float x = boundsObj1X; x >= boundsObj2X; x -= 3f)//left to right Obj1 to Obj2 X
                            {
                                
                                int index = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                                Component halo = mapListL1[index].GetComponent("Halo");
                                halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
                            }
                            
                        }
                    }
                    else if (boundsObjY1 == boundsObj2Y)
                    {
                        float y = boundsObjY1;
                        for (float x = boundsObj1X; x >= boundsObj2X; x -= 3f)//left to right Obj1 to Obj2 X
                        {
                            
                            int index = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                            Component halo = mapListL1[index].GetComponent("Halo");
                            halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
                        }
                       
                    }
                }
                else if (boundsObj1X == boundsObj2X)
                {
                    if (boundsObjY1 < boundsObj2Y)
                    {
                        float x = boundsObj1X;
                        for (float y = boundsObjY1; y <= boundsObj2Y; y += 3f)//bottom to top Obj1 to Obj2 Y
                        {
                            
                            int index = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                            Component halo = mapListL1[index].GetComponent("Halo");
                            halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
                           
                        }
                    }
                    else if (boundsObjY1 > boundsObj2Y)
                    {
                        float x = boundsObj1X;
                        for (float y = boundsObjY1; y >= boundsObj2Y; y -= 3f)//bottom to top Obj1 to Obj2 Y
                        {
                            
                            int index = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                            Component halo = mapListL1[index].GetComponent("Halo");
                            halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
                        }
                    }
                    else if (boundsObjY1 == boundsObj2Y)
                    {
                        float y = boundsObjY1;
                        float x = boundsObj1X;

                            int index = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                            Component halo = mapListL1[index].GetComponent("Halo");
                            halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
                      
                    }
                }
            }
            else if (boundsSelected1 && boundsSelected2)
            {
                float boundsObj1X = boundsObj1.GetComponent<Transform>().position.x;
                float boundsObj2X = boundsObj2.GetComponent<Transform>().position.x;
                float boundsObjY1 = boundsObj1.GetComponent<Transform>().position.z;
                float boundsObj2Y = boundsObj2.GetComponent<Transform>().position.z;
                Debug.Log(boundsObj1X + "," + boundsObjY1 + " Obj1 - " + boundsObj2X + "," + boundsObj2Y + " Obj2");
                GameObject tempObj1, tempObj2;


                if (boundsObj1X < boundsObj2X)
                {
                    if (boundsObjY1 < boundsObj2Y)
                    {
                        for (float y = boundsObjY1; y <= boundsObj2Y; y += 3f)//bottom to top Obj1 to Obj2 Y
                        {
                            for (float x = boundsObj1X; x <= boundsObj2X; x += 3f)//left to right Obj1 to Obj2 X
                            {
                                int index = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                                if (!grasslandSelected) { if (mapListL1[index].name.Contains("Grassland")) { EditMap(NodeSelector(), x, y); } } //if build selected
                                else { EditMap(NodeSelector(), x, y); } //if remove selected
                                Component halo = mapListL1[index].GetComponent("Halo");
                                halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                            }
                        }
                    }
                    else if (boundsObjY1 > boundsObj2Y)
                    {
                        for (float y = boundsObjY1; y >= boundsObj2Y; y -= 3f)//bottom to top Obj1 to Obj2 Y
                        {
                            for (float x = boundsObj1X; x <= boundsObj2X; x += 3f)//left to right Obj1 to Obj2 X
                            {
                                int index = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                                if (!grasslandSelected) { if (mapListL1[index].name.Contains("Grassland")) { EditMap(NodeSelector(), x, y); } } //if build selected
                                else { EditMap(NodeSelector(), x, y); } //if remove selected
                                Component halo = mapListL1[index].GetComponent("Halo");
                                halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                            }
                        }
                    }
                    else if (boundsObjY1 == boundsObj2Y)
                    {
                        float y = boundsObjY1;
                        for (float x = boundsObj1X; x <= boundsObj2X; x += 3f)//left to right Obj1 to Obj2 X
                        {
                            int index = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                            if (!grasslandSelected) { if (mapListL1[index].name.Contains("Grassland")) { EditMap(NodeSelector(), x, y); } } //if build selected
                            else { EditMap(NodeSelector(), x, y); } //if remove selected
                            Component halo = mapListL1[index].GetComponent("Halo");
                            halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                        }

                    }
                }
                else if (boundsObj1X > boundsObj2X)
                {
                    if (boundsObjY1 < boundsObj2Y)
                    {
                        for (float y = boundsObjY1; y <= boundsObj2Y; y += 3f)//bottom to top Obj1 to Obj2 Y
                        {
                            for (float x = boundsObj1X; x >= boundsObj2X; x -= 3f)//left to right Obj1 to Obj2 X
                            {
                                int index = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                                if (!grasslandSelected) { if (mapListL1[index].name.Contains("Grassland")) { EditMap(NodeSelector(), x, y); } } //if build selected
                                else { EditMap(NodeSelector(), x, y); } //if remove selected
                                Component halo = mapListL1[index].GetComponent("Halo");
                                halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                            }
                        }
                    }
                    else if (boundsObjY1 > boundsObj2Y)
                    {
                        for (float y = boundsObjY1; y >= boundsObj2Y; y -= 3f)//bottom to top Obj1 to Obj2 Y
                        {
                            for (float x = boundsObj1X; x >= boundsObj2X; x -= 3f)//left to right Obj1 to Obj2 X
                            {
                                int index = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                                if (!grasslandSelected) { if (mapListL1[index].name.Contains("Grassland")) { EditMap(NodeSelector(), x, y); } } //if build selected
                                else { EditMap(NodeSelector(), x, y); } //if remove selected
                                Component halo = mapListL1[index].GetComponent("Halo");
                                halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                            }
                        }
                    }
                    else if (boundsObjY1 == boundsObj2Y)
                    {
                        float y = boundsObjY1;
                        for (float x = boundsObj1X; x >= boundsObj2X; x -= 3f)//left to right Obj1 to Obj2 X
                        {
                            int index = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                            if (!grasslandSelected) { if (mapListL1[index].name.Contains("Grassland")) { EditMap(NodeSelector(), x, y); } } //if build selected
                            else { EditMap(NodeSelector(), x, y); } //if remove selected
                            Component halo = mapListL1[index].GetComponent("Halo");
                            halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                        }
                    }
                }
                else if (boundsObj1X == boundsObj2X)
                {
                    if (boundsObjY1 < boundsObj2Y)
                    {
                        for (float y = boundsObjY1; y <= boundsObj2Y; y += 3f)//bottom to top Obj1 to Obj2 Y
                        {
                            float x = boundsObj1X;
                            int index = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                            if (!grasslandSelected) { if (mapListL1[index].name.Contains("Grassland")) { EditMap(NodeSelector(), x, y); } } //if build selected
                            else { EditMap(NodeSelector(), x, y); } //if remove selected
                            Component halo = mapListL1[index].GetComponent("Halo");
                            halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                        }
                    }
                    else if (boundsObjY1 > boundsObj2Y)
                    {
                        float x = boundsObj1X;
                        for (float y = boundsObjY1; y >= boundsObj2Y; y -= 3f)//bottom to top Obj1 to Obj2 Y
                        {
                            int index = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                            if (!grasslandSelected) { if (mapListL1[index].name.Contains("Grassland")) { EditMap(NodeSelector(), x, y); } } //if build selected
                            else { EditMap(NodeSelector(), x, y); } //if remove selected
                            Component halo = mapListL1[index].GetComponent("Halo");
                            halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                        }
                    }
                    else if (boundsObjY1 == boundsObj2Y)
                    {
                        float y = boundsObjY1;
                        float x = boundsObj1X;
                        int index = 60 * ((int)-y / 3) + ((int)x / 3) - 61;
                        if (!grasslandSelected) { if (mapListL1[index].name.Contains("Grassland")) { EditMap(NodeSelector(), x, y); } } //if build selected
                        else { EditMap(NodeSelector(), x, y); } //if remove selected
                       
                        Component halo = mapListL1[index].GetComponent("Halo");
                        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
                    }
                }
                Debug.Log(boundsObj1X + "," + boundsObjY1 + " Obj1 - " + boundsObj2X + "," + boundsObj2Y + " Obj2");
                //uninitialise bounds variables
                Debug.Log("Finished Multi Build/Remove");
                boundsSelected1 = false;
                boundsSelected2 = false;
                boundsObj1 = null;
                boundsObj2 = null;
            }
        }
    }
    public GameObject NodeSelector()
    {
        if (houseSelected) { return house; }
        else if (librarySelected) { return library; }
        else if (factorySelected) { return factory; }
        else if (cityCentreSelected) { return citycentre; }
        else if (wonderSelected) { return wonder; }
        else if (farmSelected) { return farm; }
        else if (grasslandSelected) { return grassland; }
        else if (forestSelected) { return forest; }
        else if (blockadeSelected) { return blockade; }
        else if (roadSelected) { return road; }
        else if (towerAASelected) { return towerAA; }
        else if (towerMSelected) { return towerM; }
        else { return null; }

    }
    public void SetOpponentSpawn()
    {
        if (CellState.opponentSpawnBool == true)
        {
            gameKeeper.GetComponent<SetSpawn>().hasOpponentSpawn = false;
            Debug.Log("opponentspawnbool is set to true so instantiate a opponentspawn at saved location");
            Debug.Log(CellState.playerSpawn);
            Debug.Log(CellState.opponentSpawn);
            int tempInt = int.Parse(CellState.opponentSpawn);
            gameKeeper.GetComponent<SetSpawn>().SetOpponentSpawn(mapListL1[tempInt]);
            gameKeeper.GetComponent<SetSpawn>().hasOpponentSpawn = true;
        }
        else
        {
            Debug.Log("setting op spawn to default '.'");
            gameKeeper.GetComponent<SetSpawn>().hasOpponentSpawn = false;
            CellState.opponentSpawn = ".";
        }
    }
    public void SetPlayerSpawn()
    {
        if (CellState.playerSpawnBool == true)
        {
            gameKeeper.GetComponent<SetSpawn>().hasPlayerSpawn = false;
            Debug.Log("playerspawnbool is set to true so instantiate a opponentspawn at saved location");
            Debug.Log(CellState.playerSpawn);
            Debug.Log(CellState.opponentSpawn);
            int tempInt = int.Parse(CellState.playerSpawn);

            gameKeeper.GetComponent<SetSpawn>().SetPlayerSpawn(mapListL1[tempInt]);
            gameKeeper.GetComponent<SetSpawn>().hasPlayerSpawn = true;
        }
        else
        {
            Debug.Log("setting player spawn to default ','");
            gameKeeper.GetComponent<SetSpawn>().hasPlayerSpawn = false;
            CellState.playerSpawn = ".";
        }
    }//ss

    /// <summary>
    /// edit map
    /// </summary>
    public void EditMap(GameObject replacement, float x, float y)
    {
        Debug.Log("SAVELOADREPEATCHECKER - ");
        Debug.Log(PriceChecker(replacement.name) + " " + scoreObj.GetComponent<Score>().isLoad + " " + ScoreState.isLoad + " " + scoreObj.GetComponent<Score>().isLoadingBoolForMapGen);
        //edit mapListL1 & mapListL2
        Debug.Log(x + " " + y);
        int listX = (int)x / 3;
        int listY = (int)y / 3;
        int weight = 0;
        float buildingHeight = 1.2f;
        GameObject obj = replacement;//assign parsed gameobject to 'obj' var
        obj.transform.localScale.Set(2, 1, 2);//edit size of gameobject
        float indexPreProcessed = (60 * -listY - (60 - listX)) - 1; //get index from x & y pos - 1,1 \ 60,33
                                                                    //count = (60 * countY2 - (60 - countX2)) - 1;
        int index = (int)indexPreProcessed; //cast as int
        Debug.Log(index);                   //edit mapListL1 & mapListL2
        Debug.Log(x + " " + y);             // road blockade grassland forest towerm toweraa city centre house library factory wonder farm
        Debug.Log("DEBUG1");
        Debug.Log(obj.name);
        Debug.Log(scoreObj.GetComponent<Score>().isLoad);
        if (PriceChecker(obj.name) == true || /*(PriceChecker(obj.name) == false && */SaveAndLoad.IsReadyPlay == false)//)//if isLoad == false dont check price, if true THEN do check price
        {
            // Debug.Log(PriceChecker(obj.name));
            if (SaveAndLoad.IsReadyPlay == true) { scoreObj.GetComponent<Score>().BuildScoreUpdate(obj.name); Debug.Log("Updating Score"); }
            switch (obj.name)
            {
                case "Grassland":
                    Destroy(mapListL1[index]); //destroy gameobject at index of mapListL1
                    mapListL1.RemoveAt(index); //remove gameobject from list
                    mapListL1.Insert(index, Instantiate(obj, position = new Vector3(x, 0, y), Quaternion.identity)); //instantiate obj and insert instantiated obj into list
                                           // SaveAndLoad.IsReadyPlay == false                                                                          //edit L2 list
                    weight = 2;//traversable building - dijkstras related variable
                    if (SaveAndLoad.IsReadyPlay == false) { mapListL2.RemoveAt(index); mapListL2.Insert(index, CellState.MapListL2[index]); }
                    else { mapListL2.RemoveAt(index); mapListL2.Insert(index, string.Format("{0},1-0,2-0,3-0,4-0,5-0", weight)); }

                    break;
                case "City Centre":

                    Destroy(mapListL1[index]); //destroy gameobject at index of mapListL1
                    Debug.Log("DEBUG1");
                    mapListL1.RemoveAt(index); //remove gameobject from list
                    Debug.Log("DEBUG1");
                    mapListL1.Insert(index, Instantiate(obj, position = new Vector3(x, buildingHeight, y), Quaternion.identity)); //instantiate obj and insert instantiated obj into list
                                                                                                                                  //edit L2 list
                    Debug.Log("DEBUG1");
                    weight = 500; //difficult-to-traverse building - dijkstras related variable
                    if (SaveAndLoad.IsReadyPlay == false) { mapListL2.RemoveAt(index); mapListL2.Insert(index, CellState.MapListL2[index]); }
                    else { mapListL2.RemoveAt(index); mapListL2.Insert(index, string.Format("{0},1-0,2-0,3-0,4-0,5-0", weight)); }
                    break;
                case "House":
                    Destroy(mapListL1[index]); //destroy gameobject at index of mapListL1
                    mapListL1.RemoveAt(index); //remove gameobject from list
                    mapListL1.Insert(index, Instantiate(obj, position = new Vector3(x, buildingHeight, y), Quaternion.identity)); //instantiate obj and insert instantiated obj into list
                                                                                                                                  //edit L2 list
                    weight = 500; //difficult-to-traverse building - dijkstras related variable
                    if (SaveAndLoad.IsReadyPlay == false) { mapListL2.RemoveAt(index); mapListL2.Insert(index, CellState.MapListL2[index]); }
                    else { mapListL2.RemoveAt(index); mapListL2.Insert(index, string.Format("{0},1-0,2-0,3-0,4-0,5-0", weight)); }
                    break;
                case "Library":
                    Destroy(mapListL1[index]); //destroy gameobject at index of mapListL1
                    mapListL1.RemoveAt(index); //remove gameobject from list
                    mapListL1.Insert(index, Instantiate(obj, position = new Vector3(x, buildingHeight, y), Quaternion.identity)); //instantiate obj and insert instantiated obj into list
                                                                                                                                  //edit L2 list
                    weight = 500; //difficult-to-traverse building - dijkstras related variable
                    if (SaveAndLoad.IsReadyPlay == false) { mapListL2.RemoveAt(index); mapListL2.Insert(index, CellState.MapListL2[index]); }
                    else { mapListL2.RemoveAt(index); mapListL2.Insert(index, string.Format("{0},1-0,2-0,3-0,4-0,5-0", weight)); }
                    break;
                case "Factory":
                    Destroy(mapListL1[index]); //destroy gameobject at index of mapListL1
                    mapListL1.RemoveAt(index); //remove gameobject from list
                    mapListL1.Insert(index, Instantiate(obj, position = new Vector3(x, buildingHeight, y), Quaternion.identity)); //instantiate obj and insert instantiated obj into list
                                                                                                                                  //edit L2 list
                    weight = 500; //difficult-to-traverse building - dijkstras related variable
                    if (SaveAndLoad.IsReadyPlay == false) { mapListL2.RemoveAt(index); mapListL2.Insert(index, CellState.MapListL2[index]); }
                    else { mapListL2.RemoveAt(index); mapListL2.Insert(index, string.Format("{0},1-0,2-0,3-0,4-0,5-0", weight)); }
                    break;
                case "Wonder":
                    Destroy(mapListL1[index]); //destroy gameobject at index of mapListL1
                    mapListL1.RemoveAt(index); //remove gameobject from list
                    mapListL1.Insert(index, Instantiate(obj, position = new Vector3(x, buildingHeight, y), Quaternion.identity)); //instantiate obj and insert instantiated obj into list
                                                                                                                                  //edit L2 list
                    weight = 500; //difficult-to-traverse building - dijkstras related variable
                    if (SaveAndLoad.IsReadyPlay == false) { mapListL2.RemoveAt(index); mapListL2.Insert(index, CellState.MapListL2[index]); }
                    else { mapListL2.RemoveAt(index); mapListL2.Insert(index, string.Format("{0},1-0,2-0,3-0,4-0,5-0", weight)); }
                    break;
                case "Road":
                    Destroy(mapListL1[index]); //destroy gameobject at index of mapListL1
                    mapListL1.RemoveAt(index); //remove gameobject from list
                    mapListL1.Insert(index, Instantiate(obj, position = new Vector3(x, buildingHeight, y), Quaternion.identity)); //instantiate obj and insert instantiated obj into list
                                                                                                                                  //edit L2 list
                    weight = 1; //difficult-to-traverse building - dijkstras related variable
                    if (SaveAndLoad.IsReadyPlay == false) { mapListL2.RemoveAt(index); mapListL2.Insert(index, CellState.MapListL2[index]); }
                    else { mapListL2.RemoveAt(index); mapListL2.Insert(index, string.Format("{0},1-0,2-0,3-0,4-0,5-0", weight)); }
                    break;
                case "Blockade":
                    Destroy(mapListL1[index]); //destroy gameobject at index of mapListL1
                    mapListL1.RemoveAt(index); //remove gameobject from list
                    mapListL1.Insert(index, Instantiate(obj, position = new Vector3(x, buildingHeight, y), Quaternion.identity)); //instantiate obj and insert instantiated obj into list
                                                                                                                                  //edit L2 list
                    weight = 10; //traversable building - dijkstras related variable
                    if (SaveAndLoad.IsReadyPlay == false) { mapListL2.RemoveAt(index); mapListL2.Insert(index, CellState.MapListL2[index]); }
                    else { mapListL2.RemoveAt(index); mapListL2.Insert(index, string.Format("{0},1-0,2-0,3-0,4-0,5-0", weight)); }
                    break;
                case "TowerAA":
                    Destroy(mapListL1[index]); //destroy gameobject at index of mapListL1
                    mapListL1.RemoveAt(index); //remove gameobject from list
                    mapListL1.Insert(index, Instantiate(obj, position = new Vector3(x, buildingHeight, y), Quaternion.identity)); //instantiate obj and insert instantiated obj into list
                                                                                                                                  //edit L2 list
                    weight = 500; //difficult-to-traverse building - dijkstras related variable
                    if (SaveAndLoad.IsReadyPlay == false) { mapListL2.RemoveAt(index); mapListL2.Insert(index, CellState.MapListL2[index]); }
                    else { mapListL2.RemoveAt(index); mapListL2.Insert(index, string.Format("{0},1-0,2-0,3-0,4-0,5-0", weight)); }
                    break;
                case "TowerM":
                    Destroy(mapListL1[index]); //destroy gameobject at index of mapListL1
                    mapListL1.RemoveAt(index); //remove gameobject from list
                    mapListL1.Insert(index, Instantiate(obj, position = new Vector3(x, buildingHeight, y), Quaternion.identity)); //instantiate obj and insert instantiated obj into list
                                                                                                                                  //edit L2 list
                    weight = 500; //non-traversable building - dijkstras related variable
                    if (SaveAndLoad.IsReadyPlay == false) { mapListL2.RemoveAt(index); mapListL2.Insert(index, CellState.MapListL2[index]); }
                    else { mapListL2.RemoveAt(index); mapListL2.Insert(index, string.Format("{0},1-0,2-0,3-0,4-0,5-0", weight)); }
                    break;
                case "Forest":
                    Destroy(mapListL1[index]); //destroy gameobject at index of mapListL1
                    mapListL1.RemoveAt(index); //remove gameobject from list
                    mapListL1.Insert(index, Instantiate(obj, position = new Vector3(x, buildingHeight, y), Quaternion.identity)); //instantiate obj and insert instantiated obj into list
                                                                                                                                  //edit L2 list
                    weight = 4; //traversable building - dijkstras related variable
                    if (SaveAndLoad.IsReadyPlay == false) { mapListL2.RemoveAt(index); mapListL2.Insert(index, CellState.MapListL2[index]); }
                    else { mapListL2.RemoveAt(index); mapListL2.Insert(index, string.Format("{0},1-0,2-0,3-0,4-0,5-0", weight)); }
                    break;
                case "Farm":
                    Destroy(mapListL1[index]); //destroy gameobject at index of mapListL1
                    mapListL1.RemoveAt(index); //remove gameobject from list
                    mapListL1.Insert(index, Instantiate(obj, position = new Vector3(x, buildingHeight, y), Quaternion.identity)); //instantiate obj and insert instantiated obj into list
                                                                                                                                  //edit L2 list
                    weight = 3; //traversable building - dijkstras related variable
                    if (SaveAndLoad.IsReadyPlay == false) { mapListL2.RemoveAt(index); mapListL2.Insert(index, CellState.MapListL2[index]); }
                    else { mapListL2.RemoveAt(index); mapListL2.Insert(index, string.Format("{0},1-0,2-0,3-0,4-0,5-0", weight)); }
                    break;
            }
        }
        if (PriceChecker(obj.name) == false && SaveAndLoad.IsReadyPlay == false)
        {
      
            //build regardless, loading map
            //do nothing
        }
        if (PriceChecker(obj.name) == false && SaveAndLoad.IsReadyPlay == true)
        {
            Debug.Log("You do not have enough money to execute the remainder of this build OR you have reached the maximum number of this type of building");
        }
        //edit of maplists and instantiation of new gameobject complete
    }
    /// <summary>
    /// generate map
    /// </summary>
    private void DrawBoard()
    {
        Debug.Log("Generating map");//ss
        mapListL1 = new List<GameObject>();
        mapListL2 = new List<string>();
        int weight = 0;
        gameKeeper.GetComponent<SetSpawn>().hasPlayerSpawn = false;
        gameKeeper.GetComponent<SetSpawn>().hasOpponentSpawn = false;

        //NEW MAP GENERATION
        weight = 2;
        for (int ii = 1; ii <= 33; ii++)
        {
            for (int j = 1; j <= 60; j++)
            {
                GameObject obj = grassland;
                obj.transform.localScale.Set(2, 1, 2);
                mapListL1.Add(Instantiate(obj, position = new Vector3(j * offSet, 0, -ii * offSet), Quaternion.identity));
                mapListL2.Add(string.Format("{0},1-0,2-0,3-0,4-0,5-0", weight));

            }
        }
        int index = 0;
        //IF LOAD...
        Debug.Log(ScoreState.IsLoad);
        if (ScoreState.IsLoad)//&& SaveAndLoad.IsReadyDrawMap
        {
            Debug.Log("Loading map");
            CellState.playerSpawn = ".";
            CellState.opponentSpawn = ".";
            //EDIT MAP FROM SAVE
            Debug.Log(CellState.MapListL1.Count() + " = CellState MapListL1 count");
            for (int ii = 1; ii <= 33; ii++)
            {
                for (int j = 1; j <= 60; j++)
                {
                    switch (CellState.MapListL1[index])
                    {
                        case "Grassland(Clone)":
                            //do nothing
                            break;
                        case "City Centre(Clone)":
                            EditMap(citycentre, j * offSet, -ii * offSet);
                            break;
                        case "House(Clone)":
                            EditMap(house, j * offSet, -ii * offSet);
                            break;
                        case "Library(Clone)":
                            EditMap(library, j * offSet, -ii * offSet);
                            break;
                        case "Factory(Clone)":
                            EditMap(factory, j * offSet, -ii * offSet);
                            break;
                        case "Wonder(Clone)":
                            EditMap(wonder, j * offSet, -ii * offSet);
                            break;
                        case "Road(Clone)":
                            EditMap(road, j * offSet, -ii * offSet);
                            break;
                        case "Blockade(Clone)":
                            EditMap(blockade, j * offSet, -ii * offSet);
                            break;
                        case "TowerAA(Clone)":
                            EditMap(towerAA, j * offSet, -ii * offSet);
                            break;
                        case "TowerM(Clone)":
                            EditMap(towerM, j * offSet, -ii * offSet);
                            break;
                        case "Forest(Clone)":
                            EditMap(forest, j * offSet, -ii * offSet);
                            break;
                        case "Farm(Clone)":
                            EditMap(farm, j * offSet, -ii * offSet);
                            break;
                    }
                    index++;
                }
            }
        }//ss
        Debug.Log(ScoreState.Score);
        SaveAndLoad.IsReadyDrawMap = false;//unnecessary?
        SaveAndLoad.IsReadyPlay = true; // FINISH LOAD MAP - CAN BEGIN EDITING BUILDING VARIABLES
       
    }

    /// <summary>//ss
    /// save map
    /// </summary>
    public void SaveBoard() //UPDATED
    {
        Debug.Log("SaveBoard called");
        int index = 0;
        Debug.Log(mapListL1.Count);
        Debug.Log(mapListL2.Count);
        Debug.Log(CellState.MapListL1.Count());
        Debug.Log(CellState.MapListL2.Count());
        CellState.MapListL1.Clear();
        CellState.MapListL2.Clear();
        foreach (GameObject obj in mapListL1)
        {
            CellState.MapListL1.Add(obj.name); //Insertss
            CellState.MapListL2.Add(mapListL2[index]);
            index++;
        }
        ScoreState.Score = scoreObj.GetComponent<Score>().score;
        ScoreState.ScoreMultiplier = scoreObj.GetComponent<Score>().scoreMultiplier;
        ScoreState.ScoreGainRate = scoreObj.GetComponent<Score>().scoreGainRate;
        ScoreState.MaxNumLibraries = scoreObj.GetComponent<Score>().maxNumLibraries;
        ScoreState.MaxNumFactories = scoreObj.GetComponent<Score>().maxNumFactories;
        ScoreState.MaxNumHouses = scoreObj.GetComponent<Score>().maxNumHouses;
        ScoreState.MaxNumWonders = scoreObj.GetComponent<Score>().maxNumWonders;
        ScoreState.NumAATowers = scoreObj.GetComponent<Score>().numAATowers;
        ScoreState.NumMTowers = scoreObj.GetComponent<Score>().numMTowers;
        ScoreState.NumHouses = scoreObj.GetComponent<Score>().numHouses;
        ScoreState.NumLibraries = scoreObj.GetComponent<Score>().numLibraries;
        ScoreState.NumFactories = scoreObj.GetComponent<Score>().numFactories;
        ScoreState.NumCityCentres = scoreObj.GetComponent<Score>().numCityCentres;
        ScoreState.NumWonders = scoreObj.GetComponent<Score>().numWonders;
        ScoreState.NumRoads = scoreObj.GetComponent<Score>().numRoads;
        ScoreState.NumBlockades = scoreObj.GetComponent<Score>().numBlockades;
        ScoreState.NumFarms = scoreObj.GetComponent<Score>().numFarms;
        ScoreState.NumForests = scoreObj.GetComponent<Score>().numForests;

        ScoreState.TowerAAPrice = scoreObj.GetComponent<Score>().towerAAPrice;
        ScoreState.TowerMPrice = scoreObj.GetComponent<Score>().towerMPrice;
        ScoreState.HousePrice = scoreObj.GetComponent<Score>().housePrice;
        ScoreState.LibraryPrice = scoreObj.GetComponent<Score>().libraryPrice;
        ScoreState.FactoryPrice = scoreObj.GetComponent<Score>().factoryPrice;
        ScoreState.WonderPrice = scoreObj.GetComponent<Score>().wonderPrice;
        ScoreState.RoadPrice = scoreObj.GetComponent<Score>().roadPrice;
        ScoreState.BlockadePrice = scoreObj.GetComponent<Score>().blockadePrice;

        ScoreState.HouseGainRate = scoreObj.GetComponent<Score>().houseGainRate;
        ScoreState.FactoryGainRate = scoreObj.GetComponent<Score>().factoryGainRate;
        ScoreState.FactoryMultiplier = scoreObj.GetComponent<Score>().factoryMultiplier;
        ScoreState.LibraryMultiplier = scoreObj.GetComponent<Score>().libraryMultiplier;
        ScoreState.WonderMultiplier = scoreObj.GetComponent<Score>().wonderMultiplier;

        /*
         *     public double score, scoreMultiplier, scoreGainRate;
    public double maxNumHouses, maxNumLibraries, maxNumFactories, maxNumWonders;
    public double numHouses, numLibraries, numFactories, numCityCentres, numWonders, numBlockades, numRoads, numForests, numMTowers, numAATowers, numFarms;
    public double roadPrice, blockadePrice, towerMPrice, towerAAPrice, housePrice, libraryPrice, factoryPrice, wonderPrice;
    public double houseGainRate, libraryMultiplier, factoryGainRate, factoryMultiplier, wonderMultiplier;
         */
        Debug.Log(CellState.mapListL1.Count());
        Debug.Log(CellState.mapListL2.Count());
        //mapListL1.Clear();
        //mapListL2.Clear();
    }

    public void SelectNone()
    {
        houseSelected = false; librarySelected = false; factorySelected = false; wonderSelected = false; cityCentreSelected = false; roadSelected = false; blockadeSelected = false; farmSelected = false; grasslandSelected = false; forestSelected = false; towerAASelected = false; towerMSelected = false;
    }
    public void SelectHouse()
    {
        houseSelected = true; librarySelected = false; factorySelected = false; wonderSelected = false; cityCentreSelected = false; roadSelected = false; blockadeSelected = false; farmSelected = false; grasslandSelected = false; forestSelected = false; towerAASelected = false; towerMSelected = false;
    }
    public void SelectBlockade()
    {
        houseSelected = false; librarySelected = false; factorySelected = false; wonderSelected = false; cityCentreSelected = false; roadSelected = false; blockadeSelected = true; farmSelected = false; grasslandSelected = false; forestSelected = false; towerAASelected = false; towerMSelected = false;
    }
    public void SelectRoad()
    {
        houseSelected = false; librarySelected = false; factorySelected = false; wonderSelected = false; cityCentreSelected = false; roadSelected = true; blockadeSelected = false; farmSelected = false; grasslandSelected = false; forestSelected = false; towerAASelected = false; towerMSelected = false;
    }
    public void SelectWonder()
    {
        houseSelected = false; librarySelected = false; factorySelected = false; wonderSelected = true; cityCentreSelected = false; roadSelected = false; blockadeSelected = false; farmSelected = false; grasslandSelected = false; forestSelected = false; towerAASelected = false; towerMSelected = false;
    }
    public void SelectLibrary()
    {
        houseSelected = false; librarySelected = true; factorySelected = false; wonderSelected = false; cityCentreSelected = false; roadSelected = false; blockadeSelected = false; farmSelected = false; grasslandSelected = false; forestSelected = false; towerAASelected = false; towerMSelected = false;
    }
    public void SelectFactory()
    {
        houseSelected = false; librarySelected = false; factorySelected = true; wonderSelected = false; cityCentreSelected = false; roadSelected = false; blockadeSelected = false; farmSelected = false; grasslandSelected = false; forestSelected = false; towerAASelected = false; towerMSelected = false;
    }
    public void SelectCityCentre()
    {
        houseSelected = false; librarySelected = false; factorySelected = false; wonderSelected = false; cityCentreSelected = true; roadSelected = false; blockadeSelected = false; farmSelected = false; grasslandSelected = false; forestSelected = false; towerAASelected = false; towerMSelected = false;
    }
    public void SelectTowerM()
    {
        houseSelected = false; librarySelected = false; factorySelected = false; wonderSelected = false; cityCentreSelected = false; roadSelected = false; blockadeSelected = false; farmSelected = false; grasslandSelected = false; forestSelected = false; towerAASelected = false; towerMSelected = true;
    }
    public void SelectTowerAA()
    {
        houseSelected = false; librarySelected = false; factorySelected = false; wonderSelected = false; cityCentreSelected = false; roadSelected = false; blockadeSelected = false; farmSelected = false; grasslandSelected = false; forestSelected = false; towerAASelected = true; towerMSelected = false;
    }
    public void SelectForest()
    {
        houseSelected = false; librarySelected = false; factorySelected = false; wonderSelected = false; cityCentreSelected = false; roadSelected = false; blockadeSelected = false; farmSelected = false; grasslandSelected = false; forestSelected = true; towerAASelected = false; towerMSelected = false;
    }
    public void SelectFarm()
    {
        houseSelected = false; librarySelected = false; factorySelected = false; wonderSelected = false; cityCentreSelected = false; roadSelected = false; blockadeSelected = false; farmSelected = true; grasslandSelected = false; forestSelected = false; towerAASelected = false; towerMSelected = false;
    }
    public void SelectGrassland()
    {
        houseSelected = false; librarySelected = false; factorySelected = false; wonderSelected = false; cityCentreSelected = false; roadSelected = false; blockadeSelected = false; farmSelected = false; grasslandSelected = true; forestSelected = false; towerAASelected = false; towerMSelected = false;
    }

}


//WHEN ADDING LOAD LEVEL STATE OF BUILDINGS REFER TO THIS
/*
int weight = 500;
string tempL2 = mapDictL2[tempKey];
string tL21 = tempL2.Substring(4, 3);
string tL22 = tempL2.Substring(8, 3);
string tL23 = tempL2.Substring(12, 3);
string tL24 = tempL2.Substring(16, 3);
string tL25 = tempL2.Substring(20, 3);
mapDictL2[tempKey] = string.Format("{0},{1},{2},{3},{4},{5}", weight, tL21, tL22, tL23, tL24, tL25);
*/
/*foreach (string obj in CellState.MapListL1)
   {
       xConvert = index % 60;
       yConvert = (index / 60) % 33;
       Debug.Log(xConvert + "," + yConvert + " + index " + index);
       switch (obj)
       {
           case "Grassland(Clone)":
               //do nothing
               break;
           case "City Centre(Clone)":
               EditMap(citycentre, xConvert, yConvert);
               break;
           case "House(Clone)":
               EditMap(house, xConvert, yConvert);
               break;
           case "Library(Clone)":
               EditMap(library, xConvert, yConvert);
               break;
           case "Factory(Clone)":
               EditMap(factory, xConvert, yConvert);
               break;
           case "Wonder(Clone)":
               EditMap(wonder, xConvert, yConvert);
               break;
           case "Road(Clone)":
               EditMap(road, xConvert, yConvert);
               break;
           case "Blockade(Clone)":
               EditMap(blockade, xConvert, yConvert);
               break;
           case "TowerAA(Clone)":
               EditMap(towerAA, xConvert, yConvert);
               break;
           case "TowerM(Clone)":
               EditMap(towerM, xConvert, yConvert);
               break;
           case "Forest(Clone)":
               EditMap(forest, xConvert, yConvert);
               break;
           case "Farm(Clone)":
               EditMap(farm, xConvert, yConvert);
               break;
       }
       index++;*/

/* scoreObj.GetComponent<Score>().maxNumFactories = ScoreState.MaxNumFactories;
 scoreObj.GetComponent<Score>().maxNumHouses = ScoreState.MaxNumHouses;
 scoreObj.GetComponent<Score>().maxNumLibraries = ScoreState.MaxNumLibraries;
 scoreObj.GetComponent<Score>().maxNumWonders = ScoreState.MaxNumWonders;
 scoreObj.GetComponent<Score>().numAATowers = ScoreState.NumAATowers;
 scoreObj.GetComponent<Score>().numMTowers = ScoreState.NumMTowers;
 scoreObj.GetComponent<Score>().numHouses = ScoreState.NumHouses;
 scoreObj.GetComponent<Score>().numLibraries = ScoreState.NumLibraries;
 scoreObj.GetComponent<Score>().numFactories = ScoreState.NumFactories;
 scoreObj.GetComponent<Score>().numCityCentres = ScoreState.NumCityCentres;
 scoreObj.GetComponent<Score>().numWonders = ScoreState.NumWonders;
 scoreObj.GetComponent<Score>().numRoads = ScoreState.NumRoads;
 scoreObj.GetComponent<Score>().numBlockades = ScoreState.NumBlockades;
 scoreObj.GetComponent<Score>().numFarms = ScoreState.NumFarms;
 scoreObj.GetComponent<Score>().numForests = ScoreState.NumForests; */

/* scoreObj.GetComponent<Score>().roadPrice = 150;
scoreObj.GetComponent<Score>().blockadePrice = 350;
scoreObj.GetComponent<Score>().towerMPrice = 850;
scoreObj.GetComponent<Score>().towerAAPrice = 450;
scoreObj.GetComponent<Score>().housePrice = 100;
scoreObj.GetComponent<Score>().libraryPrice = 750;
scoreObj.GetComponent<Score>().factoryPrice = 2750;
scoreObj.GetComponent<Score>().wonderPrice = 40000;
scoreObj.GetComponent<Score>().factoryGainRate = 7.5;
scoreObj.GetComponent<Score>().factoryMultiplier = 0.08;
scoreObj.GetComponent<Score>().wonderMultiplier = 0.8;
scoreObj.GetComponent<Score>().libraryMultiplier = 0.005;
scoreObj.GetComponent<Score>().houseGainRate = 5; */
/*scoreObj.GetComponent<Score>().housePrice = 0;
scoreObj.GetComponent<Score>().libraryPrice = 0;
scoreObj.GetComponent<Score>().factoryPrice = 0;
scoreObj.GetComponent<Score>().wonderPrice = 0;
scoreObj.GetComponent<Score>().towerAAPrice = 0;
scoreObj.GetComponent<Score>().towerMPrice = 0;
scoreObj.GetComponent<Score>().roadPrice = 0;
scoreObj.GetComponent<Score>().blockadePrice = 0;*/

//float indexPreProcessed = (60 * -listY - (60 - listX)) - 1;


//int xConvert = index % 60;
//int yConvert = (index / 60) % 33; //FIX THIS
/* public void NodeHandlerOnBeginDrag(GameObject node)
 {
     //do nothing
     Debug.Log("begin drag");
 }
 public void NodeHandlerOnEndDrag(GameObject node)
 {
     Debug.Log("end drag");
     //do nothing
 }
 public void NodeHandlerOnDrag(GameObject node)
 {
     if (!cityCentreSelected && !houseSelected && !librarySelected && !factorySelected && !roadSelected && !blockadeSelected && !roadSelected && !towerAASelected && !towerMSelected && !grasslandSelected && !farmSelected && !forestSelected)
     {
         Debug.Log("Select a building or the remove function before selecting a node");
     }
     else
     {
         EditMap(NodeSelector(), node.transform.position.x, node.transform.position.z);
     }
     Debug.Log("dragging");
     //edit map on all detected map nodes during mouse drag 
 }*/