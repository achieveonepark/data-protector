import { defineConfig } from '@rspress/core';

export default defineConfig({
  root: 'docs',
  base: '/data-protector/',
  outDir: 'out',
  title: 'Data Protector',
  description: 'Data Protector package documentation',
  lang: 'ko',
  icon: '/icon.svg',
  logo: '/logo.svg',
  route: {
    cleanUrls: true,
    localeRedirect: 'never',
  },
  locales: [
    { lang: 'ko', label: '한국어' },
    { lang: 'en', label: 'English' },
    { lang: 'ja', label: '日本語' },
    { lang: 'zh', label: '中文' },
  ],
  themeConfig: {
    socialLinks: [
      {
        icon: 'github',
        mode: 'link',
        content: 'https://github.com/achieveonepark/data-protector',
      },
    ],
  },
});
