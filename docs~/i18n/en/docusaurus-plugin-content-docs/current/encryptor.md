---
sidebar_position: 3
---

# Encryptor

The `Encryptor` class compresses data with Gzip and encrypts it with **AES-256-GCM** (authenticated encryption). All methods are static.

The key is internally derived with SHA-256, so it can be any length.

::: warning Incompatibility with v1.0.0
v1.1.0+ uses AES-GCM. Data encrypted with v1.0.0 (AES-CBC) cannot be decrypted with this version.
:::

## Output format

```
[ Nonce: 12 bytes ][ Auth Tag: 16 bytes ][ Ciphertext ]
```

The nonce is randomly generated on every call, so encrypting the same data twice always produces different output.

---

## Encrypt

```csharp
static byte[] Encrypt(string text, string key)
static byte[] Encrypt(byte[] bytes, string key)
```

Returns compressed + encrypted raw bytes.

| Parameter | Type | Description |
|-----------|------|-------------|
| `text` / `bytes` | `string` / `byte[]` | Data to encrypt |
| `key` | `string` | Secret key (any length) |

```csharp
byte[] result = Encryptor.Encrypt("Hello World", "my-key");
```

---

## EncryptToString

```csharp
static string EncryptToString(string text, string key)
static string EncryptToString(byte[] bytes, string key)
```

Same as `Encrypt` but returns a Base64-encoded string. Suitable for `PlayerPrefs` or JSON serialization.

```csharp
string result = Encryptor.EncryptToString("Hello World", "my-key");
PlayerPrefs.SetString("Data", result);
```

---

## Decrypt

```csharp
static byte[] Decrypt(string text, string key)
static byte[] Decrypt(byte[] bytes, string key)
```

Decrypts and decompresses the data. The `string` overload decodes from Base64 first.

Throws `CryptographicException` if the key is incorrect or the data has been modified.

```csharp
byte[] result = Encryptor.Decrypt(encryptedBytes, "my-key");
```

---

## DecryptToString

```csharp
static string DecryptToString(string text, string key)
static string DecryptToString(byte[] bytes, string key)
```

Decrypts, decompresses, and returns a UTF-8 string.

```csharp
string json = Encryptor.DecryptToString(PlayerPrefs.GetString("Data"), "my-key");
```
