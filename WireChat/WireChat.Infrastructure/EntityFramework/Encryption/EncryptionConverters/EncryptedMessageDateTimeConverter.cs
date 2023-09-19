using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;

namespace WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters
{
    //Converts a MessageDateTime value object into a string, encrypts that string, and then provides the functionality
    //to decrypt it back into a MessageDateTime value object.
    internal sealed class EncryptedMessageDateTimeConverter : ValueConverter<MessageDateTime, string>
    {
        public EncryptedMessageDateTimeConverter(IEncryptionProvider encryptionProvider, ConverterMappingHints mappingHints = null)
             : base(
                  v => ConvertToString(v, encryptionProvider), // Encrypts the MessageDateTime value object.
                  v => ConvertToMessageDateTime(v, encryptionProvider), // Decrypts the encrypted string representation of the MessageDateTime value object.
                  mappingHints)
        {
        }

        #region DESCRIPTION

        // Converts an DateTimeOffset value to its encrypted string representation.
        /// <param name="messageDateTime">The messageDateTime to convert and encrypt.</param>
        /// <param name="encryptionProvider">The encryption provider used to encrypt the string.</param>
        /// <returns>The encrypted string representation of the messageDateTime.</returns>

        #endregion
        private static string ConvertToString(DateTimeOffset messageDateTime, IEncryptionProvider encryptionProvider)
        {
            // Encrypt the DateTimeOffset representation of the MessageDateTime value object.
            string encryptedValue = encryptionProvider.Encrypt(messageDateTime.ToString("o"));

            return encryptedValue;
        }

        #region DESCRIPTION

        // Converts an encrypted string representation of messageDateTime to MessageDateTime value object.
        /// <param name="value">The encrypted string representation of the messageDateTime to decrypt and convert.</param>
        /// <param name="encryptionProvider">The encryption provider used to decrypt the string.</param>
        /// <returns>The decrypted MessageDateTime value object.</returns>

        #endregion
        private static MessageDateTime ConvertToMessageDateTime(string value, IEncryptionProvider encryptionProvider)
        {
            // Decrypt the string representation of the messageDateTime.
            string decryptedValue = encryptionProvider.Decrypt(value);

            // Convert the string to MessageDateTime value object.
            return new MessageDateTime(DateTimeOffset.Parse(decryptedValue));
        }
    }
}
