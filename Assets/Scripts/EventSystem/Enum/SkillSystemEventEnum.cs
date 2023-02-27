namespace EventSystem.Enum
{
    public enum SkillSystemEventEnum
    {
        /// <summary>
        /// buff初始化
        /// </summary>
        OnBuffAwake = 0,
        /// <summary>
        /// 主动技能执行成功
        /// </summary>
        OnAbilityExecuted,
        /// <summary>
        /// 己方造成伤害前
        /// </summary>
        OnBeforeGiveDamage,
        /// <summary>
        /// 己方造成伤害后
        /// </summary>
        OnAfterGiveDamage,
        /// <summary>
        /// 敌方造成伤害前
        /// </summary>
        OnBeforeTakeDamage,
        /// <summary>
        /// 敌方造成伤害后
        /// </summary>
        OnAfterTakeDamage,
        /// <summary>
        /// 我方死亡前触发
        /// </summary>
        OnBeforeDead,
        /// <summary>
        /// 我方死亡后触发
        /// </summary>
        OnAfterDead
    }
}
