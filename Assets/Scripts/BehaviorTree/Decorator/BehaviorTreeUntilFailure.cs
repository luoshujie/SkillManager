using UnityEngine;
/// <summary>
/// 有且只有一个子节点
///只要子节点当前的状态不是 Failure
/// return running
/// </summary>
public class BehaviorTreeUntilFailure : BehaviorTreeDecoratorBase
{
    public BehaviorTreeUntilFailure()
    {
        curReturnStatus = TaskStatus.Inactive;
        name = "Decorator UntilFailure";
    }

    public override TaskStatus OnUpdate()
    {
        curRunTask = GetOnlyOneChild();
        if (curRunTask == null)
        {
            Debug.LogWarning("-错误的行为树结构--------------"+name+"获取子节点失败");
            return TaskStatus.Failure;
        }
        curReturnStatus = curRunTask.OnUpdate();
        if (curReturnStatus == TaskStatus.Inactive)
        {
             Debug.LogWarning("错误: "+name+"未初始化：TaskStatus==Inactive!");
             return TaskStatus.Failure;
        }
        
//        --遇到running返回
        if (curReturnStatus != TaskStatus.Failure)
        {
            return TaskStatus.Running;
        }
        else
        {
//            --其他返回Failure
            return TaskStatus.Failure;
        }
    }
}