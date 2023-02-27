using Skill;
using UnityEngine;

namespace Projectile
{
    /// <summary>
    /// 子弹管理器
    /// </summary>
    public class ProjectileManager
    {
        public static ProjectileManager instance = new ProjectileManager();

        /// <summary>
        /// 创建追踪子弹
        /// </summary>
        /// <param name="Owner">表示子弹的创建者</param>
        /// <param name="Ability">表示子弹关联的技能</param>
        /// <param name="FromPosition">子弹的出发地点</param>
        /// <param name="Target">子弹追踪的目标</param>
        /// <param name="Speed">子弹的飞行速率</param>
        /// <returns></returns>
        public TrackingProjectile CreateTrackingProjectile(object Owner,SkillBase Ability,Vector3 FromPosition,object Target,float Speed)
        {
            return null;
        }
        
        /// <summary>
        /// 创建线性子弹
        /// </summary>
        /// <param name="Owner">表示子弹的创建者</param>
        /// <param name="Ability">表示子弹关联的技能</param>
        /// <param name="FromPosition">子弹的出发地点</param>
        /// <param name="Velocity">子弹的飞行速度和方向</param>
        /// <param name="StartWidth">（等腰梯形检测盒）起点宽度</param>
        /// <param name="EndWith">（等腰梯形检测盒）终点宽度</param>
        /// <param name="Distance">（等腰梯形检测盒）飞行距离</param>
        /// <param name="FilterTargetInfo">子弹筛选目标信息</param>
        /// <returns></returns>
        public LinearProjectile CreateLinearProjectile(object Owner,SkillBase Ability,Vector3 FromPosition,Vector3 Velocity,float StartWidth,float EndWith,float Distance,object FilterTargetInfo)
        {
            return null;
        }
    }
}
