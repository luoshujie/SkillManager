using UnityEngine;

/// <summary>
/// 所有task基础
/// 不需要主动设置参数
/// 由树结构的机制驱动的参数
/// </summary>
public class BehaviorTreeTaskBase
{
    public TaskStatus taskStatus = TaskStatus.Running;
    public TaskStatus curReturnStatus = TaskStatus.Inactive;
    public TaskType TaskType = TaskType.UnKnow;
    public BehaviorTreeTaskRoot root;
    public int index = 1;
    public BehaviorTreeParentBase parent;
    public int layer = 1;
    public string name = "暂未设置名称";
    public string tag = "UnTag";
    public string desc = "暂无描述";

    public void ResetTaskStatus()
    {
        
    }
    ///
    ///获取同一层layer的上一个节点
    /// 
    public BehaviorTreeTaskBase GetPriviousTask()
    {
        if (parent == null)
        {
            Debug.LogWarning(name +"找不到父节点 try call GetPriviousTask");
            return null;
        }

        if (layer <= 1)
        {
            Debug.LogWarning(name + "GetPriviousTask已经是最顶层，单独Task");
        }

        BehaviorTreeTaskBase priviousTask = parent.GetCurPrivousTask();
        return priviousTask;
    }
    //获取同一层layer下一个task
    public BehaviorTreeTaskBase GetNextTask()
    {
        if (parent == null)
        {
            Debug.LogWarning(name + "找不到父节点 try call GetNextTask");
            return null;
        }

        if (layer <= 1)
        {
            Debug.LogWarning(name + "GetNextTask已经是最顶层，单独Task");
            return null;
        }

        BehaviorTreeTaskBase nextTask = parent.GetCurNextTask();
        return nextTask;
    }

    public void ToString()
    {
        string _rootId = "root id :" + this.root.id + "\n";
        string _name = "名称 : " + this.name + "\n";
        string _layer = "所处层次 ：" + this.layer + "\n";
        string _parent = "父节点 : " + this.parent.name + "\n";
        string _index = "作为子节点顺序 : " + this.index + "\n";
        string _desc = "描述 : " + this.desc + "\n";
        string _status = "UnKnow";
        if (this.curReturnStatus == TaskStatus.Inactive)
        {
            _status = "Inactive";
        }
        else if(this.curReturnStatus == TaskStatus.Failure)
        {
            _status = "Failure";
        }
        else if(this.curReturnStatus == TaskStatus.Running)
        {
            _status = "Running";
        }
        else if(this.curReturnStatus == TaskStatus.Success)
        {
            _status = "Success";
        }

        string _curReturnStatus = "运行返回结果：" + _status + '\n';
        Debug.Log(_rootId + _name + _desc + _layer + _parent + _index + _curReturnStatus);
    }

    public virtual TaskStatus OnUpdate()
    {
        return curReturnStatus;
    }
}
