import React from 'react';
import { Link } from 'react-router-dom';

const AdminDashboard = () => {
  return (
    <div className="dashboard">
      <h1>Admin Dashboard</h1>
      <p>Welcome, Admin!</p>
      <Link to="/manage-questions">Manage Questions</Link>
      { 
        
      }
    </div>
  );
};

export default AdminDashboard;
