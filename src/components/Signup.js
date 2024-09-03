import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import '../styles/Signup.css';

const Signup = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleSignup = async () => {
    try {
      const response = await fetch('http://localhost:5208/api/auth/register', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ username, password, role: 'user' }),
      });

      if (response.ok) {
        navigate('/login');
      } else {
        setError('Signup failed');
      }
    } catch (err) {
      setError('An error occurred. Please try again.');
    }
  };

  return (
    <div className="signup-container">
      <div className="home-button-container">
        <Link to="/">
          <button className="home-button">Home</button>
        </Link>
      </div>
      <div className="signup">
        <h2>Sign Up</h2>
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
        <button onClick={handleSignup}>Sign Up</button>
        <div className="signin-link">
          <p>Already have an account?</p>
          <Link to="/login">
            <button className="signin-button">Sign In</button>
          </Link>
        </div>
      </div>
    </div>
  );
};

export default Signup;
