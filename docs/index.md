---
layout: home

hero:
  name: "Data Protector"
  text: "Unity Data Security"
  tagline: Compress, encrypt, and verify your game data with a simple one-line API.
  actions:
    - theme: brand
      text: Get Started
      link: /getting-started
    - theme: alt
      text: API Reference
      link: /encryptor

features:
  - icon: 🔐
    title: AES-GCM Encryption
    details: Authenticated encryption that prevents both reading and tampering. Any wrong key or modified byte throws immediately on decrypt.
  - icon: 📦
    title: Gzip Compression
    details: Data is compressed before encryption, reducing storage size and improving performance for large payloads.
  - icon: 🔍
    title: SHA-256 Integrity
    details: Compute and validate data hashes with constant-time comparison to guard against timing attacks.
---
