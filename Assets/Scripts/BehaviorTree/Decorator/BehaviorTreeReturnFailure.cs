using UnityEngine;
/// <summary>
/// 有且只有一个子节点
///只要子节点当前的状态不是 running，
/// 也就是子节点执行结果无论是 success 还是 failure，都返回 failure！
/// 如果子节点状态是 running的话则返回 running！
/// </summary>
public class BehaviorTreeReturnFailure : BehaviorTreeDecoratorBase
{
    public BehaviorTreeReturnFailure()
    {
        curReturnStatus = TaskStatus.Inactive;
        name = "Decorator ReturnFailure";
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
        if (curReturnStatus == TaskStatus.Running)
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