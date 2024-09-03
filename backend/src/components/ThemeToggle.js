import React, { useState, useEffect } from 'react';
import '../styles/ThemeToggle.css';

const ThemeToggle = () => {
  const [darkMode, setDarkMode] = useState(() => {
    return localStorage.getItem('darkMode') === 'true';
  });

  useEffect(() => {
    // Apply the dark mode class based on the state
    if (darkMode) {
      document.body.classList.add('dark-mode');
    } else {
      document.body.classList.remove('dark-mode');
    }
  }, [darkMode]);

  const toggleTheme = () => {
    setDarkMode(!darkMode);
    localStorage.setItem('darkMode', !darkMode); 
  };

  return (
    <button className="theme-toggle" onClick={toggleTheme}>
      {darkMode ? '☀️ Bright Mode' : '🌙 Dark Mode'}
    </button>
  );
};

export default ThemeToggle;
