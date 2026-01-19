# Easy.Net.Common

Common utilities for .NET 10 applications.

## Features

### Result Pattern
A robust implementation of the Result pattern for handling operation outcomes without exceptions.

```csharp
// Success case
var result = OpeResult<User>.Success(user);

// Failure case
var result = OpeResult<User>.Failure(ex, "User not found", HttpStatusCode.NotFound);

// Usage
if (result.IsSuccess)
{
    var user = result.Value;
}
else
{
    var error = result.Error;
    Console.WriteLine(error.FriendlyMessage);
}
```

### Cryptography Helpers
AES-256-GCM encryption/decryption utilities using BouncyCastle.

```csharp
// Generate key and nonce
var keyNonce = Cryptor.KeyNonce();

// Encrypt
byte[] encrypted = Cryptor.Encrypt(plainTextBytes, keyNonce);

// Decrypt
byte[] decrypted = Cryptor.Decrypt(encrypted, keyNonce);
```

### Password-Based Key Derivation
Secure key derivation from passwords using PBKDF2.

```csharp
// Create a new key from password
var keySalt = GetKeyFromPasswordHelper.CreateKey("myPassword");

// Restore key from password and salt
byte[] key = GetKeyFromPasswordHelper.RestoreKey("myPassword", savedSalt);
```

## Installation

```bash
dotnet add package Easy.Net.Common
```

## License

MIT
