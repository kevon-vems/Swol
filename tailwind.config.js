module.exports = {
  content: [
    './Components/**/*.razor',
    './Styles/**/*.css'
  ],
  theme: {
    extend: {
      colors: {
        brand: {
          50: '#eff6ff',
          100: '#dbe9ff',
          200: '#bfd7ff',
          300: '#9ac0ff',
          400: '#7aa9ff',
          500: '#5a91f1',
          600: '#4477d0',
          700: '#345caa',
          800: '#254284',
          900: '#18295e'
        },
        graysoft: {
          50: '#f9fafb',
          100: '#f1f3f5',
          200: '#e2e5e8',
          300: '#c7ccd1',
          400: '#afb5bb',
          500: '#969da3',
          600: '#7d848a',
          700: '#636a70',
          800: '#494f55',
          900: '#30363d'
        }
      }
    }
  },
  plugins: []
};
