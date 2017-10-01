using Nsc.Wu.Common.Push;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nsc.Wu.BLL.Service
{
    public class CommunicationService
    {
        public void SendPush(string deviceId, string action, string platform,string from,string to,string data)
        {
            switch(platform)
            {
                case "IOS":
                    sendIOS(action, deviceId,from,to,data);
                    break;
                default:
                    sendAndroid(action, deviceId, from, to, data);
                    break;

            }
        }
        public void sendIOS(string action,string deviceId, string from, string to, string data)
        {
            string message = "";
            string type = "";
            PushApi push = new PushApi();
            switch (action)
            {
                case "request":
                    message = from + " wants to participate to your party " + data;
                    type = "REQUEST_RECEIVED";
                    break;
                case "invite":
                    message = from + " sent you an invitation to his party " + data;
                    type = "INVITATION_RECEIVED";
                    break;
                case "acceptrequest":
                    message = $"{from} has accepted your request to his party {data}";
                    type = "REQUEST_ACCEPTED";
                    break;

                case "acceptinvite":
                    message = $"{from} has accepted your invitation to his party {data}";
                    type = "INVITATION_ACCEPTED";
                    break;
            }
            push.IOSPush(deviceId,type, message);
        }
        public void sendAndroid(string action, string deviceId, string from, string to, string data)
        {
            string type = "";
            string message = "";
            PushApi push = new PushApi();
            switch (action)
            {
                case "request":
                    message = from + " wants to participate to your party " + data;
                    type = "REQUEST_RECEIVED";
                    break;
                case "invite":
                    message = from + " sent you an invitation to his party " + data;
                    type = "INVITATION_RECEIVED";
                    break;
                case "acceptrequest":
                    message = $"{from} has accepted your request to his party {data}";
                    type = "REQUEST_ACCEPTED";
                    break;

                case "acceptinvite":
                    message = $"{from} has accepted your invitation to his party {data}";
                    type = "INVITATION_ACCEPTED";
                    break;
            }
            push.AndroidPush(deviceId,type, message);
        }
    }
}
