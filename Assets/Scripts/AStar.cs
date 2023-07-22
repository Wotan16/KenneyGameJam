using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    private NodeGrid levelGrid;

    public List<Node> FindPath(Node startNode, Node endNode, List<Node> nodes)
    {
        List<Node> openList = new List<Node>();
        List<Node> closedList = new List<Node>();
        openList.Add(startNode);

        foreach (Node node in nodes)
        {
            node.ResetNode();
        }

        startNode.SetG(0);
        startNode.SetH(CalculateDistance(startNode, endNode));
        startNode.CalculateF();

        while(openList.Count > 0)
        {
            Node currentNode = GetLowestFNode(openList);

            if(currentNode == endNode)
            {
                List<Node> path = new List<Node>();
                Node previousNode = currentNode;
                do
                {
                    path.Insert(0, previousNode);
                    previousNode = previousNode.GetPreviousNode();
                }
                while (previousNode != startNode);

                path.Insert(0, previousNode);

                return path;
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach(Node neighbourNode in currentNode.GetNeighbourNodeList())
            {
                if (neighbourNode.GetIsClosed())
                {
                    continue;
                }

                if (closedList.Contains(neighbourNode))
                {
                    continue;
                }

                int tentativeGCost = currentNode.GetG() + CalculateDistance(currentNode, neighbourNode);
                if(tentativeGCost < neighbourNode.GetG())
                {
                    neighbourNode.SetPreviousNode(currentNode);
                    neighbourNode.SetG(tentativeGCost);
                    neighbourNode.SetH(CalculateDistance(neighbourNode, endNode));
                    neighbourNode.CalculateF();

                    if (!openList.Contains(neighbourNode))
                    {
                        openList.Add(neighbourNode);
                    }
                }
            }
        }
        Debug.LogError("no path");
        return null;
    }

    private int CalculateDistance(Node node1, Node node2)
    {
        Vector2Int node1XY = levelGrid.GetXYofNode(node1);
        Vector2Int node2XY = levelGrid.GetXYofNode(node2);
        int distance = Math.Abs(node2XY.x - node1XY.x) + Math.Abs(node2XY.y - node1XY.y);
        return distance;
    }   

    private Node GetLowestFNode(List<Node> list)
    {
        Node lowestNode = list[0];
        foreach(Node node in list)
        {
            if (node.GetF() < lowestNode.GetF())
            {
                lowestNode = node;
            }
        }
        return lowestNode;
    }
}
