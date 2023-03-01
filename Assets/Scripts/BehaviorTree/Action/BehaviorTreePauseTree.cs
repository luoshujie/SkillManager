using UnityEngine;

/// <summary>
/// 退出循環
/// </summary>
public class BehaviorTreePauseTree : BehaviorTreeActionBase
{
    public BehaviorTreePauseTree()
    {
        name = "Action PauseTree";
        taskStatus = TaskStatus.Inactive;
        desc = "暫停循環";
    }

    public override TaskStatus OnUpdate()
    {
        root.SetGlobalParam("OnPause",true);
        curReturnStatus = TaskStatus.Success;
        return TaskStatus.Success;
    }
}