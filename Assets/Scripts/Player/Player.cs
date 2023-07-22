using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public event Action OnPlayerActionEnded;

    private GridPosition position;
    private GridObject gridObject;
    public GridPosition PlayerGridPosition { get { return position; } }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Player" + transform + " - " + Instance);
            Destroy(gameObject);
        }
        Instance = this;
    }

    private void Start()
    {
        //position = LevelGrid.Instance.GetGridPosition(transform.position);
        //gridObject = LevelGrid.Instance.GetGridObject(position);
        //gridObject.type = GridObjectType.Player;
    }

    private void Rotate(Vector3 positionToLookAt)
    {
        //perform rotation
    }

    private void MoveToPosition(Vector3 targetWorldPosition)
    {
        transform.position = targetWorldPosition;
    }

    #region InputEvents
    public void OnMove(CallbackContext context)
    {
        if (!context.performed)
            return;

        Vector2 moveVector = context.ReadValue<Vector2>();
        Vector3 targetWorldPosition = transform.position + new Vector3(moveVector.x, 0, moveVector.y);
        Rotate(targetWorldPosition);

        GridPosition targetGridPosition = LevelGrid.Instance.GetGridPosition(targetWorldPosition);

        if (!LevelGrid.Instance.isValidGridPosition(targetGridPosition))
            return;


    }

    
    #endregion
}
