using Skill.Enum;

namespace Skill
{
    /// <summary>
    /// 技能基类
    /// </summary>
    public class SkillBase
    {
        /// <summary>
        /// 技能类型
        /// </summary>
        public SkillTypeEnum skillTypeEmun;
        
        /// <summary>
        /// 技能总时长
        /// </summary>
        public float duration;

        /// <summary>
        /// 技能cd
        /// </summary>
        public float skillCoolTime;

        /// <summary>
        /// 技能初始化
        /// </summary>
        public void OnAbilityInit()
        {
            
        }

        /// <summary>
        /// 开始技能冷却倒计时
        /// </summary>
        public void StartCooldown()
        {
            
        }
        
    }
}
