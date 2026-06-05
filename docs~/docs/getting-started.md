---
sidebar_position: 2
---

# 시작하기

## 요구 사항

- Unity **2022.3** 이상
- .NET Standard **2.1**

## 설치

### Unity Package Manager (git URL)

Package Manager 창을 열고 **+ → Add package from git URL**을 클릭한 후 입력하세요:

```
https://github.com/achieveonepark/data-protector.git
```

또는 프로젝트의 `Packages/manifest.json`에 직접 추가하세요:

```json
{
  "dependencies": {
    "com.achieve.data-protector": "https://github.com/achieveonepark/data-protector.git"
  }
}
```

## 빠른 시작

### 세이브 파일 암호화

```csharp
using Achieve.DataProtector;

string json = "{\"score\": 9999, \"level\": 42}";
string key  = "my-secret-key";

// 암호화 — raw bytes 반환
byte[] encrypted = Encryptor.Encrypt(json, key);

// Base64 문자열로 암호화 (PlayerPrefs 저장에 유용)
string base64 = Encryptor.EncryptToString(json, key);
PlayerPrefs.SetString("Save", base64);

// 문자열로 복호화
string loaded  = PlayerPrefs.GetString("Save");
string decoded = Encryptor.DecryptToString(loaded, key);
```

### 데이터 무결성 검증

```csharp
using Achieve.DataProtector;

byte[] data = System.IO.File.ReadAllBytes("save.dat");
byte[] hash = System.IO.File.ReadAllBytes("save.dat.hash");

if (!HashChecker.ValidateHash(data, hash))
{
    Debug.LogError("세이브 데이터가 변조되었습니다!");
}
```

### 암호화 없이 압축만 사용

```csharp
using Achieve.DataProtector;

byte[] compressed   = GzipCompressor.Compress(largeJsonString);
string decompressed = GzipCompressor.DecompressToString(compressed);
```
