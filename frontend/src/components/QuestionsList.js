import React from 'react';
import QuestionAndCodeBlock from './QuestionAndCodeBlock';
import '../styles/QuestionsList.css'; 


const QuestionsList = ({ questionsData }) => {
  return (
    <div className="questions-list-container">
      {/* Top 50 heading */}
      <h1 className="heading-top-50">Top 50 Coding Questions</h1>
      
      <div className="questions-list">
        {questionsData.length > 0 ? (
          questionsData.map((question) => (
            <div key={question.id} className="question-and-code-block">
              <h3 className="question-text">{question.questionText}</h3>
              <QuestionAndCodeBlock questionId={question.id} code={question.codeSnippet} />
            </div>
          ))
        ) : (
          <p>No questions found.</p>
        )}
      </div>
    </div>
  );
};

export default QuestionsList;
