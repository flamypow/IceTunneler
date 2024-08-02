using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : Singleton <LevelInfo>
{
    [SerializeField] private Transform[] checkpoints;

    public Transform GetCheckpoint(int index)
    {
        return checkpoints[index];
    }
}
