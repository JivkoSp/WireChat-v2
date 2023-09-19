using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;

namespace WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters
{
    //Converts a Message value object into a string, encrypts that string, and then provides the functionality
    //to decrypt it back into a Message value object.
    internal sealed class EncryptedMessageConverter : ValueConverter<Message, string>
    {
        public EncryptedMessageConverter(IEncryptionProvider encryptionProvider, ConverterMappingHints mappingHints = null)
             : base(
                  v => ConvertToString(v, encryptionProvider), // Encrypts the Message value object.
                  v => ConvertToMessage(v, encryptionProvider), // Decrypts the encrypted string representation of the Message value object.
                  mappingHints)
        {
        }

        #region DESCRIPTION

        // Converts an string value to its encrypted representation.
        /// <param name="message">The message to convert and encrypt.</param>
        /// <param name="encryptionProvider">The encryption provider used to encrypt the string.</param>
        /// <returns>The encrypted string representation of the message.</returns>

        #endregion
        private static string ConvertToString(string message, IEncryptionProvider encryptionProvider)
        {
            // Encrypt the string representation of the Message value object.
            string encryptedValue = encryptionProvider.Encrypt(message);

            return encryptedValue;
        }

        #region DESCRIPTION

        // Converts an encrypted string representation of message to Message value object.
        /// <param name="value">The encrypted string representation of the message to decrypt and convert.</param>
        /// <param name="encryptionProvider">The encryption provider used to decrypt the string.</param>
        /// <returns>The decrypted Message value object.</returns>

        #endregion
        private static Message ConvertToMessage(string value, IEncryptionProvider encryptionProvider)
        {
            // Decrypt the string representation of the message.
            string decryptedValue = encryptionProvider.Decrypt(value);

            // Convert the string to Message value object.
            return new Message(decryptedValue);
        }
    }
}
