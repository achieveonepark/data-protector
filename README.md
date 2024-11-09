# Data Protector
- Provides compression and encryption for `byte[]` and `string` data, securing it from external access before saving to storage.
- Requires a 16-byte string key provided by the user for encryption.
- Includes logic to check for file changes by generating and comparing hash values from `byte[]` or `string` data using `SHA256`.

## Install

Choose one of the following installation methods:

>Note: Check the version after # in the GitHub URL for the latest changes listed in the Changelog.

### Install via Unity Package Manager (UPM)
1. Open UPM and click the + button in the top left. 
2. Select Install package from git URL....
3. Enter `https://github.com/achieveonepark/DataProtector.git#1.0.0` and click Install.

### Manual Addition

Open the manifest.json file in your Unity project’s Packages folder.
Add the following line under dependencies:

```json
"com.achieve.quick-save": "https://github.com/achieveonepark/DataProtector.git#1.0.0"
```

## Description
### Compression and Encryption
- Uses `AES-128` encryption for data security.
- Compression is handled with C#’s `GZipStream` for efficient data storage.

## API
This package provides the following features:

```
DataProtector.Encrypt    | Returns the result after compressing and encrypting the data.
DataProtector.Decrypt    | Returns the result after decrypting and decompressing the data.
HashChecker.ComputeHash  | Extracts the hash value of the encrypted data.
HashChecker.ValidateHash | Compares two hash values.
```
