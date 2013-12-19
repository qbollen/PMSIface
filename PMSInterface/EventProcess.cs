using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMSInterface
{
    class EventPublisher
    {
        public delegate void UpdateWorkstationViewDelegate(string keycoder,string workstationName);
        public event UpdateWorkstationViewDelegate UpdateWorkstationViewEvent;
        public EventPublisher()
        {

        }

        public void Arouse(string keycoder, string workstation)
        {
            if (UpdateWorkstationViewEvent != null)
            {
                this.UpdateWorkstationViewEvent(keycoder, workstation);
            }
        }
    }

    class EventReader
    {
        private static int count = 0;
        private int currCnt;
        public EventReader(EventPublisher publisher)
        {
            count++;
            currCnt = count;
            publisher.UpdateWorkstationViewEvent +=
                new EventPublisher.UpdateWorkstationViewDelegate(UpdateView);
        }

        public delegate void addDelegate(int num, string keycoder,string workstationName);
        private void UpdateView(string keycoder,string workstationName)
        {
            FrmWorkStation frmWorkStation;
            if ((frmWorkStation = FrmMain.frmWorkstation) == null)
                return;
            //frmWorkStation.add(currCnt, keycoder, workstationName);
            //frmWorkStation.addMethod(currCnt, keycoder, workstationName);
            frmWorkStation.addMethod(currCnt, keycoder, workstationName);
        }
    }

}
