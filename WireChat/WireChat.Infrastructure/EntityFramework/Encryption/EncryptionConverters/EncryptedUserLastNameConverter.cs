using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;

namespace WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters
{
    //Converts a UserLastName value object into a string, encrypts that string, and then provides the functionality
    //to decrypt it back into a UserLastName value object.
    internal sealed class EncryptedUserLastNameConverter : ValueConverter<UserLastName, string>
    {
        /// <param name="encryptionProvider">An instance of IEncryptionProvider used for encryption and decryption operations.</param>
        /// <param name="mappingHints">Optional mapping hints for the value converter.</param>
        public EncryptedUserLastNameConverter(IEncryptionProvider encryptionProvider, ConverterMappingHints mappingHints = null)
            : base(
                  v => ConvertToString(v, encryptionProvider), // Encrypts the UserLastName value object.
                  v => ConvertToUserLastName(v, encryptionProvider), // Decrypts the encrypted string representation of the UserLastName value object.
                  mappingHints)
        {
        }

        #region DESCRIPTION

        // Converts an string value to its encrypted string representation.
        /// <param name="userLastName">The userLastName to convert and encrypt.</param>
        /// <param name="encryptionProvider">The encryption provider used to encrypt the string.</param>
        /// <returns>The encrypted string representation of the userLastName.</returns>

        #endregion
        private static string ConvertToString(string userLastName, IEncryptionProvider encryptionProvider)
        {
            // Encrypt the string representation of the UserLastName value object.
            string encryptedValue = encryptionProvider.Encrypt(userLastName);

            return encryptedValue;
        }

        #region DESCRIPTION

        // Converts an encrypted string representation of userLastName to UserLastName value object.
        /// <param name="value">The encrypted string representation of the userLastName to decrypt and convert.</param>
        /// <param name="encryptionProvider">The encryption provider used to decrypt the string.</param>
        /// <returns>The decrypted UserLastName value object.</returns>

        #endregion
        private static UserLastName ConvertToUserLastName(string value, IEncryptionProvider encryptionProvider)
        {
            // Decrypt the string representation of the userLastName.
            string decryptedValue = encryptionProvider.Decrypt(value);

            // Convert the string to UserLastName value object.
            return new UserLastName(decryptedValue);
        }
    }
}
