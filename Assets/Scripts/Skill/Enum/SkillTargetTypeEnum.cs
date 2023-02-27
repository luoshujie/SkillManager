namespace Skill.Enum
{
    /// <summary>
    /// 技能释放时不需要目标即可释放（如群疗，踩地板技能）
    /// 技能释放时需要选定目标（单体指向性技能）
    /// 技能释放时需要以指定地点为目标（常用于AOE技能）
    /// </summary>
    public enum SkillTargetTypeEnum
    {
        /// <summary>
        /// 不需要目标
        /// </summary>
        NoneTargetType,
        /// <summary>
        /// 选定目标
        /// </summary>
        NeedTargetType,
        /// <summary>
        /// 需要以指定地点
        /// </summary>
        NeedPlaceType
    }
}
