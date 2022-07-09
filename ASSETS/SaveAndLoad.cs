using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System;
using System.Linq;

[System.Serializable]
public static class SaveAndLoad
{
    public static string saveFileDir;
    public static string saveFileSelected;
    public static bool isReady, isReadyDrawMap, isReadyPlay;
    public static bool IsReadyDrawMap
    {
        get { return isReadyDrawMap; }
        set { isReadyDrawMap = value; }
    }

    public static bool IsReady
    {
        get { return isReady; }
        set { isReady = value; }
    }
    public static bool IsReadyPlay
    {
        get { return isReadyPlay; }
        set { isReadyPlay = value; }
    }
    public static string SaveFileDir
    {
        get { return saveFileDir; }
        set { saveFileDir = value; }
    }
    public static string SaveFileSelected
    {
        get { return saveFileSelected; }
        set { saveFileSelected = value; }
    }
    public static void SaveGame()
    {
        int index = 0;
        int x = 1;
        int y = 1;
        Debug.Log("SaveGame called");
        Debug.Log(SaveFileSelected);
        if (File.Exists(SaveFileSelected) || ScoreState.IsLoad == false)
        {
            if (ScoreState.IsLoad == true)
            {
                Debug.Log("found save file");
                using (StreamWriter sr = new StreamWriter(SaveFileSelected, false))
                {
                    sr.WriteLine(ScoreState.Score + "~");
                    sr.WriteLine(ScoreState.ScoreGainRate + "~");
                    sr.WriteLine(ScoreState.ScoreMultiplier + "~");
                    sr.WriteLine(".1");
                    Debug.Log(CellState.MapListL1.Count);
                    foreach (string cellName in CellState.MapListL1)
                    {
                        sr.WriteLine(CellState.MapListL1[index] + "~");
                        index++;
                    }
                    index = 0;
                    sr.WriteLine(".2");
                    sr.WriteLine(ScoreState.MaxNumHouses +"~");
                    sr.WriteLine(ScoreState.MaxNumLibraries + "~");
                    sr.WriteLine(ScoreState.MaxNumFactories +"~");
                    sr.WriteLine(ScoreState.MaxNumWonders +"~");
                    sr.WriteLine(ScoreState.NumBlockades + "~");
                    sr.WriteLine(ScoreState.NumForests + "~");
                    sr.WriteLine(ScoreState.NumAATowers +"~");
                    sr.WriteLine(ScoreState.NumMTowers +"~");
                    sr.WriteLine(ScoreState.NumRoads + "~");
                    sr.WriteLine(ScoreState.NumHouses +"~");
                    sr.WriteLine(ScoreState.NumLibraries +"~");
                    sr.WriteLine(ScoreState.NumFactories +"~");
                    sr.WriteLine(ScoreState.NumCityCentres + "~");
                    sr.WriteLine(ScoreState.NumWonders + "~");
                    sr.WriteLine(".3");
                    sr.WriteLine(ScoreState.BlockadePrice + "~");
                    sr.WriteLine(ScoreState.RoadPrice +"~");
                    sr.WriteLine(ScoreState.TowerAAPrice + "~");
                    sr.WriteLine(ScoreState.TowerMPrice + "~");
                    sr.WriteLine(ScoreState.HousePrice + "~");
                    sr.WriteLine(ScoreState.LibraryPrice + "~");
                    sr.WriteLine(ScoreState.FactoryPrice + "~");
                    sr.WriteLine(ScoreState.WonderPrice + "~");
                    sr.WriteLine(ScoreState.HouseGainRate + "~");
                    sr.WriteLine(ScoreState.LibraryMultiplier + "~");
                    sr.WriteLine(ScoreState.FactoryGainRate + "~");
                    sr.WriteLine(ScoreState.FactoryMultiplier + "~");
                    sr.WriteLine(ScoreState.WonderMultiplier + "~");
                    sr.WriteLine(".4");
                    sr.WriteLine(CellState.PlayerSpawnBool.ToString() + "~");
                    sr.WriteLine(CellState.OpponentSpawnBool.ToString() + "~");
                    sr.WriteLine(CellState.PlayerSpawn + "~");
                    sr.WriteLine(CellState.OpponentSpawn + "~");
                    sr.WriteLine(".5");
                    for (int j = 1; j <= 33; j++)
                    {
                        for (int j2 = 1; j2 <= 60; j2++)
                        {
                            sr.WriteLine(CellState.MapListL2[index] + "~");
                            index++;

                        }
                    }
                    index = 0;
                    sr.WriteLine(".6");
                    sr.Close();
                }
                ScoreState.IsLoad = false;
            }
            else
            {
                if (Directory.Exists(@"c:\saves\"))
                {
                    SaveAndLoad.SaveFileDir = @"c:\saves\";
                    Debug.Log("dir does exist");
                }
                else
                {
                    Directory.CreateDirectory(@"c:\saves\");
                    SaveAndLoad.SaveFileDir = @"c:\saves\";
                }
                string[] files = Directory.GetFiles(SaveAndLoad.SaveFileDir);
                int i = 0;
                var sb2 = new System.Text.StringBuilder();
                string newSaveFileName = string.Empty;
                string newSaveFileNameTemp = string.Empty;
                if (files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        i++;
                        if (i >= 0 && i < 10)
                        {
                            sb2.Clear();
                            newSaveFileName = file.Substring(9);
                            newSaveFileNameTemp = newSaveFileName.Remove((newSaveFileName.Length - 5));
                            sb2.AppendFormat("{0}{1}{2}", newSaveFileNameTemp, (i + 1).ToString(), ".txt").AppendLine();
                            newSaveFileName = sb2.ToString().Remove(18);
                        }
                        else if (i > 9 && i < 100)
                        {
                            sb2.Clear();
                            newSaveFileName = file.Substring(9);
                            newSaveFileNameTemp = newSaveFileName.Remove((newSaveFileName.Length - 5));
                            sb2.AppendFormat("{0}{1}{2}", newSaveFileNameTemp, (i + 1).ToString(), ".txt").AppendLine();
                            newSaveFileName = sb2.ToString().Remove(18 + 1);
                        }
                        else if (i >= 100 && i < 1000)
                        {
                            sb2.Clear();
                            newSaveFileName = file.Substring(9);
                            newSaveFileNameTemp = newSaveFileName.Remove((newSaveFileName.Length - 5));
                            sb2.AppendFormat("{0}{1}{2}", newSaveFileNameTemp, (i + 1).ToString(), ".txt").AppendLine();
                            newSaveFileName = sb2.ToString().Remove(18 + 2);
                        }
                        else if (i >= 1000 && i < 10000)
                        {
                            sb2.Clear();
                            newSaveFileName = file.Substring(9);
                            newSaveFileNameTemp = newSaveFileName.Remove((newSaveFileName.Length - 5));
                            sb2.AppendFormat("{0}{1}{2}", newSaveFileNameTemp, (i + 1).ToString(), ".txt").AppendLine();
                            newSaveFileName = sb2.ToString().Remove(18 + 3);
                        }
                        else if (i >= 10000 && i < 100000)
                        {
                            sb2.Clear();
                            newSaveFileName = file.Substring(9);
                            newSaveFileNameTemp = newSaveFileName.Remove((newSaveFileName.Length - 5));
                            sb2.AppendFormat("{0}{1}{2}", newSaveFileNameTemp, (i + 1).ToString(), ".txt").AppendLine();
                            newSaveFileName = sb2.ToString().Remove(18 + 4);
                            Debug.Log("BETWEEN 10k - 100k FILES EXIST IN C:\\saves\\ - consider culling save entires"); //can handle up to 10k save files | also cannot handle non {save}.txt files. leave them out of this directory for now
                        }
                    }
                    using (StreamWriter sr = File.CreateText((SaveFileDir + newSaveFileName).Trim()))
                    {
                        sr.WriteLine(ScoreState.score + "~");
                        sr.WriteLine(ScoreState.scoreGainRate + "~");
                        sr.WriteLine(ScoreState.scoreMultiplier + "~");
                        sr.WriteLine(".1");
                        foreach (string cellName in CellState.MapListL1)
                        {
                            sr.WriteLine(CellState.mapListL1[index] + "~");
                            index++;
                        }
                        index = 0;
                        sr.WriteLine(".2");
                        sr.WriteLine(ScoreState.MaxNumHouses +"~");
                        sr.WriteLine(ScoreState.MaxNumLibraries +"~");
                        sr.WriteLine(ScoreState.MaxNumFactories +"~");
                        sr.WriteLine(ScoreState.MaxNumWonders +"~");
                        sr.WriteLine(ScoreState.NumBlockades +"~");
                        sr.WriteLine(ScoreState.NumForests + "~");
                        sr.WriteLine(ScoreState.NumAATowers + "~");
                        sr.WriteLine(ScoreState.NumMTowers + "~");
                        sr.WriteLine(ScoreState.NumRoads +"~");
                        sr.WriteLine(ScoreState.NumHouses +"~");
                        sr.WriteLine(ScoreState.NumLibraries + "~");
                        sr.WriteLine(ScoreState.NumFactories + "~");
                        sr.WriteLine(ScoreState.NumCityCentres + "~");
                        sr.WriteLine(ScoreState.NumWonders + "~");
                        sr.WriteLine(".3");
                        sr.WriteLine(ScoreState.BlockadePrice + "~");
                        sr.WriteLine(ScoreState.RoadPrice + "~");
                        sr.WriteLine(ScoreState.TowerAAPrice + "~");
                        sr.WriteLine(ScoreState.TowerMPrice + "~");
                        sr.WriteLine(ScoreState.HousePrice + "~");
                        sr.WriteLine(ScoreState.LibraryPrice + "~");
                        sr.WriteLine(ScoreState.FactoryPrice + "~");
                        sr.WriteLine(ScoreState.WonderPrice + "~");
                        sr.WriteLine(ScoreState.HouseGainRate + "~");
                        sr.WriteLine(ScoreState.LibraryMultiplier + "~");
                        sr.WriteLine(ScoreState.FactoryGainRate + "~");
                        sr.WriteLine(ScoreState.FactoryMultiplier + "~");
                        sr.WriteLine(ScoreState.WonderMultiplier + "~");
                        sr.WriteLine(".4");
                        sr.WriteLine(CellState.PlayerSpawnBool.ToString() + "~");
                        sr.WriteLine(CellState.OpponentSpawnBool.ToString() + "~");
                        sr.WriteLine(CellState.PlayerSpawn + "~");
                        sr.WriteLine(CellState.OpponentSpawn + "~");
                        sr.WriteLine(".5");
                        Debug.Log(CellState.MapListL1.Count());
                        Debug.Log(CellState.MapListL2.Count());
                        for (int j = 1; j <= 33; j++)
                        {
                            for (int j2 = 1; j2 <= 60; j2++)
                            {
                                sr.WriteLine(CellState.MapListL2[index] + "~");
                                index++;
                            }
                        }
                        index = 0;
                        sr.WriteLine(".6");
                        sr.Close();

                    }
                }
                else if (files.Length == 0)
                {
                    newSaveFileName = "saveTestFile1.txt";
                    SaveAndLoad.SaveFileSelected = newSaveFileName;
                    using (StreamWriter sr = File.CreateText((SaveFileDir + newSaveFileName).Trim()))
                    {

                        sr.WriteLine(ScoreState.Score + "~");
                        sr.WriteLine(ScoreState.ScoreGainRate + "~");
                        sr.WriteLine(ScoreState.ScoreMultiplier +"~");
                        sr.WriteLine(".1");
                        foreach (string cellName in CellState.MapListL1)
                        {
                            sr.WriteLine(CellState.MapListL1[index] + "~");
                            index++;
                        }
                        index = 0;
                        sr.WriteLine(".2");
                        sr.WriteLine(ScoreState.MaxNumHouses + "~");
                        sr.WriteLine(ScoreState.MaxNumLibraries +"~");
                        sr.WriteLine(ScoreState.MaxNumFactories + "~");
                        sr.WriteLine(ScoreState.MaxNumWonders + "~");
                        sr.WriteLine(ScoreState.NumBlockades + "~");
                        sr.WriteLine(ScoreState.NumForests +"~");
                        sr.WriteLine(ScoreState.NumAATowers +"~");
                        sr.WriteLine(ScoreState.NumMTowers + "~");
                        sr.WriteLine(ScoreState.NumRoads + "~");
                        sr.WriteLine(ScoreState.NumHouses +"~");
                        sr.WriteLine(ScoreState.NumLibraries +"~");
                        sr.WriteLine(ScoreState.NumFactories +"~");
                        sr.WriteLine(ScoreState.NumCityCentres + "~");
                        sr.WriteLine(ScoreState.NumWonders + "~");
                        sr.WriteLine(".3");
                        sr.WriteLine(ScoreState.BlockadePrice + "~");
                        sr.WriteLine(ScoreState.RoadPrice + "~");
                        sr.WriteLine(ScoreState.TowerAAPrice +"~");
                        sr.WriteLine(ScoreState.TowerMPrice +"~");
                        sr.WriteLine(ScoreState.HousePrice +"~");
                        sr.WriteLine(ScoreState.LibraryPrice + "~");
                        sr.WriteLine(ScoreState.FactoryPrice +"~");
                        sr.WriteLine(ScoreState.WonderPrice + "~");
                        sr.WriteLine(ScoreState.HouseGainRate +"~");
                        sr.WriteLine(ScoreState.LibraryMultiplier + "~");
                        sr.WriteLine(ScoreState.FactoryGainRate +"~");
                        sr.WriteLine(ScoreState.FactoryMultiplier + "~");
                        sr.WriteLine(ScoreState.WonderMultiplier +"~");
                        sr.WriteLine(".4");
                        sr.WriteLine(CellState.PlayerSpawnBool.ToString() + "~");
                        sr.WriteLine(CellState.OpponentSpawnBool.ToString() + "~");
                        sr.WriteLine(CellState.PlayerSpawn + "~");
                        sr.WriteLine(CellState.OpponentSpawn + "~");
                        sr.WriteLine(".5");
                        for (int j = 1; j <= 33; j++)
                        {
                            for (int j2 = 1; j2 <= 60; j2++)
                            {
                                sr.WriteLine(CellState.MapListL2[index] + "~");
                                index++;
                            }
                        }
                        index = 0;
                        sr.WriteLine(".6");
                        sr.Close();

                        Debug.Log("new save file created because none others were found");
                    }
                }

                Debug.Log("new save file @ " + newSaveFileName);
                Debug.Log(CellState.MapListL1.Count);
            }
        }
        else
        {
            Debug.Log("FAIL CANNOT FIND SAVE FILE");
        }
    }
    public static void LoadGame()
    {
        Debug.Log("Loading Game in SaveAndLoad.cs");
        IsReady = false;//REMOVE?
        IsReadyPlay = false;//REMOVE?
        IsReadyDrawMap = false;
        using (StreamReader sr = new StreamReader(SaveFileDir + SaveFileSelected.Substring(8)))
        {
            var sb = new System.Text.StringBuilder();
            string line;
            string[] splitInput;
            string input;
            while ((line = sr.ReadLine()) != ".1")
            {
                Debug.Log(line); 
                sb.AppendLine(line);
            }
            input = sb.ToString();
            splitInput = input.Split('~');
            string setScore1 = splitInput[0];
            string setScore2 = splitInput[1];
            string setScore3 = splitInput[2];
            ScoreState.Score = double.Parse(setScore1);
            ScoreState.ScoreGainRate = double.Parse(setScore2);
            ScoreState.ScoreMultiplier = double.Parse(setScore3);
            ScoreState.IsLoad = true;
        }
        using (StreamReader sr = new StreamReader(SaveFileDir + SaveFileSelected.Substring(8)))
        {
            int tempInt = 0;
            var sb = new System.Text.StringBuilder();
            string line;
            string input;
            while ((line = sr.ReadLine()) != ".2")
            {
                if (line.Equals(".1"))
                {
                    sb.Clear();
                    tempInt = 0;
                }
                if (!line.Equals(".1"))
                {
                    tempInt++;
                    sb.AppendLine(line);
                }
            }
            Debug.Log(sb.ToString());
            string[] splitInput = new string[tempInt];
            input = sb.ToString();
            Debug.Log(input);
            splitInput = input.Split('~');
            int i = 0;
            Debug.Log(tempInt);
            Debug.Log(splitInput.Length);
            for (int z = 0; z < splitInput.Length; z++)
            {
                if (z == 1977)
                { Debug.Log(splitInput[z]); }
                if (z == 1978)
                { Debug.Log(splitInput[z]); }
                if (z == 1979)
                { Debug.Log(splitInput[z]); }
                if (z == 1980)
                { Debug.Log(splitInput[z]); }
                string cellName = splitInput[z];
                CellState.mapListL1.Add(cellName.Trim());
            }
            Debug.Log(CellState.MapListL1[1978]);
            Debug.Log(CellState.MapListL1[1979]);
            Debug.Log(CellState.MapListL1[1980]);
            Debug.Log(CellState.MapListL1.Count);
            CellState.MapListL1.RemoveAt(1980);
            Debug.Log(CellState.MapListL1.Count);
            Debug.Log(CellState.MapListL1.Count);
            i = 0;
            sr.Close();
        }
        using (StreamReader sr = new StreamReader(SaveFileDir + SaveFileSelected.Substring(8)))
        {
            var sb = new System.Text.StringBuilder();
            string line;
            string[] splitInput;
            string input;
            while ((line = sr.ReadLine()) != ".3")
            {
                if (line.Equals(".2"))
                {
                    sb.Clear();
                }
                if (!line.Equals(".2"))
                {
                    sb.AppendLine(line);
                }
            }
            input = sb.ToString();
            splitInput = input.Split('~');

            string setScore1 = splitInput[0];
            string setScore2 = splitInput[1];
            string setScore3 = splitInput[2];
            string setScore4 = splitInput[3];
            string setScore5 = splitInput[4];
            string setScore6 = splitInput[5];
            string setScore7 = splitInput[6];
            string setScore8 = splitInput[7];
            string setScore9 = splitInput[8];
            string setScore10 = splitInput[9];
            string setScore11 = splitInput[10];
            string setScore12 = splitInput[11];
            string setScore13 = splitInput[12];
            string setScore14 = splitInput[13];

            ScoreState.MaxNumHouses = double.Parse(setScore1);
            ScoreState.MaxNumLibraries = double.Parse(setScore2);
            ScoreState.MaxNumFactories = double.Parse(setScore3);
            ScoreState.MaxNumWonders = double.Parse(setScore4);
            ScoreState.NumBlockades = double.Parse(setScore5);
            ScoreState.NumForests = double.Parse(setScore6);
            ScoreState.NumAATowers = double.Parse(setScore7);
            ScoreState.NumMTowers = double.Parse(setScore8);
            ScoreState.NumRoads = double.Parse(setScore9);
            ScoreState.NumHouses = double.Parse(setScore10);
            ScoreState.NumLibraries = double.Parse(setScore11);
            ScoreState.NumFactories = double.Parse(setScore12);
            ScoreState.NumCityCentres = double.Parse(setScore13);
            ScoreState.NumWonders = double.Parse(setScore14);
            ScoreState.IsLoad = true;
            sr.Close();
        }
        using (StreamReader sr = new StreamReader(SaveFileDir + SaveFileSelected.Substring(8)))
        {
            var sb = new System.Text.StringBuilder();
            string line;
            string[] splitInput;
            string input;
            while ((line = sr.ReadLine()) != ".4")
            {
                if (line.Equals(".3"))
                {
                    sb.Clear();
                }
                if (!line.Equals(".3"))
                {
                    sb.AppendLine(line);
                }
            }
            input = sb.ToString();
            splitInput = input.Split('~');
            string setVar1 = splitInput[0];
            string setVar2 = splitInput[1];
            string setVar3 = splitInput[2];
            string setVar4 = splitInput[3];
            string setVar5 = splitInput[4];
            string setVar6 = splitInput[5];
            string setVar7 = splitInput[6];
            string setVar8 = splitInput[7];
            string setVar9 = splitInput[8];
            string setVar10 = splitInput[9];
            string setVar11 = splitInput[10];
            string setVar12 = splitInput[11];
            string setVar13 = splitInput[12];
            ScoreState.BlockadePrice = double.Parse(setVar1);
            ScoreState.RoadPrice = double.Parse(setVar2);
            ScoreState.TowerAAPrice = double.Parse(setVar3);
            ScoreState.TowerMPrice = double.Parse(setVar4);
            ScoreState.HousePrice = double.Parse(setVar5);
            ScoreState.LibraryPrice = double.Parse(setVar6);
            ScoreState.FactoryPrice = double.Parse(setVar7);
            ScoreState.WonderPrice = double.Parse(setVar8);
            ScoreState.HouseGainRate = double.Parse(setVar9);
            ScoreState.LibraryMultiplier = double.Parse(setVar10);
            ScoreState.FactoryGainRate = double.Parse(setVar11);
            ScoreState.FactoryMultiplier = double.Parse(setVar12);
            ScoreState.WonderMultiplier = double.Parse(setVar13);
            double tempScore = ScoreState.Score;
            for (int i = 0; i < ScoreState.NumHouses; i++)
            {
                tempScore += ScoreState.HousePrice;
            }
            for (int i = 0; i < ScoreState.NumLibraries; i++)
            {
                tempScore += ScoreState.LibraryPrice;
            }
            for (int i = 0; i < ScoreState.NumFactories; i++)
            {
                tempScore += ScoreState.FactoryPrice;

            }
            for (int i = 0; i < ScoreState.NumWonders; i++)
            {
                tempScore += ScoreState.WonderPrice;
            }
            ScoreState.Score = tempScore;
            sr.Close();
        }
        using (StreamReader sr = new StreamReader(SaveFileDir + SaveFileSelected.Substring(8)))
        {
            var sb = new System.Text.StringBuilder();
            string line;
            string[] splitInput;
            string input;
            while ((line = sr.ReadLine()) != ".5")
            {
                if (line.Equals(".4"))
                {
                    sb.Clear();
                }
                if (!line.Equals(".4"))
                {
                    sb.AppendLine(line);
                }
            }
            input = sb.ToString();
            splitInput = input.Split('~');
            string setVar1 = splitInput[0];
            string setVar2 = splitInput[1];
            string setVar3 = splitInput[2];
            string setVar4 = splitInput[3];
            string cleanedTempString3 = setVar1.Replace("\n", "").Replace("\r", "");
            if (cleanedTempString3 == "True")
            {
                CellState.PlayerSpawnBool = true;
                Debug.Log(cleanedTempString3);
            }
            else
            {
                CellState.PlayerSpawnBool = false;
                Debug.Log(cleanedTempString3);
            }
            string cleanedTempString4 = setVar2.Replace("\n", "").Replace("\r", "");
            if (cleanedTempString4 == "True")
            {
                CellState.OpponentSpawnBool = true;
                Debug.Log(cleanedTempString4);
            }
            else
            {
                CellState.OpponentSpawnBool = false;//ss
                Debug.Log(cleanedTempString4);
            }
            string cleanedTempString1 = setVar3.Replace("\n", "").Replace("\r", "");
            CellState.PlayerSpawn = cleanedTempString1;
            Debug.Log(CellState.PlayerSpawn);
            string cleanedTempString2 = setVar4.Replace("\n", "").Replace("\r", "");
            CellState.OpponentSpawn = cleanedTempString2;
            Debug.Log(CellState.OpponentSpawn);
            sr.Close();
        }
        using (StreamReader sr = new StreamReader(SaveFileDir + SaveFileSelected.Substring(8)))
        {
            var sb = new System.Text.StringBuilder();
            string line;
            string[] splitInput;
            string input;
            while ((line = sr.ReadLine()) != ".6")
            {
                if (line.Equals(".5"))
                {
                    sb.Clear();
                }
                if (!line.Equals(".5"))
                {
                    sb.AppendLine(line);
                }
            }
            input = sb.ToString();
            splitInput = input.Split('~');
            for (int i = 0; i < splitInput.Length -1; i++)
            {
                string input2 = splitInput[i];
                CellState.MapListL2.Add(input2);
            }
            Debug.Log("FINISHED LOAD");
            sr.Close();
        }
       // IsReadyDrawMap = true;
        IsReady = true;//REMOVE?
        Debug.Log(IsReadyDrawMap + " == IsReadyDrawMap SaveAndLoad.cs");
    }
}