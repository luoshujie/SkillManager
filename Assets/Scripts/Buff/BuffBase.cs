using EventSystem;
using EventSystem.Enum;
using Skill;

namespace Buff
{
    /// <summary>
    /// buff基类
    /// </summary>
    public class BuffBase
    {
        /// <summary>
        /// Buff类型Id
        /// </summary>
        public int BuffTypeId;
        /// <summary>
        /// Buff施加者
        /// </summary>
        public object Caster;
        /// <summary>
        /// Buff当前挂载的目标
        /// </summary>
        public object Parent;
        /// <summary>
        /// Buff由哪个技能创建
        /// </summary>
        public SkillBase Ability;
        /// <summary>
        /// 层数
        /// </summary>
        public int BuffLayer;
        /// <summary>
        /// 等级
        /// </summary>
        public int BuffLevel;
        /// <summary>
        /// 时长
        /// </summary>
        public float BuffDuration;
        public string BuffTag;
        /// <summary>
        /// 免疫BuffTag
        /// </summary>
        public string BuffImmuneTag;
        /// <summary>
        /// Buff创建时的一些相关上下文数据
        /// </summary>
        public object Context;

        public void BuffAwake()
        {
            SkillEventSystemManager.instance.ExecuteEvent(SkillSystemEventEnum.OnBuffAwake,null);
        }
    }
}
