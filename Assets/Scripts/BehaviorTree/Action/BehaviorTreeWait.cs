using UnityEngine;
/// <summary>
/// 等待指定的时间，期间此Task将一直返回Running，
/// 一直到时间消逝完后，返回 Success
/// </summary>
public class BehaviorTreeWait : BehaviorTreeActionBase
{
    public float waitTime = 0;
    public float curTime = 0;
    public BehaviorTreeWait()
    {
        name = "Action Wait";
        taskStatus = TaskStatus.Inactive;
        desc = "期间返回Running,时间消逝完后返回Success";
    }

    public void SetWait(float time)
    {
        waitTime = time;
        curTime = 0;
    }

    public override TaskStatus OnUpdate()
    {
        curReturnStatus = TaskStatus.Inactive;
        if (waitTime <= 0)
        {
            curTime = 0;
            curReturnStatus = TaskStatus.Success;
            return TaskStatus.Success;
        }
        CountBackwards();
        Debug.Log(curTime + " " + waitTime);
        if (curTime >= waitTime)
        {
            curTime = 0;
            curReturnStatus = TaskStatus.Success;
            return TaskStatus.Success;
        }
        else
        {
            curReturnStatus = TaskStatus.Running;
            return TaskStatus.Running;
        }
    }
//    --倒数
    public void CountBackwards()
    {
        curTime = curTime + Time.deltaTime;
    }
}
