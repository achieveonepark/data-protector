---
sidebar_position: 4
---

# GzipCompressor

The `GzipCompressor` class provides standalone Gzip compression and decompression. All methods are static.

::: tip
`Encryptor` already compresses data internally. Use `GzipCompressor` only when you need compression without encryption.
:::

---

## Compress

```csharp
static byte[] Compress(byte[] data)
static byte[] Compress(string text)
```

Compresses data using `CompressionLevel.Optimal` and returns raw bytes.

```csharp
byte[] compressed = GzipCompressor.Compress("large json string...");
```

---

## CompressToString

```csharp
static string CompressToString(byte[] data)
static string CompressToString(string text)
```

Compresses data and returns it as a Base64-encoded string.

```csharp
string compressed = GzipCompressor.CompressToString(rawBytes);
```

---

## Decompress

```csharp
static byte[] Decompress(byte[] data)
static byte[] Decompress(string text)
```

Decompresses Gzip data. The `string` overload decodes from Base64 first.

```csharp
byte[] original = GzipCompressor.Decompress(compressed);
```

---

## DecompressToString

```csharp
static string DecompressToString(byte[] data)
static string DecompressToString(string text)
```

Decompresses Gzip data and returns a UTF-8 string.

```csharp
string json = GzipCompressor.DecompressToString(compressed);
```
