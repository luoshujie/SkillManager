namespace Skill
{
    /// <summary>
    /// 主动持续施法技能
    /// </summary>
    public class GeneralAbilityChannelSkill:GeneralAbilitySkill
    {
        //如策划配置CastPoint为0.1秒，ThinkInterval为0.3秒，ChannelTime为1.4秒时。则技能将会在
        //AbilityStart0.1秒后调用ChannelStart,将在第0.4秒->0.7秒->1.0秒->1.3秒调用ChannelThink，
        //将在第1.4秒调用ChannelFinish
        /// <summary>
        /// 触发时间间隔
        /// </summary>
        public float ThinkInterval;
        /// <summary>
        /// 引导开始
        /// </summary>
        public void ChannelStart()
        {
            
        }
        /// <summary>
        /// 持续固定时间调用
        /// </summary>
        public void ChannelThink()
        {
            
        }
        /// <summary>
        /// 引导结束
        /// </summary>
        public void ChannelFinish()
        {
            
        }
    }
}
