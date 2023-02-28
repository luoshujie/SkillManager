using System;
using UnityEngine;

public class BehaviorTreeManager:MonoBehaviour
{
    public static BehaviorTreeManager instance;
    public BehaviorTreeTaskRoot tree;

    private void Awake()
    {
        instance = this;
    }

    public void Init()
    {
    }

    public void RunTree(BehaviorTreeTaskRoot enter)
    {
        tree = enter;
    }
    //--重置树下所有Action
    public void ResetTreeActions()
    {
        BehaviorTreeTaskRoot treeRoot = GetCurTreeRoot();
        treeRoot.ResetAllActionsState();
    }

    public BehaviorTreeTaskRoot GetCurTreeRoot()
    {
        return tree;
    }

    private void Update()
    {
        OnUpdate();
    }

    public void OnUpdate()
    {
        UpdateTask();
    }

    public void UpdateTask()
    {
        if (tree != null)
        {
            TaskStatus status = tree.OnUpdate();
//            if (status != TaskStatus.Running)
//            {
//                table.remove(this.curTrees, key);
//            }
        }
    }
}