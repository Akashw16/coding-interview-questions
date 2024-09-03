import React, { useState } from 'react';
import '../styles/Tabs.css';

const Tabs = ({ languages, onTabClick }) => {
  const [activeTab, setActiveTab] = useState(languages[0]);

  const handleTabClick = (language) => {
    setActiveTab(language);
    onTabClick(language);
  };

  return (
    <div className="tabs">
      {languages.map((language) => (
        <button
          key={language}
          className={activeTab === language ? 'active' : ''}
          onClick={() => handleTabClick(language)}
        >
          {language}
        </button>
      ))}
    </div>
  );
};

export default Tabs;
