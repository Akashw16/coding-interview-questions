import React, { useState, useEffect } from 'react';
import copyIcon from '../assets/copy-icon-size_24.png'; 
import bookmarkService from './bookmarkService.js';

const QuestionAndCodeBlock = ({ questionId, code }) => {
  const [isBookmarked, setIsBookmarked] = useState(false);

  useEffect(() => {
    const checkIfBookmarked = async () => {
      try {
        const bookmarks = await bookmarkService.getBookmarks(localStorage.getItem('token'));
        setIsBookmarked(bookmarks.includes(questionId));
      } catch (error) {
        console.error('Error checking bookmark status:', error);
      }
    };

    checkIfBookmarked();
  }, [questionId]);

  const handleBookmark = async () => {
    try {
      if (isBookmarked) {
        await bookmarkService.removeBookmark({ questionId });
        setIsBookmarked(false);
        alert("Bookmark removed successfully!");
      } else {
        const response = await bookmarkService.addBookmark({ questionId });
        if (response) {
          setIsBookmarked(true);
          alert("Question bookmarked successfully!");
        }
      }
    } catch (error) {
      console.error("Error during bookmarking:", error);
      alert("An error occurred while bookmarking the question.");
    }
  };

  const copyToClipboard = () => {
    if (code) {
      navigator.clipboard.writeText(code);
      alert('Code copied to clipboard!');
    } else {
      alert('No code available to copy!');
    }
  };

  const formatCodeWithComments = (code) => {
    if (!code) return '';  
    const commentRegex = /(\/\/.*$)/gm;
    return code.replace(commentRegex, '<span class="comment-line">$1</span>');
  };

  return (
    <div className="question-and-code-block">
      <div className="code-block-container slide-in">
        <div className="code-block fade-in">
          <pre>
            <code dangerouslySetInnerHTML={{ __html: formatCodeWithComments(code) }} />
          </pre>
          <button className="copy-button" onClick={copyToClipboard}>
            <img src={copyIcon} alt="Copy" className="copy-icon" />
          </button>
        </div>
      </div>
      <button onClick={handleBookmark}>
        {isBookmarked ? 'Unbookmark' : 'Bookmark'}
      </button>
    </div>
  );
};

export default QuestionAndCodeBlock;
