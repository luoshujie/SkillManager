using System.Collections.Generic;

namespace Fsm
{
    public class FsmSystem
    {
        private FsmStatusBase curStatus;
        private Dictionary<FsmStatusTypeEnum,FsmStatusBase>fsmStatusDic = new Dictionary<FsmStatusTypeEnum, FsmStatusBase>();
        public void Init()
        {
        }

        public void ChangeStatus(FsmStatusTypeEnum statusTypeEnum)
        {
            if (curStatus != null && curStatus.FsmStatusTypeEnum == statusTypeEnum)
            {
                return;
            }

            curStatus?.Leave();
            curStatus = fsmStatusDic[statusTypeEnum];
            curStatus.Enter();
        }

        public void Update()
        {
            if (curStatus != null)
            {
                curStatus.Update();
            }
        }
        
        public void Destroy()
        {
            if (fsmStatusDic!= null)
            {
                foreach (var status in fsmStatusDic.Values)
                {
                    status.Destroy();
                }
            }

            curStatus = null;
        }
    }
}
