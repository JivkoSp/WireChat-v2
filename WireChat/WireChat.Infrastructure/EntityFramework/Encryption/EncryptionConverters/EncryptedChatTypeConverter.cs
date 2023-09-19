using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;

namespace WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters
{
    //Converts a ChatType value object into a string, encrypts that string, and then provides the functionality
    //to decrypt it back into a ChatType value object.
    internal sealed class EncryptedChatTypeConverter : ValueConverter<ChatType, string>
    {
        /// <param name="encryptionProvider">An instance of IEncryptionProvider used for encryption and decryption operations.</param>
        /// <param name="mappingHints">Optional mapping hints for the value converter.</param>
        public EncryptedChatTypeConverter(IEncryptionProvider encryptionProvider, ConverterMappingHints mappingHints = null)
            : base(
                  v => ConvertToString(v, encryptionProvider), // Encrypts the ChatType value object.
                  v => ConvertToChatType(v, encryptionProvider), // Decrypts the encrypted string representation of the ChatType value object.
                  mappingHints)
        {
        }

        #region DESCRIPTION

        // Converts an string value to its encrypted representation.
        /// <param name="chatTpe">The chat type to convert and encrypt.</param>
        /// <param name="encryptionProvider">The encryption provider used to encrypt the string.</param>
        /// <returns>The encrypted string representation of the chat type.</returns>

        #endregion
        private static string ConvertToString(string chatTpe, IEncryptionProvider encryptionProvider)
        {
            // Encrypt the string representation of the ChatType value object.
            string encryptedValue = encryptionProvider.Encrypt(chatTpe);

            return encryptedValue;
        }

        #region DESCRIPTION

        // Converts an encrypted string representation of chat type to ChatType value object.
        /// <param name="value">The encrypted string representation of the chat type to decrypt and convert.</param>
        /// <param name="encryptionProvider">The encryption provider used to decrypt the string.</param>
        /// <returns>The decrypted ChatType value object.</returns>

        #endregion
        private static ChatType ConvertToChatType(string value, IEncryptionProvider encryptionProvider)
        {
            // Decrypt the string representation of the chat type.
            string decryptedValue = encryptionProvider.Decrypt(value);

            // Convert the string to ChatType value object.
            return new ChatType(decryptedValue);
        }
    }
}
