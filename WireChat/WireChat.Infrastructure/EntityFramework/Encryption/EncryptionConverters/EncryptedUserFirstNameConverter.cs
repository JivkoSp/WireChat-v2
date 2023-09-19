using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;

namespace WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters
{
    //Converts a UserFirstName value object into a string, encrypts that string, and then provides the functionality
    //to decrypt it back into a UserFirstName value object.
    internal sealed class EncryptedUserFirstNameConverter : ValueConverter<UserFirstName, string>
    {
        /// <param name="encryptionProvider">An instance of IEncryptionProvider used for encryption and decryption operations.</param>
        /// <param name="mappingHints">Optional mapping hints for the value converter.</param>
        public EncryptedUserFirstNameConverter(IEncryptionProvider encryptionProvider, ConverterMappingHints mappingHints = null)
            : base(
                  v => ConvertToString(v, encryptionProvider), // Encrypts the UserFirstName value object.
                  v => ConvertToUserFirstName(v, encryptionProvider), // Decrypts the encrypted string representation of the UserFirstName value object.
                  mappingHints)
        {
        }

        #region DESCRIPTION

        // Converts an string value to its encrypted string representation.
        /// <param name="userFirstName">The userFirstName to convert and encrypt.</param>
        /// <param name="encryptionProvider">The encryption provider used to encrypt the string.</param>
        /// <returns>The encrypted string representation of the userFirstName.</returns>

        #endregion
        private static string ConvertToString(string userFirstName, IEncryptionProvider encryptionProvider)
        {
            // Encrypt the string representation of the UserFirstName value object.
            string encryptedValue = encryptionProvider.Encrypt(userFirstName);

            return encryptedValue;
        }

        #region DESCRIPTION

        // Converts an encrypted string representation of userFirstName to UserFirstName value object.
        /// <param name="value">The encrypted string representation of the userFirstName to decrypt and convert.</param>
        /// <param name="encryptionProvider">The encryption provider used to decrypt the string.</param>
        /// <returns>The decrypted UserFirstName value object.</returns>

        #endregion
        private static UserFirstName ConvertToUserFirstName(string value, IEncryptionProvider encryptionProvider)
        {
            // Decrypt the string representation of the userFirstName.
            string decryptedValue = encryptionProvider.Decrypt(value);

            // Convert the string to UserFirstName value object.
            return new UserFirstName(decryptedValue);
        }
    }
}
