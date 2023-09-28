
using System.Security.Cryptography;
using System.Text;

namespace WireChat.Application.Extensions
{
    public static class GuidExtensions
    {
        public static Guid GenerateChatId(this Guid senderId, Guid receiverId)
        {
            // Combine the GUIDs into a single byte array
            byte[] combinedGuids = senderId.ToByteArray().Concat(receiverId.ToByteArray()).ToArray();

            // Generate a hash from the combined byte array
            using (var sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(combinedGuids);

                // Create a new GUID from the first 16 bytes of the hash
                return new Guid(hash.Take(16).ToArray());
            }
        }

        public static Guid GenerateChatId(this Guid userId, string groupName)
        {
            // Convert UserId to bytes
            byte[] userIdBytes = userId.ToByteArray();

            // Create hash from GroupName
            using (var sha256 = SHA256.Create())
            {
                byte[] groupNameHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(groupName));

                // Combine userId bytes and groupName hash into a single byte array
                byte[] combined = new byte[userIdBytes.Length + groupNameHash.Length];
                Buffer.BlockCopy(userIdBytes, 0, combined, 0, userIdBytes.Length);
                Buffer.BlockCopy(groupNameHash, 0, combined, userIdBytes.Length, groupNameHash.Length);

                // Create a Guid from the first 16 bytes of the hash
                return new Guid(sha256.ComputeHash(combined).Take(16).ToArray());
            }
        }
    }
}
