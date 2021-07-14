using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class UpdateLabel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBlockLabel();
    }
    private void UpdateBlockLabel()
    {
        TextMeshPro textMesh = GetComponentInChildren<TextMeshPro>();
        textMesh.text = transform.parent.name;
    }
}
