using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlockAmountDisplay : MonoBehaviour
{

    PathManager pathManager;
    int maxPathLength;
    //TextMeshPro blockAmountText;

    private void Awake()
    {
        pathManager = FindObjectOfType<PathManager>();
        //blockAmountText = GetComponent<TextMeshPro>();
    }
    private void Start()
    {
        maxPathLength = pathManager.GetPathCount();
    }
    private void Update()
    {
        GetComponent<Text>().text = string.Format("{0:0}/{1:0}", pathManager.GetPathCount(), maxPathLength);
        //if (blockAmountText == null) return;
        //blockAmountText.text = "hello";
    }

    //Health health;

    //private void Awake()
    //{
    //    health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

    //}
    //private void Update()
    //{
    //    GetComponent<Text>().text = string.Format("{0:0}/{1:0}", health.GetHealthPoints(), health.GetMaxHealthPoints());
    //}
}
