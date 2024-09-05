import React, { useState, useEffect } from 'react';
import copyIcon from '../assets/copy-icon-size_24.png'; 
import bookmarkService from './bookmarkService.js';

const QuestionAndCodeBlock = ({ questionId, code }) => {
  const [isBookmarked, setIsBookmarked] = useState(false);
  const [initialFetchDone, setInitialFetchDone] = useState(false);

  useEffect(() => {
    const fetchBookmarkStatus = async () => {
      try {
        if (!initialFetchDone) {
          const bookmarks = await bookmarkService.getBookmarks();
          if (bookmarks && bookmarks.some(bookmark => bookmark.questionId === questionId)) {
            setIsBookmarked(true);
          } else {
            setIsBookmarked(false);  // Ensure proper resetting on tab switch
          }
          setInitialFetchDone(true);  // Mark that the initial fetch is done
        }
      } catch (error) {
        console.error('Error fetching bookmark status:', error);
      }
    };

    fetchBookmarkStatus();
  }, [questionId, initialFetchDone]);

  const handleBookmark = async () => {
    try {
      if (isBookmarked) {
        await bookmarkService.removeBookmark({ questionId });
        setIsBookmarked(false);
        alert("Bookmark removed successfully!");
      } else {
        await bookmarkService.addBookmark({ questionId });
        setIsBookmarked(true);
        alert("Question bookmarked successfully!");
      }
    } catch (error) {
      console.error("Error during bookmarking:", error);
      alert("An error occurred while updating the bookmark status.");
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
