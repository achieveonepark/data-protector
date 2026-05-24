import { defineConfig } from 'vitepress'

export default defineConfig({
  title: 'Data Protector',
  description: 'Unity package for compressing and encrypting game data',

  locales: {
    root: {
      label: 'English',
      lang: 'en-US',
      description: 'Unity package for compressing and encrypting game data',
      themeConfig: {
        nav: [
          { text: 'Home', link: '/' },
          { text: 'Getting Started', link: '/getting-started' },
          { text: 'API', link: '/encryptor' },
        ],
        sidebar: [
          {
            text: 'Guide',
            items: [
              { text: 'Getting Started', link: '/getting-started' },
            ],
          },
          {
            text: 'API Reference',
            items: [
              { text: 'Encryptor', link: '/encryptor' },
              { text: 'GzipCompressor', link: '/gzip-compressor' },
              { text: 'HashChecker', link: '/hash-checker' },
            ],
          },
        ],
      },
    },

    ko: {
      label: '한국어',
      lang: 'ko-KR',
      description: 'Unity 게임 데이터 압축 및 암호화 패키지',
      themeConfig: {
        nav: [
          { text: '홈', link: '/ko/' },
          { text: '시작하기', link: '/ko/getting-started' },
          { text: 'API', link: '/ko/encryptor' },
        ],
        sidebar: [
          {
            text: '가이드',
            items: [
              { text: '시작하기', link: '/ko/getting-started' },
            ],
          },
          {
            text: 'API 레퍼런스',
            items: [
              { text: 'Encryptor', link: '/ko/encryptor' },
              { text: 'GzipCompressor', link: '/ko/gzip-compressor' },
              { text: 'HashChecker', link: '/ko/hash-checker' },
            ],
          },
        ],
      },
    },
  },

  themeConfig: {
    search: { provider: 'local' },
    socialLinks: [
      { icon: 'github', link: 'https://github.com/achieveonepark/data-protector' },
    ],
  },
})
