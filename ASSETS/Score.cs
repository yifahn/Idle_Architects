using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject scoreTextObject;
    public float delayAmount;
    public double scoreDouble, scoreDoubleTemp1, scoreDoubleTemp2, scoreDecTemp3;
    public double scoreMultiplierInternal, scoreGainRateInternal, scoreInternal;
    public double scoreFloor;
    public string scoreRemainder1, scoreRemainder2, scoreRemainder3;
    protected float timer;
    public bool isLoadingBoolForMapGen;

    public bool CHECKMEBOOL;

    //
    public double score, scoreMultiplier, scoreGainRate;
    public double maxNumHouses, maxNumLibraries, maxNumFactories, maxNumWonders;
    public double numHouses, numLibraries, numFactories, numCityCentres, numWonders, numBlockades, numRoads, numForests, numMTowers, numAATowers, numFarms;
    public double roadPrice, blockadePrice, towerMPrice, towerAAPrice, housePrice, libraryPrice, factoryPrice, wonderPrice;
    public double houseGainRate, libraryMultiplier, factoryGainRate, factoryMultiplier, wonderMultiplier;
    public bool isLoad;
    //

    public void Awake()
    {
        isLoadingBoolForMapGen = false;
    }
    public void Start()
    {
        Debug.Log(isLoad);
        Debug.Log("Score.cs - start - ScoreState.IsLoad " + ScoreState.IsLoad);
        Debug.Log("Score.cs - start - SaveAndLoad.IsReady " + SaveAndLoad.IsReady);
        if (ScoreState.IsLoad) //initialise load game variables
        {
            SaveAndLoad.LoadGame();

            score = ScoreState.Score;
            scoreMultiplier = ScoreState.ScoreMultiplier;
            scoreGainRate = ScoreState.ScoreGainRate;

            maxNumFactories = ScoreState.MaxNumFactories;
            maxNumHouses = ScoreState.MaxNumHouses;
            maxNumLibraries = ScoreState.MaxNumLibraries;
            maxNumWonders = ScoreState.MaxNumWonders;

            numAATowers = ScoreState.NumAATowers;
            numMTowers = ScoreState.NumMTowers;
            numHouses = ScoreState.NumHouses;
            numLibraries = ScoreState.NumLibraries;
            numFactories = ScoreState.NumFactories;
            numCityCentres = ScoreState.NumCityCentres;
            numWonders = ScoreState.NumWonders;
            numRoads = ScoreState.NumRoads;
            numBlockades = ScoreState.NumBlockades;
            numFarms = ScoreState.NumFarms;
            numForests = ScoreState.NumForests;

            roadPrice = ScoreState.RoadPrice;
            blockadePrice = ScoreState.BlockadePrice;
            towerMPrice = ScoreState.TowerMPrice;
            towerAAPrice = ScoreState.TowerAAPrice;
            housePrice = ScoreState.HousePrice;
            libraryPrice = ScoreState.LibraryPrice;
            factoryPrice = ScoreState.FactoryPrice;
            wonderPrice = ScoreState.WonderPrice;
            factoryGainRate = ScoreState.FactoryGainRate;
            factoryMultiplier = ScoreState.FactoryMultiplier;
            wonderMultiplier = ScoreState.WonderMultiplier;
            libraryMultiplier = ScoreState.LibraryMultiplier;
            houseGainRate = ScoreState.HouseGainRate;

           // SaveAndLoad.IsReadyDrawMap = true;
           // SaveAndLoad.IsReady = true;

        }
        else //initialise new game variables
        {
            score = 10000; // dev testing purposes
            scoreGainRate = 10;
            scoreMultiplier = 1;

            maxNumFactories = 0;
            maxNumHouses = 0;
            maxNumLibraries = 0;
            maxNumWonders = 0;
            numAATowers = 0;
            numMTowers = 0;
            numHouses = 0;
            numLibraries = 0;
            numFactories = 0;
            numCityCentres = 0;
            numWonders = 0;
            numRoads = 0;
            numBlockades = 0;
            numFarms = 0;
            numForests = 0;

            roadPrice = 150;
            blockadePrice = 350;
            towerMPrice = 850;
            towerAAPrice = 450;
            housePrice = 100;
            libraryPrice = 750;
            factoryPrice = 2750;
            wonderPrice = 40000;
            factoryGainRate = 7.5;
            factoryMultiplier = 0.08;
            wonderMultiplier = 0.8;
            libraryMultiplier = 0.005;
            houseGainRate = 5;

        }
        timer = 0f;
        delayAmount = 2f;
        scoreRemainder1 = "";
        scoreRemainder2 = "";
        scoreRemainder3 = "";
        scoreDouble = 0;
        scoreDoubleTemp1 = 0;
        scoreDoubleTemp2 = 0;
        scoreDecTemp3 = 0;
        scoreTextObject = gameObject;
       // SaveAndLoad.IsReady = true;
        SaveAndLoad.IsReadyDrawMap = true;
    }
    public void FixedUpdate()
    {
        if (SaveAndLoad.isReadyPlay)
        {
            timer += Time.deltaTime;
            if (timer >= delayAmount)
            {

                timer = 0f;

                double roundScoreTemp = score += (scoreGainRate * scoreMultiplier);
                roundScoreTemp = Math.Round(score, 10);
                UpdateScore(roundScoreTemp);

            }
        }
    }

    public void UpdateScore(double score)
    {
        if (score < 1000)
        {
            scoreDouble = Math.Round(score, 0);
            scoreTextObject.GetComponent<UnityEngine.UI.Text>().text = "Score: " + scoreDouble.ToString();
        }
        else if (score > 999 && score < 1000000)
        {
            scoreDouble = score;
            scoreDoubleTemp1 = scoreDouble / 1000;
            scoreDoubleTemp2 = Math.Round(scoreDoubleTemp1, 2);
            scoreTextObject.GetComponent<UnityEngine.UI.Text>().text = "Score: " + scoreDoubleTemp2 + "K";
        }
        else if (score > 999999 && score < 1000000000)
        {
            scoreDouble = score;
            scoreDoubleTemp1 = scoreDouble / 1000000;
            scoreDoubleTemp2 = Math.Round(scoreDoubleTemp1, 2);
            scoreTextObject.GetComponent<UnityEngine.UI.Text>().text = "Score: " + scoreDoubleTemp2 + "M";
        }
        else if (score > 999999999 && score < 1000000000000)
        {
            scoreDouble = score;
            scoreDoubleTemp1 = scoreDouble / 1000000000;
            scoreDoubleTemp2 = Math.Round(scoreDoubleTemp1, 2);
            scoreTextObject.GetComponent<UnityEngine.UI.Text>().text = "Score: " + scoreDoubleTemp2 + "Bn";
        }
        else if (score > 999999999999 && score < 1000000000000000)
        {
            scoreDouble = score;
            scoreDoubleTemp1 = scoreDouble / 1000000000000;
            scoreDoubleTemp2 = Math.Round(scoreDoubleTemp1, 2);
            scoreTextObject.GetComponent<UnityEngine.UI.Text>().text = "Score: " + scoreDoubleTemp2 + "Tn";
        }
    }
    public void SetWonderNumLimit()
    {
        if (maxNumWonders < 1 && numHouses > 19)
        {
            if (numHouses < 40)
            {
                maxNumWonders = 1;
            }
        }
        if (maxNumWonders < 2 && maxNumWonders > 0)
        {
            if (numHouses > 39 && numHouses < 60)
            {
                maxNumWonders = 2;
            }
        }
        if (maxNumWonders < 3 && maxNumWonders > 1)
        {
            if (numHouses > 59 && numHouses < 80)
            {
                maxNumWonders = 3;
            }
        }
        if (maxNumWonders < 4 && maxNumWonders > 2)
        {
            if (numHouses > 79 && numHouses < 100)
            {
                maxNumWonders = 4;
            }
        }
        if (maxNumWonders < 5 && maxNumWonders > 3)
        {
            if (numHouses > 99 && numHouses < 120)
            {
                maxNumWonders = 5;
            }
        }
    }
    public void SetLibraryNumLimit()
    {
        Debug.Log("Max num of librarys before added house " + maxNumLibraries);
        Debug.Log(numHouses);
        Debug.Log(numHouses / 9);
        Debug.Log(Math.Floor(numHouses / 9));
        Debug.Log(Math.Floor((double)numHouses / 9));
        Debug.Log(Math.Floor((double)(numHouses / 9)));
        double tempDouble111 = Math.Floor((double)(numHouses / 9));
        maxNumLibraries = tempDouble111;
        Debug.Log("Max num of librarys after added house " + maxNumLibraries);
    }
    public void SetFactoryNumLimit()
    {
        Debug.Log("Max num of factorys before added house " + maxNumLibraries);
        Debug.Log(numHouses);
        Debug.Log(numHouses / 5);
        Debug.Log(Math.Floor(numHouses / 5));
        Debug.Log(Math.Floor((double)numHouses / 5));
        Debug.Log(Math.Floor((double)(numHouses / 5)));
        double tempDouble222 = Math.Floor((double)(numHouses / 5));
        maxNumFactories = tempDouble222;
        Debug.Log("Max num of factorys after added house " + maxNumLibraries);
    }
    public void RemoveUpdate(string buildingName)
    {
        switch (buildingName)
        {
            case "House(Clone)":
                numHouses -= 1;
                scoreGainRate -= houseGainRate;
                double tempScoreDouble = score;
                tempScoreDouble += (housePrice / 2);
                SetLibraryNumLimit();
                SetFactoryNumLimit();
                SetWonderNumLimit();
                UpdateScore(tempScoreDouble);
                break;
            case "Road(Clone)":
                numRoads -= 1;
                break;
            case "Forest(Clone)":
                numForests -= 1;
                break;
            case "Blockade(Clone)":
                numBlockades -= 1;
                break;
            case "TowerM(Clone)":
                numMTowers -= 1;
                break;
            case "TowerAA(Clone)":
                numAATowers -= 1;
                break;
            case "Farm(Clone)":
                numFarms -= 1;
                double tempScoreDouble2 = score;
                tempScoreDouble2 += housePrice;
                UpdateScore(tempScoreDouble2);
                break;
            case "City Centre(Clone)":
                numCityCentres -= 1;
                maxNumHouses -= 10;
                break;
            case "Library(Clone)":
                numLibraries -= 1;
                scoreMultiplier -= libraryMultiplier;
                double tempScoreDouble3 = score;
                tempScoreDouble3 += (libraryPrice / 2);
                UpdateScore(tempScoreDouble3);
                break;
            case "Factory(Clone)":
                numFactories -= 1;
                scoreMultiplier -= factoryMultiplier;
                scoreGainRate -= factoryGainRate;
                double tempScoreDouble4 = score;
                tempScoreDouble4 += (factoryPrice / 2);
                UpdateScore(tempScoreDouble4);
                break;
            case "Wonder(Clone)":
                numWonders -= 1;
                scoreMultiplier -= wonderMultiplier;
                double tempScoreDouble5 = score;
                tempScoreDouble5 += (factoryPrice / 2);
                UpdateScore(tempScoreDouble5);
                break;
        }
    }
    public void BuildScoreUpdate(string buildingName)
    {
        Debug.Log(buildingName);
        switch (buildingName)
        {
            case "Grassland":
                //do nothing
                break;
            case "House":
                    Debug.Log(score + " " + 1);
                    Debug.Log("Building House");
                    numHouses += 1;
                    scoreGainRate += houseGainRate;
                    score -= housePrice;
                    SetLibraryNumLimit();
                    SetFactoryNumLimit();
                    SetWonderNumLimit();
                    UpdateScore(score);
                break;
            case "Road":
                numRoads += 1;
                score -= roadPrice;
                UpdateScore(score);
                break;
            case "Forest":
                numForests += 1;
                break;
            case "Blockade":
                numBlockades += 1;
                score -= blockadePrice;
                UpdateScore(score);
                break;
            case "TowerM":
                numMTowers += 1;
                score -= towerMPrice;
                UpdateScore(score);
                break;
            case "TowerAA":
                numAATowers += 1;
                score -= towerAAPrice;
                UpdateScore(score);
                break;
            case "Farm":
                numFarms += 1;
                break;
            case "City Centre":
                Debug.Log("Building City Centre");
                numCityCentres += 1;
                maxNumHouses += 10;
                Debug.Log(numCityCentres);
                break;
            case "Library":
                numLibraries += 1;
                scoreMultiplier += libraryMultiplier;
                score -= libraryPrice;
                UpdateScore(score);
                break;
            case "Factory":
                numFactories += 1;
                scoreGainRate += factoryGainRate;
                scoreMultiplier += factoryMultiplier;
                score -= factoryPrice;
                UpdateScore(score);
                break;
            case "Wonder":
                numWonders += 1;
                scoreMultiplier += wonderMultiplier;
                score -= wonderPrice;
                UpdateScore(score);
                break;
        }
    }
}