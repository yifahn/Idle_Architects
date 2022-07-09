using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DijkstrasShortestPath : MonoBehaviour
{
    public GameObject plane;
    public List<string> nodeNameList;
    public List<int> nodeWeightList;
    public void GenerateGraph()
    {
        var graph = new Graph();
        nodeNameList = new List<string>();
        nodeWeightList = new List<int>();
        plane = GameObject.Find("Plane");
        int i = 0;
        Node a;
        Node b;
        Node[] nodeArray = new Node[1979];
        foreach (GameObject cell in plane.GetComponent<Map>().mapListL1)
        {
            
            if (cell.name.Contains("Road"))
            {
              
                nodeNameList[i] = "Road";
              //  b = graph.CreateNode(nodeNameList[i] + " " + i);
                nodeWeightList[i] = 1;

            }
            else if (cell.name.Contains("Blockade"))
            {
                nodeNameList[i] = "Blockade";
              //  b = graph.CreateNode(nodeNameList[i] + " " + i);
                nodeWeightList[i] = 4;

            }
            else if (cell.name.Contains("Grassland"))
            {
                nodeNameList[i] = "Grassland";
              //  b = graph.CreateNode(nodeNameList[i] + " " + i);
                nodeWeightList[i] = 2;

            }
            else if (cell.name.Contains("Forest"))
            {
                nodeNameList[i] = "Forest";
             //   b = graph.CreateNode(nodeNameList[i] + " " + i);
                nodeWeightList[i] = 3;

            }
            else
            {
                nodeNameList[i] = "N/A";
              //  b = graph.CreateNode(nodeNameList[i] + " " + i);
                nodeWeightList[i] = 1000;
            }
    
            i++;
        }

        
        i = 0;
        decimal rowNum = 0;
        string parent = string.Empty;
        string child = string.Empty;
        for (int z = 0; z <= plane.GetComponent<Map>().mapListL1.Count - 1; z++)
        {
            rowNum = decimal.Floor(z / 32);
            if (z == 0 )
            {
                nodeArray[i] = graph.CreateRoot(nodeNameList[z] + " " + z); 
            }
            if (z < 59 && z > 0 ) //excluding first and last - child is left and right
            {
                nodeArray[i] = graph.CreateRoot(nodeNameList[z] + " " + z);
            }
         
        }
        
      
        int?[,] adj = graph.CreateAdjMatrix(); // We're going to implement that down below
        /*
       

        var a = graph.CreateRoot("A");
        var b = graph.CreateNode("B");
        var c = graph.CreateNode("C");
        var d = graph.CreateNode("D");
        var e = graph.CreateNode("E");
        var f = graph.CreateNode("F");
        var g = graph.CreateNode("G");
        var h = graph.CreateNode("H");
        var i = graph.CreateNode("I");
        var j = graph.CreateNode("J");
        var k = graph.CreateNode("K");
        var l = graph.CreateNode("L");
        var m = graph.CreateNode("M");
        var n = graph.CreateNode("N");
        var o = graph.CreateNode("O");
        var p = graph.CreateNode("P");

        a.AddArc(b, 1)
         .AddArc(c, 1);

        b.AddArc(e, 1)
         .AddArc(d, 3);

        c.AddArc(f, 1)
         .AddArc(d, 3);

        c.AddArc(f, 1)
         .AddArc(d, 3);

        d.AddArc(h, 8);

        e.AddArc(g, 1)
         .AddArc(h, 3);

        f.AddArc(h, 3)
         .AddArc(i, 1);

        g.AddArc(j, 3)
         .AddArc(l, 1);

        h.AddArc(j, 8)
         .AddArc(k, 8)
         .AddArc(m, 3);

        i.AddArc(k, 3)
         .AddArc(n, 1);

        j.AddArc(o, 3);

        k.AddArc(p, 3);

        l.AddArc(o, 1);

        m.AddArc(o, 1)
         .AddArc(p, 1);

        n.AddArc(p, 1);

        // o - Already added

        // p - Already added

       

        // PrintMatrix(ref adj, graph.AllNodes.Count); // We're going to implement that down below
        */
    }
}
