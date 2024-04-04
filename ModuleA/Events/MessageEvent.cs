using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.Events
{
    /// <summary>
    /// 서로 다른 뷰끼리 데이터를 주고 받을 때 사용하는 이벤트 정의
    /// </summary>
    public class MessageEvent : PubSubEvent<string>
    {
    }
}
