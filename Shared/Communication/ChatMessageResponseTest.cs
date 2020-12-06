using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Shared.DataTransferObject;


namespace LearnBlazor.Shared.Communication
{
    public class ChatMessageResponseTest: BaseResponse
    {
        public ChatMessageDTO ChatMessageDTO { get; private set; }

        private ChatMessageResponseTest(bool success, string message, ChatMessageDTO chatMessageDTO) : base(success, message)
        {
            ChatMessageDTO = chatMessageDTO;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="message">Saved message.</param>
        /// <returns>Response.</returns>
        public ChatMessageResponseTest(ChatMessageDTO chatMessageDTO) : this(true, string.Empty, chatMessageDTO)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ChatMessageResponseTest(string messageString) : this(false, messageString, null)
        { }
    }
}
