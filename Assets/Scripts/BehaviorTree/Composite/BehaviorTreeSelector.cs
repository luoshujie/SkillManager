using UnityEngine;

/// <summary>
/// or
/// </summary>
public class BehaviorTreeSelector : BehaviorTreeCompositeBase
{

    public BehaviorTreeSelector()
    {
        curReturnStatus = TaskStatus.Inactive;
        name = "SelectorTask";
    }

    public override TaskStatus OnUpdate()
    {
        if (HasChildren())
        {
            Debug.LogWarning(name + "父节点类型没有子节点！！");
            return TaskStatus.Failure;
        }

        if (curRunTask == null)
        {
            curRunTask = GetNextChild();
        }

        if (curRunTask == null)
        {
            Debug.LogWarning("错误的节点配置！：没有子节点或已越界！！" + name+"子节点长度：" + GetChildCount() + "   尝试访问：" + GetCurChildIndex()+1);
            return TaskStatus.Failure;
        }

        return RunChildByOr();
    }
    //--or 机制
//----选择组合节点：OR逻辑，直到有一个Success就返回Success
    public TaskStatus RunChildByOr()
    {
        while (curRunTask != null)
        {
            curReturnStatus = curRunTask.OnUpdate();
            curRunTask.ResetTaskStatus();
            //--返回Success说明这次Selector走完了，重置等下一轮
            if (curReturnStatus == TaskStatus.Success)
            {
                Reset();
                return TaskStatus.Success;
            }
            else if (curReturnStatus == TaskStatus.Running)
            {
                return curReturnStatus;
            }
            else
            {
                //false的时候队列执行下一个
                curRunTask = GetNextChild();
            }
        }
        //执行完了还没找到一个true
        //走到尽头返回，说明这次Selector走完了，重置等下一轮
        Reset();
        curReturnStatus = TaskStatus.Failure;
        return TaskStatus.Failure;
    }
    //--重置
    public void Reset()
    {
        curReturnStatus = TaskStatus.Inactive;
        ResetChildren();
    }
}



