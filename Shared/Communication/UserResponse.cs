using LyteChat.Shared.DataTransferObject;


namespace LyteChat.Shared.Communication
{
    public class UserResponse : BaseResponse
    {
        public UserDTO UserDTO { get; private set; }

        private UserResponse(bool success, string message, UserDTO userDTO) : base(success, message)
        {
            UserDTO = userDTO;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="message">Saved message.</param>
        /// <returns>Response.</returns>
        public UserResponse(UserDTO userDTO) : this(true, string.Empty, userDTO)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public UserResponse(string messageString) : this(false, messageString, null)
        { }
    }
}
