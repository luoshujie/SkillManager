using System;
using System.Collections.Generic;
using EventSystem.Enum;
using UnityEngine;

namespace EventSystem
{
    /// <summary>
    /// 消息监听系统
    /// </summary>
    public class SkillEventSystemManager
    {
        
        public static SkillEventSystemManager instance = new SkillEventSystemManager();
        private Dictionary<SkillSystemEventEnum, Dictionary<object,Action<object>>> eventActDic = new Dictionary<SkillSystemEventEnum, Dictionary<object, Action<object>>>();
        public void AddEvent(SkillSystemEventEnum enumType,Action<object> act,object obj)
        {
            if (!eventActDic.ContainsKey(enumType))
            {
                eventActDic.Add(enumType,new Dictionary<object, Action<object>>());
            }

            if (!eventActDic[enumType].ContainsKey(obj))
            {
                eventActDic[enumType].Add(obj,act);
            }
        }

        public void RemoveEvent(object obj, SkillSystemEventEnum enumType)
        {
            if (eventActDic != null && eventActDic.ContainsKey(enumType) && eventActDic[enumType].ContainsKey(obj))
            {
                eventActDic[enumType].Remove(obj);
            }
        }

        public void ExecuteEvent(SkillSystemEventEnum enumType, object obj)
        {
            if (eventActDic != null && eventActDic.ContainsKey(enumType))
            {
                Dictionary<object, Action<object>> dic = eventActDic[enumType];
                foreach (Action<object> action in dic.Values)
                {
                    action?.Invoke(obj);
                }
            }
        }
    }
}
