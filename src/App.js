import React, { useState, useEffect, useRef } from 'react';
import { Route, Routes, Link, Navigate, useLocation, useNavigate } from 'react-router-dom';  
import Header from './components/Header';
import QuestionsList from './components/QuestionsList';
import ThemeToggle from './components/ThemeToggle';
import SearchBar from './components/SearchBar';
import Login from './components/Login';
import Signup from './components/Signup';
import UserDashboard from './components/UserDashboard';
import AdminDashboard from './components/AdminDashboard';
import ProtectedRoute from './components/ProtectedRoute';
import './App.css';
import './styles/Responsive.css';
import axios from 'axios';

function App() {
  const [loggedInUser, setLoggedInUser] = useState(localStorage.getItem('loggedInUser') || null);
  const [isDarkMode, setIsDarkMode] = useState(() => localStorage.getItem('darkMode') === 'true');
  const [questionsData, setQuestionsData] = useState([]);
  const questionRefs = useRef([]);
  const location = useLocation();
  const navigate = useNavigate();

  useEffect(() => {
    const fetchQuestions = async () => {
      try {
        const response = await axios.get('http://localhost:5208/api/questions');
        if (response.data) {
          setQuestionsData(response.data);
        }
      } catch (error) {
        console.error('Error fetching questions:', error);
      }
    };
    fetchQuestions();
  }, []);

  useEffect(() => {
    if (loggedInUser) {
      const fetchBookmarks = async () => {
        try {
          const token = localStorage.getItem('token');
          const response = await axios.get('http://localhost:5208/api/bookmarks/user', {
            headers: {
              Authorization: `Bearer ${token}`,
            },
          });

          const bookmarkedQuestions = response.data?.data || [];
          if (Array.isArray(bookmarkedQuestions)) {
            setQuestionsData((prevQuestions) =>
              prevQuestions.map((q) =>
                bookmarkedQuestions.includes(q.id) ? { ...q, bookmarked: true } : q
              )
            );
          }
        } catch (error) {
          console.error('Error fetching bookmarks:', error);
        }
      };
      fetchBookmarks();
    }
  }, [loggedInUser]);

  useEffect(() => {
    document.body.classList.toggle('dark-mode', isDarkMode);
  }, [isDarkMode]);

  const handleSearch = (searchTerm) => {
    const index = questionsData.findIndex((q) =>
      q?.questionText?.toLowerCase().includes(searchTerm.toLowerCase())
    );
    if (index !== -1) {
      questionRefs.current[index].scrollIntoView({ behavior: 'smooth' });
    } else {
      alert('Question not found!');
    }
  };

  const handleLogout = () => {
    localStorage.clear();
    setLoggedInUser(null);
    navigate('/');
  };

  const handleUserClick = () => navigate('/user-dashboard');

  return (
    <div className="App">
      <div className="header-controls">
        {['/login', '/signup', '/user-dashboard', '/admin-dashboard'].includes(location.pathname) && (
          <Link to="/">
            <button className="home-button">Home</button>
          </Link>
        )}
        {!['/login', '/signup', '/user-dashboard', '/admin-dashboard'].includes(location.pathname) && (
          <>
            <ThemeToggle isDarkMode={isDarkMode} setIsDarkMode={setIsDarkMode} />
            <SearchBar questions={questionsData} onSearch={handleSearch} />
            {loggedInUser ? (
              <>
                <button className="username-button" onClick={handleUserClick}>
                  {loggedInUser}
                </button>
                <button className="login-button" onClick={handleLogout}>
                  Logout
                </button>
              </>
            ) : (
              <Link to="/login">
                <button className="login-button">Login/Sign Up</button>
              </Link>
            )}
          </>
        )}
      </div>

      <Routes>
        <Route
          path="/login"
          element={loggedInUser ? <Navigate to="/" /> : <Login onLogin={setLoggedInUser} />}
        />
        <Route path="/signup" element={<Signup />} />
        <Route
          path="/user-dashboard"
          element={
            <ProtectedRoute requiredRole="user">
              <UserDashboard />
            </ProtectedRoute>
          }
        />
        <Route
          path="/admin-dashboard"
          element={
            <ProtectedRoute requiredRole="admin">
              <AdminDashboard />
            </ProtectedRoute>
          }
        />
        <Route
          path="/"
          element={
            <>
              <Header />
              <QuestionsList questionsData={questionsData} />
            </>
          }
        />
      </Routes>
    </div>
  );
}

export default App;
