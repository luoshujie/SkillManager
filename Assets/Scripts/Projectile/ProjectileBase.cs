using UnityEngine;

namespace Projectile
{
    /// <summary>
    /// 子弹基类 子弹本身是没有任何特殊逻辑的，它只有位置更新，检查命中目标和是否结束并销毁这几个简单的功能。
    /// </summary>
    public class ProjectileBase
    {
        /// <summary>
        /// 触发计算
        /// </summary>
        /// <param name="projHandle">发出的目标</param>
        /// <param name="hitTarget">命中目标</param>
        /// <param name="hitPosition">命中位置</param>
        public void OnProjectileHit(object projHandle,GameObject hitTarget,Vector3 hitPosition)
        {
            
        }
    }
}
