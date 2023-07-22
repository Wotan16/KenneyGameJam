using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Unit unit;
    private void Start()
    {
        GridPosition position = LevelGrid.Instance.GetGridPosition(transform.position);
        //gridObject.type = GridObjectType.Enemy;
    }
}
