using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugObject : MonoBehaviour
{
    [SerializeField] private MeshRenderer backgroundMesh;
    [SerializeField] private TextMeshProUGUI GText;
    [SerializeField] private TextMeshProUGUI HText;
    [SerializeField] private TextMeshProUGUI FText;
    [SerializeField] private GameObject foregroundObject;

    public void SetGText(string value)
    {
        GText.text = value;
    }
    public void SetHText(string value)
    {
        HText.text = value;
    }
    public void SetFText(string value)
    {
        FText.text = value;
    }
    
    public void SetBackgroundColor(Color color)
    {
        backgroundMesh.material.color = color;
    }

    public void Hide()
    {
        foregroundObject.SetActive(true);
    }

    public void Show()
    {
        foregroundObject.SetActive(false);
    }
}
