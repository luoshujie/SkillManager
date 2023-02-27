using Skill.Enum;

namespace Skill
{
    /// <summary>
    /// 主动技能
    /// </summary>
    public class GeneralAbilitySkill : SkillBase
    {
        /// <summary>
        /// 技能目标类型
        /// </summary>
        public SkillTargetTypeEnum skillTargetTypeEnum;

        /// <summary>
        /// 前摇时长
        /// </summary>
        public float frontPoint;
        /// <summary>
        /// 后摇时长
        /// </summary>
        public float backPoint;
        /// <summary>
        /// 技能开始
        /// </summary>
        public void OnAbilityStart()
        {
            
        }

        /// <summary>
        /// 结束
        /// </summary>
        public void Finish()
        {
            
        }
    }
}
