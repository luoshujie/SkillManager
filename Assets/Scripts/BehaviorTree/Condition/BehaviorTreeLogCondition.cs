using UnityEngine;

/// <summary>
/// 打印
/// </summary>
public class BehaviorTreeLogCondition : BehaviorTreeConditionalBase
{
    public string Log = "";
    public BehaviorTreeLogCondition()
    {
        name = "Condition LogCondition";
    }
    
    public override TaskStatus OnUpdate()
    {
        curReturnStatus = TaskStatus.Success;
        ToString();
        return curReturnStatus;
    }
}
