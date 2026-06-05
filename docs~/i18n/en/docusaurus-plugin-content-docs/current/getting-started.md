---
sidebar_position: 2
---

# Getting Started

## Requirements

- Unity **2022.3** or later
- .NET Standard **2.1**

## Installation

### Via Unity Package Manager (git URL)

Open the Package Manager window, click **+ → Add package from git URL**, and enter:

```
https://github.com/achieveonepark/data-protector.git
```

Or add it directly to your `Packages/manifest.json`:

```json
{
  "dependencies": {
    "com.achieve.data-protector": "https://github.com/achieveonepark/data-protector.git"
  }
}
```

## Quick Start

### Encrypting a save file

```csharp
using Achieve.DataProtector;

string json = "{\"score\": 9999, \"level\": 42}";
string key  = "my-secret-key";

// Encrypt — returns raw bytes
byte[] encrypted = Encryptor.Encrypt(json, key);

// Encrypt to Base64 string (useful for PlayerPrefs)
string base64 = Encryptor.EncryptToString(json, key);
PlayerPrefs.SetString("Save", base64);

// Decrypt back to string
string loaded  = PlayerPrefs.GetString("Save");
string decoded = Encryptor.DecryptToString(loaded, key);
```

### Verifying data integrity

```csharp
using Achieve.DataProtector;

byte[] data = System.IO.File.ReadAllBytes("save.dat");
byte[] hash = System.IO.File.ReadAllBytes("save.dat.hash");

if (!HashChecker.ValidateHash(data, hash))
{
    Debug.LogError("Save data has been tampered!");
}
```

### Compression without encryption

```csharp
using Achieve.DataProtector;

byte[] compressed   = GzipCompressor.Compress(largeJsonString);
string decompressed = GzipCompressor.DecompressToString(compressed);
```
