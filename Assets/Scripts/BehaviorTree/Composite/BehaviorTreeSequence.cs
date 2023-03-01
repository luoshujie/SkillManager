using UnityEngine;

/// <summary>
/// and
/// </summary>
public class BehaviorTreeSequence : BehaviorTreeCompositeBase
{

    public BehaviorTreeSequence()
    {
        curReturnStatus = TaskStatus.Inactive;
        name = "SequenceTask";
    }

    public override TaskStatus OnUpdate()
    {
        if (!HasChildren())
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

        return RunChildByAnd();
    }
    //and:遇到一个false就中断执行
    //序列组合节点：AND逻辑，所有子节点Success才返回Success
    public TaskStatus RunChildByAnd()
    {
        while (curRunTask != null)
        {
            curReturnStatus = curRunTask.OnUpdate();
            curRunTask.ResetTaskStatus();
            //找到false或者running直接返回,就中断执行,这一帧到此结束
            if (curReturnStatus == TaskStatus.Failure)
            {
                //--返回Failure说明这次Sequence走完了，重置等下一轮
                Reset();
                return TaskStatus.Failure;
            }
            else if (curReturnStatus == TaskStatus.Running)
            {
                return TaskStatus.Running;
            }
            else
            {
                //false的时候队列执行下一个
                curRunTask = GetNextChild();
            }
        }
        //找完了所有节点没有false，那么success
        //说明这次Sequence走完了，重置等下一轮
        curReturnStatus = TaskStatus.Success;
        Reset();
        return TaskStatus.Success;
    }
    //--重置
    public void Reset()
    {
        ResetChildren();
    }
}



