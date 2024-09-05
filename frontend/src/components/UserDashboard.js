import React, { useState, useEffect } from 'react';
import bookmarkService from './bookmarkService';
import copyIcon from '../assets/copy-icon-size_24.png';
import '../styles/UserDashboard.css'; 

const UserDashboard = () => {
  const [bookmarkedQuestions, setBookmarkedQuestions] = useState([]);

  useEffect(() => {
    const fetchBookmarkedQuestions = async () => {
      try {
        const bookmarks = await bookmarkService.getBookmarks();
        setBookmarkedQuestions(bookmarks);
      } catch (error) {
        console.error('Error fetching bookmarked questions:', error);
      }
    };

    fetchBookmarkedQuestions();
  }, []);

  // Unbookmark the question
  const handleUnbookmark = async (questionId) => {
    try {
      // Pass the correct questionId for unbookmarking
      await bookmarkService.removeBookmark({ questionId });
      setBookmarkedQuestions((prevQuestions) =>
        prevQuestions.filter((q) => q.id !== questionId)
      );
      alert('Bookmark removed successfully!');
    } catch (error) {
      console.error('Error unbookmarking the question:', error);
      alert('An error occurred while unbookmarking the question.');
    }
  };

  const copyToClipboard = (code) => {
    if (code) {
      navigator.clipboard.writeText(code);
      alert('Code copied to clipboard!');
    } else {
      alert('No code available to copy!');
    }
  };

  return (
    <div className="user-dashboard-container">
      <h1 className="user-dashboard-heading">Your Bookmarked Questions</h1>
      {bookmarkedQuestions.length > 0 ? (
        bookmarkedQuestions.map((question, index) => (
          <div key={question.id} className="user-dashboard-question-block">
            <div className="user-dashboard-question-text">
              {index + 1}. {question.questionText}
            </div>
            <div className="user-dashboard-code-block-container">
              <pre className="user-dashboard-code-block">
                <code>{question.codeSnippet}</code>
              </pre>
              <button
                className="user-dashboard-copy-button"
                onClick={() => copyToClipboard(question.codeSnippet)}
              >
                <img src={copyIcon} alt="Copy" className="user-dashboard-copy-icon" />
              </button>
            </div>
            {/* Unbookmark button only */}
            <button
              onClick={() => handleUnbookmark(question.id)} // Make sure question.id is correct
            >
              Unbookmark
            </button>
          </div>
        ))
      ) : (
        <p>No bookmarked questions found.</p>
      )}
    </div>
  );
};

export default UserDashboard;
