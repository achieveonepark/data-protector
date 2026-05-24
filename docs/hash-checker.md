# HashChecker

The `HashChecker` class computes and validates SHA-256 hashes. All methods are static.

`ValidateHash` uses `CryptographicOperations.FixedTimeEquals` for constant-time comparison, preventing timing attacks.

---

## ComputeHash

```csharp
static byte[] ComputeHash(byte[] data)
static string ComputeHash(string input)
```

Computes a SHA-256 hash.

- `byte[]` overload — returns the raw 32-byte hash.
- `string` overload — returns a lowercase hex string (e.g. `"a3f5d2..."`).

```csharp
byte[] hash = HashChecker.ComputeHash(fileBytes);
string hex  = HashChecker.ComputeHash("hello world");
```

---

## ValidateHash

```csharp
static bool ValidateHash(byte[] data, byte[] expectedHash)
```

Computes the SHA-256 hash of `data` and compares it to `expectedHash` using constant-time comparison. Returns `true` if the hashes match.

| Parameter | Type | Description |
|-----------|------|-------------|
| `data` | `byte[]` | Data to verify |
| `expectedHash` | `byte[]` | Previously stored 32-byte hash |

```csharp
byte[] data       = System.IO.File.ReadAllBytes("save.dat");
byte[] storedHash = System.IO.File.ReadAllBytes("save.hash");

bool isValid = HashChecker.ValidateHash(data, storedHash);
```

::: tip
Store the hash separately from the data (e.g. a different file or server-side) so tampering is detectable.
:::
