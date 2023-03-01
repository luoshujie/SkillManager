using UnityEngine;

/// <summary>
/// 打印
/// </summary>
public class BehaviorTreeLog : BehaviorTreeActionBase
{
    public string Log = "";
    public BehaviorTreeLog()
    {
        name = "Action Log";
    }

    public void SetLog(string log)
    {
        Log = log;
    }
    
    public override TaskStatus OnUpdate()
    {
        curReturnStatus = TaskStatus.Success;
        Debug.Log(Log);
        ToString();
        return TaskStatus.Success;
    }
}
