import React, { useState, useEffect } from 'react';
import bookmarkService from './bookmarkService';
import QuestionAndCodeBlock from './QuestionAndCodeBlock';

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

  return (
    <div className="user-dashboard">
      <h1>Your Bookmarked Questions</h1>
      {bookmarkedQuestions.length > 0 ? (
        bookmarkedQuestions.map((question) => (
          <QuestionAndCodeBlock
            key={question.id}
            questionId={question.id}
            code={question.codeSnippet}
            questionText={question.questionText}
          />
        ))
      ) : (
        <p>No bookmarked questions found.</p>
      )}
    </div>
  );
};

export default UserDashboard;
