import React, { useState } from 'react';
import '../styles/SearchBar.css';
import searchIcon from '../assets/search.png'; 

const SearchBar = ({ onSearch }) => {
  const [searchTerm, setSearchTerm] = useState('');

  const handleSearch = () => {
    onSearch(searchTerm);
  };

  return (
    <div className="search-bar">
      <input
        type="text"
        placeholder="Search for a question..."
        value={searchTerm}
        onChange={(e) => setSearchTerm(e.target.value)}
      />
      <button className="search-button" onClick={handleSearch}>
        <img src={searchIcon} alt="Search" />
      </button>
    </div>
  );
};

export default SearchBar;
