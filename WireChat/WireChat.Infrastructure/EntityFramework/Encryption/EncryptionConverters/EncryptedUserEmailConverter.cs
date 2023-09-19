using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;

namespace WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters
{
    //Converts a UserEmail value object into a string, encrypts that string, and then provides the functionality
    //to decrypt it back into a UserEmail value object.
    internal sealed class EncryptedUserEmailConverter : ValueConverter<UserEmail, string>
    {
        /// <param name="encryptionProvider">An instance of IEncryptionProvider used for encryption and decryption operations.</param>
        /// <param name="mappingHints">Optional mapping hints for the value converter.</param>
        public EncryptedUserEmailConverter(IEncryptionProvider encryptionProvider, ConverterMappingHints mappingHints = null)
            : base(
                  v => ConvertToString(v, encryptionProvider), // Encrypts the UserEmail value object.
                  v => ConvertToUserEmail(v, encryptionProvider), // Decrypts the encrypted string representation of the UserEmail value object.
                  mappingHints)
        {
        }

        #region DESCRIPTION

        // Converts an string value to its encrypted string representation.
        /// <param name="userEmail">The userEmail to convert and encrypt.</param>
        /// <param name="encryptionProvider">The encryption provider used to encrypt the string.</param>
        /// <returns>The encrypted string representation of the userEmail.</returns>

        #endregion
        private static string ConvertToString(string userEmail, IEncryptionProvider encryptionProvider)
        {
            // Encrypt the string representation of the UserEmail value object.
            string encryptedValue = encryptionProvider.Encrypt(userEmail);

            return encryptedValue;
        }

        #region DESCRIPTION

        // Converts an encrypted string representation of userEmail to UserEmail value object.
        /// <param name="value">The encrypted string representation of the userEmail to decrypt and convert.</param>
        /// <param name="encryptionProvider">The encryption provider used to decrypt the string.</param>
        /// <returns>The decrypted UserEmail value object.</returns>

        #endregion
        private static UserEmail ConvertToUserEmail(string value, IEncryptionProvider encryptionProvider)
        {
            // Decrypt the string representation of the userEmail.
            string decryptedValue = encryptionProvider.Decrypt(value);

            // Convert the string to UserEmail value object.
            return new UserEmail(decryptedValue);
        }
    }
}
