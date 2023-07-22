using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseToWorld : MonoBehaviour
{
    public static MouseToWorld instance { get; private set; }

    [SerializeField] private Camera _mainCamera;
    [SerializeField] private LayerMask _floorMask;

    private float _maxDistance = 400f;

    private void Awake()
    {
        instance = this;
    }

    public RaycastHit GetMouseToWorldHit()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit, _maxDistance, _floorMask);

        Debug.DrawRay(_mainCamera.transform.position, hit.point - _mainCamera.transform.position, Color.blue);

        return hit;
    }
}
