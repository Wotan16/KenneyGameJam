using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected GridPosition gridPosition;

    protected void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, this);
    }

    public void Move(GridPosition newGridPosition)
    {
        transform.position = LevelGrid.Instance.GetWorldPosition(newGridPosition);
        GridPosition oldGridPosition = gridPosition;
        gridPosition = newGridPosition;
        LevelGrid.Instance.UnitMovedGridPosition(this, oldGridPosition, newGridPosition);
    }

    public GridPosition GetGridPosition()
    {
        return gridPosition;
    }

    public void LookAt(Vector3 position)
    {
        transform.LookAt(position);
    }
}
