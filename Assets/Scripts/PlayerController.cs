using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [SerializeField] private PlayerUnit playerUnit;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one PlayerController" + transform + " - " + Instance);
            Destroy(gameObject);
        }
        Instance = this;
    }

    private void Rotate(GridPosition targetGridPosition)
    {
        Vector3 targetWorldPosition = LevelGrid.Instance.GetWorldPosition(targetGridPosition);
        playerUnit.LookAt(targetWorldPosition);
    }

    private bool TryMove(GridPosition targetGridPosition)
    {
        Rotate(targetGridPosition);

        if (!LevelGrid.Instance.isValidGridPosition(targetGridPosition))
            return false;

        if (!LevelGrid.Instance.GetWalkableOnGridPosition(targetGridPosition))
            return false;

        if (LevelGrid.Instance.HasAnyUnitOnGridPosition(targetGridPosition))
            return false;

        playerUnit.Move(targetGridPosition);
        return true;
    }

    #region InputEvents
    public void OnMoveForward(CallbackContext context)
    {
        if (!context.performed)
            return;

        GridPosition playerUnitPosition = playerUnit.GetGridPosition();
        GridPosition targetGridPosition = new GridPosition(playerUnitPosition.x, playerUnitPosition.z + 1);
        TryMove(targetGridPosition);
    }

    public void OnMoveBack(CallbackContext context)
    {
        if (!context.performed)
            return;

        GridPosition playerUnitPosition = playerUnit.GetGridPosition();
        GridPosition targetGridPosition = new GridPosition(playerUnitPosition.x, playerUnitPosition.z - 1);
        TryMove(targetGridPosition);
    }
    public void OnMoveRight(CallbackContext context)
    {
        if (!context.performed)
            return;

        GridPosition playerUnitPosition = playerUnit.GetGridPosition();
        GridPosition targetGridPosition = new GridPosition(playerUnitPosition.x + 1, playerUnitPosition.z);
        TryMove(targetGridPosition);
    }
    public void OnMoveLeft(CallbackContext context)
    {
        if (!context.performed)
            return;

        GridPosition playerUnitPosition = playerUnit.GetGridPosition();
        GridPosition targetGridPosition = new GridPosition(playerUnitPosition.x - 1, playerUnitPosition.z);
        TryMove(targetGridPosition);
    }
    public void OnInteract(CallbackContext context)
    {   
        if (!context.performed)
            return;
    }

    public void OnThrow(CallbackContext context)
    {
        if (!context.performed)
            return;
    }

    #endregion
}
