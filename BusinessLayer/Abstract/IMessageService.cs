using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> ListInbox(string mail);
        List<Message> ListSendbox(int id);
        void MessageAdd(Message message);
        Message GetByID(int id);
        void DeleteMessage(Message message);
        void MessageUpdate(Message message);
        Message Belong(int writerID, int messageID);

    }
}
