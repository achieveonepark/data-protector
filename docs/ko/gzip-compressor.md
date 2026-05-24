# GzipCompressor

`GzipCompressor` 클래스는 독립적인 Gzip 압축/해제 기능을 제공합니다. 모든 메서드는 정적(static)입니다.

::: tip
`Encryptor` 클래스는 이미 내부적으로 압축을 수행합니다. 암호화 없이 압축만 필요한 경우에 사용하세요.
:::

---

## Compress

```csharp
static byte[] Compress(byte[] data)
static byte[] Compress(string text)
```

`CompressionLevel.Optimal`로 데이터를 압축하고 raw bytes를 반환합니다.

```csharp
byte[] compressed = GzipCompressor.Compress("large json string...");
```

---

## CompressToString

```csharp
static string CompressToString(byte[] data)
static string CompressToString(string text)
```

데이터를 압축하고 Base64 문자열로 반환합니다.

```csharp
string compressed = GzipCompressor.CompressToString(rawBytes);
```

---

## Decompress

```csharp
static byte[] Decompress(byte[] data)
static byte[] Decompress(string text)
```

Gzip 데이터의 압축을 해제합니다. `string` 오버로드는 Base64를 먼저 디코딩합니다.

```csharp
byte[] original = GzipCompressor.Decompress(compressed);
```

---

## DecompressToString

```csharp
static string DecompressToString(byte[] data)
static string DecompressToString(string text)
```

압축을 해제하고 UTF-8 문자열로 반환합니다.

```csharp
string json = GzipCompressor.DecompressToString(compressed);
```
