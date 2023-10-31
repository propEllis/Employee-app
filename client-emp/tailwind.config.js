/** @type {import('tailwindcss').Config} */
module.exports = {
  // https://tailwindcss.com/docs/dark-mode
  darkMode: 'class',
  content: ["./src/**/*.{js,jsx}"],
  theme: {
    extend: {
      colors: {
        'regal-blue': '#243c5a',
      },
    },
  },
  plugins: [],
};
