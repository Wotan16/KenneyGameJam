using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    //[SerializeField] private AStar aStar;
    //[SerializeField] private NodeGrid levelGrid;

    //private Node startNode;
    //private Node endNode;

    //private void Start()
    //{
    //    startNode = levelGrid.GetNodeFromGrid(0, 0);
    //    startNode.SetBackgroundColor(Color.blue);
    //    endNode = levelGrid.GetNodeFromGrid(9, 9);
    //    endNode.SetBackgroundColor(Color.red);
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            Debug.Log(LevelGrid.Instance.GetWorldPosition(new GridPosition(0, 0)));
        }
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        SetStartNode();
    //    }
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        SetEndNode();
    //    }
    //    if (Input.GetKeyDown(KeyCode.T))
    //    {
    //        ShowPath();
    //    }
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        HideNode();
    //    }
    //    if (Input.GetMouseButtonDown(1))
    //    {
    //        ShowNode();
    //    }
    //}

    //private void ShowNode()
    //{
    //    RaycastHit hit = MouseToWorld.instance.GetMouseToWorldHit();
    //    Node node = levelGrid.GetNodeByWorldPosition(hit.point);
    //    node.OpenNode();
    //}

    //private void HideNode()
    //{
    //    RaycastHit hit = MouseToWorld.instance.GetMouseToWorldHit();
    //    Node node = levelGrid.GetNodeByWorldPosition(hit.point);
    //    node.CloseNode();
    //}

    //private void ShowPath()
    //{
    //    List<Node> path = aStar.FindPath(startNode, endNode, levelGrid.GetNodeList());

    //    foreach (Node node in path)
    //    {
    //        node.SetBackgroundColor(Color.green);
    //    }
    //}

    //private void SetEndNode()
    //{
    //    endNode.ResetNode();
    //    RaycastHit hit = MouseToWorld.instance.GetMouseToWorldHit();
    //    endNode = levelGrid.GetNodeByWorldPosition(hit.point);
    //    endNode.SetBackgroundColor(Color.red);
    //}

    //private void SetStartNode()
    //{
    //    startNode.ResetNode();
    //    RaycastHit hit = MouseToWorld.instance.GetMouseToWorldHit();
    //    startNode = levelGrid.GetNodeByWorldPosition(hit.point);
    //    startNode.SetBackgroundColor(Color.blue);
    //}
}
