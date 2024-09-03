import axios from 'axios';

// Set up your backend URL
const API_URL = 'http://localhost:5208/api';

// Login API call
export const login = async (credentials) => {
  try {
    const response = await axios.post(`${API_URL}/auth/login`, credentials);
    return response.data;
  } catch (error) {
    throw error;
  }
};

// Register API call
export const register = async (userData) => {
  try {
    const response = await axios.post(`${API_URL}/auth/register`, userData);
    return response.data;
  } catch (error) {
    throw error;
  }
};

// Fetch questions API call
export const fetchQuestions = async () => {
  try {
    const response = await axios.get(`${API_URL}/questions`);
    return response.data;
  } catch (error) {
    throw error;
  }
};

// Fetch bookmarks API call
export const fetchBookmarks = async () => {
  try {
    const response = await axios.get(`${API_URL}/bookmarks`, {
      headers: {
        'Authorization': `Bearer ${localStorage.getItem('token')}`,
      },
    });
    return response.data;
  } catch (error) {
    throw error;
  }
};

// Add bookmark API call
export const addBookmark = async (bookmarkData) => {
  try {
    const response = await axios.post(`${API_URL}/bookmarks/add`, bookmarkData, {
      headers: {
        'Authorization': `Bearer ${localStorage.getItem('token')}`,
      },
    });
    return response.data;
  } catch (error) {
    throw error;
  }
};
