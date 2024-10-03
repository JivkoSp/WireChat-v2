# Authentication and Authorization

## Choosing .NET Core Identity API for Authentication and Authorization

### The decision to use the .NET Core Identity API for WireChat’s authentication and authorization was made based on several key considerations

- **Comprehensive Built-in Features** The Identity API provides a robust and well-integrated set of features for user management, authentication, and authorization. It supports common requirements like user registration,
  login, password management, role-based access control (RBAC), and claims-based authorization without the need for building these features from scratch. This made it a natural choice for accelerating development
  while ensuring the implementation of industry-standard practices.
- **Security** The Identity API offers out-of-the-box support for secure features such as password hashing, two-factor authentication (2FA), and token-based authentication, ensuring strong protection
  of user accounts. By leveraging Identity's built-in security mechanisms, the risk of introducing vulnerabilities that might arise from custom implementations are minimized.
- Integration with ASP.NET Core Middleware The Identity API integrates seamlessly with ASP.NET Core’s middleware pipeline, allowing for consistent management of authentication across the entire application.
  This design choice also allows us to easily plug in other authentication mechanisms (e.g., OAuth, JWT tokens) if required in the future, providing flexibility as the app evolves.
- Extensibility and Customization While the Identity API provides many default behaviors, it also allows for significant customization, which was important for meeting the specific needs of WireChat. For example:
    - Custom user properties are supported (e.g., profile pictures, status updates).
    - The ability to extend role-based access controls to fit more complex authorization scenarios, like group-specific permissions, aligns well with the application’s growth roadmap.
    - Claims-based authorization and policies were used to implement finer-grained control over what actions users can perform, which is critical in features like blocking/unblocking users or moderating group chats.
- Scalability As WireChat is designed to support a growing user base, scalability was a critical factor. The Identity API, when paired with Entity Framework Core, provides excellent support for handling large datasets.
  The ability to store and manage user accounts, claims, and roles in a relational database (like SQL Server or PostgreSQL) ensures that the authentication and authorization layers will scale with increasing usage.
- Future-Proofing The decision to use .NET Core Identity was also influenced by its flexibility for future enhancements. For instance, while the current implementation supports password authentication
  and two-factor authentication (using QR codes), the system can be easily extended to include OAuth-based logins (e.g., Google, Facebook) or custom external authentication providers without significant
  architectural changes.
- Consistency with .NET Ecosystem WireChat is built using .NET Core, and Identity is the recommended framework for authentication and authorization in this ecosystem.
  By using Identity, we can ensure that we follow best practices and take advantage of security updates and features that are regularly improved by the .NET community and Microsoft.
  This reduces the long-term maintenance burden on the development team.

## Trade-offs Considered

### While the Identity API offers numerous advantages, a few trade-offs were considered

- **Complexity**: In some cases, the built-in functionality of Identity can introduce complexity, especially when customizing certain features like password policies or multi-tenancy.
  However, the trade-off was acceptable due to the strong foundation Identity provides.
- **Learning Curve**: For new developers or those unfamiliar with Identity, there is a learning curve involved in understanding how to extend and customize the API.
  However, the investment in learning Identity was outweighed by its long-term benefits in maintainability and security.

## Hashing user passwords

ASP.NET Core Identity uses the [pbkdf2-sha512](https://www.ietf.org/rfc/rfc2898.txt) algorithm by default for hashing user passwords. PBKDF2 is a widely accepted, secure hashing algorithm that applies a 
cryptographic hash function (typically HMAC-SHA256) multiple times (by default, 10,000 iterations) to a password combined with a unique salt. 
This process makes it computationally expensive to brute-force or crack the password.

### Key aspects of PBKDF2 in ASP.NET Core Identity

- **Salt**: A unique salt is generated for each user and is stored alongside the hashed password in the database. This ensures that the same password will generate different hashes when different salts are used,
  preventing malicious actors from using precomputed rainbow tables.
  This technique is also known as a [rainbow table attack](https://medium.com/@jsquared7/password-cracking-what-is-a-rainbow-table-attack-and-how-to-prevent-it-7904000ffcff);
- **Iterations**: The number of iterations (default is 10,000) is used to make the hashing process slower, which increases the difficulty of brute-forcing passwords;
- **HMAC-SHA256**: The hashing function used within PBKDF2 in Identity is HMAC-SHA256, which is a secure, cryptographic hash function that ensures the integrity of the hash;
- **Compliance with Standards** - PBKDF2 is part of the PKCS #5 standard (also known as [RFC 8018](https://www.rfc-editor.org/rfc/rfc8018)), making it well-documented and widely accepted for password hashing.
   
The password hashing and verification process is handled by the PasswordHasher<TUser> class, which uses PBKDF2 internally to hash passwords when they are created or changed.

### Additional Notes

- **Configurable Iterations**: The number of iterations can be increased in Identity for stronger protection, but this comes at a performance cost, so the configuration should balance security and performance;
- **Backward Compatibility**: If you have an older system that used a different password hashing algorithm (e.g., SHA-1 or SHA-256), ASP.NET Core Identity can support those hashes and gradually migrate users
  to the more secure PBKDF2 algorithm when they log in;
