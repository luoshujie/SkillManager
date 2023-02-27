namespace Skill.Enum
{
    /// <summary>
    //被动类型的技能(PassiveAblity)
    //主动施法技能（最常见的通用主动施法类技能，如普通攻击等一次性触发效果类技能（GeneralAbility），引导类持续施法技能(ChannelAbility)，如大法师暴风雪）
    //开关类技能（(ToggleAbility)点击技能开启/关闭效果，类似于恶魔猎手献祭）
    //激活类技能（(ActivateAbility)点下右键激活/停止，一般是给普通攻击附加特殊效果）
    /// </summary>
    public enum SkillTypeEnum
    {
        /// <summary>
        /// 被动类型的技能
        /// </summary>
        PassiveAblitySkillType,
        /// <summary>
        /// 主动施法技能
        /// </summary>
        GeneralAbilitySkillType,
        /// <summary>
        /// 开关类技能
        /// </summary>
        ToggleAbilitySkillType,
        /// <summary>
        /// 激活类技能
        /// </summary>
        ActivateAbilitySkillType
    }
}
