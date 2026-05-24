# Encryptor

`Encryptor` 클래스는 데이터를 Gzip으로 압축한 후 **AES-256-GCM** 인증 암호화로 처리합니다. 모든 메서드는 정적(static)입니다.

키는 내부적으로 SHA-256으로 유도되므로 임의 길이의 문자열을 사용할 수 있습니다.

::: warning v1.0.0과의 비호환
v1.1.0부터는 AES-GCM을 사용합니다. v1.0.0(AES-CBC)으로 암호화된 데이터는 이 버전에서 복호화할 수 없습니다.
:::

## 출력 포맷

```
[ Nonce: 12 bytes ][ Auth Tag: 16 bytes ][ Ciphertext ]
```

Nonce는 매 호출마다 새로 생성되므로 동일한 데이터를 두 번 암호화해도 결과가 항상 다릅니다.

---

## Encrypt

```csharp
static byte[] Encrypt(string text, string key)
static byte[] Encrypt(byte[] bytes, string key)
```

압축 후 암호화된 raw bytes를 반환합니다.

| 파라미터 | 타입 | 설명 |
|---------|------|------|
| `text` / `bytes` | `string` / `byte[]` | 암호화할 데이터 |
| `key` | `string` | 비밀 키 (임의 길이) |

```csharp
byte[] result = Encryptor.Encrypt("Hello World", "my-key");
```

---

## EncryptToString

```csharp
static string EncryptToString(string text, string key)
static string EncryptToString(byte[] bytes, string key)
```

`Encrypt`와 동일하지만 Base64 문자열로 반환합니다. `PlayerPrefs`나 JSON 직렬화에 적합합니다.

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

데이터를 복호화하고 압축을 해제합니다. `string` 오버로드는 Base64를 먼저 디코딩합니다.

키가 잘못되었거나 데이터가 변조된 경우 `CryptographicException`을 발생시킵니다.

```csharp
byte[] result = Encryptor.Decrypt(encryptedBytes, "my-key");
```

---

## DecryptToString

```csharp
static string DecryptToString(string text, string key)
static string DecryptToString(byte[] bytes, string key)
```

복호화, 압축 해제 후 UTF-8 문자열로 반환합니다.

```csharp
string json = Encryptor.DecryptToString(PlayerPrefs.GetString("Data"), "my-key");
```
