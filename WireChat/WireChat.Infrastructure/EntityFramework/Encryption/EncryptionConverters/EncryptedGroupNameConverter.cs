using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;

namespace WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters
{
    internal sealed class EncryptedGroupNameConverter : ValueConverter<GroupName, string>
    {
        public EncryptedGroupNameConverter(IEncryptionProvider encryptionProvider, ConverterMappingHints mappingHints = null)
             : base(
                  v => ConvertToString(v, encryptionProvider), // Encrypts the GroupName value object.
                  v => ConvertToGroupName(v, encryptionProvider), // Decrypts the encrypted string representation of the GroupName value object.
                  mappingHints)
        {
        }

        #region DESCRIPTION

        // Converts an string value to its encrypted representation.
        /// <param name="groupName">The groupName to convert and encrypt.</param>
        /// <param name="encryptionProvider">The encryption provider used to encrypt the string.</param>
        /// <returns>The encrypted string representation of the groupName.</returns>

        #endregion
        private static string ConvertToString(string groupName, IEncryptionProvider encryptionProvider)
        {
            // Encrypt the string representation of the GroupName value object.
            string encryptedValue = encryptionProvider.Encrypt(groupName);

            return encryptedValue;
        }

        #region DESCRIPTION

        // Converts an encrypted string representation of message to GroupName value object.
        /// <param name="value">The encrypted string representation of the groupName to decrypt and convert.</param>
        /// <param name="encryptionProvider">The encryption provider used to decrypt the string.</param>
        /// <returns>The decrypted GroupName value object.</returns>

        #endregion
        private static GroupName ConvertToGroupName(string value, IEncryptionProvider encryptionProvider)
        {
            // Decrypt the string representation of the groupName.
            string decryptedValue = encryptionProvider.Decrypt(value);

            // Convert the string to GroupName value object.
            return new GroupName(decryptedValue);
        }
    }
}
