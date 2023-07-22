using System;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    [SerializeField] private DebugObject debugObject;
    private List<Node> _connectedNodes;
    private int _g;
    private int _h;
    private int _f;
    private Node _previousNode;
    private bool isClosed;

    public Node()
    {
        isClosed = false;
        _connectedNodes = new List<Node>();
        ResetNode();
    }

    public List<Node> GetNeighbourNodeList()
    {
        return _connectedNodes;
    }

    public void AddNode(Node node)
    {
        _connectedNodes.Add(node);
    }

    public void ResetNode()
    {
        _g = int.MaxValue;
        _h = 0;
        _f = _g + _h;
        _previousNode = null;
        debugObject.SetGText(0.ToString());
        debugObject.SetHText(0.ToString());
        debugObject.SetFText(0.ToString());
        debugObject.SetBackgroundColor(Color.gray);
    }

    public void SetG(int value)
    {
        _g = value;
        debugObject.SetGText(_g.ToString());
    }
    public void SetH(int value)
    {
        _h = value;
        debugObject.SetHText(_h.ToString());
    }

    public void CalculateF()
    {
        _f = _g + _h;
        debugObject.SetFText(_f.ToString());
    }

    public void SetPreviousNode(Node node)
    {
        _previousNode = node;
    }

    public int GetG()
    {
        return _g;
    }
    public int GetH()
    {
        return _h;
    }
    public int GetF()
    {
        return _f;
    }
    public bool GetIsClosed()
    {
        return isClosed;
    }

    public void CloseNode()
    {
        isClosed = true;
        debugObject.Hide();
    }
    public void OpenNode()
    {
        isClosed = false;
        debugObject.Show();
    }
    public Node GetPreviousNode()
    {
        return _previousNode;
    }

    public void SetBackgroundColor(Color color)
    {
        debugObject.SetBackgroundColor(color);
    }
}
