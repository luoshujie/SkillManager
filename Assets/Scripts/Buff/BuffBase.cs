using Buff.Enum;
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
        /// buff类型
        /// </summary>
        public BuffTypeEnum BuffTypeEnum;
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

        /// <summary>
        /// 触发间隔时间
        /// </summary>
        public float StartIntervalThink;
       
        
        /// <summary>
        /// buff开始生效（加入到buff容器后）
        /// </summary>
        public void OnBuffStart()
        {
        }
        
        /// <summary>
        /// 当Buff添加时存在相同类型且Caster相等的时候，Buff执行刷新流程（更新Buff层数，等级，持续时间等数据）
        /// </summary>
        public void OnBuffRefresh()
        {
        
        }
        /// <summary>
        /// 当Buff销毁前（还未从Buff容器中移除
        /// </summary>
        public void OnBuffRemove()
        {
            
        }
        /// <summary>
        /// 当Buff销毁后（已从Buff容器中移除）
        /// </summary>
        public void OnBuffDestroy()
        {
            
        }

        /// <summary>
        /// Buff创建定时器，以触发间隔持续效果
        /// </summary>
        public void OnIntervalThink()
        {
            
        }
    }
}
