using System;
using System.Collections.Generic;
using UnityEngine;

//--可能很容易理解，因为他们在某种程度上改变游戏的状态和结果。
/// <summary>
/// 根节点
/// 有四种不同类型的 task(任务): 包括
/// 1 action（行为），
/// 2 composite（复合），--1,EntryParallel | 2,Selector | 3,Sequence
/// 3 conditional（条件），
/// 4 decorator（修饰符）！--Interrupt  Repeater  UntilSuccess
/// </summary>
public class BehaviorTreeTaskRoot
{
    public int id;
    public string name = "根起始点";
    public int layer = 0;
    public string desc = "行为树入口";
    public BehaviorTreeTaskBase curRunTask;
    public BehaviorTreeTaskBase startTask;
    public List<BehaviorTreeTaskBase> taskStackList = new List<BehaviorTreeTaskBase>();
    public Dictionary<string,object> globalTable = new Dictionary<string, object>();
    public Dictionary<string,BehaviorTreeTaskBase> taskList = new Dictionary<string, BehaviorTreeTaskBase>();
    public void AddGlobalTask(string tag,BehaviorTreeTaskBase task)
    {
        string key = tag.ToString();
        if (taskList.ContainsKey(key))
        {
            taskList[key] = task;
        }
        else
        {
            taskList.Add(key,task);
        }
    }

    public BehaviorTreeTaskBase FindGlobalTask(string tag)
    {
        if (taskList.ContainsKey(tag))
        {
            return taskList[tag];
        }
        else
        {
            Debug.LogWarning(name + "TaskRoot can not find task by tag: " + tag);
            return null;
        }
    }

    public Dictionary<string, BehaviorTreeTaskBase> GetAllTasks()
    {
        return taskList;
    }
    //----------------此树下全局参数
    public void SetGlobalParam(string key, object data)
    {
        if (globalTable.ContainsKey(key))
        {
            globalTable[key] = data;
        }
        else
        {
            globalTable.Add(key,data);
        }
    }

    public object GetGlobalParam(string key)
    {
        if (globalTable.ContainsKey(key))
        {
            return globalTable[key];
        }
        else
        {
            Debug.LogWarning("找不到全局参数："  + key);
            return null;
        }
    }

    public void SetStart(BehaviorTreeTaskBase task)
    {
        startTask = task;
    }

    public void ResetAllActionsState()
    {
        foreach (BehaviorTreeTaskBase taskBase in taskList.Values)
        {
            if (taskBase.TaskType == TaskType.Action)
            {
                taskBase.taskStatus = TaskStatus.Inactive;
                Debug.Log(taskBase.name + "taskType == TaskStatus.Inactive" );
            }
        }
    }

    public void PushTask(BehaviorTreeTaskBase task)
    {
        // task.parent = this;
        task.root = this;
        task.layer = layer + 1;
        startTask = task;
    }

    public bool IsParentTypeTask(BehaviorTreeTaskBase task)
    {
        if (task.TaskType == TaskType.Composite || task.TaskType == TaskType.Decorator)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnTopTaskChange()
    {
        if (taskStackList.Count > 0)
        {
            BehaviorTreeTaskBase topTask = taskStackList[taskList.Count - 1];
            if (IsParentTypeTask(topTask))
            {

            }
            else
            {
                curRunTask = topTask;
            }
        }
        else
        {
            curRunTask = null;
        }
    }

    public BehaviorTreeTaskBase PopTask()
    {
        if (taskStackList.Count < 1)
        {
            return null;
        }
        BehaviorTreeTaskBase task = taskStackList[taskStackList.Count - 1];
        taskStackList.RemoveAt(taskStackList.Count - 1);
        return task;
    }

    public TaskStatus OnUpdate()
    {
        object b = GetGlobalParam("OnPause");
        bool isB = (bool) b;
        if (isB)
        {
            return TaskStatus.Running;
        }
        if (startTask != null)
        {
            return startTask.OnUpdate();
        }
        else
        {
            return TaskStatus.Failure;
        }
    }
}