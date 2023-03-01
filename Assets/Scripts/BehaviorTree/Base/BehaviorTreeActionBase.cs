/// <summary>
/// 活动节点基类
/// </summary>
public class BehaviorTreeActionBase : BehaviorTreeTaskBase
{
    public BehaviorTreeActionBase()
    {
        TaskType = TaskType.Action;
        name = "IAction";
    }
}
