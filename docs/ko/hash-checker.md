# HashChecker

`HashChecker` 클래스는 SHA-256 해시를 계산하고 검증합니다. 모든 메서드는 정적(static)입니다.

`ValidateHash`는 타이밍 공격을 방지하기 위해 `CryptographicOperations.FixedTimeEquals`(상수 시간 비교)를 사용합니다.

---

## ComputeHash

```csharp
static byte[] ComputeHash(byte[] data)
static string ComputeHash(string input)
```

SHA-256 해시를 계산합니다.

- `byte[]` 오버로드 — 32바이트 raw 해시를 반환합니다.
- `string` 오버로드 — 소문자 16진수 문자열을 반환합니다 (예: `"a3f5d2..."`).

```csharp
byte[] hash = HashChecker.ComputeHash(fileBytes);
string hex  = HashChecker.ComputeHash("hello world");
```

---

## ValidateHash

```csharp
static bool ValidateHash(byte[] data, byte[] expectedHash)
```

`data`의 SHA-256 해시를 계산하고 `expectedHash`와 상수 시간 비교로 검증합니다. 해시가 일치하면 `true`를 반환합니다.

| 파라미터 | 타입 | 설명 |
|---------|------|------|
| `data` | `byte[]` | 검증할 데이터 |
| `expectedHash` | `byte[]` | 미리 저장해 둔 32바이트 해시 |

```csharp
byte[] data       = System.IO.File.ReadAllBytes("save.dat");
byte[] storedHash = System.IO.File.ReadAllBytes("save.hash");

bool isValid = HashChecker.ValidateHash(data, storedHash);
```

::: tip
해시를 데이터와 별도로 저장하세요 (예: 별도 파일 또는 서버). 그래야 변조를 감지할 수 있습니다.
:::
