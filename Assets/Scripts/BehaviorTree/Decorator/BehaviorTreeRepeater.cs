using UnityEngine;
/// <summary>
/// Repeater（重复/循环）装饰节点
///有且只有一个子节点！！
/// 1 重复多少次
/// 2 End On Failure
/// 3 Repeat Forever
/// </summary>
public class BehaviorTreeRepeater : BehaviorTreeDecoratorBase
{
//    --<0无限次repeat，==0结束，>0倒数repeat
    public int repeatCount = -1;
    public bool isOnPause = false;

    public BehaviorTreeRepeater()
    {
        curReturnStatus = TaskStatus.Inactive;
        name = "Decorator Repeater";
    }

    public void SetRepeatCount(int count)
    {
        repeatCount = count;
    }
//    --暂停repeat,参数bool
    public void PauseRepeat(bool b)
    {
        isOnPause = b;
    }

    public TaskStatus GetChildStatus()
    {
        return curReturnStatus;
    }
    
    public override TaskStatus OnUpdate()
    {
//        --暂停状态，不去Update子节点
        if (isOnPause)
        {
            return TaskStatus.Running;
        }

        curRunTask = GetOnlyOneChild();
        if (curRunTask.TaskType == TaskType.Composite)
        {
            BehaviorTreeParentBase parentBase = curRunTask as BehaviorTreeParentBase;
            if (parentBase != null) parentBase.ResetChildren();
        }

        if (curRunTask == null)
        {
            Debug.LogWarning("-错误的行为树结构--------------"+name+"获取子节点失败");
            return TaskStatus.Failure;
        }
//        --<!=0无限次repeat，==0结束，>0倒数repeat
//            --真正Repeat重复子节点
        if (repeatCount != 0)
        {
//            --记录子节点的状态   
            curReturnStatus = curRunTask.OnUpdate();
        }
//        --默认一直循环
        if (repeatCount == 0)
        {
            return TaskStatus.Failure;
        }
        else if (repeatCount >= 1)
        {
            repeatCount = repeatCount - 1;
            return TaskStatus.Running;
        }
        else
        {
            return TaskStatus.Running;
        }
    }
}