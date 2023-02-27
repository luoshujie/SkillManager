namespace Buff
{
    /// <summary>
    /// buff 修改运动类型
    /// </summary>
    public class BuffMotionModifier : BuffModifier
    {
        /// <summary>
        /// 更新运动
        /// </summary>
        public void OnMotionUpdate()
        {
            
        }

        /// <summary>
        /// 运动中断时
        /// </summary>
        public void OnMotionInterrupt()
        {
            
        }
        
        /// <summary>
        /// 运动
        /// </summary>
        /// <param name="motionTypeId">运动类型id 配置项。包含运动位移参数及相关数据</param>
        /// <param name="priority">优先级 低优先级不能打断高优先级。</param>
        /// <param name="forceInterrupt">是否忽略优先级，强制打断当前的运动</param>
        public void ApplyMotion(int motionTypeId,int priority,bool forceInterrupt)
        {
            
        }

        /// <summary>
        /// 运动前的Buff效果
        /// </summary>
        public void UpdateBeforeMovement()
        {
            
        }

        /// <summary>
        /// 运动后的Buff效果
        /// </summary>
        public void UpdateAfterMovement()
        {
            
        }
    }
}
