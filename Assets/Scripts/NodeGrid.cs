using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGrid
{
    private int width;
    private int height;
    private Node[,] nodeGrid;
    
    public NodeGrid(int width, int height)
    {
        this.width = width;
        this.height = height;
        InitializeNodeGrid();
    }

    private void InitializeNodeGrid()
    {
        nodeGrid = new Node[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

                nodeGrid[x, y] = new Node();
            }
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x - 1 >= 0)
                {
                    nodeGrid[x, y].AddNode(nodeGrid[x - 1, y]);
                }
                if (x + 1 < width)
                {
                    nodeGrid[x, y].AddNode(nodeGrid[x + 1, y]);
                }
                if (y - 1 >= 0)
                {
                    nodeGrid[x, y].AddNode(nodeGrid[x, y - 1]);
                }
                if (y + 1 < height)
                {
                    nodeGrid[x, y].AddNode(nodeGrid[x, y + 1]);
                }
            }
        }
    }

    public List<Node> GetNodeList()
    {
        List<Node> nodeList = new List<Node>();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                nodeList.Add(nodeGrid[x, y]);
            }
        }

        return nodeList;
    }

    public Node GetNodeFromGrid(int x, int y)
    {
        return nodeGrid[x, y];
    }

    public Vector2Int GetXYofNode(Node node)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if(node == nodeGrid[x, y])
                {
                    return new Vector2Int(x, y);
                }
            }
        }
        Debug.LogError("Grid doesn't contain this node");
        return new Vector2Int(0, 0);
    }

    //public Node GetNodeByWorldPosition(Vector3 position)
    //{
    //    Vector2Int coordinates = GetXYfromWorldPosition(position);
    //    Node node = GetNodeFromGrid(coordinates.x, coordinates.y);
    //    return node;
    //}

    //public Vector2Int GetXYfromWorldPosition(Vector3 position)
    //{
    //    Vector3 actualPosition = position - transform.position;
    //    float worldX = actualPosition.x;
    //    float worldY = actualPosition.z;
    //    float x = worldX / cellSize;
    //    float y = worldY / cellSize;
    //    return new Vector2Int((int) x, (int)y);
    //}
}
