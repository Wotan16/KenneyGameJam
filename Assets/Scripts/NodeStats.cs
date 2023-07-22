using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeStats
{
    private float _g;
    private float _h;
    private float _f;
    private Node _previousNode;

    public void ResetNode()
    {
        _g = float.MaxValue;
        _h = 0;
        CalculateF();
        _previousNode = null;
    }

    public void SetG(float value)
    {
        _g = value;
    }
    public void SetH(float value)
    {
        _h = value;
    }

    public void CalculateF()
    {
        _f = _g + _h;
    }

    public void SetPreviousNode(Node node)
    {
        _previousNode = node;
    }

    public float GetG()
    {
        return _g;
    }
    public float GetH()
    {
        return _h;
    }
    public float GetF()
    {
        return _f;
    }

    public Node GetPreviousNode()
    {
        return _previousNode;
    }

}
