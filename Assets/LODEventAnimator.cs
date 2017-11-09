using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LODEventAnimator : LODEvent
{
    public Animator animator;
    protected override void Start()
    {
        base.Start();
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }

        OnLODLevelChanged.AddListener(RefreshMesh);
    }

    void RefreshMesh(int level)
    {
        if (animator && level >=0 && level < Lods.Count)
        {
            Lods[level].transform.SetSiblingIndex(0);
            animator.Rebind();
        }
    }
}
