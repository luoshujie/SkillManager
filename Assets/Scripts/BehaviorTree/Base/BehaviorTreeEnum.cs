

// Composite 复合节点
//复合节点又控制着子节点的执行规则，是顺序执行还是并行执行，亦或者随机执行，
//是遇到成功就立即返回成功还是遇到失败就立即返回失败，亦或者遇到成功继续执行下一个，
//或者遇到失败继续执行下一个呢？

// Decorator 装饰节点
// 装饰任务是用于包裹其他任务的任务，他只能有一个子任务。
// 装饰任务可以改变子任务的行为，例如，装饰任务可以保持子任务持续运行或者改变子任务的返回值


/// <summary>
/// 任务运行状态
/// </summary>
public enum TaskStatus
{
	/// <summary>
	/// 非活动状态
	/// </summary>
    Inactive = 1,
	/// <summary>
	/// 失败
	/// </summary>
    Failure = 2,
	/// <summary>
	/// 成功
	/// </summary>
    Success = 3,
	/// <summary>
	/// 运行中
	/// </summary>
    Running = 4
}
/// <summary>
/// 任务类型
/// </summary>
public enum TaskType
{
	/// <summary>
	/// null
	/// </summary>
	UnKnow = 0,
	/// <summary>
	/// 复合节点--必须包含子节点
	/// </summary>
	Composite = 1,
	/// <summary>
	/// 装饰节点--必须包含子节点
	/// </summary>
	Decorator = 2,
	/// <summary>
	/// 行为节点--最终子节点
	/// </summary>
	Action = 3,
	/// <summary>
	/// 条件节点--最终子节点
	/// </summary>
	Conditional = 4
}
