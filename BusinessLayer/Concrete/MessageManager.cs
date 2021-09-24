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

        public Message Belong(int messageID,string writerMail)
        {
            return _messageDal.Get(x => x.MessageID == messageID && (x.SenderMail == writerMail||x.RecieverMail==writerMail));
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

        public List<Message> ListInbox(string word,string mail)
        {
            return _messageDal.List(x => x.RecieverMail == mail && (x.MessageContent.Contains(word) || x.Subject.Contains(word))).OrderByDescending(x=>x.MessageID).ToList();
        }
        public List<Message> ListSendbox(string word, string mail)
        {
            return _messageDal.List(x => x.SenderMail == mail && (x.MessageContent.Contains(word) || x.Subject.Contains(word))).OrderByDescending(x => x.MessageID).ToList();
        }

        public List<Message> ListInbox(string mail)
        {
            return _messageDal.List(x => x.RecieverMail == mail && x.MessageStatus);
        }

        public List<Message> ListSendbox(string mail)
        {
            return _messageDal.List(x => x.SenderMail == mail && x.MessageStatus);
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
