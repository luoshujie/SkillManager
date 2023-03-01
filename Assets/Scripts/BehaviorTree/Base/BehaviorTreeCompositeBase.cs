/// <summary>
/// 常用于Sequence的第一个节点判断
/// </summary>
public class BehaviorTreeCompositeBase : BehaviorTreeParentBase
{
    public BehaviorTreeCompositeBase()
    {
        TaskType = TaskType.Composite;
    }
}
