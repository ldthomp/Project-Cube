using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    FinishBlock nextLevel;
    List<GameObject> path = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        nextLevel = GetComponent<FinishBlock>();
        PopulateList();
    }
    public int GetPathCount()
    {
        return path.Count;
    }
    private void PopulateList()
    {
        var blocksInPath = FindObjectsOfType<PathBlock>();
        
        foreach (PathBlock block in blocksInPath)
        {
            path.Add(block.gameObject);
            print("adding blocks to list. List is now " + path.Count);
        }
    }

    public void RemoveBlockFromList()
    {
        path.RemoveAt(0);
        print("list length now " + path.Count);
    }
}
