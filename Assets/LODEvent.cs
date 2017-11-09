using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LODGroup))]
public class LODEvent : MonoBehaviour {
    public List<GameObject> Lods;
    
    int currentLevel = -1;

    /// <summary>
    /// -1 means Culled
    /// </summary>
    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
    }

    [Tooltip("手动设定用于识别LODLevel的Mesh，不设定会自动选取")]
    public Renderer[] levelChecker;
    // Use this for initialization
    protected virtual void Start () {
        if (levelChecker == null || levelChecker.Length == 0)
        {
            levelChecker = new Renderer[Lods.Count];
            for (int i = 0; i < Lods.Count; i++)
            {
                if (Lods[i])
                {
                    var renderer = Lods[i].GetComponentInChildren<Renderer>();
                    levelChecker[i] = renderer;
                    if (renderer.isVisible)
                    {
                        currentLevel = i;
                    }
                }    
            }
        }
    }
	
	// Update is called once per frame
	void Update () {


        if (levelChecker.Length == 0)
        {
            return;
        }
        int newLevel = -1;

        if (currentLevel != -1 && levelChecker[currentLevel].isVisible)
        {
            ///Lod 没有改变
            newLevel = currentLevel;
        }
        else
        {
            ///Lod 发生变化
            for (int i = levelChecker.Length - 1; i >= 0; i--)
            {
                if (levelChecker[i].isVisible)
                {
                    newLevel = i;
                    break;
                }
            }
        }

        if (newLevel != currentLevel)
        {
            ///触发LOD级别改变事件
            OnLODLevelChanged.Invoke(newLevel);
        }

        currentLevel = newLevel;
	}

    public UnityEngine.UI.Dropdown.DropdownEvent OnLODLevelChanged;
}
