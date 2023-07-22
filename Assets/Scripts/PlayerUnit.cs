using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    [SerializeField] private GameObject BarrelVisual;
    public bool HasBarrel;

    public void ThrowBarrel()
    {
        //throw
        HasBarrel = false;
        BarrelVisual.SetActive(false);
    }

    public void PutBarrel(GridPosition targetPosition)
    {
        //put
        HasBarrel = false;
        BarrelVisual.SetActive(false);
    }

    public void PickUpBarrel()
    {
        HasBarrel = true;
        BarrelVisual.SetActive(true);
    }
}
