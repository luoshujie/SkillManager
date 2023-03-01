

using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 行为树中的父任务 task
/// 包括：composite（复合），decorator（修饰符）！
/// 虽然 Monobehaviour 没有类似的 API，但是并不难去理解这些功能：
/// </summary>
public class BehaviorTreeParentBase : BehaviorTreeTaskBase
{
    public int curChilIndex = -1;
    public BehaviorTreeTaskBase curRunTask;
    public List<BehaviorTreeTaskBase> childTasks = new List<BehaviorTreeTaskBase>();
    /// <summary>
    /// 重置当前访问的子节点位置为第一个
    /// </summary>
    public void ResetChildren()
    {
        curRunTask = null;
        curChilIndex = -1;
    }

    public int GetCurChildIndex()
    {
        return curChilIndex;
    }
    //--对于ReaterTask等只能有一个子节点的
    public BehaviorTreeTaskBase GetOnlyOneChild()
    {
        if (GetChildCount() != 1)
        {
            Debug.LogWarning(name + "应该有且只有一个子节点！but：childCount:" + GetChildCount());
        }
        return childTasks[0];
    }

    public int GetChildCount()
    {
        return childTasks.Count;
    }
    //--添加子节点有顺序要求
    public BehaviorTreeParentBase AddChild(BehaviorTreeTaskBase task)
    {
        if (task == null)
        {
            Debug.LogWarning("add task is nil !!");
            return null;
        }
        Debug.Log(name + "  添加子节点 : " + task.name);
        int index = GetChildCount() + 1;
        task.index = index;
        task.layer = layer + 1;
        task.parent = this;
        task.root = this.root;
        childTasks.Add(task);
        root.AddGlobalTask(task.tag, task);
        return this;
    }
    public void ClearChildTasks()
    {
        curChilIndex = -1;
        childTasks.Clear();
    }

    public bool HasChildren()
    {
        return GetChildCount() > 0;
    }

    public BehaviorTreeTaskBase GetNextChild()
    {
        if (GetChildCount() > curChilIndex + 1)
        {
            curChilIndex = curChilIndex + 1;
            BehaviorTreeTaskBase nextTask = childTasks[curChilIndex];
            return nextTask;
        }
        else
        {
            return null;
        }
    }
    //获取前一个子节点，不移动指针
    public BehaviorTreeTaskBase GetCurPrivousTask()
    {
        if (curChilIndex<=0)
        {
            Debug.LogWarning(name + "GetCurPrivousTask : 已经是最前的Task或childtask为空");
            return null;
        }
        else
        {
            return childTasks[curChilIndex - 1];
        }
    }
//    获取下一个子节点，不移动指针
    public BehaviorTreeTaskBase GetCurNextTask()
    {
        if (curChilIndex >= GetChildCount()+1)
        {
            Debug.LogWarning(name + "GetCurNextTask : 已经是最后的Task或childtask为空");
            return null;
        }
        else
        {
            return childTasks[curChilIndex + 1];
        }
    }
}