using Laughy.Models.UiModels;
using Syncfusion.XForms.Chat;

namespace Laughy
{
    public class MessageConverter : IChatMessageConverter
    {
        //Methods
        public IMessage ConvertToChatMessage(object data, SfChat chat)
        {
            var message = new TextMessage();
            var item = data as MessageUiModel;

            message.Text = item.Text;
            message.Author = item.User;
            message.Data = item;

            return message;
        }

        public object ConvertToData(object chatMessage, SfChat chat)
        {
            var message = new MessageUiModel();
            var item = chatMessage as TextMessage;

            message.Text = item.Text;
            message.User = chat.CurrentUser;

            return message;
        }
    }
}
