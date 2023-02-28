/// <summary>
/// 活动节点基类
/// </summary>
public class BehaviorTreeActionBase : BehaviorTreeTaskBase
{
    public TaskType TaskType = TaskType.Action;
    public string name = "IAction";
}
