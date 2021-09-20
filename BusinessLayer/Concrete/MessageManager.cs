using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message Belong(int writerID, int messageID)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessage(Message message)
        {
            message.MessageStatus = false;
            _messageDal.Update(message);
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> ListInbox(string mail)
        {
            return _messageDal.List(x => x.RecieverMail == mail && x.MessageStatus);
        }

        public List<Message> ListSendbox(int id)
        {
            return _messageDal.List(x => x.WriterID == id && x.MessageStatus);
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
