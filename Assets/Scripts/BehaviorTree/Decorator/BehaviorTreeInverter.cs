using UnityEngine;

/// <summary>
/// 有且只有一个子节点
///running 则返回running
/// Success和Failure：子节点的任务完成后返回值，在这个节点会被取反并传递到上一级中！
/// </summary>
public class BehaviorTreeInverter : BehaviorTreeDecoratorBase
{

    public BehaviorTreeInverter()
    {
        curReturnStatus = TaskStatus.Inactive;
        name = "Decorator Inverter";
    }

    public override TaskStatus OnUpdate()
    {
        curRunTask = GetOnlyOneChild();
        if (curRunTask == null)
        {
            Debug.LogWarning("错误的节点结构" + name + "获取子节点失败");
            return TaskStatus.Failure;
        }

        curReturnStatus = curRunTask.OnUpdate();
        if (curReturnStatus == TaskStatus.Inactive)
        {
            Debug.LogWarning("错误:" + name + "未初始化：TaskStatus==Inactive!");
            return TaskStatus.Failure;
        }

        //遇到running返回
        if (curReturnStatus == TaskStatus.Running)
        {
            return TaskStatus.Running;
        }
        else if (curReturnStatus == TaskStatus.Success)
        {
            return TaskStatus.Failure;
        }
        else if (curReturnStatus == TaskStatus.Failure)
        {
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }
}