using ModuleA.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleA.ViewModels
{
    public class ViewBViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="eventAggregator">서로 다른 뷰끼리 데이터를 주고 받을때 사용</param>
        public ViewBViewModel(IEventAggregator eventAggregator)
        {
            Message = "View B";
            //eventAggregator -> 여기서는 수신할 함수 등록용도로 사용
            eventAggregator.GetEvent<MessageEvent>().Subscribe(MessageReceived);
        }

        private void MessageReceived(string payload)
        {
            Message = payload;
        }
    }
}
