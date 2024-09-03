import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import '../styles/Login.css';

const Login = ({ onLogin }) => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      const response = await fetch('http://localhost:5208/api/auth/login', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ username, password }),
      });

      const responseBody = await response.json();
      console.log('Response Body:', responseBody);

      if (response.ok && responseBody.token) {
        // Login successful
        localStorage.setItem('token', responseBody.token);
        localStorage.setItem('loggedInUser', username);

        const role = responseBody.role || 'user';
        localStorage.setItem('role', role);

        onLogin(username);

        // Navigate to the appropriate dashboard based on the role
        if (role === 'admin') {
          navigate('/admin-dashboard');
        } else if (role === 'user') {
          navigate('/user-dashboard');
        }
      } else {
        setError('Invalid credentials');
        console.error('Login failed:', response.status);
      }
    } catch (err) {
      console.error('Error during login:', err);
      setError('An error occurred. Please try again.');
    }
  };

  return (
    <div className="login-container">
      <div className="login">
        <h2>Login</h2>
        {error && <p style={{ color: 'red' }}>{error}</p>}
        <input
          type="text"
          placeholder="Username"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
        />
        <input
          type="password"
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        <button onClick={handleLogin}>Login</button>

        <div className="signup-link">
          <p>Don't have an account?</p>
          <Link to="/signup">
            <button className="signup-button">Sign Up</button>
          </Link>
        </div>
      </div>
    </div>
  );
};

export default Login;
