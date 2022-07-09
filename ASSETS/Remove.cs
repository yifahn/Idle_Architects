using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    public GameObject plane,panel;
    GameObject score;
    public void OnEnable()
    {
        panel = GameObject.Find("LeftPanel");
        plane = GameObject.Find("Plane");
        score = GameObject.Find("Score");
    }
    public void removeCell(string cellName)
    {
       /* if (cellName.Contains("House"))
        {
            Instantiate(BuildingKeeper.grassland, new Vector3(BuildingKeeper.selectedCell.transform.position.x, 0, BuildingKeeper.selectedCell.transform.position.z), Quaternion.identity);
            plane.GetComponent<Map>().EditCellListRemove(BuildingKeeper.grassland);
            score.GetComponent<Score>().RemoveUpdate(BuildingKeeper.house.name);
            Debug.Log("should arrive near the end");
            Destroy(BuildingKeeper.selectedCell);
            Debug.Log("success");
        }
        else if (cellName.Contains("Library"))
        {
            Instantiate(BuildingKeeper.grassland, new Vector3(BuildingKeeper.selectedCell.transform.position.x, 0, BuildingKeeper.selectedCell.transform.position.z), Quaternion.identity);
            plane.GetComponent<Map>().EditCellListRemove(BuildingKeeper.grassland);
            score.GetComponent<Score>().RemoveUpdate(BuildingKeeper.library.name);
            Destroy(BuildingKeeper.selectedCell);
            Debug.Log("success");
        }
        else if (cellName.Contains("Factory"))
        {
            Instantiate(BuildingKeeper.grassland, new Vector3(BuildingKeeper.selectedCell.transform.position.x, 0, BuildingKeeper.selectedCell.transform.position.z), Quaternion.identity);
            plane.GetComponent<Map>().EditCellListRemove(BuildingKeeper.grassland);
            score.GetComponent<Score>().RemoveUpdate(BuildingKeeper.factory.name);
            Destroy(BuildingKeeper.selectedCell);
            Debug.Log("success");
        }
        else if (cellName.Contains("Road"))
        {
            Instantiate(BuildingKeeper.grassland, new Vector3(BuildingKeeper.selectedCell.transform.position.x, 0, BuildingKeeper.selectedCell.transform.position.z), Quaternion.identity);
            plane.GetComponent<Map>().EditCellListRemove(BuildingKeeper.grassland);
            score.GetComponent<Score>().RemoveUpdate(BuildingKeeper.road.name);
            Destroy(BuildingKeeper.selectedCell);
            Debug.Log("success");
        }
        else if (cellName.Contains("Blockade"))
        {
            Instantiate(BuildingKeeper.grassland, new Vector3(BuildingKeeper.selectedCell.transform.position.x, 0, BuildingKeeper.selectedCell.transform.position.z), Quaternion.identity);
            plane.GetComponent<Map>().EditCellListRemove(BuildingKeeper.grassland);
            score.GetComponent<Score>().RemoveUpdate(BuildingKeeper.blockade.name);
            Destroy(BuildingKeeper.selectedCell);
            Debug.Log("success");
        }
        else if (cellName.Contains("TowerM"))
        {

            Instantiate(BuildingKeeper.grassland, new Vector3(BuildingKeeper.selectedCell.transform.position.x, 0, BuildingKeeper.selectedCell.transform.position.z), Quaternion.identity);
            plane.GetComponent<Map>().EditCellListRemove(BuildingKeeper.grassland);
            score.GetComponent<Score>().RemoveUpdate(BuildingKeeper.towerM.name);
            Destroy(BuildingKeeper.selectedCell);
            Debug.Log("success");
        }
        else if (cellName.Contains("TowerAA"))
        {
            Instantiate(BuildingKeeper.grassland, new Vector3(BuildingKeeper.selectedCell.transform.position.x, 0, BuildingKeeper.selectedCell.transform.position.z), Quaternion.identity);
            plane.GetComponent<Map>().EditCellListRemove(BuildingKeeper.grassland);
            score.GetComponent<Score>().RemoveUpdate(BuildingKeeper.towerAA.name);
            Destroy(BuildingKeeper.selectedCell);
            Debug.Log("success");
        }
        else if (cellName.Contains("CityCentre"))
        {
            Instantiate(BuildingKeeper.grassland, new Vector3(BuildingKeeper.selectedCell.transform.position.x, 0, BuildingKeeper.selectedCell.transform.position.z), Quaternion.identity);
            Debug.Log(BuildingKeeper.selectedCell.gameObject.GetInstanceID());
            Debug.Log(BuildingKeeper.selectedCell.name);

            plane.GetComponent<Map>().EditCellListRemove(BuildingKeeper.grassland);
            score.GetComponent<Score>().RemoveUpdate(BuildingKeeper.cityCentre.name);
            Destroy(BuildingKeeper.selectedCell);
            Debug.Log("success");

        }
        else if (cellName.Contains("Forest"))
        {
            Instantiate(BuildingKeeper.grassland, new Vector3(BuildingKeeper.selectedCell.transform.position.x, 0, BuildingKeeper.selectedCell.transform.position.z), Quaternion.identity);
            plane.GetComponent<Map>().EditCellListRemove(BuildingKeeper.grassland);
            score.GetComponent<Score>().RemoveUpdate(BuildingKeeper.forest.name);
            Destroy(BuildingKeeper.selectedCell);
            Debug.Log("success");
        }
        else if (cellName.Contains("Wonder"))
        {
            Instantiate(BuildingKeeper.grassland, new Vector3(BuildingKeeper.selectedCell.transform.position.x, 0, BuildingKeeper.selectedCell.transform.position.z), Quaternion.identity);
            plane.GetComponent<Map>().EditCellListRemove(BuildingKeeper.grassland);
            score.GetComponent<Score>().RemoveUpdate(BuildingKeeper.wonder.name);
            Destroy(BuildingKeeper.selectedCell);
            Debug.Log("success");
        }
       */
    }
    public void callRemove()
    {
        Debug.Log("arrived here!");
        if (gameObject.name.Contains("City Centre"))
        {
            Debug.Log("success");
            removeCell("CityCentre");
        }
        else if (gameObject.name.Contains("House"))
        {
            Debug.Log("success");
            removeCell("House");
        }
        else if (gameObject.name.Contains("Library"))
        {
            Debug.Log("success");
            removeCell("Library");
        }
        else if (gameObject.name.Contains("Factory"))
        {
            Debug.Log("success");
            removeCell("Factory");
        }
        else if (gameObject.name.Contains("Wonder"))
        {
            Debug.Log("success");
            removeCell("Wonder");
        }
        else if (gameObject.name.Contains("Road"))
        {
            Debug.Log("success");
            removeCell("Road");
        }
        else if (gameObject.name.Contains("Blockade"))
        {
            Debug.Log("success");
            removeCell("Blockade");
        }
        else if (gameObject.name.Contains("TowerM"))
        {
            Debug.Log("success");
            removeCell("TowerM");
        }
        else if (gameObject.name.Contains("TowerAA"))
        {
            Debug.Log("success");
            removeCell("TowerAA");
        }
        else if (gameObject.name.Contains("Farm"))
        {
            Debug.Log("success");
            removeCell("Farm");
        }
    }
}
